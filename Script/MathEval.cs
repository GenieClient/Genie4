using System;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie.Script
{
    public class MathEval
    {
        private class ClassSymbol : IComparer
        {
            public string Token;
            public TOKENCLASS Cls;
            public PRECEDENCE PrecedenceLevel;

            public int Compare(object x, object y)
            {
                ClassSymbol asym, bsym;
                asym = (ClassSymbol)x;
                bsym = (ClassSymbol)y;
                if (String.Compare(asym.Token, bsym.Token) > 0)
                    return 1;
                if (String.Compare(asym.Token,bsym.Token) < 0)
                    return -1;
                if ((int)asym.PrecedenceLevel == -1 | (int)bsym.PrecedenceLevel == -1)
                    return 0;
                if (asym.PrecedenceLevel > bsym.PrecedenceLevel)
                    return 1;
                if (asym.PrecedenceLevel < bsym.PrecedenceLevel)
                    return -1;
                return 0;
            }
        }

        private enum PRECEDENCE
        {
            NULL = -1,
            NONE = 0,
            LEVEL0 = 1,
            LEVEL1 = 2,
            LEVEL2 = 3,
            LEVEL3 = 4,
            LEVEL4 = 5,
            LEVEL5 = 6
        }

        private enum TOKENCLASS
        {
            KEYWORD = 1,
            IDENTIFIER = 2,
            NUMBER = 3,
            OPERATORTOKEN = 4,
            PUNCTUATION = 5
        }

        private Collection m_tokens;
        private int[,] m_State;
        // private string[] m_KeyWords;
        private string m_colstring;
        private const string ALPHA = "_ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string DIGITS = "#0123456789";
        private string[] m_funcs = new[] { "sin", "cos", "tan", "arcsin", "arccos", "arctan", "sqrt", "max", "min", "floor", "ceiling", "log", "log10", "ln", "round", "abs", "neg", "pos" };


        private Genie.Collections.ArrayList m_operators;
        private Stack m_stack = new Stack();

        private void init_operators()
        {
            ClassSymbol op;
            m_operators = new Genie.Collections.ArrayList();
            op = new ClassSymbol();
            op.Token = "-";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL1;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "+";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL1;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "*";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL2;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "/";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL2;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = @"\";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL2;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "%";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL2;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "^";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL3;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "!";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL5;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "&";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL5;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "-";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL4;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "+";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL4;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = "(";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL5;
            m_operators.Add(op);
            op = new ClassSymbol();
            op.Token = ")";
            op.Cls = TOKENCLASS.OPERATORTOKEN;
            op.PrecedenceLevel = PRECEDENCE.LEVEL0;
            m_operators.Add(op);
            m_operators.Sort(op);
        }

        public double Evaluate(string expression)
        {
            var symbols = new Queue();
            try
            {
                if (Information.IsNumeric(expression))
                    return Conversions.ToDouble(expression);
                calc_scan(expression, ref symbols);
                return level0(ref symbols);
            }
            catch
            {
                throw new Exception("Invalid expression: " + expression);
            }
        }

        private double calc_op(ClassSymbol op, double operand1, double operand2 = default)
        {
            var switchExpr = op.Token.ToLower();
            switch (switchExpr)
            {
                case "^":
                    {
                        return Math.Pow(operand1, operand2);
                    }

                case "+":
                    {
                        var switchExpr1 = op.PrecedenceLevel;
                        switch (switchExpr1)
                        {
                            case PRECEDENCE.LEVEL1:
                                {
                                    return operand2 + operand1;
                                }

                            case PRECEDENCE.LEVEL4:
                                {
                                    return operand1;
                                }
                        }

                        break;
                    }

                case "-":
                    {
                        var switchExpr2 = op.PrecedenceLevel;
                        switch (switchExpr2)
                        {
                            case PRECEDENCE.LEVEL1:
                                {
                                    return operand1 - operand2;
                                }

                            case PRECEDENCE.LEVEL4:
                                {
                                    return -1 * operand1;
                                }
                        }

                        break;
                    }

                case "*":
                    {
                        return operand2 * operand1;
                    }

                case "/":
                    {
                        return operand1 / operand2;
                    }

                case @"\":
                    {
                        return Conversions.ToLong(operand1) / Conversions.ToLong(operand2);
                    }

                case "%":
                    {
                        return operand1 % operand2;
                    }

                case "!":
                    {
                        int i;
                        double res = 1;
                        if (operand1 > 1)
                        {
                            for (i = Conversions.ToInteger(operand1); i >= 1; i -= 1)
                                res = res * i;
                        }

                        return res;
                    }
            }

            return default;
        }

        private double calc_function(string func, Collection args)
        {
            var switchExpr = func.ToLower();
            switch (switchExpr)
            {
                case "cos":
                    {
                        return Math.Cos(Conversions.ToDouble(args[1]));
                    }

                case "sin":
                    {
                        return Math.Sin(Conversions.ToDouble(args[1]));
                    }

                case "tan":
                    {
                        return Math.Tan(Conversions.ToDouble(args[1]));
                    }

                case "floor":
                    {
                        return Math.Floor(Conversions.ToDouble(args[1]));
                    }

                case "ceiling":
                    {
                        return Math.Ceiling(Conversions.ToDouble(args[1]));
                    }

                case "max":
                    {
                        return Math.Max(Conversions.ToDouble(args[1]), Conversions.ToDouble(args[2]));
                    }

                case "min":
                    {
                        return Math.Min(Conversions.ToDouble(args[1]), Conversions.ToDouble(args[2]));
                    }

                case "arcsin":
                    {
                        return Math.Asin(Conversions.ToDouble(args[1]));
                    }

                case "arccos":
                    {
                        return Math.Acos(Conversions.ToDouble(args[1]));
                    }

                case "arctan":
                    {
                        return Math.Atan(Conversions.ToDouble(args[1]));
                    }

                case "sqrt":
                    {
                        return Math.Sqrt(Conversions.ToDouble(args[1]));
                    }

                case "log":
                    {
                        return Math.Log10(Conversions.ToDouble(args[1]));
                    }

                case "log10":
                    {
                        return Math.Log10(Conversions.ToDouble(args[1]));
                    }

                case "abs":
                    {
                        return Math.Abs(Conversions.ToDouble(args[1]));
                    }

                case "round":
                    {
                        if (args.Count == 2)
                        {
                            return Math.Round(Conversions.ToDouble(args[1]), Conversions.ToInteger(args[2]));
                        }
                        else
                        {
                            return Math.Round(Conversions.ToDouble(args[1]));
                        }
                    }

                case "ln":
                    {
                        return Math.Log(Conversions.ToDouble(args[1]));
                    }

                case "neg":
                    {
                        return -1 * Conversions.ToDouble(args[1]);
                    }

                case "pos":
                    {
                        return +1 * Conversions.ToDouble(args[1]);
                    }
            }

            return default;
        }

        private double identifier(string token)
        {
            var switchExpr = token.ToLower();
            switch (switchExpr)
            {
                case "e":
                    {
                        return Math.E;
                    }

                case "pi":
                    {
                        return Math.PI;
                    }

                default:
                    {
                        break;
                    }
                    // look in symbol table....?
            }

            return default;
        }

        private bool is_operator(string token, ref ClassSymbol myoperator, PRECEDENCE level = PRECEDENCE.NULL)
        {
            try
            {
                var op = new ClassSymbol();
                op.Token = token;
                op.PrecedenceLevel = level;
                int ir = m_operators.BinarySearch(op, op);
                if (ir > -1)
                {
                    myoperator = (ClassSymbol)m_operators[ir];
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool is_function(string token)
        {
            try
            {
                int lr = Array.BinarySearch(m_funcs, token.ToLower());
                return lr > -1;
            }
            catch
            {
                return false;
            }
        }

        public bool calc_scan(string line, ref Queue symbols)
        {
            int sp;  // start position marker
            int cp;  // current position marker
            int col; // input column
            int lex_state;
            char cc;
            symbols = new Queue();
            line = line + " "; // add a space as an end marker
            sp = 0;
            cp = 0;
            lex_state = 1;
            while (cp <= line.Length - 1)
            {
                cc = line[cp];

                // if cc is not found then IndexOf returns -1 giving col = 2.
                col = m_colstring.IndexOf(cc) + 3;

                // set the input column 
                var switchExpr = col;
                switch (switchExpr)
                {
                    case 2: // cc wasn't found in the column string
                        {
                            if (ALPHA.IndexOf(char.ToUpper(cc)) > 0)      // letter column?
                            {
                                col = 1;
                            }
                            else if (DIGITS.IndexOf(char.ToUpper(cc)) > 0) // number column?
                            {
                                col = 2;
                            }
                            else // everything else is assigned to the punctuation column
                            {
                                col = 6;
                            }

                            break;
                        }

                    case object _ when switchExpr > 5: // cc was found and is > 5 so must be in operator column
                        {
                            col = 7;
                            break;
                        }
                        // case else ' cc was found - col contains the correct column
                }

                // find the new state based on current state and column (determined by input)
                lex_state = m_State[lex_state - 1, col - 1];
                var switchExpr1 = lex_state;
                switch (switchExpr1)
                {
                    case 3: // function or variable  end state 
                        {

                            // TODO variables aren't supported but substitution 
                            // could easily be performed here or after
                            // tokenization

                            var sym = new ClassSymbol();
                            sym.Token = line.Substring(sp, cp - sp);
                            if (is_function(sym.Token))
                            {
                                sym.Cls = TOKENCLASS.KEYWORD;
                            }
                            else
                            {
                                sym.Cls = TOKENCLASS.IDENTIFIER;
                            }

                            symbols.Enqueue(sym);
                            lex_state = 1;
                            cp = cp - 1;
                            break;
                        }

                    case 5: // number end state
                        {
                            var sym = new ClassSymbol();
                            sym.Token = line.Substring(sp, cp - sp);
                            sym.Cls = TOKENCLASS.NUMBER;
                            symbols.Enqueue(sym);
                            lex_state = 1;
                            cp = cp - 1;
                            break;
                        }

                    case 6: // punctuation end state
                        {
                            var sym = new ClassSymbol();
                            sym.Token = line.Substring(sp, cp - sp + 1);
                            sym.Cls = TOKENCLASS.PUNCTUATION;
                            symbols.Enqueue(sym);
                            lex_state = 1;
                            break;
                        }

                    case 7: // operator end state
                        {
                            var sym = new ClassSymbol();
                            sym.Token = line.Substring(sp, cp - sp + 1);
                            sym.Cls = TOKENCLASS.OPERATORTOKEN;
                            symbols.Enqueue(sym);
                            lex_state = 1;
                            break;
                        }
                }

                cp += 1;
                if (lex_state == 1)
                    sp = cp;
            }

            return true;
        }

        private void init()
        {
            var state = new[,] { { 2, 4, 1, 1, 4, 6, 7 }, { 2, 3, 3, 3, 3, 3, 3 }, { 1, 1, 1, 1, 1, 1, 1 }, { 2, 4, 5, 5, 4, 5, 5 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 } };

            init_operators();
            m_State = state;
            m_colstring = (char)9 + " " + ".()";
            foreach (ClassSymbol op in m_operators)
                m_colstring = m_colstring + op.Token;
            Array.Sort(m_funcs);
            m_tokens = new Collection();
        }

        public MathEval()
        {
            init();
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double level0(ref Queue tokens)
        {
            return level1(ref tokens);
        }

        private double level1_prime(ref Queue tokens, double result)
        {
            ClassSymbol symbol = new ClassSymbol(), myoperator = new ClassSymbol();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                return result;
            }

            // binary level1 precedence operators....+, -
            if (is_operator(symbol.Token, ref myoperator, PRECEDENCE.LEVEL1))
            {
                tokens.Dequeue();
                result = calc_op(myoperator, result, level2(ref tokens));
                result = level1_prime(ref tokens, result);
            }

            return result;
        }

        private double level1(ref Queue tokens)
        {
            return level1_prime(ref tokens, level2(ref tokens));
        }

        private double level2(ref Queue tokens)
        {
            return level2_prime(ref tokens, level3(ref tokens));
        }

        private double level2_prime(ref Queue tokens, double result)
        {
            ClassSymbol symbol = new ClassSymbol(), myoperator = new ClassSymbol();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                return result;
            }

            // binary level2 precedence operators....*, /, \, %

            if (is_operator(symbol.Token, ref myoperator, PRECEDENCE.LEVEL2))
            {
                tokens.Dequeue();
                result = calc_op(myoperator, result, level3(ref tokens));
                result = level2_prime(ref tokens, result);
            }

            return result;
        }

        private double level3(ref Queue tokens)
        {
            return level3_prime(ref tokens, level4(ref tokens));
        }

        private double level3_prime(ref Queue tokens, double result)
        {
            ClassSymbol symbol = new ClassSymbol(), myoperator = new ClassSymbol();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                return result;
            }

            // binary level3 precedence operators....^
            if (is_operator(symbol.Token, ref myoperator, PRECEDENCE.LEVEL3))
            {
                tokens.Dequeue();
                result = calc_op(myoperator, result, level4(ref tokens));
                result = level3_prime(ref tokens, result);
            }

            return result;
        }

        private double level4(ref Queue tokens)
        {
            return level4_prime(ref tokens);
        }

        private double level4_prime(ref Queue tokens)
        {
            ClassSymbol symbol = new ClassSymbol(), myoperator = new ClassSymbol();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                throw new Exception("Invalid expression.");
            }

            // unary level4 precedence right associative  operators.... +, -
            if (is_operator(symbol.Token, ref myoperator, PRECEDENCE.LEVEL4))
            {
                tokens.Dequeue();
                return calc_op(myoperator, level5(tokens));
            }
            else
            {
                return level5(tokens);
            }
        }

        private double level5(Queue tokens)
        {
            return level5_prime(tokens, level6(ref tokens));
        }

        private double level5_prime(Queue tokens, double result)
        {
            ClassSymbol symbol = new ClassSymbol(), myoperator = new ClassSymbol();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                return result;
            }

            // unary level5 precedence left associative operators.... !
            if (is_operator(symbol.Token, ref myoperator, PRECEDENCE.LEVEL5))
            {
                tokens.Dequeue();
                return calc_op(myoperator, result);
            }
            else
            {
                return result;
            }
        }

        private double level6(ref Queue tokens)
        {
            ClassSymbol symbol;
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                throw new Exception("Invalid expression.");
            }

            double val;

            // constants, identifiers, keywords, -> expressions
            if ((symbol.Token ?? "") == "(") // opening paren of new expression
            {
                tokens.Dequeue();
                val = level0(ref tokens);
                symbol = (ClassSymbol)tokens.Dequeue();
                // closing paren
                if ((symbol.Token ?? "") != ")")
                    throw new Exception("Invalid expression.");
                return val;
            }
            else
            {
                var switchExpr = symbol.Cls;
                switch (switchExpr)
                {
                    case TOKENCLASS.IDENTIFIER:
                        {
                            tokens.Dequeue();
                            return identifier(symbol.Token);
                        }

                    case TOKENCLASS.KEYWORD:
                        {
                            tokens.Dequeue();
                            return calc_function(symbol.Token, arguments(tokens));
                        }

                    case TOKENCLASS.NUMBER:
                        {
                            tokens.Dequeue();
                            m_stack.Push(Conversions.ToDouble(symbol.Token));
                            return Conversions.ToDouble(symbol.Token);
                        }

                    default:
                        {
                            throw new Exception("Invalid expression.");
                        }
                }
            }
        }

        private Collection arguments(Queue tokens)
        {
            ClassSymbol symbol;
            var args = new Collection();
            if (tokens.Count > 0)
            {
                symbol = (ClassSymbol)tokens.Peek();
            }
            else
            {
                throw new Exception("Invalid expression.");
            }

            if ((symbol.Token ?? "") == "(")
            {
                tokens.Dequeue();
                args.Add(level0(ref tokens));
                symbol = (ClassSymbol)tokens.Dequeue();
                while ((symbol.Token ?? "") != ")")
                {
                    if ((symbol.Token ?? "") == ",")
                    {
                        args.Add(level0(ref tokens));
                    }
                    else
                    {
                        throw new Exception("Invalid expression.");
                    }

                    symbol = (ClassSymbol)tokens.Dequeue();
                }

                return args;
            }
            else
            {
                throw new Exception("Invalid expression.");
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
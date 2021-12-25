using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GenieClient
{
    public class INaturalComparer : Comparer<string>, IDisposable
    {
        private Dictionary<string, string[]> table;

        public INaturalComparer()
        {
            table = new Dictionary<string, string[]>();
        }

        public void Dispose()
        {
            table.Clear();
            table = null;
        }

        public override int Compare(string x, string y)
        {
            if ((x ?? "") == (y ?? ""))
            {
                return 0;
            }

            var x1 = new[] { string.Empty };
            var y1 = new[] { string.Empty };
            if (!table.TryGetValue(x, out x1))
            {
                x1 = Regex.Split(x.Replace(" ", ""), "([0-9]+)");
                table.Add(x, x1);
            }

            if (!table.TryGetValue(y, out y1))
            {
                y1 = Regex.Split(y.Replace(" ", ""), "([0-9]+)");
                table.Add(y, y1);
            }

            int i = 0;
            while (i < x1.Length && i < y1.Length)
            {
                if ((x1[i] ?? "") != (y1[i] ?? ""))
                {
                    return PartCompare(x1[i], y1[i]);
                }

                i += 1;
            }

            if (y1.Length > x1.Length)
            {
                return 1;
            }
            else if (x1.Length > y1.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int PartCompare(string left, string right)
        {
            int x;
            int y;
            if (!int.TryParse(left, out x))
            {
                return left.CompareTo(right);
            }

            if (!int.TryParse(right, out y))
            {
                return left.CompareTo(right);
            }

            return x.CompareTo(y);
        }
    }
}
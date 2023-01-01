﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Reflection;

/* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
/* TODO ERROR: Skipped IfDirectiveTrivia */
/* TODO ERROR: Skipped DefineDirectiveTrivia *//* TODO ERROR: Skipped DefineDirectiveTrivia *//* TODO ERROR: Skipped DefineDirectiveTrivia *//* TODO ERROR: Skipped DefineDirectiveTrivia *//* TODO ERROR: Skipped DefineDirectiveTrivia */
/* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
/* TODO ERROR: Skipped IfDirectiveTrivia */
namespace GenieClient.My
{

    /* TODO ERROR: Skipped IfDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]

    /* TODO ERROR: Skipped IfDirectiveTrivia */
    internal partial class MyApplication : Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        [STAThread()]
        [DebuggerHidden()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static void Main(string[] Args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(UseCompatibleTextRendering);
            }
            finally
            {
            }

            Dictionary<string, string> embeddedAssemblies = new Dictionary<string, string>();
            
            //3rd party assemblies
            embeddedAssemblies.Add("GenieClient.Libs.Jint.dll", "Jint.dll");
            embeddedAssemblies.Add("GenieClient.Libs.Antlr3.Runtime.dll", "Antlr3.Runtime.dll");
            embeddedAssemblies.Add("GenieClient.Libs.Interfaces.dll", "Interfaces.dll");

            foreach (KeyValuePair<string, string> embeddedAssembly in embeddedAssemblies)
            {
                EmbeddedAssembly.Load(embeddedAssembly.Key, embeddedAssembly.Value);
            }


            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            MyProject.Application.Run(Args);
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
    }


    /* TODO ERROR: Skipped EndIfDirectiveTrivia */
    /* TODO ERROR: Skipped IfDirectiveTrivia */
    [System.CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]

    /* TODO ERROR: Skipped IfDirectiveTrivia */
    internal partial class MyComputer : Microsoft.VisualBasic.Devices.Computer
    {
        /* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
        [DebuggerHidden()]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MyComputer() : base()
        {
        }
    }
    /* TODO ERROR: Skipped EndIfDirectiveTrivia */
    [HideModuleName()]
    [System.CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")]
    internal static partial class MyProject
    {

        /* TODO ERROR: Skipped IfDirectiveTrivia */
        [System.ComponentModel.Design.HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            [DebuggerHidden()]
            get
            {
                return m_ComputerObjectProvider.GetInstance;
            }
        }

        private readonly static ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        [System.ComponentModel.Design.HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            [DebuggerHidden()]
            get
            {
                return m_AppObjectProvider.GetInstance;
            }
        }

        private readonly static ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();
        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        [System.ComponentModel.Design.HelpKeyword("My.User")]
        internal static Microsoft.VisualBasic.ApplicationServices.User User
        {
            [DebuggerHidden()]
            get
            {
                return m_UserObjectProvider.GetInstance;
            }
        }

        private readonly static ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User> m_UserObjectProvider = new ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.User>();
        /* TODO ERROR: Skipped ElifDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        /* TODO ERROR: Skipped DefineDirectiveTrivia */
        [System.ComponentModel.Design.HelpKeyword("My.Forms")]
        internal static MyForms Forms
        {
            [DebuggerHidden()]
            get
            {
                return m_MyFormsObjectProvider.GetInstance;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        internal sealed partial class MyForms
        {
            [DebuggerHidden()]
            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                if (Instance is null || Instance.IsDisposed)
                {
                    if (m_FormBeingCreated is object)
                    {
                        if (m_FormBeingCreated.ContainsKey(typeof(T)) == true)
                        {
                            throw new InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_RecursiveFormCreate"));
                        }
                    }
                    else
                    {
                        m_FormBeingCreated = new Hashtable();
                    }

                    m_FormBeingCreated.Add(typeof(T), null);
                    try
                    {
                        return new T();
                    }
                    catch (System.Reflection.TargetInvocationException ex) when (ex.InnerException is object)
                    {
                        string BetterMessage = Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message);
                        throw new InvalidOperationException(BetterMessage, ex.InnerException);
                    }
                    finally
                    {
                        m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                else
                {
                    return Instance;
                }
            }

            [DebuggerHidden()]
            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                instance = null;
            }

            [DebuggerHidden()]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public MyForms() : base()
            {
            }

            [ThreadStatic()]
            private static Hashtable m_FormBeingCreated;

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public override bool Equals(object o)
            {
                return base.Equals(o);
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            internal new Type GetType()
            {
                return typeof(MyForms);
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public override string ToString()
            {
                return base.ToString();
            }
        }

        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped IfDirectiveTrivia */
        [System.ComponentModel.Design.HelpKeyword("My.WebServices")]
        internal static MyWebServices WebServices
        {
            [DebuggerHidden()]
            get
            {
                return m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            [DebuggerHidden()]
            public override bool Equals(object o)
            {
                return base.Equals(o);
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            [DebuggerHidden()]
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            [DebuggerHidden()]
            internal new Type GetType()
            {
                return typeof(MyWebServices);
            }

            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            [DebuggerHidden()]
            public override string ToString()
            {
                return base.ToString();
            }

            [DebuggerHidden()]
            private static T Create__Instance__<T>(T instance) where T : new()
            {
                if (instance is null)
                {
                    return new T();
                }
                else
                {
                    return instance;
                }
            }

            [DebuggerHidden()]
            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default;
            }

            [DebuggerHidden()]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public MyWebServices() : base()
            {
            }
        }

        private readonly static ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();
        /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            internal T GetInstance
            {
                /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElseDirectiveTrivia */
                [DebuggerHidden()]
                get
                {
                    if (m_ThreadStaticValue is null)
                        m_ThreadStaticValue = new T();
                    return m_ThreadStaticValue;
                }
                /* TODO ERROR: Skipped EndIfDirectiveTrivia */
            }

            [DebuggerHidden()]
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public ThreadSafeObjectProvider() : base()
            {
            }

            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElseDirectiveTrivia */
            [System.Runtime.CompilerServices.CompilerGenerated()]
            [ThreadStatic()]
            private static T m_ThreadStaticValue;
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        }
    }
}
/* TODO ERROR: Skipped EndIfDirectiveTrivia */

using System;
using System.ComponentModel;
using System.Diagnostics;
using GenieClient.Mapper;

namespace GenieClient.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogChangelog m_DialogChangelog;

            public DialogChangelog DialogChangelog
            {
                [DebuggerHidden]
                get
                {
                    m_DialogChangelog = MyForms.Create__Instance__(m_DialogChangelog);
                    return m_DialogChangelog;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogChangelog)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogChangelog);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogConnect m_DialogConnect;

            public DialogConnect DialogConnect
            {
                [DebuggerHidden]
                get
                {
                    m_DialogConnect = MyForms.Create__Instance__(m_DialogConnect);
                    return m_DialogConnect;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogConnect)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogConnect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogDownload m_DialogDownload;

            public DialogDownload DialogDownload
            {
                [DebuggerHidden]
                get
                {
                    m_DialogDownload = MyForms.Create__Instance__(m_DialogDownload);
                    return m_DialogDownload;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogDownload)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogDownload);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogEdit m_DialogEdit;

            public DialogEdit DialogEdit
            {
                [DebuggerHidden]
                get
                {
                    m_DialogEdit = MyForms.Create__Instance__(m_DialogEdit);
                    return m_DialogEdit;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogEdit)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogEdit);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogException m_DialogException;

            public DialogException DialogException
            {
                [DebuggerHidden]
                get
                {
                    m_DialogException = MyForms.Create__Instance__(m_DialogException);
                    return m_DialogException;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogException)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogException);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogKey m_DialogKey;

            public DialogKey DialogKey
            {
                [DebuggerHidden]
                get
                {
                    m_DialogKey = MyForms.Create__Instance__(m_DialogKey);
                    return m_DialogKey;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogKey)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogKey);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogProfileConnect m_DialogProfileConnect;

            public DialogProfileConnect DialogProfileConnect
            {
                [DebuggerHidden]
                get
                {
                    m_DialogProfileConnect = MyForms.Create__Instance__(m_DialogProfileConnect);
                    return m_DialogProfileConnect;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogProfileConnect)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogProfileConnect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogReconnect m_DialogReconnect;

            public DialogReconnect DialogReconnect
            {
                [DebuggerHidden]
                get
                {
                    m_DialogReconnect = MyForms.Create__Instance__(m_DialogReconnect);
                    return m_DialogReconnect;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogReconnect)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogReconnect);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DialogScriptName m_DialogScriptName;

            public DialogScriptName DialogScriptName
            {
                [DebuggerHidden]
                get
                {
                    m_DialogScriptName = MyForms.Create__Instance__(m_DialogScriptName);
                    return m_DialogScriptName;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_DialogScriptName)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DialogScriptName);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FormConfig m_FormConfig;

            public FormConfig FormConfig
            {
                [DebuggerHidden]
                get
                {
                    m_FormConfig = MyForms.Create__Instance__(m_FormConfig);
                    return m_FormConfig;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_FormConfig)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FormConfig);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FormMain m_FormMain;

            public FormMain FormMain
            {
                [DebuggerHidden]
                get
                {
                    m_FormMain = MyForms.Create__Instance__(m_FormMain);
                    return m_FormMain;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_FormMain)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FormMain);
                }
            }

           

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ScriptExplorer m_ScriptExplorer;

            public ScriptExplorer ScriptExplorer
            {
                [DebuggerHidden]
                get
                {
                    m_ScriptExplorer = MyForms.Create__Instance__(m_ScriptExplorer);
                    return m_ScriptExplorer;
                }

                [DebuggerHidden]
                set
                {
                    if (value == m_ScriptExplorer)
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_ScriptExplorer);
                }
            }
        }
    }
}
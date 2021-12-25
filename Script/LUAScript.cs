// Imports System.IO
// Imports LuaInterface

// Public Class LUAScript
// Public Event EventPrintError(BysText As String)
// Public Event EventPrintText(BysText As String, ByoColor As Color, ByoBgColor As Color)
// Public Event EventSendText(ByVal sText As String, ByVal sScript As String, ByVal bToQueue As Boolean)
// Public Event EventVariableChanged(ByVal sVariable As String)
// Public Event EventExitScript()

// Private m_oGlobals As Genie.Globals ' Global Values

// Private ScriptName As String = String.Empty

// Private lua As Lua = New Lua()

// Public Sub New(Bygl As Genie.Globals)
// m_oGlobals = gl

// lua.RegisterFunction("echo", Me, Me.GetType().GetMethod("PrintText"))
// lua.RegisterFunction("put", Me, Me.GetType().GetMethod("PutText"))
// lua.RegisterFunction("send", Me, Me.GetType().GetMethod("SendText"))
// lua.RegisterFunction("exit", Me, Me.GetType().GetMethod("ExitScript"))
// lua.RegisterFunction("setglobal", Me, Me.GetType().GetMethod("SetVariable"))
// lua.RegisterFunction("getglobal", Me, Me.GetType().GetMethod("GetVariable"))
// End Sub

// Public Sub PrintError(ByVal sText As String)
// RaiseEvent EventPrintError(sText)
// End Sub

// Public Sub PrintText(BysText As String)
// RaiseEvent EventPrintText(sText & vbNewLine, m_oGlobals.PresetList.Item("scriptecho").FgColor, Color.Transparent)
// End Sub

// Private Sub PutText(ByVal text As String)
// RaiseEvent EventSendText(text, ScriptName, False)
// End Sub

// Private Sub SendText(ByVal text As String)
// RaiseEvent EventSendText(text, ScriptName, True)
// End Sub

// Public Sub ExitScript()
// RaiseEvent EventExitScript()
// End Sub

// Public Function GetVariable(ByVal var As String) As String
// If m_oGlobals.VariableList.ContainsKey(var) Then
// Return m_oGlobals.VariableList.Item(var)
// Else
// Return String.Empty
// End If
// End Function

// Public Sub SetVariable(ByVal var As String, ByVal value As String)
// If m_oGlobals.VariableList.ContainsKey(var) Then
// m_oGlobals.VariableList.Item(var) = value
// Else
// m_oGlobals.VariableList.Add(var, value)
// End If

// RaiseEvent EventVariableChanged(var)
// End Sub

// Public Function DoFile(ByVal sFile As String) As Boolean
// Dim sFriendlyName As String = sFile

// ScriptName = sFile

// If sFile.IndexOf("\") = -1 Then
// Dim sLocation As String = String.Empty

// If m_oGlobals.Config.sScriptDir.Contains(":") Then
// sLocation = m_oGlobals.Config.sScriptDir
// Else
// sLocation = LocalDirectory.Path
// If m_oGlobals.Config.sScriptDir.StartsWith("\") Then
// sLocation &= m_oGlobals.Config.sScriptDir
// Else
// sLocation &= "\" & m_oGlobals.Config.sScriptDir
// End If
// End If

// If sLocation.EndsWith("\") Then
// sFile = sLocation & sFile
// Else
// sFile = sLocation & "\" & sFile
// End If
// End If

// Dim fi As FileInfo = New FileInfo(sFile)

// If fi.Exists And fi.Length > 0 Then
// Try
// lua.DoFile(sFile)
// Catch ex As LuaException
// RaiseEvent EventPrintError(ex.ToString)
// End Try
// Else
// PrintError("Unable to load file: " & sFriendlyName)
// ExitScript()
// Return False
// End If
// End Function

// End Class
// Imports System.IO
// Imports LuaInterface

// Public Class LUAScript
// Public Event EventPrintError(BysText As String)
// Public Event EventPrintText(BysText As String, ByoColor As Color, ByoBgColor As Color)
// Public Event EventSendText(ByVal sText As String, ByVal sScript As String, ByVal bToQueue As Boolean)
// Public Event EventVariableChanged(ByVal sVariable As String)
// Public Event EventExitScript()

// Private m_oGlobals As Genie.Globals ' Global Values

// Private ScriptName As String = String.Empty

// Private lua As Lua = New Lua()

// Public Sub New(Bygl As Genie.Globals)
// m_oGlobals = gl

// lua.RegisterFunction("echo", Me, Me.GetType().GetMethod("PrintText"))
// lua.RegisterFunction("put", Me, Me.GetType().GetMethod("PutText"))
// lua.RegisterFunction("send", Me, Me.GetType().GetMethod("SendText"))
// lua.RegisterFunction("exit", Me, Me.GetType().GetMethod("ExitScript"))
// lua.RegisterFunction("setglobal", Me, Me.GetType().GetMethod("SetVariable"))
// lua.RegisterFunction("getglobal", Me, Me.GetType().GetMethod("GetVariable"))
// End Sub

// Public Sub PrintError(ByVal sText As String)
// RaiseEvent EventPrintError(sText)
// End Sub

// Public Sub PrintText(BysText As String)
// RaiseEvent EventPrintText(sText & vbNewLine, m_oGlobals.PresetList.Item("scriptecho").FgColor, Color.Transparent)
// End Sub

// Private Sub PutText(ByVal text As String)
// RaiseEvent EventSendText(text, ScriptName, False)
// End Sub

// Private Sub SendText(ByVal text As String)
// RaiseEvent EventSendText(text, ScriptName, True)
// End Sub

// Public Sub ExitScript()
// RaiseEvent EventExitScript()
// End Sub

// Public Function GetVariable(ByVal var As String) As String
// If m_oGlobals.VariableList.ContainsKey(var) Then
// Return m_oGlobals.VariableList.Item(var)
// Else
// Return String.Empty
// End If
// End Function

// Public Sub SetVariable(ByVal var As String, ByVal value As String)
// If m_oGlobals.VariableList.ContainsKey(var) Then
// m_oGlobals.VariableList.Item(var) = value
// Else
// m_oGlobals.VariableList.Add(var, value)
// End If

// RaiseEvent EventVariableChanged(var)
// End Sub

// Public Function DoFile(ByVal sFile As String) As Boolean
// Dim sFriendlyName As String = sFile

// ScriptName = sFile

// If sFile.IndexOf("\") = -1 Then
// Dim sLocation As String = String.Empty

// If m_oGlobals.Config.sScriptDir.Contains(":") Then
// sLocation = m_oGlobals.Config.sScriptDir
// Else
// sLocation = LocalDirectory.Path
// If m_oGlobals.Config.sScriptDir.StartsWith("\") Then
// sLocation &= m_oGlobals.Config.sScriptDir
// Else
// sLocation &= "\" & m_oGlobals.Config.sScriptDir
// End If
// End If

// If sLocation.EndsWith("\") Then
// sFile = sLocation & sFile
// Else
// sFile = sLocation & "\" & sFile
// End If
// End If

// Dim fi As FileInfo = New FileInfo(sFile)

// If fi.Exists And fi.Length > 0 Then
// Try
// lua.DoFile(sFile)
// Catch ex As LuaException
// RaiseEvent EventPrintError(ex.ToString)
// End Try
// Else
// PrintError("Unable to load file: " & sFriendlyName)
// ExitScript()
// Return False
// End If
// End Function

// End Class

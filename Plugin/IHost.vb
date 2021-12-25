Public Interface IHost

    Sub EchoText(ByVal Text As String)

    Sub SendText(ByVal Text As String)

    Property Variable(ByVal Var As String) As String

    ReadOnly Property ParentForm() As System.Windows.Forms.Form

	ReadOnly Property IsVerified(ByVal key As String) As Boolean

	ReadOnly Property IsPremium(ByVal key As String) As Boolean

	ReadOnly Property InterfaceVersion() As Integer

	Property PluginKey() As String

End Interface

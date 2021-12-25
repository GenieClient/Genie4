Public Interface IPlugin

    ReadOnly Property Name() As String

    ReadOnly Property Version() As String

    ReadOnly Property Description() As String

    ReadOnly Property Author() As String

    Sub Initialize(ByVal Host As IHost)

    Sub Show()

    Sub VariableChanged(ByVal Variable As String)

    Function ParseText(ByVal Text As String, ByVal Window As String) As String

    Function ParseInput(ByVal Text As String) As String

    Sub ParseXML(ByVal XML As String)

    Property Enabled() As Boolean

    Sub ParentClosing()

End Interface

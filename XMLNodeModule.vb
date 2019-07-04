Imports System.Xml

Public Class XMLNodeModule

#Region " Declare Variable"
    Private _parentNode As XmlElement
    Private _nodeName As String
    Private _attributesList As Dictionary(Of String, String)
    Private _innerText As String
    Private _childNodes As XmlNodeList

    Private Const OBJ_NOTHING As Object = Nothing
    Private Const STR_NOTHING As String = ""
    Private Const NO_NAME As String = "NoName"
    Private Const DEF_ATTR_NAME As String = "name"
    Private Const DEF_ATTR_TEXT As String = "Node"
    Private Const DEF_NODE_INNE As String = "No Text"
#End Region

#Region " Properties"
    ''' <summary>
    ''' Parent node of current node
    ''' </summary>
    ''' <returns></returns>
    Public Property ParentNode() As XmlElement
        Get
            Return _parentNode
        End Get
        Set(value As XmlElement)
            _parentNode = value
        End Set
    End Property

    ''' <summary>
    ''' Name of current node
    ''' </summary>
    ''' <returns></returns>
    Public Property NodeName() As String
        Get
            Return _nodeName
        End Get
        Set(value As String)
            _nodeName = value
        End Set
    End Property

    ''' <summary>
    ''' List Attributes of current node
    ''' </summary>
    ''' <returns></returns>
    Public Property Attributes() As Dictionary(Of String, String)
        Get
            Return _attributesList
        End Get
        Set(value As Dictionary(Of String, String))
            _attributesList = value
        End Set
    End Property

    ''' <summary>
    ''' Text in innerText of current Node
    ''' </summary>
    ''' <returns></returns>
    Public Property InnerText() As String
        Get
            Return _innerText
        End Get
        Set(value As String)
            _innerText = value
        End Set
    End Property

    ''' <summary>
    ''' List child nodes of Current node
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ChildNodes() As XmlNodeList
        Get
            Return _childNodes
        End Get
    End Property
#End Region

#Region " Contructor & Destructor"
    ''' <summary>
    ''' Constructor without parameter
    ''' </summary>
    Public Sub New()
        _parentNode = OBJ_NOTHING
        _nodeName = NO_NAME
        _innerText = STR_NOTHING
        _childNodes = OBJ_NOTHING
        _attributesList = OBJ_NOTHING
    End Sub

    ''' <summary>
    ''' Constructor with XmlElement Parent and current node name
    ''' </summary>
    ''' <param name="parentNode">XmlElemnet: Node parent</param>
    ''' <param name="nodeName">String: Node name</param>
    Public Sub New(ByRef parentNode As XmlElement, ByVal nodeName As String)
        _parentNode = parentNode
        _nodeName = nodeName
        _innerText = STR_NOTHING
        _childNodes = OBJ_NOTHING
        _attributesList = OBJ_NOTHING
    End Sub

    ''' <summary>
    ''' Constructor with XmlElement Parent,Name of Node, attributes of Node
    ''' </summary>
    ''' <param name="parentNode">XmlElemnet: Node parent</param>
    ''' <param name="nodeName">String: Node name</param>
    '''  <param name="Attributes">Dictionary(String, String): Attributes of Node</param>
    Public Sub New(ByRef parentNode As XmlElement, ByVal nodeName As String, ByVal Attributes As Dictionary(Of String, String))
        _parentNode = parentNode
        _nodeName = nodeName
        _innerText = STR_NOTHING
        _childNodes = OBJ_NOTHING
        _attributesList = Attributes
    End Sub

    ''' <summary>
    ''' Constructor with XmlElement Parent,Name of Node, attributes of Node
    ''' </summary>
    ''' <param name="parentNode">XmlElemnet: Node parent</param>
    ''' <param name="nodeName">String: Node name</param>
    ''' <param name="Attributes">Dictionary(String, String): Attributes of Node</param>
    ''' <param name="childNodes">XmlNodeList: List of Child node of current node</param>
    Public Sub New(ByRef parentNode As XmlElement, ByVal nodeName As String, ByVal Attributes As Dictionary(Of String, String), ByVal childNodes As XmlNodeList)
        _parentNode = parentNode
        _nodeName = nodeName
        _innerText = STR_NOTHING
        _childNodes = childNodes
        _attributesList = Attributes
    End Sub

    ''' <summary>
    ''' Constructor with XmlElement Parent,Name of Node, attributes of Node
    ''' </summary>
    ''' <param name="parentNode">XmlElemnet: Node parent</param>
    ''' <param name="nodeName">String: Node name</param>
    ''' <param name="Attributes">Dictionary(String, String): Attributes of Node</param>
    ''' <param name="childNodes">XmlNodeList: List of Child node of current node</param>
    ''' <param name="innerText">String: Text inner</param>
    Public Sub New(ByRef parentNode As XmlElement, ByVal nodeName As String, ByVal Attributes As Dictionary(Of String, String), ByVal childNodes As XmlNodeList, ByRef innerText As String)
        _parentNode = parentNode
        _nodeName = nodeName
        _innerText = innerText
        _childNodes = childNodes
        _attributesList = Attributes
    End Sub

    ''' <summary>
    ''' Destructor of Class
    ''' </summary>
    Protected Overrides Sub Finalize()
        ' Destructor
    End Sub
#End Region

#Region " Shared Function"
    ''' <summary>
    ''' Reset with default text node
    ''' </summary>
    Public Sub ResetDefault()
        _attributesList = New Dictionary(Of String, String) From {{DEF_ATTR_NAME, DEF_ATTR_TEXT}}
        _parentNode = OBJ_NOTHING
        _nodeName = NO_NAME
        _innerText = DEF_NODE_INNE
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="attributesDefault"></param>
    ''' <param name="innerText"></param>
    Public Sub ResetDefaultWithName(ByVal attributesDefault As String, ByVal innerText As String)
        _attributesList = New Dictionary(Of String, String) From {{DEF_ATTR_NAME, attributesDefault}}
        _parentNode = OBJ_NOTHING
        _nodeName = NO_NAME
        _innerText = innerText
    End Sub

#End Region
End Class


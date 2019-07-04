Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Data

Public Class PopupForm

    Private TreeData As Dictionary(Of Long, XMLNodeModule) = New Dictionary(Of Long, XMLNodeModule)
    Private TreeKey As Long = 0

    Public Sub New()
        InitializeComponent()
        Icon = My.Resources.ImageResources.Control_Panel21
    End Sub

    Private Sub B_Browser_Click(sender As Object, e As EventArgs) Handles B_Browser.Click
        Dim dialog As FileFolderDialog = New FileFolderDialog()
        If (dialog.ShowDialog() = DialogResult.OK) Then
            Dim path = dialog.SelectedPath
            T_XmlPath.Text = path
            Try
                If (IO.File.Exists(path)) Then
                    Dim reader As New StreamReader(path, System.Text.Encoding.UTF8)
                    Dim root As XmlDocument = New XmlDocument
                    root.Load(reader)
                    Tree_Xml.Nodes.Clear()
                    AddTreeViewChildNodes(Tree_Xml.Nodes, root.DocumentElement)
                Else
                    MessageBox.Show("The " & IO.Path.GetFileName(path) & "you selected was not found.")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Add the children of this XML node 
    ''' to this child nodes collection.
    ''' </summary>
    ''' <param name="parent_nodes"></param>
    ''' <param name="xml_node"></param>
    Private Sub AddTreeViewChildNodes(ByVal parent_nodes As TreeNodeCollection, ByVal xml_node As XmlNode)
        For Each child_node As XmlNode In xml_node.ChildNodes
            ' Make the new TreeView node.
            Dim new_node As TreeNode = parent_nodes.Add(child_node.Name)

            'Create Dictionary Node
            new_node.Tag = TreeKey
            Dim attributes As Dictionary(Of String, String) = New Dictionary(Of String, String)
            For Each attribute As XmlAttribute In child_node.Attributes
                attributes.Add(attribute.Name, attribute.InnerText)
            Next
            Dim node_Module As XMLNodeModule
            If child_node.FirstChild.NodeType <> XmlNodeType.Text Then
                node_Module = New XMLNodeModule(xml_node, child_node.Name, attributes, child_node.ChildNodes)
            Else
                node_Module = New XMLNodeModule(xml_node, child_node.Name, attributes, child_node.ChildNodes, child_node.FirstChild.Value)
            End If

            TreeData.Add(TreeKey, node_Module)
            TreeKey = TreeKey + 1
            ' Recursively make this node's descendants.
            If child_node.FirstChild.NodeType <> XmlNodeType.Text Then
                AddTreeViewChildNodes(new_node.Nodes, child_node)
            End If

            ' If this is a leaf node, make sure it's visible.
            If new_node.Nodes.Count = 0 Then _
            new_node.EnsureVisible()
            Next
    End Sub

    Private Sub Tree_Xml_Click(sender As Object, e As EventArgs) Handles Tree_Xml.Click
        Dim info As TreeViewHitTestInfo = Tree_Xml.HitTest(Tree_Xml.PointToClient(Cursor.Position))
        If info IsNot Nothing Then
            Dim key As Long = Long.Parse(info.Node.Tag)
            DisplayInfo(TreeData.Item(key))
        End If
    End Sub

    Private Sub DisplayInfo(ByRef xmlModule As XMLNodeModule)
        T_ParentNode.Text = xmlModule.ParentNode.Name
        T_InnerText.Text = xmlModule.InnerText
        T_NodeName.Text = xmlModule.NodeName
        '---------------------------
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("No", GetType(String))
        dt.Columns.Add("NodeName", GetType(String))
        Dim dr As DataRow
        Dim count As Integer = 1
        For Each node As XmlNode In xmlModule.ChildNodes
            dr = dt.NewRow
            dr.Item("No") = count
            dr.Item("NodeName") = node.Name
            dt.Rows.Add(dr)
            count = count + 1
        Next
        LB_ChildNode.DataSource = dt
        LB_ChildNode.DisplayMember = "NodeName"
        '---------------------------
        Dim dt_attributes As DataTable = New DataTable
        dt_attributes.Columns.Add("key", GetType(String))
        dt_attributes.Columns.Add("value", GetType(String))
        count = 1
        For Each attribute As KeyValuePair(Of String, String) In xmlModule.Attributes
            dr = dt_attributes.NewRow
            dr.Item("key") = attribute.Key
            dr.Item("value") = attribute.Value
            dt_attributes.Rows.Add(dr)
            count = count + 1
        Next
        CB_Attributes.DataSource = dt_attributes
        CB_Attributes.DisplayMember = "key"
        CB_Attributes.ValueMember = "value"
        CB_Attributes.SelectedIndex = 0

    End Sub

    Private Sub CB_Attributes_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_Attributes.SelectedValueChanged

        Try
            T_Attribute.Text = sender.SelectedValue
        Catch ex As Exception
        End Try
    End Sub
End Class

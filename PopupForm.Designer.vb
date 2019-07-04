<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PopupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PopupForm))
        Me.Tree_Xml = New System.Windows.Forms.TreeView()
        Me.P_TreeXML = New System.Windows.Forms.Panel()
        Me.B_DeleteNode = New System.Windows.Forms.Button()
        Me.B_UpdateNode = New System.Windows.Forms.Button()
        Me.B_AddNode = New System.Windows.Forms.Button()
        Me.B_AddChilNode = New System.Windows.Forms.Button()
        Me.LB_ChildNode = New System.Windows.Forms.ListBox()
        Me.CB_Attributes = New System.Windows.Forms.ComboBox()
        Me.L_ChilsNode = New System.Windows.Forms.Label()
        Me.L_InnerText = New System.Windows.Forms.Label()
        Me.T_InnerText = New System.Windows.Forms.TextBox()
        Me.L_Attributes = New System.Windows.Forms.Label()
        Me.T_Attribute = New System.Windows.Forms.TextBox()
        Me.L_NodeName = New System.Windows.Forms.Label()
        Me.T_NodeName = New System.Windows.Forms.TextBox()
        Me.L_ParentNode = New System.Windows.Forms.Label()
        Me.T_ParentNode = New System.Windows.Forms.TextBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.Tab_EditXML = New System.Windows.Forms.TabPage()
        Me.B_Browser = New System.Windows.Forms.Button()
        Me.L_PathXML = New System.Windows.Forms.Label()
        Me.T_XmlPath = New System.Windows.Forms.TextBox()
        Me.Tab_Settings = New System.Windows.Forms.TabPage()
        Me.Tab_Help = New System.Windows.Forms.TabPage()
        Me.FileFolderDialog1 = New TrayApp.FileFolderDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.P_TreeXML.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.Tab_EditXML.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tree_Xml
        '
        Me.Tree_Xml.Dock = System.Windows.Forms.DockStyle.Left
        Me.Tree_Xml.Location = New System.Drawing.Point(0, 0)
        Me.Tree_Xml.Name = "Tree_Xml"
        Me.Tree_Xml.Size = New System.Drawing.Size(377, 434)
        Me.Tree_Xml.TabIndex = 2
        '
        'P_TreeXML
        '
        Me.P_TreeXML.Controls.Add(Me.B_DeleteNode)
        Me.P_TreeXML.Controls.Add(Me.B_UpdateNode)
        Me.P_TreeXML.Controls.Add(Me.B_AddNode)
        Me.P_TreeXML.Controls.Add(Me.B_AddChilNode)
        Me.P_TreeXML.Controls.Add(Me.LB_ChildNode)
        Me.P_TreeXML.Controls.Add(Me.CB_Attributes)
        Me.P_TreeXML.Controls.Add(Me.L_ChilsNode)
        Me.P_TreeXML.Controls.Add(Me.L_InnerText)
        Me.P_TreeXML.Controls.Add(Me.T_InnerText)
        Me.P_TreeXML.Controls.Add(Me.L_Attributes)
        Me.P_TreeXML.Controls.Add(Me.T_Attribute)
        Me.P_TreeXML.Controls.Add(Me.L_NodeName)
        Me.P_TreeXML.Controls.Add(Me.T_NodeName)
        Me.P_TreeXML.Controls.Add(Me.L_ParentNode)
        Me.P_TreeXML.Controls.Add(Me.T_ParentNode)
        Me.P_TreeXML.Controls.Add(Me.Tree_Xml)
        Me.P_TreeXML.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.P_TreeXML.Location = New System.Drawing.Point(3, 81)
        Me.P_TreeXML.Name = "P_TreeXML"
        Me.P_TreeXML.Size = New System.Drawing.Size(932, 434)
        Me.P_TreeXML.TabIndex = 3
        '
        'B_DeleteNode
        '
        Me.B_DeleteNode.Location = New System.Drawing.Point(487, 398)
        Me.B_DeleteNode.Name = "B_DeleteNode"
        Me.B_DeleteNode.Size = New System.Drawing.Size(91, 23)
        Me.B_DeleteNode.TabIndex = 143
        Me.B_DeleteNode.Text = "Delete Node"
        Me.B_DeleteNode.UseVisualStyleBackColor = True
        '
        'B_UpdateNode
        '
        Me.B_UpdateNode.Location = New System.Drawing.Point(584, 398)
        Me.B_UpdateNode.Name = "B_UpdateNode"
        Me.B_UpdateNode.Size = New System.Drawing.Size(91, 23)
        Me.B_UpdateNode.TabIndex = 143
        Me.B_UpdateNode.Text = "Update Node"
        Me.B_UpdateNode.UseVisualStyleBackColor = True
        '
        'B_AddNode
        '
        Me.B_AddNode.Location = New System.Drawing.Point(681, 398)
        Me.B_AddNode.Name = "B_AddNode"
        Me.B_AddNode.Size = New System.Drawing.Size(91, 23)
        Me.B_AddNode.TabIndex = 143
        Me.B_AddNode.Text = "Add Node"
        Me.B_AddNode.UseVisualStyleBackColor = True
        '
        'B_AddChilNode
        '
        Me.B_AddChilNode.Location = New System.Drawing.Point(778, 398)
        Me.B_AddChilNode.Name = "B_AddChilNode"
        Me.B_AddChilNode.Size = New System.Drawing.Size(137, 23)
        Me.B_AddChilNode.TabIndex = 143
        Me.B_AddChilNode.Text = "Add Child Node"
        Me.B_AddChilNode.UseVisualStyleBackColor = True
        '
        'LB_ChildNode
        '
        Me.LB_ChildNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LB_ChildNode.Enabled = False
        Me.LB_ChildNode.FormattingEnabled = True
        Me.LB_ChildNode.ItemHeight = 12
        Me.LB_ChildNode.Location = New System.Drawing.Point(480, 170)
        Me.LB_ChildNode.Name = "LB_ChildNode"
        Me.LB_ChildNode.Size = New System.Drawing.Size(436, 124)
        Me.LB_ChildNode.TabIndex = 142
        '
        'CB_Attributes
        '
        Me.CB_Attributes.FormattingEnabled = True
        Me.CB_Attributes.Location = New System.Drawing.Point(480, 87)
        Me.CB_Attributes.Name = "CB_Attributes"
        Me.CB_Attributes.Size = New System.Drawing.Size(163, 20)
        Me.CB_Attributes.TabIndex = 141
        '
        'L_ChilsNode
        '
        Me.L_ChilsNode.AutoSize = True
        Me.L_ChilsNode.Location = New System.Drawing.Point(406, 170)
        Me.L_ChilsNode.Name = "L_ChilsNode"
        Me.L_ChilsNode.Size = New System.Drawing.Size(67, 12)
        Me.L_ChilsNode.TabIndex = 4
        Me.L_ChilsNode.Text = "Childs Node"
        '
        'L_InnerText
        '
        Me.L_InnerText.AutoSize = True
        Me.L_InnerText.Location = New System.Drawing.Point(406, 133)
        Me.L_InnerText.Name = "L_InnerText"
        Me.L_InnerText.Size = New System.Drawing.Size(57, 12)
        Me.L_InnerText.TabIndex = 4
        Me.L_InnerText.Text = "Inner Text"
        '
        'T_InnerText
        '
        Me.T_InnerText.Location = New System.Drawing.Point(480, 130)
        Me.T_InnerText.Name = "T_InnerText"
        Me.T_InnerText.Size = New System.Drawing.Size(436, 19)
        Me.T_InnerText.TabIndex = 140
        '
        'L_Attributes
        '
        Me.L_Attributes.AutoSize = True
        Me.L_Attributes.Location = New System.Drawing.Point(406, 95)
        Me.L_Attributes.Name = "L_Attributes"
        Me.L_Attributes.Size = New System.Drawing.Size(56, 12)
        Me.L_Attributes.TabIndex = 4
        Me.L_Attributes.Text = "Attributes"
        '
        'T_Attribute
        '
        Me.T_Attribute.Location = New System.Drawing.Point(650, 88)
        Me.T_Attribute.Name = "T_Attribute"
        Me.T_Attribute.Size = New System.Drawing.Size(266, 19)
        Me.T_Attribute.TabIndex = 130
        '
        'L_NodeName
        '
        Me.L_NodeName.AutoSize = True
        Me.L_NodeName.Location = New System.Drawing.Point(406, 58)
        Me.L_NodeName.Name = "L_NodeName"
        Me.L_NodeName.Size = New System.Drawing.Size(64, 12)
        Me.L_NodeName.TabIndex = 4
        Me.L_NodeName.Text = "Node Name"
        '
        'T_NodeName
        '
        Me.T_NodeName.Location = New System.Drawing.Point(480, 55)
        Me.T_NodeName.Name = "T_NodeName"
        Me.T_NodeName.Size = New System.Drawing.Size(436, 19)
        Me.T_NodeName.TabIndex = 120
        '
        'L_ParentNode
        '
        Me.L_ParentNode.AutoSize = True
        Me.L_ParentNode.Location = New System.Drawing.Point(406, 25)
        Me.L_ParentNode.Name = "L_ParentNode"
        Me.L_ParentNode.Size = New System.Drawing.Size(68, 12)
        Me.L_ParentNode.TabIndex = 4
        Me.L_ParentNode.Text = "Parent Node"
        '
        'T_ParentNode
        '
        Me.T_ParentNode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_ParentNode.Location = New System.Drawing.Point(480, 22)
        Me.T_ParentNode.Name = "T_ParentNode"
        Me.T_ParentNode.ReadOnly = True
        Me.T_ParentNode.Size = New System.Drawing.Size(436, 19)
        Me.T_ParentNode.TabIndex = 110
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.Tab_EditXML)
        Me.TabControl.Controls.Add(Me.Tab_Settings)
        Me.TabControl.Controls.Add(Me.Tab_Help)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Multiline = True
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(946, 544)
        Me.TabControl.TabIndex = 10
        '
        'Tab_EditXML
        '
        Me.Tab_EditXML.BackColor = System.Drawing.Color.Transparent
        Me.Tab_EditXML.Controls.Add(Me.TextBox1)
        Me.Tab_EditXML.Controls.Add(Me.B_Browser)
        Me.Tab_EditXML.Controls.Add(Me.L_PathXML)
        Me.Tab_EditXML.Controls.Add(Me.T_XmlPath)
        Me.Tab_EditXML.Controls.Add(Me.P_TreeXML)
        Me.Tab_EditXML.Location = New System.Drawing.Point(4, 22)
        Me.Tab_EditXML.Name = "Tab_EditXML"
        Me.Tab_EditXML.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_EditXML.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tab_EditXML.Size = New System.Drawing.Size(938, 518)
        Me.Tab_EditXML.TabIndex = 0
        Me.Tab_EditXML.Text = "Edit XML Format"
        '
        'B_Browser
        '
        Me.B_Browser.Location = New System.Drawing.Point(641, 9)
        Me.B_Browser.Name = "B_Browser"
        Me.B_Browser.Size = New System.Drawing.Size(75, 23)
        Me.B_Browser.TabIndex = 6
        Me.B_Browser.Text = "Browser"
        Me.B_Browser.UseVisualStyleBackColor = True
        '
        'L_PathXML
        '
        Me.L_PathXML.AutoSize = True
        Me.L_PathXML.Font = New System.Drawing.Font("MS UI Gothic", 11.25!)
        Me.L_PathXML.Location = New System.Drawing.Point(17, 15)
        Me.L_PathXML.Name = "L_PathXML"
        Me.L_PathXML.Size = New System.Drawing.Size(54, 15)
        Me.L_PathXML.TabIndex = 5
        Me.L_PathXML.Text = "Xml file"
        '
        'T_XmlPath
        '
        Me.T_XmlPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.T_XmlPath.Location = New System.Drawing.Point(86, 11)
        Me.T_XmlPath.Name = "T_XmlPath"
        Me.T_XmlPath.ReadOnly = True
        Me.T_XmlPath.Size = New System.Drawing.Size(560, 19)
        Me.T_XmlPath.TabIndex = 4
        '
        'Tab_Settings
        '
        Me.Tab_Settings.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Settings.Name = "Tab_Settings"
        Me.Tab_Settings.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Settings.Size = New System.Drawing.Size(938, 518)
        Me.Tab_Settings.TabIndex = 1
        Me.Tab_Settings.Text = "Settings"
        Me.Tab_Settings.UseVisualStyleBackColor = True
        '
        'Tab_Help
        '
        Me.Tab_Help.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Help.Name = "Tab_Help"
        Me.Tab_Help.Size = New System.Drawing.Size(938, 518)
        Me.Tab_Help.TabIndex = 2
        Me.Tab_Help.Text = "Helps"
        Me.Tab_Help.UseVisualStyleBackColor = True
        '
        'FileFolderDialog1
        '
        Me.FileFolderDialog1.SelectedPath = ""
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(86, 37)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(262, 19)
        Me.TextBox1.TabIndex = 7
        '
        'PopupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 544)
        Me.Controls.Add(Me.TabControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "PopupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tray Application Dialog"
        Me.P_TreeXML.ResumeLayout(False)
        Me.P_TreeXML.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.Tab_EditXML.ResumeLayout(False)
        Me.Tab_EditXML.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tree_Xml As TreeView
    Friend WithEvents P_TreeXML As Panel
    Friend WithEvents TabControl As TabControl
    Friend WithEvents Tab_EditXML As TabPage
    Friend WithEvents Tab_Settings As TabPage
    Friend WithEvents B_DeleteNode As Button
    Friend WithEvents B_UpdateNode As Button
    Friend WithEvents B_AddNode As Button
    Friend WithEvents B_AddChilNode As Button
    Friend WithEvents LB_ChildNode As ListBox
    Friend WithEvents CB_Attributes As ComboBox
    Friend WithEvents L_ChilsNode As Label
    Friend WithEvents L_InnerText As Label
    Friend WithEvents T_InnerText As TextBox
    Friend WithEvents L_Attributes As Label
    Friend WithEvents T_Attribute As TextBox
    Friend WithEvents L_NodeName As Label
    Friend WithEvents T_NodeName As TextBox
    Friend WithEvents L_ParentNode As Label
    Friend WithEvents T_ParentNode As TextBox
    Friend WithEvents B_Browser As Button
    Friend WithEvents L_PathXML As Label
    Friend WithEvents T_XmlPath As TextBox
    Friend WithEvents Tab_Help As TabPage
    Friend WithEvents FileFolderDialog1 As FileFolderDialog
    Friend WithEvents TextBox1 As TextBox
End Class

Imports System.IO
Imports System.Xml
Imports System.Windows.Forms

Public Class AppContext
    Inherits ApplicationContext

#Region " Storage "

    Private WithEvents Tray As NotifyIcon
    Private WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuDisplayForm As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem
    Private WithEvents mnuSelectXml As ToolStripMenuItem
    Private WithEvents mnuDescription As ToolTip
    Private innerText As Dictionary(Of String, String)
    Private keyOfInnerText As Integer
    Private appActive As Boolean

#End Region

#Region " Constructor "

    Public Sub New()
        innerText = New Dictionary(Of String, String)
        keyOfInnerText = 0
        appActive = True

        'Initialize the menus
        Call CreateMainMenu()
        mnuDescription = New ToolTip()

        'Initialize the tray
        Tray = New NotifyIcon
        Tray.Icon = My.Resources.ImageResources.Control_Panel21
        Tray.ContextMenuStrip = MainMenu
        Tray.Text = My.Resources.TextResources.TrayTextActive

        'Display
        Tray.Visible = True
    End Sub

#End Region

#Region " Public Function"
    Public Sub AddMenuFromXML(ByVal root As XmlDocument)
        Try
            If root.HasChildNodes Then
                If root.FirstChild.GetType.ToString = "System.Xml.XmlDeclaration" Then
                    root.RemoveChild(root.FirstChild)
                End If
                MainMenu.Items.Clear()
                For Each item As XmlElement In root.ChildNodes()
                    If item.HasChildNodes AndAlso item.ChildNodes.Item(0).Name <> "#text" Then
                        Dim subitems As ToolStripMenuItem = AddChildsToContextMenuStrip(item)
                        For Each subitem As ToolStripMenuItem In subitems.DropDownItems
                            Dim subitemClone = CloneToolStripMenu(subitem)
                            MainMenu.Items.Add(subitemClone)
                            AddHandler subitemClone.Click, AddressOf ItemsMouseClick
                            AddHandler subitemClone.MouseEnter, AddressOf Command_MouseEnter
                            AddHandler subitemClone.MouseLeave, AddressOf Command_MouseLeave
                        Next
                    Else
                        Dim subitemClone = New ToolStripMenuItem(item.Attributes("name").Value)
                        AddHandler subitemClone.Click, AddressOf ItemsMouseClick
                        AddHandler subitemClone.MouseEnter, AddressOf Command_MouseEnter
                        AddHandler subitemClone.MouseLeave, AddressOf Command_MouseLeave

                        keyOfInnerText += 1
                        subitemClone.Name = New System.Text.StringBuilder("MenuItem" & keyOfInnerText).ToString
                        innerText.Add(subitemClone.Name, item.InnerText.Clone())
                        MainMenu.Items.Add(subitemClone)
                    End If
                Next
            End If
            'Add Default Menu
            Call CreateMainMenu()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region " Private Function"
    ''' <summary>
    ''' Add DefultMenu to MenusToolStrip
    ''' </summary>
    Private Sub CreateMainMenu()
        mnuSelectXml = New ToolStripMenuItem(My.Resources.TextResources.MenuSelectXml)
        mnuDisplayForm = New ToolStripMenuItem(My.Resources.TextResources.MenuShow)
        mnuSep1 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem(My.Resources.TextResources.MenuExit)
        If MainMenu Is Nothing Then
            MainMenu = New ContextMenuStrip
        End If
        MainMenu.Items.AddRange(New ToolStripItem() {mnuSep1, mnuSelectXml, mnuDisplayForm, mnuExit})
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="root"></param>
    ''' <returns></returns>
    Private Function AddChildsToContextMenuStrip(ByVal root As XmlElement) As ToolStripMenuItem
        Dim listItemMain As List(Of ToolStripMenuItem) = New List(Of ToolStripMenuItem)
        '---------------------------
        For Each item As XmlElement In root
            Dim subtool As ToolStripMenuItem = New ToolStripMenuItem(item.Attributes("name").Value)

            If item.HasChildNodes AndAlso item.ChildNodes.Item(0).Name <> "#text" Then
                Dim subitems As ToolStripMenuItem = AddChildsToContextMenuStrip(item)
                For Each subitem As ToolStripMenuItem In subitems.DropDownItems
                    Dim subitemClone = CloneToolStripMenu(subitem)
                    subtool.DropDownItems.Add(subitemClone)
                    AddHandler subitemClone.Click, AddressOf ItemsMouseClick
                    AddHandler subitemClone.MouseEnter, AddressOf Command_MouseEnter
                    AddHandler subitemClone.MouseLeave, AddressOf Command_MouseLeave
                Next
            Else
                keyOfInnerText += 1
                subtool.Name = New System.Text.StringBuilder("MenuItem" & keyOfInnerText).ToString
                Dim xmlnode As XmlNode = item.Clone

                innerText.Add(subtool.Name, New String(xmlnode.FirstChild.InnerText))
            End If
            listItemMain.Add(subtool)

        Next
        Dim subMenu As New ToolStripMenuItem()
        For Each item As ToolStripMenuItem In listItemMain
            subMenu.DropDownItems.Add(item)
            AddHandler item.Click, AddressOf ItemsMouseClick
            AddHandler item.MouseEnter, AddressOf Command_MouseEnter
            AddHandler item.MouseLeave, AddressOf Command_MouseLeave
        Next
        Return subMenu
    End Function

    ''' <summary>
    ''' Add event handle to ToolStripMenuItem
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ItemsMouseClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim key As String = CType(sender, ToolStripMenuItem).Name
        If innerText.ContainsKey(key) Then
            Call CopyTextToClipboard(innerText.Item(key))
        End If
    End Sub

    Private Sub ItemMouseHover(ByVal sender As Object, ByVal e As EventArgs)
        Dim key As String = CType(sender, ToolStripMenuItem).Name
        If innerText.ContainsKey(key) Then
            mnuDescription.Show(innerText.Item(key), MainMenu, 3000)
        End If
    End Sub

    Private Sub Command_MouseEnter(sender As Object, e As EventArgs)
        Dim key As String = CType(sender, ToolStripMenuItem).Name
        If innerText.ContainsKey(key) Then
            mnuDescription.Show(innerText.Item(key), MainMenu)
        End If
    End Sub

    Private Sub Command_MouseLeave(sender As Object, e As EventArgs)
        mnuDescription.Hide(MainMenu)
    End Sub

    ''' <summary>
    ''' Set text clipboard
    ''' </summary>
    ''' <param name="Text"></param>
    Private Sub CopyTextToClipboard(ByVal Text As String)
        Clipboard.Clear()
        Clipboard.SetText(Text)
    End Sub

    ''' <summary>
    ''' Clone ToolStripMenu from ToolStripMenuItem
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    Friend Function CloneToolStripMenu(ByVal this As ToolStripMenuItem) As ToolStripMenuItem
        Dim menuItem As New ToolStripMenuItem
        'Copy all Item to Clone Item
        menuItem.AccessibleName = this.AccessibleName
        menuItem.AccessibleRole = this.AccessibleRole
        menuItem.Alignment = this.Alignment
        menuItem.AllowDrop = this.AllowDrop
        menuItem.Anchor = this.Anchor
        menuItem.AutoSize = this.AutoSize
        menuItem.AutoToolTip = this.AutoToolTip
        menuItem.BackColor = this.BackColor
        menuItem.BackgroundImage = this.BackgroundImage
        menuItem.BackgroundImageLayout = this.BackgroundImageLayout
        menuItem.Checked = this.Checked
        menuItem.CheckOnClick = this.CheckOnClick
        menuItem.CheckState = this.CheckState
        menuItem.DisplayStyle = this.DisplayStyle
        menuItem.Dock = this.Dock
        menuItem.DoubleClickEnabled = this.DoubleClickEnabled
        menuItem.DropDown = this.DropDown
        menuItem.DropDownDirection = this.DropDownDirection
        menuItem.Enabled = this.Enabled
        menuItem.Font = this.Font
        menuItem.ForeColor = this.ForeColor
        menuItem.Image = this.Image
        menuItem.ImageAlign = this.ImageAlign
        menuItem.ImageScaling = this.ImageScaling
        menuItem.ImageTransparentColor = this.ImageTransparentColor
        menuItem.Margin = this.Margin
        menuItem.MergeAction = this.MergeAction
        menuItem.MergeIndex = this.MergeIndex
        menuItem.Name = this.Name
        menuItem.Overflow = this.Overflow
        menuItem.Padding = this.Padding
        menuItem.RightToLeft = this.RightToLeft
        menuItem.ShortcutKeys = this.ShortcutKeys
        menuItem.ShowShortcutKeys = this.ShowShortcutKeys
        menuItem.Tag = this.Tag
        menuItem.Text = this.Text
        menuItem.TextAlign = this.TextAlign
        menuItem.TextDirection = this.TextDirection
        menuItem.TextImageRelation = this.TextImageRelation
        menuItem.ToolTipText = this.ToolTipText
        menuItem.Available = this.Available

        'If Not AutoSize Then
        '    menuItem.Size = this.Size
        'End If

        Return menuItem
    End Function
#End Region

#Region " Event handlers "
    ''' <summary>
    ''' Thread Exit
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AppContext_ThreadExit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ThreadExit
        'Guarantees that the icon will not linger.
        Tray.Visible = False
    End Sub

    ''' <summary>
    ''' Event Click to show Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuDisplayForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDisplayForm.Click
        If Tray.Text = My.Resources.TextResources.TrayTextInActive Then
            Exit Sub
        End If
        ShowDialog()
    End Sub

    ''' <summary>
    ''' Event Click to Exit Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        ExitApplication()
    End Sub

    ''' <summary>
    ''' Event Click to Choose XML
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub mnuChooXml_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSelectXml.Click
        Dim dialog As FileFolderDialog = New FileFolderDialog()
        If (dialog.ShowDialog() = DialogResult.OK) Then
            Dim path = dialog.SelectedPath
            Try
                If (IO.File.Exists(path)) Then
                    Dim reader As New StreamReader(path, System.Text.Encoding.UTF8)
                    Dim root As XmlDocument = New XmlDocument
                    root.Load(reader)
                    Call AddMenuFromXML(root)
                Else
                    MessageBox.Show("The " & IO.Path.GetFileName(path) & "you selected was not found.")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If


    End Sub

    ''' <summary>
    ''' Event Double Click to show Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tray.MouseDoubleClick
        If Tray.Text = My.Resources.TextResources.TrayTextInActive Then
            Exit Sub
        End If
        mnuDisplayForm.PerformClick()
    End Sub

    Private Sub OnIconMouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Tray.MouseClick

        If e.Button = MouseButtons.Left Then
            appActive = Not appActive
            Tray.Icon = If(appActive, My.Resources.ImageResources.Control_Panel21, My.Resources.ImageResources.InActiveICo)
            Tray.Text = If(appActive, My.Resources.TextResources.TrayTextActive, My.Resources.TextResources.TrayTextInActive)
        Else
            If Tray.Text = My.Resources.TextResources.TrayTextInActive Then
                Exit Sub
            End If
            MainMenu.Visible = True
        End If
    End Sub
#End Region

End Class

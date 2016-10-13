Imports System.IO
Imports System.Xml

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Dim xmldoc As New XmlDocument()
        'Dim xmlnode As XmlNode
        'Dim fs As New FileStream(Application.StartupPath + "\tree.xml", FileMode.Open, FileAccess.Read)
        'xmldoc.Load(fs)
        'xmlnode = xmldoc.ChildNodes(1)
        'TreeView1.Nodes.Clear()
        ''TreeView1.Nodes.Add(New TreeNode(xmldoc.DocumentElement.Name))
        'Dim tNode As TreeNode
        ''tNode = TreeView1.Nodes(0)
        'AddNode(xmlnode, tNode)

        Dim xmldoc As New XmlDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim fs As New FileStream(Application.StartupPath + "\product.xml", FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("Product")
        For i = 0 To xmlnode.Count - 1
            xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
            ''str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim() & "  " & xmlnode(i).ChildNodes.Item(1).InnerText.Trim() & "  " & xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
            '' MsgBox(str)
            TreeView1.Nodes.Add(xmlnode(i).ChildNodes.Item(1).InnerText.Trim())

        Next

    End Sub

    Private Sub AddNode(ByVal inXmlNode As XmlNode, ByVal inTreeNode As TreeNode)
        Dim xNode As XmlNode
        Dim tNode As TreeNode
        Dim nodeList As XmlNodeList
        Dim i As Integer
        If inXmlNode.HasChildNodes Then
            nodeList = inXmlNode.ChildNodes
            For i = 0 To nodeList.Count - 1
                xNode = inXmlNode.ChildNodes(i)
                inTreeNode.Nodes.Add(New TreeNode(xNode.Name))
                tNode = inTreeNode.Nodes(i)
                AddNode(xNode, tNode)
            Next
        Else
            inTreeNode.Text = inXmlNode.InnerText.ToString
        End If
    End Sub
End Class

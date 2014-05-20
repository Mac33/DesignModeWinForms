Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel.Design



Namespace WindowsApplication1
    Partial Public Class Form1
        Inherits Form


        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As New DataTable()
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("Number", GetType(Integer))
            tbl.Columns.Add("Date", GetType(DateTime))
            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i)})
            Next i
            Return tbl
        End Function



        Public Sub New()
            InitializeComponent()
            Me.DataGridView1.DataSource = CreateTable(20)
            customizator1.DesignContainer = Me.panelA
            customizator1.SelectedControl = Me.DataGridView1
        End Sub



        Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _
            RadioButton1.CheckedChanged,
            RadioButton2.CheckedChanged,
            RadioButton3.CheckedChanged,
            RadioButton4.CheckedChanged,
            RadioButton5.CheckedChanged

            CheckBox2.Checked = False

            If RadioButton1.Checked Then
                customizator1.DesignContainer = Me.panelA
                customizator1.SelectedControl = Me.DataGridView1
            End If

            If RadioButton2.Checked Then
                customizator1.DesignContainer = Me
                customizator1.SelectedControl = Me.Panel2
            End If

            If RadioButton3.Checked Then
                customizator1.DesignContainer = Me
                customizator1.SelectedControl = panelA
            End If
            If RadioButton4.Checked Then
                customizator1.DesignContainer = TextEdit1.Parent
                customizator1.SelectedControl = TextEdit1
            End If
            If RadioButton5.Checked Then
                customizator1.DesignContainer = Me
                customizator1.SelectedControl = TextEdit1.Parent
            End If

        End Sub

        Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
            customizator1.IsCustomization = CheckBox2.Checked
            Me.Button1.Select()
        End Sub

        

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        End Sub
    End Class
End Namespace
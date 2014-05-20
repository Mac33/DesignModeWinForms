Imports Microsoft.VisualBasic
Imports System


Namespace WindowsApplication1
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.panelA = New System.Windows.Forms.Panel()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.DataGridView1 = New System.Windows.Forms.DataGridView()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.CheckBox1 = New System.Windows.Forms.CheckBox()
            Me.TextEdit1 = New System.Windows.Forms.TextBox()
            Me.CheckBox2 = New System.Windows.Forms.CheckBox()
            Me.RadioButton1 = New System.Windows.Forms.RadioButton()
            Me.RadioButton2 = New System.Windows.Forms.RadioButton()
            Me.RadioButton3 = New System.Windows.Forms.RadioButton()
            Me.RadioButton4 = New System.Windows.Forms.RadioButton()
            Me.RadioButton5 = New System.Windows.Forms.RadioButton()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.customizator1 = New WindowsApplication1.Customizator()
            Me.panelA.SuspendLayout()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'panelA
            '
            Me.panelA.Controls.Add(Me.Button1)
            Me.panelA.Controls.Add(Me.DataGridView1)
            Me.panelA.Location = New System.Drawing.Point(12, 107)
            Me.panelA.Name = "panelA"
            Me.panelA.Size = New System.Drawing.Size(407, 353)
            Me.panelA.TabIndex = 4
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(329, 327)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(75, 23)
            Me.Button1.TabIndex = 4
            Me.Button1.Text = "Click"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'DataGridView1
            '
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.Size = New System.Drawing.Size(401, 213)
            Me.DataGridView1.TabIndex = 3
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.CheckBox1)
            Me.Panel1.Controls.Add(Me.TextEdit1)
            Me.Panel1.Location = New System.Drawing.Point(472, 107)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(226, 353)
            Me.Panel1.TabIndex = 5
            '
            'CheckBox1
            '
            Me.CheckBox1.AutoSize = True
            Me.CheckBox1.Location = New System.Drawing.Point(32, 67)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.Size = New System.Drawing.Size(57, 17)
            Me.CheckBox1.TabIndex = 1
            Me.CheckBox1.Text = "Check"
            Me.CheckBox1.UseVisualStyleBackColor = True
            '
            'TextEdit1
            '
            Me.TextEdit1.Location = New System.Drawing.Point(32, 41)
            Me.TextEdit1.Name = "TextEdit1"
            Me.TextEdit1.Size = New System.Drawing.Size(100, 20)
            Me.TextEdit1.TabIndex = 0
            Me.TextEdit1.Text = "Text"
            '
            'CheckBox2
            '
            Me.CheckBox2.AutoSize = True
            Me.CheckBox2.Location = New System.Drawing.Point(12, 18)
            Me.CheckBox2.Name = "CheckBox2"
            Me.CheckBox2.Size = New System.Drawing.Size(91, 17)
            Me.CheckBox2.TabIndex = 6
            Me.CheckBox2.Text = "Customization"
            Me.CheckBox2.UseVisualStyleBackColor = True
            '
            'RadioButton1
            '
            Me.RadioButton1.AutoSize = True
            Me.RadioButton1.Checked = True
            Me.RadioButton1.Location = New System.Drawing.Point(3, 5)
            Me.RadioButton1.Name = "RadioButton1"
            Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
            Me.RadioButton1.TabIndex = 7
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.Text = "GridControl"
            Me.RadioButton1.UseVisualStyleBackColor = True
            '
            'RadioButton2
            '
            Me.RadioButton2.AutoSize = True
            Me.RadioButton2.Location = New System.Drawing.Point(86, 5)
            Me.RadioButton2.Name = "RadioButton2"
            Me.RadioButton2.Size = New System.Drawing.Size(52, 17)
            Me.RadioButton2.TabIndex = 8
            Me.RadioButton2.Text = "Menu"
            Me.RadioButton2.UseVisualStyleBackColor = True
            '
            'RadioButton3
            '
            Me.RadioButton3.AutoSize = True
            Me.RadioButton3.Location = New System.Drawing.Point(144, 5)
            Me.RadioButton3.Name = "RadioButton3"
            Me.RadioButton3.Size = New System.Drawing.Size(113, 17)
            Me.RadioButton3.TabIndex = 9
            Me.RadioButton3.Text = "GridControl's panel"
            Me.RadioButton3.UseVisualStyleBackColor = True
            '
            'RadioButton4
            '
            Me.RadioButton4.AutoSize = True
            Me.RadioButton4.Location = New System.Drawing.Point(263, 5)
            Me.RadioButton4.Name = "RadioButton4"
            Me.RadioButton4.Size = New System.Drawing.Size(64, 17)
            Me.RadioButton4.TabIndex = 10
            Me.RadioButton4.Text = "TextBox"
            Me.RadioButton4.UseVisualStyleBackColor = True
            '
            'RadioButton5
            '
            Me.RadioButton5.AutoSize = True
            Me.RadioButton5.Location = New System.Drawing.Point(333, 5)
            Me.RadioButton5.Name = "RadioButton5"
            Me.RadioButton5.Size = New System.Drawing.Size(100, 17)
            Me.RadioButton5.TabIndex = 11
            Me.RadioButton5.Text = "TextBox's panel"
            Me.RadioButton5.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.RadioButton1)
            Me.Panel2.Controls.Add(Me.RadioButton5)
            Me.Panel2.Controls.Add(Me.RadioButton2)
            Me.Panel2.Controls.Add(Me.RadioButton4)
            Me.Panel2.Controls.Add(Me.RadioButton3)
            Me.Panel2.Location = New System.Drawing.Point(122, 12)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(576, 29)
            Me.Panel2.TabIndex = 12
            '
            'customizator1
            '
            Me.customizator1.DesignContainer = Me
            Me.customizator1.IsCustomization = False
            Me.customizator1.SelectedControl = Nothing
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(710, 601)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.CheckBox2)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.panelA)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.panelA.ResumeLayout(False)
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private customizator1 As Customizator
        Friend WithEvents panelA As System.Windows.Forms.Panel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents TextEdit1 As Windows.Forms.TextBox
        Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
        Friend WithEvents Button1 As System.Windows.Forms.Button

    End Class
End Namespace


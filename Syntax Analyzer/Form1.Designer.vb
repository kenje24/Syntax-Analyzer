<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        RichTextBox1 = New RichTextBox()
        Button1 = New Button()
        DataGridView1 = New DataGridView()
        DataGridView2 = New DataGridView()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(12, 12)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(406, 629)
        RichTextBox1.TabIndex = 0
        RichTextBox1.Text = ""
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(295, 571)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 56)
        Button1.TabIndex = 1
        Button1.Text = "ANALYZE"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(424, 12)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(433, 284)
        DataGridView1.TabIndex = 2
        ' 
        ' DataGridView2
        ' 
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Location = New Point(424, 303)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.Size = New Size(433, 324)
        DataGridView2.TabIndex = 3
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(295, 509)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 56)
        Button2.TabIndex = 4
        Button2.Text = "CHOOSE FILE"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(357, 219)
        Button3.Name = "Button3"
        Button3.Size = New Size(133, 56)
        Button3.TabIndex = 5
        Button3.Text = "DescendingOrder.txt"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(357, 281)
        Button4.Name = "Button4"
        Button4.Size = New Size(133, 56)
        Button4.TabIndex = 6
        Button4.Text = "GuessNumber.txt"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(357, 343)
        Button5.Name = "Button5"
        Button5.Size = New Size(133, 56)
        Button5.TabIndex = 7
        Button5.Text = "UnitConverter.txt"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(869, 653)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(DataGridView2)
        Controls.Add(DataGridView1)
        Controls.Add(Button1)
        Controls.Add(RichTextBox1)
        Name = "Form1"
        Text = "SYNTAX ANALYZER"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button

End Class

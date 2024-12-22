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
        Me.TextBoxContent = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ButtonLoadPaste = New System.Windows.Forms.Button()
        Me.ButtonUpdatePaste = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBoxContent
        '
        Me.TextBoxContent.Location = New System.Drawing.Point(12, 88)
        Me.TextBoxContent.Multiline = True
        Me.TextBoxContent.Name = "TextBoxContent"
        Me.TextBoxContent.Size = New System.Drawing.Size(223, 132)
        Me.TextBoxContent.TabIndex = 1
        Me.TextBoxContent.Text = "Your Txt here"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TextBoxContent"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 238)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(223, 26)
        Me.TextBox1.TabIndex = 5
        '
        'ButtonLoadPaste
        '
        Me.ButtonLoadPaste.Location = New System.Drawing.Point(12, 12)
        Me.ButtonLoadPaste.Name = "ButtonLoadPaste"
        Me.ButtonLoadPaste.Size = New System.Drawing.Size(223, 23)
        Me.ButtonLoadPaste.TabIndex = 6
        Me.ButtonLoadPaste.Text = "ButtonLoadPaste"
        Me.ButtonLoadPaste.UseVisualStyleBackColor = True
        '
        'ButtonUpdatePaste
        '
        Me.ButtonUpdatePaste.Location = New System.Drawing.Point(12, 41)
        Me.ButtonUpdatePaste.Name = "ButtonUpdatePaste"
        Me.ButtonUpdatePaste.Size = New System.Drawing.Size(223, 23)
        Me.ButtonUpdatePaste.TabIndex = 7
        Me.ButtonUpdatePaste.Text = "ButtonUpdatePaste"
        Me.ButtonUpdatePaste.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 270)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(223, 26)
        Me.TextBox2.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(247, 301)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ButtonUpdatePaste)
        Me.Controls.Add(Me.ButtonLoadPaste)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxContent)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxContent As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonLoadPaste As Button
    Friend WithEvents ButtonUpdatePaste As Button
    Friend WithEvents TextBox2 As TextBox
End Class

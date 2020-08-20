<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeaderFichier = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonChargerM3U = New System.Windows.Forms.Button()
        Me.ButtonCopier = New System.Windows.Forms.Button()
        Me.LabelPath = New System.Windows.Forms.Label()
        Me.LabelSize = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CheckBoxUTF8 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxANSI = New System.Windows.Forms.CheckBox()
        Me.LabelProgess = New System.Windows.Forms.Label()
        Me.CheckBoxOnlyNew = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSync = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnleverDeLaListeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderFichier, Me.ColumnHeaderSize})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(119, 50)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.Size = New System.Drawing.Size(573, 349)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderFichier
        '
        Me.ColumnHeaderFichier.Text = "Fichiers :"
        Me.ColumnHeaderFichier.Width = 450
        '
        'ColumnHeaderSize
        '
        Me.ColumnHeaderSize.Text = "Taille (MB) :"
        Me.ColumnHeaderSize.Width = 100
        '
        'ButtonChargerM3U
        '
        Me.ButtonChargerM3U.Location = New System.Drawing.Point(12, 12)
        Me.ButtonChargerM3U.Name = "ButtonChargerM3U"
        Me.ButtonChargerM3U.Size = New System.Drawing.Size(94, 23)
        Me.ButtonChargerM3U.TabIndex = 0
        Me.ButtonChargerM3U.Text = "Charger M3U"
        Me.ButtonChargerM3U.UseVisualStyleBackColor = True
        '
        'ButtonCopier
        '
        Me.ButtonCopier.Location = New System.Drawing.Point(13, 376)
        Me.ButtonCopier.Name = "ButtonCopier"
        Me.ButtonCopier.Size = New System.Drawing.Size(94, 23)
        Me.ButtonCopier.TabIndex = 5
        Me.ButtonCopier.Text = "Démarrer"
        Me.ButtonCopier.UseVisualStyleBackColor = True
        '
        'LabelPath
        '
        Me.LabelPath.Location = New System.Drawing.Point(119, 21)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(381, 23)
        Me.LabelPath.TabIndex = 3
        '
        'LabelSize
        '
        Me.LabelSize.AutoSize = True
        Me.LabelSize.Location = New System.Drawing.Point(510, 22)
        Me.LabelSize.Name = "LabelSize"
        Me.LabelSize.Size = New System.Drawing.Size(0, 13)
        Me.LabelSize.TabIndex = 4
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "m3u"
        Me.OpenFileDialog1.DereferenceLinks = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 407)
        Me.ProgressBar1.Maximum = 0
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(679, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 0
        '
        'CheckBoxUTF8
        '
        Me.CheckBoxUTF8.AutoSize = True
        Me.CheckBoxUTF8.Location = New System.Drawing.Point(13, 50)
        Me.CheckBoxUTF8.Name = "CheckBoxUTF8"
        Me.CheckBoxUTF8.Size = New System.Drawing.Size(53, 17)
        Me.CheckBoxUTF8.TabIndex = 1
        Me.CheckBoxUTF8.Text = "UTF8"
        Me.CheckBoxUTF8.UseVisualStyleBackColor = True
        '
        'CheckBoxANSI
        '
        Me.CheckBoxANSI.AutoSize = True
        Me.CheckBoxANSI.Location = New System.Drawing.Point(13, 73)
        Me.CheckBoxANSI.Name = "CheckBoxANSI"
        Me.CheckBoxANSI.Size = New System.Drawing.Size(51, 17)
        Me.CheckBoxANSI.TabIndex = 2
        Me.CheckBoxANSI.Text = "ANSI"
        Me.CheckBoxANSI.UseVisualStyleBackColor = True
        '
        'LabelProgess
        '
        Me.LabelProgess.AutoSize = True
        Me.LabelProgess.Location = New System.Drawing.Point(13, 437)
        Me.LabelProgess.Name = "LabelProgess"
        Me.LabelProgess.Size = New System.Drawing.Size(0, 13)
        Me.LabelProgess.TabIndex = 8
        Me.LabelProgess.UseMnemonic = False
        '
        'CheckBoxOnlyNew
        '
        Me.CheckBoxOnlyNew.Location = New System.Drawing.Point(13, 314)
        Me.CheckBoxOnlyNew.Name = "CheckBoxOnlyNew"
        Me.CheckBoxOnlyNew.Size = New System.Drawing.Size(104, 56)
        Me.CheckBoxOnlyNew.TabIndex = 4
        Me.CheckBoxOnlyNew.Text = "Copier les Nouveaux Fichiers Seulement"
        Me.CheckBoxOnlyNew.UseVisualStyleBackColor = True
        '
        'CheckBoxSync
        '
        Me.CheckBoxSync.AutoSize = True
        Me.CheckBoxSync.Location = New System.Drawing.Point(13, 291)
        Me.CheckBoxSync.Name = "CheckBoxSync"
        Me.CheckBoxSync.Size = New System.Drawing.Size(87, 17)
        Me.CheckBoxSync.TabIndex = 3
        Me.CheckBoxSync.Text = "Synchroniser"
        Me.CheckBoxSync.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnleverDeLaListeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 26)
        '
        'EnleverDeLaListeToolStripMenuItem
        '
        Me.EnleverDeLaListeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.EnleverDeLaListeToolStripMenuItem.Name = "EnleverDeLaListeToolStripMenuItem"
        Me.EnleverDeLaListeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.EnleverDeLaListeToolStripMenuItem.Text = "Enlever de la liste"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 455)
        Me.Controls.Add(Me.CheckBoxSync)
        Me.Controls.Add(Me.CheckBoxOnlyNew)
        Me.Controls.Add(Me.LabelProgess)
        Me.Controls.Add(Me.CheckBoxANSI)
        Me.Controls.Add(Me.CheckBoxUTF8)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LabelSize)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.ButtonCopier)
        Me.Controls.Add(Me.ButtonChargerM3U)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CopieM3U"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderFichier As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonChargerM3U As System.Windows.Forms.Button
    Friend WithEvents ButtonCopier As System.Windows.Forms.Button
    Friend WithEvents LabelPath As System.Windows.Forms.Label
    Friend WithEvents LabelSize As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeaderSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CheckBoxUTF8 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxANSI As System.Windows.Forms.CheckBox
    Friend WithEvents LabelProgess As System.Windows.Forms.Label
    Friend WithEvents CheckBoxOnlyNew As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSync As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EnleverDeLaListeToolStripMenuItem As ToolStripMenuItem
End Class

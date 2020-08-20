Imports System.IO
Imports System.Text
Imports System.ComponentModel


''' <summary>
''' CopieM3U 1.2.0.16
''' 3 aout 2014 au 09 octobre 2015
''' Work on Windows 7 sp1, windows 8 and Windows 8.1. Need .Net Framework 4.5
''' Copyright Martin Laflamme 2014/2015
''' </summary>
''' Ajouté, Format de liste de lecture *.m3u8
''' Ajouté, la possibilitée d'enlever des fichiers de la liste


Public Class frmMain

    Dim NomLogiciel As String = "CopieM3U " & String.Format("Version {0}", My.Application.Info.Version.ToString) & "  " & System.IO.File.GetLastWriteTime(System.AppDomain.CurrentDomain.BaseDirectory & "copieM3U.exe").ToLongDateString() & "  " & My.Application.Info.Copyright
    Dim Savedir As String
    Dim FileArray(100000) As String
    Dim bw As BackgroundWorker = New BackgroundWorker
    Dim Count As Integer = 0
    Dim OnlyNew As Boolean = False
    Dim Sync As Boolean = False
    Dim TotalinMB As Double

    Public Sub New()
        InitializeComponent()

        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True

        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        ProgressBar1.Maximum = 100

        ButtonCopier.Enabled = False

        Me.Text = NomLogiciel

        CheckBoxANSI.Checked = False
        CheckBoxUTF8.Checked = True
        CheckBoxOnlyNew.Checked = False
        CheckBoxSync.Checked = True
        Sync = True
    End Sub

    Private Sub frmMain_Close(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
        End If
    End Sub

    Private Sub ButtonChargerM3U_Click(sender As Object, e As EventArgs) Handles ButtonChargerM3U.Click
        OpenFileDialog1.Title = "Choisir un fichier .m3u ou .m3u8 (Liste de lecture)"
        OpenFileDialog1.DefaultExt = "m3u"
        OpenFileDialog1.Filter = "Liste de lecture (*.m3u)|*.m3u|Liste de lecture (*.m3u8)|*.m3u8"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName = "" Then Exit Sub

        ListView1.Items.Clear()
        LabelPath.Text = OpenFileDialog1.FileName
        If CheckBoxUTF8.Checked = True Then
            LoadUTF8()
        Else
            LoadANSI()
        End If
    End Sub

    Private Sub LoadUTF8()
        Dim reader As New StreamReader(OpenFileDialog1.FileName, Encoding.UTF8)
        Dim line As String = Nothing
        Dim lines As Integer = 0
        Dim objItem As ListViewItem
        Dim Totalsize As Double = 0
        Dim Totalcount As Integer = 0
        TotalinMB = 0
        While (reader.Peek() <> -1)
            line = reader.ReadLine()
            If Not line.StartsWith("#") Then
                Dim Xtension As String = Path.GetExtension(line) 'determine extension
                If Xtension.ToLower = ".mp3" OrElse Xtension.ToLower = ".m4a" Then
                    If File.Exists(line) Then
                        Dim size As Double = Getsize(line)
                        Dim sizeinMB As Double = (size / 1024) / 1024
                        Totalsize += size
                        Totalcount += 1
                        'Add to listview
                        objItem = ListView1.Items.Add(line)
                        With objItem
                            .SubItems.Add(sizeinMB.ToString("F2"))
                        End With
                    Else
                        MessageBox.Show("Le fichier : " & line & " n'existe pas ou utilise un encodage différent de celui sélectionné", "CopytoM3U", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End While
        TotalinMB = (Totalsize / 1024) / 1024
        If TotalinMB > 1024 Then
            Dim TotalinGB As Double = TotalinMB / 1024
            LabelSize.Text = Totalcount & " fichiers pour " & TotalinGB.ToString("F2") & " GB"
        Else
            LabelSize.Text = Totalcount & " fichiers pour " & TotalinMB.ToString("F2") & " MB"
        End If
        If Totalcount > 0 Then
            ButtonCopier.Enabled = True
        End If
    End Sub

    Private Sub LoadANSI()
        Dim reader As New StreamReader(OpenFileDialog1.FileName, Encoding.Default)
        Dim line As String = Nothing
        Dim lines As Integer = 0
        Dim objItem As ListViewItem
        Dim Totalsize As Double = 0
        Dim Totalcount As Integer = 0
        TotalinMB = 0
        While (reader.Peek() <> -1)
            line = reader.ReadLine()
            If Not line.StartsWith("#") Then
                Dim Xtension As String = Path.GetExtension(line) 'determine extension
                If Xtension.ToLower = ".mp3" OrElse Xtension.ToLower = ".m4a" Then
                    If File.Exists(line) Then
                        Dim size As Double = Getsize(line)
                        Dim sizeinMB As Double = (size / 1024) / 1024
                        Totalsize += size
                        Totalcount += 1
                        'Add to listview
                        objItem = ListView1.Items.Add(line)
                        With objItem
                            .SubItems.Add(sizeinMB.ToString("F2"))
                        End With
                    Else
                        MessageBox.Show("Le fichier : " & line & " n'existe pas ou la liste de lecture utilise un encodage différent de celui sélectionné", "CopytoM3U", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        End While
        TotalinMB = (Totalsize / 1024) / 1024
        If TotalinMB > 1024 Then
            Dim TotalinGB As Double = TotalinMB / 1024
            LabelSize.Text = Totalcount & " fichiers pour " & TotalinGB.ToString("F2") & " GB"
        Else
            LabelSize.Text = Totalcount & " fichiers pour " & TotalinMB.ToString("F2") & " MB"
        End If
        If Totalcount > 0 Then
            ButtonCopier.Enabled = True
        End If
    End Sub

    Private Function Getsize(file As String) As Double
        Dim myFile As New FileInfo(file)
        Return myFile.Length
    End Function

    Private Sub ListView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Process.Start(ListView1.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub ButtonCopier_Click(sender As Object, e As EventArgs) Handles ButtonCopier.Click
        Count = ListView1.Items.Count
        If Count <> 0 Then
            FolderBrowserDialog1.Description = "Choisisser le dossier ou vous voulez copier vos fichiers."
            Dim dlgResult As DialogResult = FolderBrowserDialog1.ShowDialog()
            If dlgResult = Windows.Forms.DialogResult.OK Then
                Savedir = FolderBrowserDialog1.SelectedPath
                ButtonChargerM3U.Enabled = False
                ButtonCopier.Enabled = False
                CheckBoxOnlyNew.Enabled = False
                CheckBoxSync.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                If Sync Then
                    LabelProgess.Text = "Synchronisation des fichiers..."
                Else
                    LabelProgess.Text = "Création de la liste des fichiers à copier..."
                End If
                Dim i As Integer = 0
                For Each lvItem As ListViewItem In ListView1.Items
                    FileArray(i) = lvItem.Text
                    i += 1
                Next
                If bw.IsBusy = False Then
                    bw.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        If bw.CancellationPending Then
            e.Cancel = True
        Else
            ' Perform a time consuming operation and report progress.
            Dim prog As Integer = 0

            If Not Sync Then
                For Each value As String In FileArray
                    If value <> "" Then
                        If Not OnlyNew Then
                            File.Copy(value, Savedir & "\" & Path.GetFileName(value), True)
                            prog += 1
                            bw.ReportProgress(prog)
                        Else
                            If Not File.Exists(Savedir & "\" & Path.GetFileName(value)) Then
                                File.Copy(value, Savedir & "\" & Path.GetFileName(value), True)
                                prog += 1
                                bw.ReportProgress(prog)
                            Else
                                prog += 1
                                bw.ReportProgress(prog)
                                Continue For
                            End If
                        End If
                    End If
                Next
            Else
                ' Sync procedure
                ' delete removed files
                Dim DeleteFileArray(100000) As String
                Dim i As Integer = 0
                For Each files As String In Directory.GetFiles(Savedir & "\")
                    If Not isfileinm3u(files) Then
                        DeleteFileArray(i) = files
                        i += 1
                        bw.ReportProgress(prog)
                    End If
                Next
                For Each filetodelete As String In DeleteFileArray
                    If filetodelete <> "" Then
                        DeleteFile(filetodelete)
                        bw.ReportProgress(prog)
                    End If
                Next
                Array.Clear(DeleteFileArray, 0, DeleteFileArray.Length)

                'Copie new file
                For Each value As String In FileArray
                    If value <> "" Then
                        If Not File.Exists(Savedir & "\" & Path.GetFileName(value)) Then
                            File.Copy(value, Savedir & "\" & Path.GetFileName(value), True)
                            prog += 1
                            bw.ReportProgress(prog)
                        Else
                            prog += 1
                            bw.ReportProgress(prog)
                            Continue For
                        End If
                    End If
                Next

            End If
        End If
    End Sub

    Public Function isfileinm3u(file As String) As Boolean
        Dim found As Boolean = False
        For Each m3ufile As String In FileArray
            Dim m3ufilename As String = Path.GetFileName(m3ufile)
            Dim filename As String = Path.GetFileName(file)
            If filename = m3ufilename Then
                found = True
            End If
        Next
        If found Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DeleteFile(ByRef sPath As String) As Integer
        Dim RetVal As Integer = 0
        Try
            My.Computer.FileSystem.DeleteFile(sPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
        Catch ex As FileNotFoundException
            MessageBox.Show("Erreur de synchronisation: Le fichier à effacer n'a pas été trouvé.", "CopieM3U", MessageBoxButtons.OK, MessageBoxIcon.Warning) 'error : file not found
            RetVal = -1
        Catch ex As ArgumentNullException
            'MessageBox.Show("Error : Textbox empty") 'error : empty textbox
            RetVal = -1
        Catch ex As PathTooLongException
            'MessageBox.Show("The path exceeds the system-defined maximum length")
            RetVal = -1
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.ToString, "CopieM3U") 'else display any possible error
            RetVal = -1
        Finally
        End Try
        Return RetVal
    End Function

    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        If Sync Then
            If e.ProgressPercentage = 0 Then
                LabelProgess.Text = "Synchronisation des fichiers..."
            Else
                ProgressBar1.Value = e.ProgressPercentage / Count * 100
                LabelProgess.Text = "Copie des nouveaux fichiers... Progrès = " & e.ProgressPercentage.ToString & " / " & Count.ToString & " Fichiers"
            End If
        Else
            ProgressBar1.Value = e.ProgressPercentage / Count * 100
            LabelProgess.Text = "Copie des nouveaux fichiers... Progrès = " & e.ProgressPercentage.ToString & " / " & Count.ToString & " Fichiers"
        End If
    End Sub

    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled Then
            MessageBox.Show("Job Cancellée!", "CopieM3U", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonChargerM3U.Enabled = True
            ButtonCopier.Enabled = True
            CheckBoxOnlyNew.Enabled = True
            CheckBoxSync.Enabled = True
            ProgressBar1.Value = 0
            LabelProgess.Text = ""
            Array.Clear(FileArray, 0, FileArray.Length)
            Me.Cursor = Cursors.Default
        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show("Erreur: " & e.Error.Message, "CopieM3U", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ButtonChargerM3U.Enabled = True
            ButtonCopier.Enabled = True
            CheckBoxOnlyNew.Enabled = True
            CheckBoxSync.Enabled = True
            ProgressBar1.Value = 0
            LabelProgess.Text = ""
            Array.Clear(FileArray, 0, FileArray.Length)
            Me.Cursor = Cursors.Default
        Else
            If Sync Then
                MessageBox.Show("Synchronisation terminée!", "CopieM3U", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Tout vos fichiers ont été copiés", "CopieM3U", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ButtonChargerM3U.Enabled = True
            ButtonCopier.Enabled = True
            CheckBoxOnlyNew.Enabled = True
            CheckBoxSync.Enabled = True
            ProgressBar1.Value = 0
            LabelProgess.Text = ""
            Array.Clear(FileArray, 0, FileArray.Length)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CheckBoxANSI_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxANSI.CheckedChanged
        If CheckBoxANSI.Checked Then
            CheckBoxUTF8.Checked = False
        Else
            CheckBoxUTF8.Checked = True
        End If
    End Sub

    Private Sub CheckBoxUTF8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxUTF8.CheckedChanged
        If CheckBoxUTF8.Checked Then
            CheckBoxANSI.Checked = False
        Else
            CheckBoxANSI.Checked = True
        End If
    End Sub

    Private Sub CheckBoxOnlyNew_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOnlyNew.CheckedChanged
        If CheckBoxOnlyNew.Checked Then
            CheckBoxSync.Checked = False
            OnlyNew = True
        Else
            OnlyNew = False
        End If
    End Sub

    Private Sub CheckBoxSync_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSync.CheckedChanged
        If CheckBoxSync.Checked Then
            CheckBoxOnlyNew.Checked = False
            Sync = True
        Else
            Sync = False
        End If
    End Sub

    Private Sub EnleverDeLaListeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnleverDeLaListeToolStripMenuItem.Click
        Dim totalsizetoremove As Double
        For Each lvItem As ListViewItem In ListView1.Items
            If lvItem.Selected Then
                Dim filessize As String = lvItem.SubItems.Item(1).Text
                totalsizetoremove += Convert.ToDouble(filessize)
                ListView1.Items.Remove(lvItem)
            End If
        Next
        Count = ListView1.Items.Count
        Dim newtotal As Double = TotalinMB - totalsizetoremove
        If newtotal > 1024 Then
            Dim newtotalgb As Double = newtotal / 1024
            LabelSize.Text = Count.ToString & " fichiers pour " & newtotalgb.ToString("F2") & " GB"
        Else
            LabelSize.Text = Count.ToString & " fichiers pour " & newtotal.ToString("F2") & " MB"
        End If
        TotalinMB = newtotal
        If Count = 0 Then
            ButtonCopier.Enabled = False
            LabelSize.Text = Count.ToString & " fichiers pour " & 0 & " MB"
            TotalinMB = 0
        End If
    End Sub
End Class

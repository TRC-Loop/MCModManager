Imports System.IO
Public Class Form1
    Private Sub timelblrefreh_Tick(sender As Object, e As EventArgs) Handles timelblrefreh.Tick
        ToolStripLabel2.Text = "Time: " + DateTime.Now.ToString("g")
    End Sub

    Private Sub modrefresher_Tick(sender As Object, e As EventArgs) Handles modrefresher.Tick
        Dim path As String = Environ("USERPROFILE") + "\AppData\Roaming"
        If System.IO.Directory.Exists(path + "\.minecraft") Then
            If System.IO.Directory.Exists(path + "\.minecraft\mods") Then
                Dim di As New IO.DirectoryInfo(path + "\.minecraft\mods")
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo
                ListBox1.Items.Clear()
                ListBox1.BeginUpdate()
                Dim i As Int64 = 0
                'list the names of all files in the specified directory
                For Each dra In diar1
                    i += 1
                    ListBox1.Items.Add(dra)
                Next
                ListBox1.EndUpdate()
                ToolStripLabel1.Text = "Mods: " + i.ToString()
            Else
                System.IO.Directory.CreateDirectory(path + "\.minecraft\mods")
            End If
        Else
            MsgBox("Error: Minecraft Not installed")
        End If


        'list the names of all files in the specified directory

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Process.Start(Environ("USERPROFILE") + "\AppData\Roaming\.minecraft\mods")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        OpenFileDialog1.Multiselect = True '// Allow Multiple File Selections.
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim pth As String = Environ("USERPROFILE") + "\AppData\Roaming"
            For Each selFile As String In OpenFileDialog1.FileNames


                Dim sourcepath As String = selFile
                Dim DestPath As String = Environ("USERPROFILE") + "\AppData\Roaming\.minecraft\mods\"
                Dim fn = Path.GetFileName(selFile)
                My.Computer.FileSystem.CopyFile(
                selFile,
                DestPath + fn, overwrite:=True)
            Next

            Dim di As New IO.DirectoryInfo(pth + "\.minecraft\mods")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo
            ListBox1.Items.Clear()
            ListBox1.BeginUpdate()
            Dim i As Int64 = 0
            'list the names of all files in the specified directory
            For Each dra In diar1
                i += 1
                ListBox1.Items.Add(dra)
            Next
            ListBox1.EndUpdate()
            ToolStripLabel1.Text = "Mods: " + i.ToString()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = Environ("USERPROFILE") + "\Downloads"
        Dim path As String = Environ("USERPROFILE") + "\AppData\Roaming"
        If System.IO.Directory.Exists(path + "\.minecraft") Then
            If System.IO.Directory.Exists(path + "\.minecraft\mods") Then
                Dim di As New IO.DirectoryInfo(path + "\.minecraft\mods")
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo
                ListBox1.Items.Clear()
                ListBox1.BeginUpdate()
                Dim i As Int64 = 0
                'list the names of all files in the specified directory
                For Each dra In diar1
                    i += 1
                    ListBox1.Items.Add(dra)
                Next
                ListBox1.EndUpdate()
                ToolStripLabel1.Text = "Mods: " + i.ToString()
            Else
                System.IO.Directory.CreateDirectory(path + "\.minecraft\mods")
            End If
        Else
            MsgBox("Error: Minecraft Not installed")
        End If
        ToolStripLabel2.Text = "Time: " + DateTime.Now.ToString("g")
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ListBox1.SelectedIndex = -1 Then
            MsgBox("No Mod selected.")
            Return
        Else
            Dim fl = Environ("USERPROFILE") + "\AppData\Roaming\.minecraft\mods\" + ListBox1.SelectedItem.ToString()
            My.Computer.FileSystem.DeleteFile(
            fl,
            FileIO.UIOption.AllDialogs,
            FileIO.RecycleOption.SendToRecycleBin,
            FileIO.UICancelOption.ThrowException)

            Dim path As String = Environ("USERPROFILE") + "\AppData\Roaming"
            If System.IO.Directory.Exists(path + "\.minecraft") Then
                If System.IO.Directory.Exists(path + "\.minecraft\mods") Then
                    Dim di As New IO.DirectoryInfo(path + "\.minecraft\mods")
                    Dim diar1 As IO.FileInfo() = di.GetFiles()
                    Dim dra As IO.FileInfo
                    ListBox1.Items.Clear()
                    ListBox1.BeginUpdate()
                    Dim i As Int64 = 0
                    'list the names of all files in the specified directory
                    For Each dra In diar1
                        i += 1
                        ListBox1.Items.Add(dra)
                    Next
                    ListBox1.EndUpdate()
                    ToolStripLabel1.Text = "Mods: " + i.ToString()
                Else
                    System.IO.Directory.CreateDirectory(path + "\.minecraft\mods")
                End If
            Else
                MsgBox("Error: Minecraft Not installed")
            End If


            'list the names of all files in the specified directory
        End If

    End Sub
End Class

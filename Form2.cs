//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;

//namespace RemoteDeployManager
//{
//    public partial class Form2 : Form
//    {
//        private string targetPath;
//        private List<string> targetFiles = new List<string>();
//        private List<(string destinationPath, List<string> destinationFiles)> destinationFolders = new List<(string, List<string>)>();

//        public Form2()
//        {
//            InitializeComponent();
//        }

//        private void LoadBtn_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
//                if (!File.Exists(configPath))
//                {
//                    MessageBox.Show("Config file not found.");
//                    return;
//                }

//                var doc = XDocument.Load(configPath);

//                var target = doc.Descendants("Target_folder").FirstOrDefault();
//                if (target == null)
//                {
//                    MessageBox.Show("Target_folder not found in config.");
//                    return;
//                }

//                targetPath = target.Element("TargetPath")?.Value.Trim();
//                if (string.IsNullOrEmpty(targetPath) || !Directory.Exists(targetPath))
//                {
//                    MessageBox.Show("TargetPath invalid or not found.");
//                    return;
//                }

//                targetFiles = target.Element("TargetFiles")?.Value
//                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
//                    .Select(f => f.Trim())
//                    .ToList();

//                if (targetFiles == null || targetFiles.Count == 0)
//                {
//                    MessageBox.Show("No target files specified.");
//                    return;
//                }

//                var destinationNodes = doc.Descendants("Destination_folder").ToList();
//                foreach (var dest in destinationNodes)
//                {
//                    var path = dest.Element("DestinationPath")?.Value.Trim();
//                    if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
//                    {
//                        MessageBox.Show($"DestinationPath invalid or not found: {path}");
//                        continue;
//                    }

//                    var files = dest.Element("DestinationFiles")?.Value
//                        .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
//                        .Select(f => f.Trim())
//                        .ToList();

//                    destinationFolders.Add((path, files));
//                }

//                if (destinationFolders.Count == 0)
//                {
//                    MessageBox.Show("No valid destination folders found.");
//                }
//                else
//                {
//                    MessageBox.Show("Load successful.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading config: {ex.Message}");
//            }
//        }

//        private async void TransferBtn_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(targetPath) || targetFiles.Count == 0 || destinationFolders.Count == 0)
//            {
//                MessageBox.Show("Please load config first.");
//                return;
//            }

//            var progressForm = new ProgressForm();
//            this.Hide();
//            progressForm.Show();

//            await Task.Run(() =>
//            {
//                try
//                {
//                    foreach (var (destinationPath, files) in destinationFolders)
//                    {
//                        foreach (var fileName in files)
//                        {
//                            if (!targetFiles.Contains(fileName))
//                                continue; // Only copy files listed in TargetFiles

//                            var sourceFile = Path.Combine(targetPath, fileName);
//                            var destFile = Path.Combine(destinationPath, fileName);

//                            if (File.Exists(sourceFile))
//                            {
//                                CopyFileWithProgress(sourceFile, destFile, progressForm);
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error during transfer: {ex.Message}");
//                }
//            });

//            progressForm.TransferCompleted();
//            this.Close();
//        }

//        private void CopyFileWithProgress(string sourcePath, string destPath, ProgressForm progressForm)
//        {
//            const int bufferSize = 1024 * 1024; // 1MB buffer
//            byte[] buffer = new byte[bufferSize];
//            long totalBytes = new FileInfo(sourcePath).Length;
//            long totalRead = 0;

//            using (var source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
//            using (var dest = new FileStream(destPath, FileMode.Create, FileAccess.Write))
//            {
//                int bytesRead;
//                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
//                {
//                    dest.Write(buffer, 0, bytesRead);
//                    totalRead += bytesRead;
//                    int progressPercent = (int)((totalRead * 100) / totalBytes);
//                    progressForm.UpdateProgress(progressPercent);
//                }
//            }
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;

//namespace RemoteDeployManager
//{
//    public partial class Form2 : Form
//    {
//        private string targetPath;
//        private List<string> targetFiles = new List<string>();
//        private List<(string destinationPath, List<string> destinationFiles)> destinationFolders = new List<(string, List<string>)>();

//        public Form2()
//        {
//            InitializeComponent();
//        }

//        private void LoadBtn_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
//                if (!File.Exists(configPath))
//                {
//                    MessageBox.Show("Config file not found.");
//                    return;
//                }

//                var doc = XDocument.Load(configPath);

//                var target = doc.Descendants("Target_folder").FirstOrDefault();
//                if (target == null)
//                {
//                    MessageBox.Show("Target_folder not found in config.");
//                    return;
//                }

//                targetPath = target.Element("TargetPath")?.Value.Trim();
//                if (string.IsNullOrEmpty(targetPath) || !Directory.Exists(targetPath))
//                {
//                    MessageBox.Show("TargetPath invalid or not found.");
//                    return;
//                }

//                targetFiles = target.Element("TargetFiles")?.Value
//                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
//                    .Select(f => f.Trim())
//                    .ToList();

//                if (targetFiles == null || targetFiles.Count == 0)
//                {
//                    MessageBox.Show("No target files specified.");
//                    return;
//                }

//                var destinationNodes = doc.Descendants("Destination_folder").ToList();
//                foreach (var dest in destinationNodes)
//                {
//                    var path = dest.Element("DestinationPath")?.Value.Trim();
//                    if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
//                    {
//                        MessageBox.Show($"DestinationPath invalid or not found: {path}");
//                        continue;
//                    }

//                    var files = dest.Element("DestinationFiles")?.Value
//                        .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
//                        .Select(f => f.Trim())
//                        .ToList();

//                    destinationFolders.Add((path, files));
//                }

//                if (destinationFolders.Count == 0)
//                {
//                    MessageBox.Show("No valid destination folders found.");
//                }
//                else
//                {
//                    MessageBox.Show("Load successful.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading config: {ex.Message}");
//            }
//        }

//        private async void TransferBtn_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(targetPath) || targetFiles.Count == 0 || destinationFolders.Count == 0)
//            {
//                MessageBox.Show("Please load config first.");
//                return;
//            }

//            var progressForm = new ProgressForm();
//            this.Hide();
//            progressForm.Show();

//            await Task.Run(() =>
//            {
//                try
//                {
//                    foreach (var (destinationPath, files) in destinationFolders)
//                    {
//                        BackupExistingFiles(destinationPath);
//                        foreach (var fileName in files)
//                        {
//                            if (!targetFiles.Contains(fileName))
//                                continue; // Only copy files listed in TargetFiles

//                            var sourceFile = Path.Combine(targetPath, fileName);
//                            var destFile = Path.Combine(destinationPath, fileName);

//                            if (File.Exists(sourceFile))
//                            {
//                                CopyFileWithProgress(sourceFile, destFile, progressForm);
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error during transfer: {ex.Message}");
//                }
//            });

//            progressForm.TransferCompleted();
//            this.Close();
//        }


//        private void BackupExistingFiles(string targetFolder)
//        {
//            if (!Directory.Exists(targetFolder))
//                return;

//            string backupFolder = Path.Combine(targetFolder, "Backup");
//            Directory.CreateDirectory(backupFolder);

//            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
//            string backupZip = Path.Combine(backupFolder, $"backup_{timestamp}.zip");

//            using (ZipArchive zip = ZipFile.Open(backupZip, ZipArchiveMode.Create))
//            {
//                foreach (string file in Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories))
//                {
//                    if (file.StartsWith(backupFolder, StringComparison.OrdinalIgnoreCase))
//                        continue;

//                    string relativePath = GetRelativePath(targetFolder, file);
//                    zip.CreateEntryFromFile(file, relativePath);
//                }
//            }
//        }


//        // Helper function to compute relative paths
//        private string GetRelativePath(string basePath, string fullPath)
//        {
//            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
//            Uri fileUri = new Uri(fullPath);
//            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fileUri).ToString().Replace('/', '\\'));
//        }


//        private void CopyFileWithProgress(string sourcePath, string destPath, ProgressForm progressForm)
//        {
//            const int bufferSize = 1024 * 1024; // 1MB buffer
//            byte[] buffer = new byte[bufferSize];
//            long totalBytes = new FileInfo(sourcePath).Length;
//            long totalRead = 0;

//            using (var source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
//            using (var dest = new FileStream(destPath, FileMode.Create, FileAccess.Write))
//            {
//                int bytesRead;
//                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
//                {
//                    dest.Write(buffer, 0, bytesRead);
//                    totalRead += bytesRead;
//                    int progressPercent = (int)((totalRead * 100) / totalBytes);
//                    progressForm.UpdateProgress(progressPercent);
//                }
//            }
//        }
//    }
//}







using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RemoteDeployManager
{
    public partial class Form2 : Form
    {
        private string targetPath;
        private List<string> targetFiles = new List<string>();
        private List<(string destinationPath, List<string> destinationFiles)> destinationFolders = new List<(string, List<string>)>();

        public Form2()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
                if (!File.Exists(configPath))
                {
                    MessageBox.Show("Config file not found.");
                    return;
                }

                var doc = XDocument.Load(configPath);

                var target = doc.Descendants("Target_folder").FirstOrDefault();
                if (target == null)
                {
                    MessageBox.Show("Target_folder not found in config.");
                    return;
                }

                targetPath = target.Element("TargetPath")?.Value.Trim();
                if (string.IsNullOrEmpty(targetPath) || !Directory.Exists(targetPath))
                {
                    MessageBox.Show("TargetPath invalid or not found.");
                    return;
                }

                targetFiles = target.Element("TargetFiles")?.Value
                    .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.Trim())
                    .ToList();

                if (targetFiles == null || targetFiles.Count == 0)
                {
                    MessageBox.Show("No target files specified.");
                    return;
                }

                var destinationNodes = doc.Descendants("Destination_folder").ToList();
                foreach (var dest in destinationNodes)
                {
                    var path = dest.Element("DestinationPath")?.Value.Trim();
                    if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                    {
                        MessageBox.Show($"DestinationPath invalid or not found: {path}");
                        continue;
                    }

                    var files = dest.Element("DestinationFiles")?.Value
                        .Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(f => f.Trim())
                        .ToList();

                    destinationFolders.Add((path, files));
                }

                if (destinationFolders.Count == 0)
                {
                    MessageBox.Show("No valid destination folders found.");
                }
                else
                {
                    MessageBox.Show("Load successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}");
            }
        }

        private async void TransferBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(targetPath) || targetFiles.Count == 0 || destinationFolders.Count == 0)
            {
                MessageBox.Show("Please load config first.");
                return;
            }

            var progressForm = new ProgressForm();
            this.Hide();
            progressForm.Show();

            await Task.Run(() =>
            {
                try
                {
                    foreach (var (destinationPath, files) in destinationFolders)
                    {
                        BackupExistingFiles(destinationPath);
                        foreach (var fileName in files)
                        {
                            if (!targetFiles.Contains(fileName))
                                continue; // Only copy files listed in TargetFiles

                            var sourceFile = Path.Combine(targetPath, fileName);
                            var destFile = Path.Combine(destinationPath, fileName);

                            if (File.Exists(sourceFile))
                            {
                                CopyFileWithProgress(sourceFile, destFile, progressForm);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during transfer: {ex.Message}");
                }
            });

            progressForm.TransferCompleted();
            ExecuteCmdInDestinationFolders();
            this.Close();
        }


        private void BackupExistingFiles(string targetFolder)
        {
            if (!Directory.Exists(targetFolder))
                return;

            string backupFolder = Path.Combine(targetFolder, "Backup");
            Directory.CreateDirectory(backupFolder);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupZip = Path.Combine(backupFolder, $"backup_{timestamp}.zip");

            using (ZipArchive zip = ZipFile.Open(backupZip, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories))
                {
                    if (file.StartsWith(backupFolder, StringComparison.OrdinalIgnoreCase))
                        continue;

                    string relativePath = GetRelativePath(targetFolder, file);
                    zip.CreateEntryFromFile(file, relativePath);
                }
            }
        }


        // Helper function to compute relative paths
        private string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            Uri fileUri = new Uri(fullPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fileUri).ToString().Replace('/', '\\'));
        }


        private void CopyFileWithProgress(string sourcePath, string destPath, ProgressForm progressForm)
        {
            const int bufferSize = 1024 * 1024; // 1MB buffer
            byte[] buffer = new byte[bufferSize];
            long totalBytes = new FileInfo(sourcePath).Length;
            long totalRead = 0;

            using (var source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            using (var dest = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dest.Write(buffer, 0, bytesRead);
                    totalRead += bytesRead;
                    int progressPercent = (int)((totalRead * 100) / totalBytes);
                    progressForm.UpdateProgress(progressPercent);
                }
            }
        }

        private void ExecuteCmdInDestinationFolders()
        {
            foreach (var folder in destinationFolders)
            {
                string destPath = folder.Item1;
                string cmdPath = Path.Combine(destPath, "run.cmd");

                if (File.Exists(cmdPath))
                {
                    try
                    {
                        var psi = new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/c \"{cmdPath}\"",
                            // WorkingDirectory removed due to UNC incompatibility
                            CreateNoWindow = true,
                            UseShellExecute = false
                        };

                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to run cmd in {destPath}: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"run.cmd not found in {destPath}");
                }
            }
        }


    }
}
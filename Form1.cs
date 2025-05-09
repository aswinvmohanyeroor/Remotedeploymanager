using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RemoteDeployManager
{
    public partial class Form1 : Form
    {
        private string selectedFolder;
        private Dictionary<string, string> serverPaths = new Dictionary<string, string>
        {
            { "Server1", @"C:\TargetFolder" },
            { "Server2", @"D:\Server2\TargetFolder" },
            { "Server3", @"\\192.168.111.129\Test" }
        };

        public Form1()
        {
            InitializeComponent();
            treeView1.AfterCheck += TreeView1_AfterCheck; // Attach event handler
        }

        private void SelectFolderBTN_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.ShowNewFolderButton = true;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = folderBrowserDialog.SelectedPath;
                    folderNametxtBox.Text = Path.GetFullPath(selectedFolder);
                    LoadFilesAndFolders(selectedFolder);
                }
            }
        }

        private void LoadFilesAndFolders(string folderPath)
        {
            treeView1.Nodes.Clear();
            treeView1.CheckBoxes = true;

            TreeNode rootNode = new TreeNode(Path.GetFileName(folderPath)) { Tag = folderPath };
            treeView1.Nodes.Add(rootNode);

            PopulateTreeView(folderPath, rootNode);
            rootNode.Expand();
        }

        private void PopulateTreeView(string folderPath, TreeNode parentNode)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(folderPath))
                {
                    TreeNode folderNode = new TreeNode(Path.GetFileName(directory)) { Tag = directory };
                    parentNode.Nodes.Add(folderNode);
                    PopulateTreeView(directory, folderNode);
                }

                foreach (string file in Directory.GetFiles(folderPath))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file)) { Tag = file };
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading files: " + ex.Message);
            }
        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
                UpdateParentCheckState(e.Node);
            }
        }

        private void CheckAllChildNodes(TreeNode parentNode, bool isChecked)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                node.Checked = isChecked;
                CheckAllChildNodes(node, isChecked);
            }
        }

        private void UpdateParentCheckState(TreeNode node)
        {
            if (node.Parent != null)
            {
                bool allChecked = node.Parent.Nodes.Cast<TreeNode>().All(n => n.Checked);
                bool anyChecked = node.Parent.Nodes.Cast<TreeNode>().Any(n => n.Checked);

                node.Parent.Checked = allChecked;
                UpdateParentCheckState(node.Parent);
            }
        }

        private List<string> GetCheckedItems(TreeNodeCollection nodes)
        {
            List<string> selectedItems = new List<string>();

            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    // Add only top-level selected item and exclude its child files/folders
                    if (node.Parent == null || !node.Parent.Checked)
                    {
                        selectedItems.Add(node.Tag.ToString());
                    }
                }
                selectedItems.AddRange(GetCheckedItems(node.Nodes)); // Recursive call
            }

            return selectedItems;
        }


        private void BackupBTN_Click(object sender, EventArgs e)
        {
            // Ensure at least one server is selected
            if (ServercheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one server before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure at least one file/folder is selected from the TreeView
            List<string> selectedItems = GetCheckedItems(treeView1.Nodes);
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one file or folder from the TreeView.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a copy of the checked servers to avoid modification issues
            List<string> selectedServers = ServercheckedListBox.CheckedItems.Cast<string>().ToList();

            foreach (string serverName in selectedServers)
            {
                if (serverPaths.ContainsKey(serverName))
                {
                    string targetFolder = serverPaths[serverName];

                    // Create a backup of the existing files in the server folder
                    BackupExistingFiles(targetFolder);

                    // Copy selected files and folders to the target folder
                    CopySelectedFiles(selectedItems, targetFolder);
                }
                else
                {
                    MessageBox.Show($"No path configured for {serverName}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Backup and file transfer completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void BackupExistingFiles(string targetFolder)
        {
            if (!Directory.Exists(targetFolder))
                return;

            string backupFolder = Path.Combine(targetFolder, "Backup");

            // Ensure the backup folder exists
            Directory.CreateDirectory(backupFolder);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupZip = Path.Combine(backupFolder, $"backup_{timestamp}.zip");

            using (ZipArchive zip = ZipFile.Open(backupZip, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories))
                {
                    // Skip files inside the Backup folder
                    if (file.StartsWith(backupFolder, StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Compute relative path for proper folder structure inside ZIP
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


        private void CopySelectedFiles(List<string> selectedItems, string targetFolder)
        {
            Directory.CreateDirectory(targetFolder);

            foreach (string item in selectedItems)
            {
                if (Directory.Exists(item))
                {
                    // If item is a folder, copy entire folder
                    string destinationFolder = Path.Combine(targetFolder, Path.GetFileName(item));
                    CopyDirectory(item, destinationFolder);
                }
                else if (File.Exists(item))
                {
                    // Compute the relative path manually
                    string relativePath = item.Substring(selectedFolder.Length).TrimStart('\\', '/');
                    string destinationPath = Path.Combine(targetFolder, relativePath);

                    // Ensure subdirectory exists before copying
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    File.Copy(item, destinationPath, true);
                }
            }
        }

        // Helper function to copy entire directory
        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (string file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                string relativePath = file.Substring(sourceDir.Length).TrimStart('\\', '/');
                string destinationPath = Path.Combine(destinationDir, relativePath);

                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                File.Copy(file, destinationPath, true);
            }
        }

        private void resetBTN_Click(object sender, EventArgs e)
        {
            folderNametxtBox.Clear();
            treeView1.Nodes.Clear();
            ServercheckedListBox.SelectedItems.Clear();

            MessageBox.Show("Reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}

using System;
using System.Windows.Forms;

namespace RemoteDeployManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ServercheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BackupBTN = new System.Windows.Forms.Button();
            this.resetBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderNametxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(232)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1987, 238);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(633, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(613, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote Deploy Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.ServercheckedListBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BackupBTN);
            this.panel2.Controls.Add(this.resetBTN);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.folderNametxtBox);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 238);
            this.panel2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1987, 976);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 9.900001F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(978, 771);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(835, 41);
            this.label6.TabIndex = 16;
            this.label6.Text = "if you don\'t have, it will automatically create the folder.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(978, 718);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(842, 41);
            this.label5.TabIndex = 15;
            this.label5.Text = "Try with Server 1: Server 1 location is C:\\TargetFolder. ";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Roboto", 8F);
            this.treeView1.Location = new System.Drawing.Point(32, 341);
            this.treeView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1489, 290);
            this.treeView1.TabIndex = 14;
            // 
            // ServercheckedListBox
            // 
            this.ServercheckedListBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.ServercheckedListBox.FormattingEnabled = true;
            this.ServercheckedListBox.Items.AddRange(new object[] {
            "Server1",
            "Server2",
            "Server3"});
            this.ServercheckedListBox.Location = new System.Drawing.Point(1579, 341);
            this.ServercheckedListBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ServercheckedListBox.Name = "ServercheckedListBox";
            this.ServercheckedListBox.Size = new System.Drawing.Size(311, 269);
            this.ServercheckedListBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1568, 284);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 48);
            this.label4.TabIndex = 12;
            this.label4.Text = "Server\'s";
            // 
            // BackupBTN
            // 
            this.BackupBTN.BackColor = System.Drawing.Color.Green;
            this.BackupBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackupBTN.FlatAppearance.BorderSize = 0;
            this.BackupBTN.Font = new System.Drawing.Font("Roboto", 9.900001F);
            this.BackupBTN.ForeColor = System.Drawing.Color.White;
            this.BackupBTN.Location = new System.Drawing.Point(45, 718);
            this.BackupBTN.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BackupBTN.Name = "BackupBTN";
            this.BackupBTN.Size = new System.Drawing.Size(434, 145);
            this.BackupBTN.TabIndex = 10;
            this.BackupBTN.Text = "Backup and Deploy";
            this.BackupBTN.UseVisualStyleBackColor = false;
            this.BackupBTN.Click += new System.EventHandler(this.BackupBTN_Click);
            // 
            // resetBTN
            // 
            this.resetBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resetBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetBTN.FlatAppearance.BorderSize = 0;
            this.resetBTN.Font = new System.Drawing.Font("Roboto", 9.900001F);
            this.resetBTN.ForeColor = System.Drawing.Color.White;
            this.resetBTN.Location = new System.Drawing.Point(541, 718);
            this.resetBTN.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.resetBTN.Name = "resetBTN";
            this.resetBTN.Size = new System.Drawing.Size(317, 145);
            this.resetBTN.TabIndex = 6;
            this.resetBTN.Text = "Reset";
            this.resetBTN.UseVisualStyleBackColor = false;
            this.resetBTN.Click += new System.EventHandler(this.resetBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 284);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 48);
            this.label3.TabIndex = 4;
            this.label3.Text = "Select files";
            // 
            // folderNametxtBox
            // 
            this.folderNametxtBox.Enabled = false;
            this.folderNametxtBox.Font = new System.Drawing.Font("Roboto", 12F);
            this.folderNametxtBox.Location = new System.Drawing.Point(32, 91);
            this.folderNametxtBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.folderNametxtBox.Multiline = true;
            this.folderNametxtBox.Name = "folderNametxtBox";
            this.folderNametxtBox.Size = new System.Drawing.Size(1489, 140);
            this.folderNametxtBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Roboto", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1579, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 145);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SelectFolderBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Your Folder";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1987, 1214);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemoteDeployManager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox folderNametxtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button resetBTN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BackupBTN;
        private System.Windows.Forms.CheckedListBox ServercheckedListBox;
        private System.Windows.Forms.TreeView treeView1;
        private Label label5;
        private Label label6;
    }
}


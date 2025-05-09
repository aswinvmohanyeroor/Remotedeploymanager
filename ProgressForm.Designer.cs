namespace RemoteDeployManager
{
    partial class ProgressForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(50, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 50);
            this.progressBar1.TabIndex = 0;
            // 
            // ProgressForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 150);
            this.Controls.Add(this.progressBar1);
            this.Name = "ProgressForm";
            this.Text = "Transferring Files...";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

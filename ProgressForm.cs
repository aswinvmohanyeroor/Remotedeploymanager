using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RemoteDeployManager
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int percent)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = percent));
            }
            else
            {
                progressBar1.Value = percent;
            }
        }

        public void TransferCompleted()
        {

            MessageBox.Show("Transfer completed.");
            this.Invoke(new Action(() => this.Close()));
        }
    }
}

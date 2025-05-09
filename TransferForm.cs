using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 

namespace RemoteDeployManager
{
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false; // disable closing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "Transferring Files...";
            Label lbl = new Label();
            lbl.Text = "Please wait, transferring files...";
            lbl.Dock = DockStyle.Fill;
            lbl.Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(lbl);
            this.Size = new System.Drawing.Size(500, 200);
        }
    }
}

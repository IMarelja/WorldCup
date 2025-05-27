using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCup.Utilities;

namespace WorldCup
{
    public partial class ConfirmBox : Form
    {
        public ConfirmBox()
        {
            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void ConfirmBox_Load(object sender, EventArgs e)
        {
            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public static DialogResult Show()
        {
            using (var box = new ConfirmBox())
            {
                return box.ShowDialog();
            }
        }
    }
}

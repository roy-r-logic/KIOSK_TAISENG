using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSKApp
{
    public partial class MessageForm : Form
    {
        public MessageForm(string message)
        {
            InitializeComponent();

            lblMsg.Text = message;
        }

        private void MessageForm_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void LblMsg_Click(object sender, EventArgs e)
        {

        }
    }
}

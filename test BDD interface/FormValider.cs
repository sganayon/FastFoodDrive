using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_BDD_interface
{
    public partial class FormValider : Form
    {
        string Message;
        public FormValider(string msg)
        {
            InitializeComponent();
            Message = msg;
        }

        private void FormValider_Load(object sender, EventArgs e)
        {
            label1.Text = Message;
        }
    }
}

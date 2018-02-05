using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test_BDD_interface
{
    public partial class Form2 : Form
    {
        public Form2()
        {//affiche le menu burgers
            InitializeComponent();
        }

        private void bURGERSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bURGERSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basemacdoDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        { 
            string req = "select * from BURGERS";
            SqlConnection connection = BDD.open();
            BDD.gridview(req, connection, bURGERSDataGridView);
            connection.Close();
        }
    }
}

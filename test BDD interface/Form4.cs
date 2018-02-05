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
    public partial class Form4 : Form
    {
        public Form4()
        {//affiche le menu de desserts
            InitializeComponent();
        }

        private void dESSERTSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dESSERTSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basemacdoDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string req = "select * from DESSERTS";
            SqlConnection connection = BDD.open();
            BDD.gridview(req, connection, dESSERTSDataGridView);
            connection.Close();
        }
    }
}

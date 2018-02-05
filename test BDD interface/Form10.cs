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
    public partial class Form10 : Form
    {
        public Form10()
        {//affiche les abonnes
            InitializeComponent();
        }

        private void aDRESSESBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aDRESSESBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basemacdoDataSet);

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string req = "select * from ADRESSES";
            SqlConnection connection = BDD.open();
            BDD.gridview(req, connection, aDRESSESDataGridView);
            connection.Close();
        }
    }
}

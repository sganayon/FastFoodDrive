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
    public partial class Form3 : Form
    {
        public Form3()
        {//affiche le menu salades
            InitializeComponent();
        }

        private void sALADESBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sALADESBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basemacdoDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string req = "select * from SALADES";
            SqlConnection connection = BDD.open();
            BDD.gridview(req, connection, sALADESDataGridView);
            connection.Close();
        }
    }
}

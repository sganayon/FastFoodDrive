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
using System.Threading;


namespace test_BDD_interface
{//suppression des nouveautes
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        string table;

        private void button1_Click(object sender, EventArgs e)
        {
            string req;
            SqlConnection connection = BDD.open();

            //supprime les lignes ou L'id est superieur a 3 donc les nouveautes;
            req = "DELETE FROM "+table+" WHERE Id > 3 ";
            BDD.delete(req, connection);
            connection.Close();

            //ouvre une forme pour avertir l'utilisateur que la commande a reussie et ferme la fenetre de suppression
            FormValider frmval = new FormValider("Element(s) suprimer");
            frmval.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//selectionne la table
            if (radioButton1.Checked)
            {
                table = "BURGERS";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton2.Checked)
            {
                table = "SALADES";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton3.Checked)
            {
                table = "DESSERTS";
            }
        }
    }
}

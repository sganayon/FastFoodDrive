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
    public partial class Form7 : Form
    {//modifie l'element selectionne
        public Form7()
        {
            InitializeComponent();
        }

        string table;
        string col;
        string prix;
        string nom;
        string reduc;

        private void button1_Click(object sender, EventArgs e)
        {
            nom = textBox1.Text;
            prix = textBox2.Text;
            reduc = textBox3.Text;

            string req;
            SqlConnection connection = BDD.open();

            //modifie le prix du produit concerne;
            req = "UPDATE "+table+" SET prix = '"+prix+"', reduction = '"+reduc+"' WHERE "+col+" = '"+nom+"'";
            BDD.update(req, connection);
            connection.Close();

            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//selectionne la table et la colonne
            if (radioButton1.Checked)
            {
                table = "BURGERS";
                col = "burger";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton2.Checked)
            {
                table = "SALADES";
                col = "salade";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton3.Checked)
            {
                table = "DESSERTS";
                col = "dessert";
            }
        }
    }
}

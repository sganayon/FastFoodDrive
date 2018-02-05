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
using System.IO;

namespace test_BDD_interface
{//affiche les nouveautes

    // declare un delegue qui permet d'avoir un evenement avec les donnees que l'on veut recuperer
    public delegate void Form8Event(string prix, string reduc, string nom, string type);

    public partial class Form8 : Form
    {
        public Form1 val;
       
        public Form8()
        {
            InitializeComponent();
        }

        public event Form8Event infoForm8;// declare un evenement infoform8 pour la form8
        List<string> nouv = new List<string>();
        string name;
        int ind1;
        int indpre1;
        int ind2;
        int indpre2;
        int ind3;
        int indpre3;

        private void Form8_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label5.Text = "";
            label6.Text = "";

            string req;

            SqlConnection connection1 = BDD.open();
            //permet d'afficher les nouveautes dans la listbox
            req = "SELECT burger FROM BURGERS WHERE Id > 3";
            BDD.FillCLB(req, connection1, checkedListBox1);
            connection1.Close();

            SqlConnection connection2 = BDD.open();
            req = "SELECT salade FROM SALADES WHERE Id > 3";
            BDD.FillCLB(req, connection2, checkedListBox2);
            connection2.Close();

            SqlConnection connection3 = BDD.open();
            req = "SELECT dessert FROM DESSERTS WHERE Id > 3";
            BDD.FillCLB(req, connection3, checkedListBox3);
            connection3.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//valide le burger selectionne
            //recupere le nom de l'element coche
            name = Convert.ToString(checkedListBox1.SelectedItem);

            SqlConnection connection = BDD.open(); 
            string req = "SELECT prix, reduction FROM BURGERS WHERE burger='" + name + "'";
            BDD.filllabel(req, connection, label1, label7);

            this.infoForm8(label1.Text, label7.Text, name, "Burgers"); //creation de l'evenement infoform8
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//permet de ne selectionner qu'un seul item se declenche a chaque changement d'indexe

            indpre1 = ind1;
            ind1 = checkedListBox1.SelectedIndex;

            if (checkedListBox1.GetItemChecked(indpre1))
            {//si l'indexe precedent etait selectionne alors on le deselectionne
                checkedListBox1.SetItemCheckState(indpre1, CheckState.Unchecked);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {//valider la selection de la salade
            name = Convert.ToString(checkedListBox2.SelectedItem);

            SqlConnection connection = BDD.open();
            string req = "SELECT prix, reduction FROM SALADES WHERE salade='" + name + "'";
            BDD.filllabel(req, connection, label5, label8);

            connection.Close();
            this.infoForm8(label5.Text, label8.Text, name, "Salades"); //creation de l'evenement infoform8
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//permet de ne selectionner qu'un seul item

            indpre2 = ind2;
            ind2 = checkedListBox2.SelectedIndex;
            if (checkedListBox2.GetItemChecked(indpre2))
            {
                checkedListBox2.SetItemCheckState(indpre2, CheckState.Unchecked);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {//valide le dessert selectionne
            name = Convert.ToString(checkedListBox3.SelectedItem);

            SqlConnection connection = BDD.open();
            string req = "SELECT prix, reduction FROM DESSERTS WHERE dessert='" + name + "'";
            BDD.filllabel(req, connection, label6, label9);

            this.infoForm8(label6.Text, label9.Text, name, "Desserts"); //creation de l'evenement infoform8
        }

        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {//permet de ne selectionner qu'un seul item

            indpre3 = ind3;
            ind3 = checkedListBox3.SelectedIndex;
            if (checkedListBox3.GetItemChecked(indpre3))
            {
                checkedListBox3.SetItemCheckState(indpre3, CheckState.Unchecked);
            }

        }
    }
}

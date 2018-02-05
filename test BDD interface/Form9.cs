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
using System.Net.Mail;

namespace test_BDD_interface
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
            string req;

            SqlConnection connection = BDD.open();
            //permet d'afficher les nouveautes dans la listbox
            req = "SELECT salade FROM SALADES WHERE Id > 3";
            BDD.FillCLB(req, connection, checkedListBox1);
            connection.Close();

            SqlConnection connection2 = BDD.open();
            //permet d'afficher les nouveautes dans la listbox
            req = "SELECT burger FROM BURGERS WHERE Id > 3";
            BDD.FillCLB(req, connection2, checkedListBox1);
            connection2.Close();

            SqlConnection connection3 = BDD.open();
            //permet d'afficher les nouveautes dans la listbox
            req = "SELECT dessert FROM DESSERTS WHERE Id > 3";
            BDD.FillCLB(req, connection3, checkedListBox1);
            connection3.Close();

            SqlConnection connection4 = BDD.open();
            //permet de recuperer les produits en promotion
            req = "SELECT burger, reduction FROM BURGERS WHERE reduction != 0";
            BDD.FillCLB2(req, connection4, checkedListBox2);
            connection4.Close();

            SqlConnection connection5 = BDD.open();
            //permet de recuperer les produits en promotion
            req = "SELECT salade, reduction FROM SALADES WHERE reduction != 0";
            BDD.FillCLB2(req, connection5, checkedListBox2);
            connection5.Close();


            SqlConnection connection6 = BDD.open();
            //permet de recuperer les produits en promotion
            req = "SELECT dessert, reduction FROM DESSERTS WHERE reduction != 0";
            BDD.FillCLB2(req, connection6, checkedListBox2);
            connection6.Close();

            //coche tous les items de la checkedlistbox2 (compte les elements et les coche un a un)
            int f = checkedListBox2.Items.Count;
            int g = 0;
            while (g < f)
            {
                checkedListBox2.SetItemCheckState(g, CheckState.Checked);
                g++;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {//envoie le mail 
            string mdp = textBox1.Text;
            string body = "";
            string body2 = "";
            int NbItemCLB1 = checkedListBox1.CheckedItems.Count;
            int NbItemCLB2 = checkedListBox2.CheckedItems.Count;
         
            //ajoute les elements de la CLB un a un dans une chaine
            for (int i = 0; i < NbItemCLB1; i++)
            {
               body = body + "<li>" + checkedListBox1.CheckedItems[i].ToString() + "</li>";
            }

            //idem
            for (int j = 0; j < NbItemCLB2; j = j+2)
            {
                body2 = body2 + "<li>" + checkedListBox2.CheckedItems[j].ToString() + checkedListBox2.CheckedItems[j+1].ToString() + "</li>";
            }

            tool.mail(mdp, body, body2);

            this.Close();
        }

        char val = 'n';
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//selectionne tous les elements de la CLB
            tool.CLBsel(checkedListBox1, val);       
        }

        private void button2_Click(object sender, EventArgs e)
        {//ajoute ou supprime des adresses mail
            string req;
            if (supp == 'n') {
                
                SqlConnection connection = BDD.open();
                //permet d'ajouter une @mail
                req = "INSERT INTO ADRESSES(adresse) values('" + textBox2.Text + "')";
                BDD.inserer(req, connection);
                connection.Close();
                textBox2.Text = "";
            }
            else
            {
                SqlConnection connection2 = BDD.open();
                //permet de supprimer une @mail
                req = "DELETE FROM ADRESSES WHERE adresse = '"+textBox2.Text+"'";
                BDD.delete(req, connection2);
                connection2.Close();
                textBox2.Text = "";
            }
            
        }

        char supp = 'n';
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {//change le nom du bouton suivant si le check box est coche ou pas
            if (supp == 'y')
            {
                supp = 'n';
                button2.Text = "ajouter";
            }
            else
            {
                supp = 'y';
                button2.Text = "supprimer";
            }
        }
    }
}

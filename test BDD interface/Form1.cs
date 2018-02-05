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
{
    
    public partial class Form1 : Form
    {
        //commande temporaire qui stocke les produits selectionnes
        public static List<string> cmdtmp = new List<string>();
        //liste pour recuperer les valeurs des methodes statiques
        public static List<string> res = new List<string>();

        //string prixnouv;//variable pour recuperer le prix du produit selectionne dans form8.
        //string nomnouv;//variable pour recuperer le nom du produit selectione dans form8
        //string typenouv;//variable pour recuperer le type du produit selectione dans form8
        //string reducnouv;//variable pour recuperer la reduction du produit selectione dans form8
  
        public Form1()
        {
            InitializeComponent();
        }
        //Form8 frm8;//declare la form8
        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.DarkGray;

            // TODO: cette ligne de code charge les données dans la table 'basemacdoDataSet.SALADES'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.sALADESTableAdapter.Fill(this.basemacdoDataSet.SALADES);
            // TODO: cette ligne de code charge les données dans la table 'basemacdoDataSet.DESSERTS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.dESSERTSTableAdapter.Fill(this.basemacdoDataSet.DESSERTS);
            // TODO: cette ligne de code charge les données dans la table 'basemacdoDataSet.BURGERS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.bURGERSTableAdapter.Fill(this.basemacdoDataSet.BURGERS);
            //label d'architecture servant de reference pour le texte et l'image des boutons
            archi.Text = "1";
            button7.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\new.png");
            button7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {//burgers
            SqlConnection connection = BDD.open();
            string ord;
            //tool.sw1(button1.Text, connection, label1.Text, cmdtps.Text,archi.Text,objcmd.Text);
            //Update(res[0].ToString(),res[1].ToString(),res[2].ToString(),res[3].ToString());
            
            //suivant le texte du boutton 1 differents produits sont ajoutes dans la commande temporaire
            //ainsi que le prix apres calcul de la reduction du produit dans un label objcmd
            //enfin on passe au niveau d'architecture suivant (menu -> choix plat -> produit -> sauce )
            switch (button1.Text)
            {
                case "Burgers":
                    archi.Text = "2b";
                    cmdtmp.Add("Burger");
                    break;

                case "chicken":
                    archi.Text = "3c";
                    cmdtmp.Add("chicken");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='chicken'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "fromage":
                    archi.Text = "3fr";
                    cmdtmp.Add("fromage");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='fromage'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "mac flury":
                    archi.Text = "3m";
                    cmdtmp.Add("macflury");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='mac_flurry'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "poivre":
                    archi.Text = "4p";
                    cmdtmp.Add("poivre");
                    break;

                case "vinaigrette":
                    archi.Text = "4v";
                    cmdtmp.Add("vinaigrette");
                    break;

                case "chocolat":
                    archi.Text = "4c";
                    cmdtmp.Add("chocolat");
                    break;

                case "confirmer":
                    archi.Text = "1";
                    //le label cmdtps est la commande finale des produits commandes par l'utilisateur, string join permet de concatener une liste avec une virgule comme separateur
                    cmdtps.Text = cmdtps.Text + " \r\n " + string.Join(", ", cmdtmp) +"\t\t"+ objcmd.Text +" euros";
                    //label1 est le label stockant le prix total de la commande
                    label1.Text = Convert.ToString((Convert.ToDecimal(label1.Text) + Convert.ToDecimal (objcmd.Text)));
                    //on efface la commande temporaire car elle a ete validee
                    cmdtmp.Clear();
                    break;

                default:
                    break;
            }
            // Fermeture connection 
            connection.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {//salades
            SqlConnection connection = BDD.open();
            string ord;
            //tool.sw1(button2.Text, connection, label1.Text, cmdtps.Text, archi.Text, objcmd.Text);
            //Update(res[0].ToString(), res[1].ToString(), res[2].ToString(), res[3].ToString());
            
            //voir button1.click pour plus d'informations
            switch (button2.Text)
            {
                case "Salades":
                    archi.Text = "2s";
                    cmdtmp.Add("Salade");
                    break;

                case "big mac":
                    archi.Text = "3b";
                    cmdtmp.Add("big mac");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='big_mac'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "oriental":
                    archi.Text = "3or";
                    cmdtmp.Add("oriental");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='oriental'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "sun day":
                    archi.Text = "3s";
                    cmdtmp.Add("sun day");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='sun_day'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "'":
                    archi.Text = "4k";
                    cmdtmp.Add("ketchup");
                    break;

                case "balsamic":
                    archi.Text = "4b";
                    cmdtmp.Add("balsamic");
                    break;

                case "caramel":
                    archi.Text = "4ca";
                    cmdtmp.Add("caramel");
                    break;

                default:
                    break;
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {//dessert
            SqlConnection connection = BDD.open();
            string ord;
            //tool.sw1(button3.Text, connection, label1.Text, cmdtps.Text, archi.Text, objcmd.Text);
            //Update(res[0].ToString(), res[1].ToString(), res[2].ToString(), res[3].ToString());
            
            //voir button.click pour plus d'informations
            switch (button3.Text)
            {
                case "Desserts":
                    archi.Text = "2d";
                    cmdtmp.Add("Desserts");
                    break;

                case "fish":
                    archi.Text = "3f";
                    cmdtmp.Add("long fish");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='fish'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "crudite":
                    archi.Text = "3cr";
                    cmdtmp.Add("crudite");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='crudite'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case "cookie":
                    archi.Text = "3co";
                    cmdtmp.Add("cookie");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='cookie'";
                    objcmd.Text = BDD.GetPrixReduc(ord, connection);
                    break;

                case ".":
                    archi.Text = "4m";
                    cmdtmp.Add("mayonaise");
                    break;

                case "sans sauce":
                    archi.Text = "4ss";
                    cmdtmp.Add("sans sauce");
                    break;

                case "sans coulis":
                    archi.Text = "4sc";
                    cmdtmp.Add("sans coul");
                    break;

                default:
                    break;
            }
            connection.Close();
        }

        private void archi_Click(object sender, EventArgs e)
        {
           
        }

        private void archi_TextChanged(object sender, EventArgs e)
        {//label d'architecture permettant de changer le texte et l'image des boutons

            if(archi.Text == "1")
            {
                button1.Text = "Burgers";
                button1.ForeColor = Color.Black;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\burger2.png");
                button2.Text = "Salades";
                button2.ForeColor = Color.Black;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\salade.png");
                button3.Text = "Desserts";
                button3.ForeColor = Color.White;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\dessert.png");
            }

            if (archi.Text == "2b")
            {
                button1.Text = "chicken";
                button1.ForeColor = Color.Black;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\poulet pane.jpg");
                button2.Text = "big mac";
                button2.ForeColor = Color.Black;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\steak1.png");
                button3.Text = "fish";
                button3.ForeColor = Color.Black;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\fish.png");
            }

            if (archi.Text == "2s")
            {
                button1.Text = "fromage";
                button1.ForeColor = Color.Black;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\chevre.png");
                button2.Text = "oriental";
                button2.ForeColor = Color.Black;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\oriental.jpg.png");
                button3.Text = "crudite";
                button3.ForeColor = Color.Black;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\crudite.png");
            }

            if(archi.Text == "2d")
            {
                button1.Text = "mac flury";
                button1.ForeColor = Color.Black;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\mac flury.png");
                button2.Text = "sun day";
                button2.ForeColor = Color.Black;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\sun day.jpg.png");
                button3.Text = "cookie";
                button3.ForeColor = Color.Black;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\COOKIE.png");
            }

            if(archi.Text == "3c" || archi.Text == "3b" || archi.Text == "3f")
            {
                button1.Text = "poivre";
                button1.ForeColor = Color.White;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\poivre.png");
                button2.Text = "'";
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\ketchup.png");
                button3.Text = ".";
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\mayo.png");
            }

            if (archi.Text == "3fr" || archi.Text == "3or" || archi.Text == "3cr")
            {
                button1.Text = "vinaigrette";
                button1.ForeColor = Color.White;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vinaigrette.png");
                button2.Text = "balsamic";
                button2.ForeColor = Color.White;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\balsamic.png");
                button3.Text = "sans sauce";
                button3.ForeColor = Color.Black;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vide.png");
            }

            if (archi.Text == "3m" || archi.Text == "3s" || archi.Text == "3co")
            {
                button1.Text = "chocolat";
                button1.ForeColor = Color.White;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\chocolat.png");
                button2.Text = "caramel";
                button2.ForeColor = Color.Black;
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\caramel.png");
                button3.Text = "sans coulis";
                button3.ForeColor = Color.Black;
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vide.png");
            }

            if (archi.Text == "4p" || archi.Text == "4k" || archi.Text == "4m" || archi.Text == "4v" || archi.Text == "4b" || archi.Text == "4ss" || archi.Text == "4c" || archi.Text == "4ca" || archi.Text == "4sc" )
            {
                button1.Text = "confirmer";
                button1.ForeColor = Color.Black;
                button1.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vide.png");
                button2.Text = "";
                button2.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vide.png");
                button3.Text = "";
                button3.Image = Image.FromFile(@"C:\Users\axel\Desktop\telecom\Info\csharp\img\vide.png");
            }
        }

        private void button1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmdtps_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {//retour d'un cran dans la selection des produits, il faut donc enlever de la commande temporaire le produit precedemment selectionne

            //suivant l'architecture actuelle on va retourner a l'architecture precedente et enlever le produit correspondant
            switch (archi.Text)
            {
                case "2b":
                    archi.Text = "1";
                    cmdtmp.Remove("Burger");
                    break;

                case "2s":
                    archi.Text = "1";
                    cmdtmp.Remove("Salade");
                    break;

                case "2d":
                    archi.Text = "1";
                    cmdtmp.Remove("Desserts");
                    break;

                case "3c":
                    archi.Text = "2b";
                    cmdtmp.Remove("chicken");
                    break;

                case "3b":
                    archi.Text = "2b";
                    cmdtmp.Remove("big mac");
                    break;

                case "3f":
                    archi.Text = "2b";
                    cmdtmp.Remove("long fish");
                    break;

                case "3fr":
                    archi.Text = "2s";
                    cmdtmp.Remove("fromage");
                    break;

                case "3or":
                    archi.Text = "2s";
                    cmdtmp.Remove("oriental");
                    break;

                case "3cr":
                    archi.Text = "2s";
                    cmdtmp.Remove("crudite");
                    break;

                case "3m":
                    archi.Text = "2d";
                    cmdtmp.Remove("macflury");
                    break;

                case "3s":
                    archi.Text = "2d";
                    cmdtmp.Remove("sun day");
                    break;

                case "3co":
                    archi.Text = "2d";
                    cmdtmp.Remove("cookie");
                    break;
                
                case "4p":
                    archi.Text = "3b";
                    cmdtmp.Remove("poivre");
                    break;

                case "4k":
                    archi.Text = "3b";
                    cmdtmp.Remove("ketchup");
                    break;

                case "4m":
                    archi.Text = "3b";
                    cmdtmp.Remove("mayonaise");
                    break;

                case "4v":
                    archi.Text = "3fr";
                    cmdtmp.Remove("vinaigrette");
                    break;

                case "4b":
                    archi.Text = "3fr";
                    cmdtmp.Remove("balsamic");
                    break;

                case "4ss":
                    archi.Text = "3fr";
                    cmdtmp.Remove("sans sauce");
                    break;

                case "4c":
                    archi.Text = "3m";
                    cmdtmp.Remove("chocolat");
                    break;

                case "4ca":
                    archi.Text = "3m";
                    cmdtmp.Remove("caramel");
                    break;

                case "4sc":
                    archi.Text = "3m";
                    cmdtmp.Remove("sans coul");
                    break;

                default:
                    break;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {//valider pour imprimer la commande 

            tool.save(cmdtps.Text, label1.Text, saveFileDialog1);
            //on repasse a l'architecture de base et on efface toutes les commandes et prix crees
            label1.Text = "0";
            cmdtps.Text = "drive";
            cmdtmp.Clear();
            archi.Text = "1";

        }

        private void button6_Click(object sender, EventArgs e)
        {//annuler la ligne de commande en cours ou la commande

            if (val == 'n')
            {//annule le produit commande en cours
                cmdtmp.Clear();
                archi.Text = "1";
            }
            else
            {//annuler la commande entiere
                label1.Text = "0";
                cmdtps.Text = "drive";
                cmdtmp.Clear();
                archi.Text = "1";
            }
        }

        private void menusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void afficherLesMenusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void burgersToolStripMenuItem_Click(object sender, EventArgs e)
        {//affiche le menu de burgers
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void saladesToolStripMenuItem_Click(object sender, EventArgs e)
        {//affiche le menu de salades
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void dessertsToolStripMenuItem_Click(object sender, EventArgs e)
        {//affiche le menu de desserts
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void objcmd_Click(object sender, EventArgs e)
        {

        }

        private void bURGERSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {//met a jour le dataset si le datagridview a ete modifie
            this.Validate();
            this.bURGERSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.basemacdoDataSet);

        }

        char val = 'n';
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//supprimer la commande entiere ou juste le produit en cours
            if(val == 'n') { val = 'y'; }
            else { val = 'n'; }
        }

        private void label1_Click(object sender, EventArgs e)
        {//prix total de la commande

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {//ajoute un produit a la base de donnees
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void suprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {//supprime un produit de la base de donnees
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {//modifie un produit de la base de donnees
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {//nouveautes
            Form8 frm8 = new Form8();
            // form1 s'abonne a l'evenement infoform8 de form8 et active la methode getinfo du fichier tool.cs 
            frm8.infoForm8 += new Form8Event(this.getinfo);
            frm8.Show();
            //fom1 s'abonne a l'evenement architoform1 de tool.cs et active la methode updatearchi
            //tool.ArchiToForm1 += new tool.toolEvent(UpdateArchi);
        }

        private void envoyerMailToolStripMenuItem_Click(object sender, EventArgs e)
        {//envoyer des mails
            Form9 frm9 = new Form9();
            frm9.Show();
        }
        
        private void afficherLesAbonnesToolStripMenuItem_Click(object sender, EventArgs e)
        {//afficher les abonnes a la newsletter
            Form10 frm10 = new Form10();
            frm10.Show();
        }
        
        
        private void UpdateArchi(string newval, string prixfinal)
        {//methode pour mettre a jour le label archi et objcmd a partir des valeurs en parametres
            archi.Text = newval;
            objcmd.Text = prixfinal;
        }

        /*
        private void Update(string archie, string objcmde, string label1e, string cmdtpse)
        {//idem met a jour des labels non static a partir des valeurs en parametres
            archi.Text = archie;
            objcmd.Text = objcmde;
            label1.Text = label1e;
            cmdtps.Text = cmdtpse;
        }
        */

        public void getinfo(string prix, string reduc, string nom, string type)
        {//recupere les valeurs de l'evenement infoform8 
            switch (type)
            {
                case "Burgers":
                    archi.Text = "3b";
                    cmdtmp.Add("Burger");
                    break;

                case "Salades":
                    archi.Text = "3fr";
                    cmdtmp.Add("Salade");
                    break;

                case "Desserts":
                    archi.Text = "3m";
                    cmdtmp.Add("Dessert");
                    break;

                default: break;
            }
            cmdtmp.Add(nom);
            objcmd.Text = Convert.ToString(Convert.ToDouble(prix) - (Convert.ToDouble(prix) * Convert.ToDouble(reduc) / 100));
        }
    }
}

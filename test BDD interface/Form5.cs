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
using System.Threading;


namespace test_BDD_interface
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int iburger = 0;
        int isalade = 0;
        int idessert = 0;
        int itable = 0;
        string table;
        string col;

        private void Form5_Load(object sender, EventArgs e)
        {
            string req;
            SqlConnection connection = BDD.open();

            //permet de recuperer le nb de lignes de la table BURGERS
            req = "SELECT COUNT(*) FROM BURGERS";
            iburger = BDD.NbLigne(req, connection);

            //permet de recuperer le nb de lignes de la table SALADES
            req = "SELECT COUNT(*) FROM SALADES";
            isalade = BDD.NbLigne(req, connection);

            //permet de recuperer le nb de lignes de la table DESSERTS
            req = "SELECT COUNT(*) FROM DESSERTS";
            idessert = BDD.NbLigne(req,connection);

            connection.Close();
            //le calcul se fait en moins de 30 sec donc on peut garder la meme connection.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itable++;
            string name = textBox1.Text;
            string prix = textBox2.Text;
            string reduc = textBox3.Text;

            SqlConnection connection = BDD.open();

            //insert une ligne dans la database
            string req = "INSERT INTO "+table+"(Id, "+col+", prix, reduction) Values (" + Convert.ToString(itable) + ", '" + name + "', " + prix + ", " + reduc + ")";
            BDD.inserer(req, connection);
            connection.Close();
            
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {//selectionne la table, cologne et nb de lignes a mettre dans la requete
            if (radioButton1.Checked)
            {
                table = "BURGERS";
                col = "burger";
                itable = iburger;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton2.Checked)
            {
                table = "SALADES";
                col = "salade";
                itable = isalade;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {//idem
            if (radioButton3.Checked)
            {
                table = "DESSERTS";
                col = "dessert";
                itable = idessert;
            }
        }


        List<string> lignes = new List<string>();
        List<string> mots = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {//recupere un fichier csv

            int nbcolonnes = 3; //nombre de colones de notre table (BURGERS/SALADES/DESSERTS)
            char[] splitligne = new char[] { '\n' };
            char[] splitmot = new char[] { ';' };

            string fileContent = tool.lire(openFileDialog1);
            //creer un tableau de string avec les cellules remplis par des sous string du fichier csv.
            //la methode Split prend en parametre le separateur qui permet de fractionner la string et retourne les sous chaines (les lignes) 
            string[] lignesplit = fileContent.Split(splitligne);

            //on compte le nombre de cellules du tableau
            int nblignes = lignesplit.Count();
               
            //on cree un tableau dimentionne suivant le nombre de lignes multiplie par le nombre de colonne (ici toujours egal a 3)
            string[] motsplit = new string[(nblignes * nbcolonnes)];
            //on cree un tableau surdimentionne pour stocker une ligne de 3 mots
            string[] temp = new string[30];
                
            
            int i;
            int z = 0;

            //la derniere ligne est toujours vide donc on ne la prend pas
            for (i = 0; i < (nblignes - 1); i++)
            {
                //on separt la ligne en mot grace au separateur ;
                temp = lignesplit[i].Split(splitmot);
                //on remplit le tableau des mots ligne par ligne comme une ligne n'a que 3 mots on incremente z par 3 et on utilise les 3 premieres cellules de temp
                motsplit[z] = temp[0];
                motsplit[z + 1] = temp[1];
                motsplit[z + 2] = temp[2];
                z = z + 3;
            }
            z = 0;

            int j;
            //on compte le nombre de cellules de mots
            int nbmots = motsplit.Count();

            //permet de selectionner la table avec la premiere case du fichier csv cela permet d'eviter de cocher la table comme pour un ajout simple
            col = Convert.ToString(motsplit[0]);
            switch (col)
            {
                case "burger":
                    table = "BURGERS";
                    break;
                case "salade":
                    table = "SALADES";
                    break;
                case "dessert":
                    table = "DESSERTS";
                    break;
                default:break;
            }

            int nbligne = 0;
            SqlConnection connection2 = BDD.open();
            //on compte le nombre d'enregistrements dans la table pour pouvoir affecter un id plus grand
            string req2 = "SELECT COUNT(*) FROM "+table;
            nbligne = BDD.NbLigne(req2, connection2);
            connection2.Close();

            char ajtreussi = 'y';
            //boucle d'insertion dans la base on insert 3 mots a chaque fois (nom, prix, reduction) on ne prend pas en compte les 3 premiers qui sont le titre des colonnes ni les 3 derniers qui sont vides
            for (j = 3; j < nbmots - 3; j = j + 3)
            {
                 //incrementation du nb de lignes pour enregistrer  
                 nbligne++;
                 SqlConnection connection = BDD.open();
                 string req = "INSERT INTO "+table+" (Id, "+col+", prix, reduction) Values (" + Convert.ToString(nbligne) + ", '" + Convert.ToString(motsplit[j]) + "', " + Convert.ToString(motsplit[j + 1]) + ", " + Convert.ToString(motsplit[j + 2]) + ")";
                 //on n'utilise pas BDD.inserer car cela ouvrirait autant de fomvalider que d'iteration
                 //creation du dataadapter qui va gerer les donnees (ajt/supr/modi) dans la BDD selectionnee par connec
                 SqlDataAdapter adapter = new SqlDataAdapter(req, connection);
                 //on appelle la methode insertcommand pour creer la commande d'insertion (req) dans la BDD
                 adapter.InsertCommand = new SqlCommand(req, connection);
                
                 try
                 { //on excecute la commande d'insertion
                     adapter.InsertCommand.ExecuteNonQuery();
                 }
                 catch (Exception ex)
                 {//si cela echoue on affiche un message box (contrainte d'unicité ou de non selection de la table)
                     MessageBox.Show("Une erreur est survenue lors de l'insertion", ex.Message);
                    ajtreussi = 'n';
                }
                 connection.Close();
            }
            //si il n'y a eu aucune erreur lors de l'insertion
            if (ajtreussi == 'y')
            {
                //ouvre une forme pour afficher a l'utilisateur que la commande a reussie et ferme la fenetre d'ajout
                FormValider frmval = new FormValider("Element(s) ajouter");
                frmval.Show();
                this.Close();
            }
         }
     }
}


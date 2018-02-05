using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;


namespace test_BDD_interface
{
    //pour que les autres class puissent avoir acces aux methodes de BDD
    public partial class BDD
    {
        //pour que les autres form puissent voir ces methodes
        public static SqlConnection open ()
        {
            string connect = "server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\axel\\Desktop\\telecom\\Info\\csharp\\test BDD interface\\test BDD interface\\basemacdo.mdf;Integrated Security = True; Connect Timeout = 30";
            SqlConnection connection = new SqlConnection(connect);
            connection.Open();
            return connection;
        }

        public static string GetPrixReduc(string ord, SqlConnection connec)
        {
            Double prix = 0;
            Double reduc = 0;
            //creation de la requete a la base de donnees. (prend une chaine de caractere et un objet Sqlconnection pour selectionner la base
            SqlCommand command = new SqlCommand(ord, connec);
            //creation du reader qui va recuperer les valeurs liees a la requete.
            SqlDataReader reader = command.ExecuteReader();
            //Le reader ressemble a un tableau, reader.read() permet de lire la ligne actuelle et de selectionner la suivante, ici il n'a q'une ligne a lire donc pas besoin de boucle (cela renvoit vrai tant qu'il y a des lignes a lire).
            reader.Read();
            //le reader ne lit qu'une ligne de deux colonnes
            prix = reader.GetDouble(0);
            reduc = reader.GetDouble(1);
            // Fermeture reader 
            reader.Close();
            return (Convert.ToString((prix - (prix * reduc) / 100)));
        }

        public static int NbLigne(string req, SqlConnection connec)
        {
            int nbligne = 0;
            SqlCommand command = new SqlCommand(req, connec);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                //une seule valeur a lire (un entier)
                reader.Read();
                nbligne = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {//si cela echoue on affiche un message box (non selection de la table)
                MessageBox.Show("Une erreur est survenue lors de la lecture", ex.Message);
            }
            
            return nbligne;
        }

        public static void inserer(string req, SqlConnection connec)
        {
            //creation du dataadapter qui va gerer les donnees (ajt/supr/modi) dans la BDD selectionnee par connec
            SqlDataAdapter adapter = new SqlDataAdapter(req, connec);
            //on appelle la methode insertcommand pour creer la commande d'insertion (req) dans la BDD
            adapter.InsertCommand = new SqlCommand(req, connec);
            try
            { //on excecute la commande d'insertion
                adapter.InsertCommand.ExecuteNonQuery();

                //ouvre une forme pour afficher a l'utilisateur que la commande a reussie et ferme la fenetre d'ajout
                FormValider frmval = new FormValider("Element(s) ajouter");
                frmval.Show();
            }
            catch (Exception ex)
            {//si cela echoue on affiche un message box (contrainte d'unicité)
                MessageBox.Show("Une erreur est survenue lors de l'insertion", ex.Message);
            }
            
        }

        public static void delete(string req, SqlConnection connec)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(req, connec);
            //de meme cette fois c'est la commande de suppression creee par la requete (req) a la BDD selectionnee par (connec)
            adapter.DeleteCommand = new SqlCommand(req, connec);
            
            adapter.DeleteCommand.ExecuteNonQuery();
        }

        public static void update(string req, SqlConnection connec)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(req, connec);
            //idem, on peut remarquer que update peut aussi se faire avec des delete et insert
            adapter.UpdateCommand = new SqlCommand(req, connec);
            try
            {
                adapter.UpdateCommand.ExecuteNonQuery();

                //ouvre une fenetre pour avertir l'utilisateur que la commande a reussie et ferme la fenetre de modification
                FormValider frmval = new FormValider("Element(s) mis a jours");
                frmval.Show();
            }
            catch (Exception ex)
            {//si cela echoue on affiche un message box (contrainte d'unicité)
                MessageBox.Show("Une erreur est survenue lors de la mise a jours", ex.Message);
            }
        }

        public static void FillCLB(string req, SqlConnection connec, CheckedListBox CLB)
        {
            SqlCommand command = new SqlCommand(req, connec);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {//ajoute les valeurs du reader a la CLB
                CLB.Items.Add(Convert.ToString(reader.GetString(0)));
            }
            reader.Close();
        }

        public static void filllabel(string req, SqlConnection connec, Label Lprix, Label Lreduc)
        {
            SqlCommand command = new SqlCommand(req, connec);
            SqlDataReader reader = command.ExecuteReader();
            //une seule ligne a lire mais deux colonnes
            reader.Read();
            Lprix.Text = Convert.ToString(reader.GetDouble(0));
            Lreduc.Text = Convert.ToString(reader.GetDouble(1));
            reader.Close();
        }

        public static void FillCLB2(string req, SqlConnection connec, CheckedListBox CLB)
        {
            SqlCommand command = new SqlCommand(req, connec);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CLB.Items.Add(Convert.ToString(reader.GetString(0)));
                CLB.Items.Add(" moins " + Convert.ToString(reader.GetDouble(1)) + "%");
            }
            reader.Close();
        }

        public static void dest(string req, SqlConnection connec, MailMessage message)
        {//permet de charger tous les destinataires du mail
            SqlCommand command = new SqlCommand(req, connec);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                message.To.Add(Convert.ToString(reader.GetString(0)));
            }
            reader.Close();
        }

        public static void gridview(string req, SqlConnection connect, DataGridView grid )
        {//MAJ du datagridview via une requete de selection
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(req, connect);
            adapter.Fill(table);
            //on valide les changements de la datatable (qui etait vide puis remplis par le dataadapter)
            table.AcceptChanges();
            //le datagridview va pointer vers le datatable et donc l'afficher
            grid.DataSource = table;
        }
    }
}

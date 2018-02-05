using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;


namespace test_BDD_interface
{
    public partial class tool
    {
        //declare et definie un evenement ArchiToForm1 de tool.cs qui va prendre deux textes en parametres et les envoyer a la form1
        //public delegate void toolEvent(string archi, string prixfinal);
        //public static event toolEvent ArchiToForm1;

        public static void save(string cmdtps, string label1, SaveFileDialog saveFileDialog1)
        {//sauvegarde la note du client
            string fileContent;
            fileContent = cmdtps + "\r\n" + "TOTAL" + "\t\t\t\t\t" + label1 + " euros";

            // On met des filtres pour les types de fichiers : "Nom|*.extension|autreNom|*.autreExtension" (autant de filtres qu'on veut).
            saveFileDialog1.Filter = "Fichiers texte|*.txt|Tous les fichiers|*.*";
            // Le filtre sélectionné : le 2e (là on ne commence pas à compter à 0).
            saveFileDialog1.FilterIndex = 2;
            // On affiche le dernier dossier ouvert.
            saveFileDialog1.RestoreDirectory = true;
            // Si l'utilisateur clique sur "Ouvrir"
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //objet Stream qui contient le fichier selectionne avec droit de lecture et ecriture
                    Stream myStream = saveFileDialog1.OpenFile();

                    if (myStream != null)
                    {
                        using (myStream)
                        {
                            //utilisation d'un objet StreamWriter qui prend un objet Stream (donc le fichier a ecrire) et l'encodage
                            using (StreamWriter writer = new StreamWriter(myStream, Encoding.UTF8))
                            {
                                //le writer va ecrire la chaine de caractere suivant les parametres 
                                writer.Write(fileContent);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'écriture du fichier: {0}.", ex.Message);
                }
            }
        }

        public static string lire(OpenFileDialog openFileDialog1)
        {
            string fileName;
            string fileContent = "";
            // On interdit la sélection de plusieurs fichiers.
            openFileDialog1.Multiselect = false;
            // On supprime le nom de fichier, qui ici vaut "openFileDialog1" (avant sélection d'un fichier).
            openFileDialog1.FileName = string.Empty;
            // On met des filtres pour les types de fichiers : "Nom|*.extension|autreNom|*.autreExtension" (autant de filtres qu'on veut).
            openFileDialog1.Filter = "Fichiers texte|*.txt|Tous les fichiers|*.*";
            // Le filtre sélectionné : le 2e (là on ne commence pas à compter à 0).
            openFileDialog1.FilterIndex = 2;
            // On affiche le dernier dossier ouvert.
            openFileDialog1.RestoreDirectory = true;
            // Si l'utilisateur clique sur "Ouvrir"...
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // On récupère le nom du fichier.
                    fileName = openFileDialog1.FileName;
                    //creation d'un objet stream qui contient le fichier ouvert
                    Stream myStream = openFileDialog1.OpenFile();
                    if (myStream != null)
                    {
                        using (myStream)
                        {
                            //utilisation d'un objet StreamReader qui prend un objet Stream (donc le fichier a lire) et l'encodage
                            using (StreamReader reader = new StreamReader(myStream, Encoding.UTF8))
                            {
                                //on lit le fichier du debut jusqu'a la fin et on le met dans une string
                                fileContent = reader.ReadToEnd();

                            }
                        }
                    }
                }
                // En cas d'erreur...
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'ouverture du fichier : {0}.", ex.Message);
                }

            }
            return fileContent;
        }

        public static void mail(string mdp, string body, string body2)
        {
            string req;
            string h1color = "FF4000";
            string h2color = "B40404";
            string listcolor = "black";

            //creation d'un objet mail
            MailMessage message = new MailMessage();
            //selection du server mail de google avec le port securise
            SmtpClient stpc = new SmtpClient("smtp.gmail.com", 587);
            //permet d'envoyer nos identifiants qui serons verifies car on utilise le port securise
            stpc.Credentials = new System.Net.NetworkCredential("axel.poulat1@gmail.com", mdp);
            //on securise notre connection en la chiffrant
            stpc.EnableSsl = true;
            //indique de qui provient le mail
            message.From = new MailAddress("axel.poulat1@gmail.com");
            
            SqlConnection connection = BDD.open();
            //permet de charger tous les destinataires du mail
            req = "SELECT adresse FROM ADRESSES";
            BDD.dest(req, connection, message);
            connection.Close();

            //remplit les lignes du mail (objet, corps) qui sera un mail html
            message.Subject = "Promotion à ne pas manquer";
            message.Body = "<h1><font color = " + h1color+"><center>Mac Ventre vous annonce :</center></font></h1><br> <h2><font color ="+h2color+">voici les nouveautés en restaurant :</font></h2><br> <ul><font size = 3 color ="+listcolor+">" + body + "</font></ul><br> <h2><font color =" + h2color + ">De plus ces produits sont toujours en promotion : </font></h2><br> <ul><font size = 3 color ="+listcolor+">" + body2 + "</font></ul>";
            message.IsBodyHtml = true;
            //envoie le mail
            try
            {
                stpc.Send(message);
                //ouvre une fenetre pour avertir l'utilisateur que la commande a reussie
                FormValider frmval = new FormValider("Mail(s) envoyé(s)");
                frmval.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de l'envoi du mail", ex.Message);
            }


        }
         
        public static void CLBsel(CheckedListBox CLB, char val)
        {
            if (val == 'n')
            {
                val = 'y';
                //selectionne tous les items de la checkedlistbox
                int k = CLB.Items.Count;
                int l = 0;
                while (l < k)
                {
                    CLB.SetItemCheckState(l, CheckState.Checked);
                    l++;
                }
            }
            else
            {
                val = 'n';
                //deselectionne tous les items de la checkedlistbox
                int k = CLB.Items.Count;
                int l = 0;
                while (l < k)
                {
                    CLB.SetItemCheckState(l, CheckState.Unchecked);
                    l++;
                }
            }
        }
        
        /*       
        public static void getinfo(string prix, string reduc, string nom, string type)
        {//recupere les valeurs de l'evenement infoform8 et en renvoie certaine a form1 par une deuxieme evenement (pour les labels non static)
            string archi = "0";
            string prixfinal;
            switch (type)
            {
                case "Burgers":
                    archi = "3b";
                    Form1.cmdtmp.Add("Burger");
                    break;

                case "Salades":
                    archi = "3fr";
                    Form1.cmdtmp.Add("Salade");
                    break;

                case "Desserts":
                    archi = "3m";
                    Form1.cmdtmp.Add("Dessert");
                    break;
                    
                default: break;
            }
            Form1.cmdtmp.Add(nom);
            prixfinal = Convert.ToString(Convert.ToDouble(prix) - (Convert.ToDouble(prix) * Convert.ToDouble(reduc) / 100));
            tool.ArchiToForm1(archi, prixfinal);// creation de l'evenement architoform1 pour envoyer la valeur archi au label archi de form1
        }
        */
        /* //non utilise car peu d'interet niveau optimisation du code
        public static void sw1(string texte, SqlConnection connection, string label1, string cmdtps, string archi, string objcmd)
        {
            string[] presult = new string[3];
            string ord;
            switch (texte)
            {
                //block pour le texte du bouton1
                case "Burgers":
                    archi = "2b";
                    Form1.cmdtmp.Add("Burger");
                    break;

                case "chicken":
                    archi = "3c";
                    Form1.cmdtmp.Add("chicken");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='chicken'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "fromage":
                    archi = "3fr";
                    Form1.cmdtmp.Add("fromage");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='fromage'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "mac flury":
                    archi = "3m";
                    Form1.cmdtmp.Add("macflury");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='mac_flurry'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "poivre":
                    archi = "4p";
                    Form1.cmdtmp.Add("poivre");
                    break;

                case "vinaigrette":
                    archi = "4v";
                    Form1.cmdtmp.Add("vinaigrette");
                    break;

                case "chocolat":
                    archi = "4c";
                    Form1.cmdtmp.Add("chocolat");
                    break;


                //block pour le texte du bouton 2 
                case "Salades":
                    archi = "2s";
                    Form1.cmdtmp.Add("Salade");
                    break;

                case "big mac":
                    archi = "3b";
                    Form1.cmdtmp.Add("big mac");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='big_mac'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "oriental":
                    archi = "3or";
                    Form1.cmdtmp.Add("oriental");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='oriental'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "sun day":
                    archi = "3s";
                    Form1.cmdtmp.Add("sun day");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='sun_day'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "'":
                    archi = "4k";
                    Form1.cmdtmp.Add("ketchup");
                    break;

                case "balsamic":
                    archi = "4b";
                    Form1.cmdtmp.Add("balsamic");
                    break;

                case "caramel":
                    archi = "4ca";
                    Form1.cmdtmp.Add("caramel");
                    break;

                //block pour le texte du bouton 3
                case "Desserts":
                    archi = "2d";
                    Form1.cmdtmp.Add("Desserts");
                    break;

                case "fish":
                    archi = "3f";
                    Form1.cmdtmp.Add("long fish");
                    ord = "SELECT prix, reduction FROM BURGERS WHERE burger='fish'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "crudite":
                    archi = "3cr";
                    Form1.cmdtmp.Add("crudite");
                    ord = "SELECT prix, reduction FROM SALADES WHERE salade='crudite'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case "cookie":
                    archi = "3co";
                    Form1.cmdtmp.Add("cookie");
                    ord = "SELECT prix, reduction FROM DESSERTS WHERE dessert='cookie'";
                    objcmd = BDD.GetPrixReduc(ord, connection);
                    break;

                case ".":
                    archi = "4m";
                    Form1.cmdtmp.Add("mayonaise");
                    break;

                case "sans sauce":
                    archi = "4ss";
                    Form1.cmdtmp.Add("sans sauce");
                    break;

                case "sans coulie":
                    archi = "4sc";
                    Form1.cmdtmp.Add("sans coul");
                    break;

                //block final (appuie sur le bouton1) 
                case "confirmer":
                    archi = "1";
                    cmdtps = cmdtps + " \r\n " + string.Join(", ", Form1.cmdtmp) + "\t\t" + objcmd + " euros";
                    label1 = Convert.ToString((Convert.ToDecimal(label1) + Convert.ToDecimal(objcmd)));
                    Form1.cmdtmp.Clear();
                    break;

                default:
                    break;
            }
            Form1.res.Clear();
            Form1.res.Add(archi);
            Form1.res.Add(objcmd);
            Form1.res.Add(label1);
            Form1.res.Add(cmdtps);
        }
        */
    }
}

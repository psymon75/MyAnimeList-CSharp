using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Anime
{
    public partial class sql : Form

    {
        const string FICHIERCONFIG = "sqlinfos.txt";
        DBConnect db;
        Form1 frm;
        public sql(Form1 frmin)
        {
            InitializeComponent();
            frm = frmin;
            if (File.Exists(FICHIERCONFIG))
            {
                StreamReader sr = new StreamReader(FICHIERCONFIG);
                string line;
                string infos = "";
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    infos += line+"\n";
                }
                string[] info = infos.Split('\n');
                txbHost.Text = info[0];
                txbDatabase.Text = info[1];
                txbUser.Text = info[2];
                txbPassword.Text = info[3];
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (frm.manga != null)
            {
                db = new DBConnect(txbHost.Text, txbDatabase.Text, txbUser.Text, txbPassword.Text);
                if (db.OpenConnection() == true)
                {
                    listBox1.Items.Add("Connecté au serveur...");
                    listBox1.Items.Add("Create the database strucuture if needed...");
                    listBox1.Items.Add("Check if user is already in DB...");
                    listBox1.Items.Add("Synchronize...");
                    db.Save(frm.manga);
                    db.CloseConnection();
                    frm.db = db;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid informations", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is no anime in list", "No anime listed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveInfos_Click(object sender, EventArgs e)
        {
            string fichier = FICHIERCONFIG;
                StreamWriter sw = null;
                try
                {
                    if (File.Exists(fichier))
                    {
                        File.Delete(fichier);
                    }
                    // Le fichier n'existe pas. On le crée.
                    sw = new StreamWriter(fichier);
                    sw.WriteLine(txbHost.Text);
                    sw.WriteLine(txbDatabase.Text);
                    sw.WriteLine(txbUser.Text);
                    sw.WriteLine(txbPassword.Text);
                    sw.Close();
                    sw = null;
                    // Remarque : On peut utiliser sw = File.AppendText(NomFichier) pour ajouter
                    // du texte à un fichier existant
                    

                }
                finally
                {
                   
                    // Fermeture streamwriter
                    if (sw != null) sw.Close();
                    MessageBox.Show("Informations has been save", "Save informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
    }
}

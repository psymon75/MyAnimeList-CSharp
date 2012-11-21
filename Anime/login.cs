using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;


namespace Anime
{
    
    public partial class login : Form
    {
        WebClient client = new WebClient();
        
        private string pseudo,mdp;

        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            pseudo = txbPseudo.Text.Trim();
            mdp = txbMdp.Text.Trim();

            //string req = "http://mal-api.com/account/verify_credentials";
            //HttpWebRequest request = null;
            //HttpWebResponse response = null;
            

                //request = (HttpWebRequest)WebRequest.Create(req);//OK 200
                //request.Credentials = new NetworkCredential(pseudo, txbMdp.Text);
                //response = (HttpWebResponse)request.GetResponse();
                //if (response.StatusCode.ToString() == "OK")
                //{
                    Form1 frm = new Form1(pseudo,mdp, client);
                    frm.Show();
                    this.Visible = false;
                //}
                //else
                //{
                //    MessageBox.Show("Erreur login");
                //}

                
             
            
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Error.ToString());
            if (e.Error.ToString() == "200" )
            {
                Form1 frm = new Form1(pseudo,mdp, client);
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Mauvaise combinaison");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;


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
            System.Net.ServicePointManager.Expect100Continue = false; 
            string url = "http://myanimelist.net/api/account/verify_credentials.xml";
            WebRequest request = WebRequest.Create(url);

            request.ContentType = "text/xml";
            request.Method = "GET";
            string authInfo = txbPseudo.Text+":"+txbMdp.Text;
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));


            try
            {
                bool ok = false;
                string rep;
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string str = reader.ReadLine();
                while (str != null)
                {
                    str = reader.ReadLine();
                    rep = str;
                    if((rep != null) && (rep.Contains(txbPseudo.Text)))
                    {
                        ok = true;
                    }
                }
                if (ok)
                {
                    pseudo = txbPseudo.Text.Trim();
                    mdp = txbMdp.Text.Trim();
                    MessageBox.Show("Connection réussie !");
                    Form1 frm = new Form1(pseudo, mdp, client);
                    frm.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Erreur de pseudo/mot de passe");
                }
            }
            catch (WebException wex)
            {
                MessageBox.Show("Erreur de pseudo/mot de passe");
            }
            
            

        //    //string req = "http://mal-api.com/account/verify_credentials";
        //    //HttpWebRequest request = null;
        //    //HttpWebResponse response = null;
            

        //        //request = (HttpWebRequest)WebRequest.Create(req);//OK 200
        //        //request.Credentials = new NetworkCredential(pseudo, txbMdp.Text);
        //        //response = (HttpWebResponse)request.GetResponse();
        //        //if (response.StatusCode.ToString() == "OK")
        //        //{
                    
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("Erreur login");
        ////        }

                
             
            
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

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
using MySql.Data.MySqlClient;
using System.Xml;

namespace Anime
{
    public partial class Form1 : Form
    {
        public DBConnect db;

        string pseudo, mdp, currentAnime;
        WebClient client = new WebClient();
        Dictionary<string, string> infos = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> manga = new Dictionary<string, Dictionary<string, string>>();


        public Form1(string pseudoin, string mdpin, WebClient clientin)
        {
            InitializeComponent();
            pseudo = pseudoin;
            mdp = mdpin;
            client = clientin;
            this.Text += " " + pseudo;
            btnSetStatus.Enabled = false;
            toolStripSQLState.Text = "No";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string request = "http://mal-api.com/anime/search?q=" + txbSearch.Text;

            string text = client.DownloadString(request);

            GetAnimeToDictionnary(text);
            showAnimeTitle();
        }

        private void showAnimeTitle()
        {
            listBox1.Items.Clear();
            foreach (KeyValuePair<string, Dictionary<string, string>> pair in manga)
            {
                listBox1.Items.Add(pair.Key);
            }
        }

        private void showAnimeInfos(string name)
        {
            libInfos.Items.Clear();

            currentAnime = name;
            Dictionary<string, string> infos = manga[name];
            foreach (KeyValuePair<string, string> key in infos)
            {
                libInfos.Items.Add(string.Format("{0}{1,10}", key.Key, key.Value).Trim());
                if (key.Key == "id")
                {
                    GetAnimeImg(int.Parse(key.Value));
                    showAnimeTitle();
                }

            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            btnSetStatus.Enabled = true;
            string name = listBox1.Items[listBox1.SelectedIndex].ToString();
            showAnimeInfos(name);
        }



        public void GetAnimeToDictionnary(string list)
        {
            manga = new Dictionary<string, Dictionary<string, string>>();
            infos = new Dictionary<string, string>();
            string title = "";
            listBox1.Items.Clear();
            string[] lines = list.Split(',');
            int size = lines.Length;
            int nb = 1;
            foreach (string st in lines)
            {
                nb++;
                string line = "";
                line = st.TrimStart();
                line = st.TrimEnd();
                if (line.Contains(':'))
                {
                    string[] pair = line.Split(':');

                    for (int i = 0; i < pair.Length - 1; i++)
                    {
                        pair[i] = pair[i].Replace('{', ' ');
                        pair[i] = pair[i].Replace('}', ' ');
                        pair[i] = pair[i].Replace('[', ' ');
                        pair[i] = pair[i].Replace('"', ' ');
                        pair[i] = pair[i].TrimEnd();
                        pair[i] = pair[i].TrimStart();
                    }

                    if (nb == size)
                    {
                        infos.Add(pair[0], pair[1]);
                        if (!manga.ContainsKey(title))
                        {
                            manga.Add(title, infos);
                        }
                    }
                    else
                    {
                        //start of list
                        if (pair[0] == "title")
                        {
                            title = pair[1].Replace('"', ' ');
                            title = title.TrimEnd();
                            title = title.TrimStart();
                            if (!infos.ContainsKey(pair[0]))
                            {
                                infos.Add(pair[0], pair[1]);
                            }
                        }
                        if (pair[0] == "anime")
                        {
                            infos.Add(pair[1], pair[2]);
                        }
                        if (pair[0] == "image_url")
                        {
                            if (!infos.ContainsKey(pair[0]))
                            {
                                infos.Add(pair[0], pair[1] + pair[2]);
                            }
                        }
                        else if (pair[0] == "id")
                        {
                            if (!manga.ContainsKey(title))
                            {
                                manga.Add(title, infos);
                                infos = new Dictionary<string, string>();
                                title = "";
                                infos.Add(pair[0], pair[1]);
                            }
                        }
                        else
                        {
                            if (!infos.ContainsKey(pair[0]))
                            {
                                infos.Add(pair[0], pair[1]);
                            }
                        }
                    }

                }
            }
        }
        public void GetAnimeImg(int id)
        {
            if (client.IsBusy)
            {
                client.CancelAsync();
            }
            string request = "http://mal-api.com/anime/" + id;
            client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(request));
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string[] lines = e.Result.Split(',');
            foreach (string st in lines)
            {
                string[] pair = st.Split(':');
                if (pair[0] == "\"image_url\"")
                {
                    string chemin = pair[1].Replace('"', ' ') + ":" + pair[2].Replace('"', ' ');
                    chemin = chemin.Trim();
                    if (client.IsBusy)
                    {
                        client.CancelAsync();

                    }
                    client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                    client.DownloadDataAsync(new Uri(chemin)); //DownloadData function from here

                }
            }
        }

        void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                byte[] imageData = e.Result;
                MemoryStream stream = new MemoryStream(imageData);
                Image img = Image.FromStream(stream);
                stream.Close();
                pictureBox1.Image = img;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void myAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolstripLoading.Value = 0;

            string request = "http://mal-api.com/animelist/" + pseudo;

            DownloadData(request, "AnimeList");
        }

        private void DownloadData(string request, string type)
        {
            toolstripInfo.Text = "Downloading data...";
            switch (type)
            {
                case "AnimeList":
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadAnimeListCompleted);
                    break;

            }
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);

            client.DownloadStringAsync(new Uri(request));
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            toolstripLoading.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadAnimeListCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            toolstripInfo.Text = "Download complet !";
            GetAnimeToDictionnary(e.Result);
            showAnimeTitle();

        }

        private void toMySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql frm = new sql(this);
            frm.ShowDialog();
            if (this.db != null)
            {
                toolStripSQLState.Text = "OK";
            }
            //DBConnect conn = new DBConnect();
            //conn.Save(manga, pseudo);
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> infos = manga[currentAnime];
            infos["watched_status"] = cmdStatus.SelectedItem.ToString();
            manga[currentAnime] = infos;
            showAnimeInfos(currentAnime);
        }

        private void btnSaveToMAL_Click(object sender, EventArgs e)
        {
            int id = getAnimeId(currentAnime);


        }

        private int getAnimeId(string name)
        {
            Dictionary<string, string> infos = manga[name];
            return int.Parse(infos["id"]);
        }

        private void toXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "";
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Dictionary<string, string>> data in manga)
            {
                XmlDocument xml = new XmlDocument();
                int id = getAnimeId(data.Key);
                XmlElement el = (XmlElement)xml.AppendChild(xml.CreateElement("anime"));
                el.SetAttribute("id", id.ToString());
                foreach (KeyValuePair<string, string> data2 in data.Value)
                {
                    if (data2.Key != "anime")
                    {
                        el.AppendChild(xml.CreateElement(data2.Key)).InnerText = data2.Value;
                    }
                }


                output += IndentXMLString(xml.InnerXml);

            }
            StreamReader sr = null;
            StreamWriter sw = null;
            string line;
            string fichier = "";

            SFD.Filter = "XML File (*.xml)|*.xml|All files (*.*)|*.*";
            SFD.InitialDirectory = Environment.CurrentDirectory;

            if (SFD.ShowDialog() == DialogResult.OK)
            {
                fichier = SFD.FileName;
                try
                {
                    if (File.Exists(fichier))
                    {
                        File.Delete(fichier);
                    }
                    // Le fichier n'existe pas. On le crée.
                    sw = new StreamWriter(fichier);
                    sw.WriteLine(output);
                    sw.Close();
                    sw = null;
                    // Remarque : On peut utiliser sw = File.AppendText(NomFichier) pour ajouter
                    // du texte à un fichier existant
                    

                }
                finally
                {
                    
                    // Fermeture streamreader
                    if (sr != null) sr.Close();
                    // Fermeture streamwriter
                    if (sw != null) sw.Close();
                }
            }

        }
        private static string IndentXMLString(string xml)
        {
            string outXml = string.Empty;
            MemoryStream ms = new MemoryStream();
            // Create a XMLTextWriter that will send its output to a memory stream (file)
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                // Load the unformatted XML text string into an instance 
                // of the XML Document Object Model (DOM)
                doc.LoadXml(xml);

                // Set the formatting property of the XML Text Writer to indented
                // the text writer is where the indenting will be performed
                xtw.Formatting = Formatting.Indented;

                // write dom xml to the xmltextwriter
                doc.WriteContentTo(xtw);
                // Flush the contents of the text writer
                // to the memory stream, which is simply a memory file
                xtw.Flush();

                // set to start of the memory stream (file)
                ms.Seek(0, SeekOrigin.Begin);
                // create a reader to read the contents of 
                // the memory stream (file)
                StreamReader sr = new StreamReader(ms);
                // return the formatted string to caller
                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return string.Empty;
            }
        }

    }
}

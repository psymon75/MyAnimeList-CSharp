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
        public const string FILE_SAVE = "save.xml";
        string pseudo, mdp, currentAnime, currentPseudo;
        WebClient client = new WebClient();
        Dictionary<string, string> infos = new Dictionary<string, string>();
        public Dictionary<string, Dictionary<string, string>> manga = new Dictionary<string, Dictionary<string, string>>();


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

            currentAnime = name;
            Dictionary<string, string> infos = manga[name];
            DataTable table1 = new DataTable("animeinfos");
            table1.Columns.Add("Type");
            table1.Columns.Add("Value");
            foreach (KeyValuePair<string, string> key in infos)
            {
                //libInfos.Items.Add(string.Format("{0}{1,10}", key.Key, key.Value).Trim());
                if (key.Key == "id")
                {
                    GetAnimeImg(int.Parse(key.Value));
                    showAnimeTitle();
                }
                // Create two DataTable instances.
                
                
                table1.Rows.Add(key.Key,key.Value);

                

                
            }
            // Create a DataSet and put both tables in it.
            DataSet set = new DataSet("anime");
            set.Tables.Add(table1);

            // Visualize DataSet.
            string xml = set.GetXml();
            DataSet myDataSet = new DataSet();
            XmlTextReader xmlreader = new XmlTextReader(xml, XmlNodeType.Document, null);
            myDataSet.ReadXml(xmlreader);
            dataGridView1.DataSource = myDataSet.Tables[0];
            dataGridView1.EndEdit();
            dataGridView1.Refresh();
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
            listBox1.Items.Clear();
            string title = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(list);

            XmlNodeList nodelist = doc.GetElementsByTagName("anime");
            for (int i = 0; i < nodelist.Count; i++)
            {
                infos = new Dictionary<string, string>();
                XmlNodeList nodes = nodelist.Item(i).ChildNodes;
                for (int j = 0; j < nodelist.Item(i).ChildNodes.Count; j++)
                {
                    if (nodes.Item(j).Name == "title")
                    {
                        title = nodes.Item(j).InnerText;
                    }
                    infos.Add(nodes.Item(j).Name, nodes.Item(j).InnerText);
                }

                manga.Add(title, infos);
            }

        }
        public void GetAnimeImg(int id)
        {
            if (client.IsBusy)
            {
                client.CancelAsync();
            }
            string request = "http://mal-api.com/anime/" + id + "?format=xml";
            client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri(request));
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(e.Result);
            string chemin = "";

            XmlNodeList nodelist = doc.GetElementsByTagName("anime");
            for (int i = 0; i < nodelist.Count; i++)
            {
                infos = new Dictionary<string, string>();
                XmlNodeList nodes = nodelist.Item(i).ChildNodes;
                for (int j = 0; j < nodelist.Item(i).ChildNodes.Count; j++)
                {
                    if (nodes.Item(j).Name == "image_url")
                    {
                        chemin = nodes.Item(j).InnerText;
                    }
                }
            }


                    if (client.IsBusy)
                    {
                        client.CancelAsync();

                    }
                    client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                    if (client.IsBusy == true)
                    {
                        MessageBox.Show("A download task is actually running.");
                    }
                    else
                    {
                        client.DownloadDataAsync(new Uri(chemin)); //DownloadData function from here
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
            currentAnime = pseudo;
            string request = "http://mal-api.com/animelist/" + pseudo + "?format=xml";

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
                case "AnimeListXml":
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadAnimeListXmlCompleted);
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

#region Download Completed
        void client_DownloadAnimeListCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            toolstripInfo.Text = "Download complet !";
            
            GetAnimeToDictionnary(e.Result);
            showAnimeTitle();

        }

        void client_DownloadAnimeListXmlCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            toolstripInfo.Text = "Download complet !";
            StreamWriter sw;
            string fichier = pseudo + ".xml";
            
                if (File.Exists(fichier))
                {
                    File.Delete(fichier);
                }
                // Le fichier n'existe pas. On le crée.
                sw = new StreamWriter(fichier);
                sw.WriteLine(e.Result);
                sw.Close();
                sw = null;
                // Remarque : On peut utiliser sw = File.AppendText(NomFichier) pour ajouter
                // du texte à un fichier existant
                MessageBox.Show("List saved correctly.");

        }
#endregion
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
            System.Net.ServicePointManager.Expect100Continue = false;
            string status = manga[currentAnime]["watched_status"];
            string epi = manga[currentAnime]["watched_episodes"];
            string score = manga[currentAnime]["score"];

    //        WebRequest request = WebRequest.Create("http://mal-api.com/animelist/anime/"+id);

    //        request.ContentType = "application/x-www-form-urlencoded";
    //        request.Method = "POST";
    //        string authInfo = pseudo + ":" + mdp;
    //        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authInfo));
            string formContent = "status=" + status +
    "&episodes=" + epi + "&score=" + score;

            using (WebClient wc = new WebClient())
            {
                wc.Credentials = new NetworkCredential(pseudo, mdp);
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.UploadData("http://mal-api.com/animelist/anime/" + id, "POST", System.Text.Encoding.ASCII.GetBytes("field1=value1&amp;field2=value2"));
            }

        }

        private int getAnimeId(string name)
        {
            Dictionary<string, string> infos = manga[name];
            return int.Parse(infos["id"]);
        }

        private string animeToXML()
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
            return output;
        }

        private void toXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = animeToXML();
            StreamReader sr = null;
            StreamWriter sw = null;
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

        private void btnSaveDisk_Click(object sender, EventArgs e)
        {
            toolstripLoading.Value = 0;
            currentAnime = pseudo;
            string request = "http://mal-api.com/animelist/" + pseudo + "?format=xml";

            DownloadData(request, "AnimeListXml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.Expect100Continue = false; 
            if (File.Exists(pseudo+".xml"))
            {
                if (MessageBox.Show("Your list has been found on the disk. Do you want to load it ?", "List found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    string get = System.IO.File.ReadAllText(pseudo + ".xml");
                    GetAnimeToDictionnary(get);
                    showAnimeTitle();
                }
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sql frm = new sql(this);
            frm.ShowDialog();
            if (this.db != null)
            {
                toolStripSQLState.Text = "OK";
            }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            toolstripLoading.Value = 0;
            currentAnime = txbUserLIst.Text;
            string request = "http://mal-api.com/animelist/" + txbUserLIst.Text + "?format=xml";

            DownloadData(request, "AnimeList");
        }

    }
}

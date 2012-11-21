using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Anime
{
    public partial class sql : Form

    {
        Form1 frm;
        public sql(Form1 frmin)
        {
            InitializeComponent();
            frm = frmin;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect(txbHost.Text,txbDatabase.Text,txbUser.Text,txbPassword.Text);
            if (db.OpenConnection() == true)
            {
                db.CloseConnection();
                frm.db = db;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid informations", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

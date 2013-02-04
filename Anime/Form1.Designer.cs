namespace Anime
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toMySQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolstripLoading = new System.Windows.Forms.ToolStripProgressBar();
            this.toolstripInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSQLState = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdStatus = new System.Windows.Forms.ComboBox();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.btnSaveToMAL = new System.Windows.Forms.Button();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.btnSaveDisk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUserLIst = new System.Windows.Forms.TextBox();
            this.btnUserList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(272, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Rechercher";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(12, 42);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(254, 20);
            this.txbSearch.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(12, 96);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(334, 256);
            this.listBox1.TabIndex = 2;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.myListToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.mySQLToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1117, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // myListToolStripMenuItem
            // 
            this.myListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myAnimeToolStripMenuItem,
            this.myFavouritesToolStripMenuItem});
            this.myListToolStripMenuItem.Name = "myListToolStripMenuItem";
            this.myListToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.myListToolStripMenuItem.Text = "My List";
            // 
            // myAnimeToolStripMenuItem
            // 
            this.myAnimeToolStripMenuItem.Name = "myAnimeToolStripMenuItem";
            this.myAnimeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.myAnimeToolStripMenuItem.Text = "My Animes";
            this.myAnimeToolStripMenuItem.Click += new System.EventHandler(this.myAnimeToolStripMenuItem_Click);
            // 
            // myFavouritesToolStripMenuItem
            // 
            this.myFavouritesToolStripMenuItem.Name = "myFavouritesToolStripMenuItem";
            this.myFavouritesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.myFavouritesToolStripMenuItem.Text = "My Favourites";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toMySQLToolStripMenuItem,
            this.toFileToolStripMenuItem,
            this.toHTMLToolStripMenuItem,
            this.toXMLToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toMySQLToolStripMenuItem
            // 
            this.toMySQLToolStripMenuItem.Name = "toMySQLToolStripMenuItem";
            this.toMySQLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toMySQLToolStripMenuItem.Text = "To MySQL";
            this.toMySQLToolStripMenuItem.Click += new System.EventHandler(this.toMySQLToolStripMenuItem_Click);
            // 
            // toFileToolStripMenuItem
            // 
            this.toFileToolStripMenuItem.Name = "toFileToolStripMenuItem";
            this.toFileToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toFileToolStripMenuItem.Text = "To File";
            // 
            // toHTMLToolStripMenuItem
            // 
            this.toHTMLToolStripMenuItem.Name = "toHTMLToolStripMenuItem";
            this.toHTMLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toHTMLToolStripMenuItem.Text = "To HTML";
            // 
            // toXMLToolStripMenuItem
            // 
            this.toXMLToolStripMenuItem.Name = "toXMLToolStripMenuItem";
            this.toXMLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.toXMLToolStripMenuItem.Text = "To XML";
            this.toXMLToolStripMenuItem.Click += new System.EventHandler(this.toXMLToolStripMenuItem_Click);
            // 
            // mySQLToolStripMenuItem
            // 
            this.mySQLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.mySQLToolStripMenuItem.Name = "mySQLToolStripMenuItem";
            this.mySQLToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.mySQLToolStripMenuItem.Text = "MySQL";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.connectToolStripMenuItem.Text = "Synchronize this list";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripLoading,
            this.toolstripInfo,
            this.toolStripStatusLabel1,
            this.toolStripSQLState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1117, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolstripLoading
            // 
            this.toolstripLoading.Name = "toolstripLoading";
            this.toolstripLoading.Size = new System.Drawing.Size(100, 16);
            // 
            // toolstripInfo
            // 
            this.toolstripInfo.Name = "toolstripInfo";
            this.toolstripInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel1.Text = "MySQL connexion :";
            // 
            // toolStripSQLState
            // 
            this.toolStripSQLState.Name = "toolStripSQLState";
            this.toolStripSQLState.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(833, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 284);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cmdStatus
            // 
            this.cmdStatus.FormattingEnabled = true;
            this.cmdStatus.Items.AddRange(new object[] {
            "Watched",
            "Plan to watch",
            "Watching"});
            this.cmdStatus.Location = new System.Drawing.Point(415, 359);
            this.cmdStatus.Name = "cmdStatus";
            this.cmdStatus.Size = new System.Drawing.Size(121, 21);
            this.cmdStatus.TabIndex = 7;
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Location = new System.Drawing.Point(585, 357);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(75, 23);
            this.btnSetStatus.TabIndex = 8;
            this.btnSetStatus.Text = "Set status";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // btnSaveToMAL
            // 
            this.btnSaveToMAL.Location = new System.Drawing.Point(691, 357);
            this.btnSaveToMAL.Name = "btnSaveToMAL";
            this.btnSaveToMAL.Size = new System.Drawing.Size(92, 23);
            this.btnSaveToMAL.TabIndex = 9;
            this.btnSaveToMAL.Text = "Save to MAL";
            this.btnSaveToMAL.UseVisualStyleBackColor = true;
            this.btnSaveToMAL.Click += new System.EventHandler(this.btnSaveToMAL_Click);
            // 
            // btnSaveDisk
            // 
            this.btnSaveDisk.Location = new System.Drawing.Point(118, 359);
            this.btnSaveDisk.Name = "btnSaveDisk";
            this.btnSaveDisk.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDisk.TabIndex = 10;
            this.btnSaveDisk.Text = "Save to disk";
            this.btnSaveDisk.UseVisualStyleBackColor = true;
            this.btnSaveDisk.Click += new System.EventHandler(this.btnSaveDisk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Get a user\'s list :";
            // 
            // txbUserLIst
            // 
            this.txbUserLIst.Location = new System.Drawing.Point(99, 65);
            this.txbUserLIst.Name = "txbUserLIst";
            this.txbUserLIst.Size = new System.Drawing.Size(167, 20);
            this.txbUserLIst.TabIndex = 12;
            // 
            // btnUserList
            // 
            this.btnUserList.Location = new System.Drawing.Point(271, 63);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(75, 23);
            this.btnUserList.TabIndex = 13;
            this.btnUserList.Text = "Get";
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.btnUserList_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(367, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(312, 255);
            this.dataGridView1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 419);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUserList);
            this.Controls.Add(this.txbUserLIst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveDisk);
            this.Controls.Add(this.btnSaveToMAL);
            this.Controls.Add(this.btnSetStatus);
            this.Controls.Add(this.cmdStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "My Anime List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myFavouritesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolstripLoading;
        private System.Windows.Forms.ToolStripStatusLabel toolstripInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toMySQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toXMLToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmdStatus;
        private System.Windows.Forms.Button btnSetStatus;
        private System.Windows.Forms.Button btnSaveToMAL;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSQLState;
        private System.Windows.Forms.Button btnSaveDisk;
        private System.Windows.Forms.ToolStripMenuItem mySQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserLIst;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


namespace Anime
{
    partial class sql
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.txbHost = new System.Windows.Forms.TextBox();
            this.txbDatabase = new System.Windows.Forms.TextBox();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(96, 169);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txbHost
            // 
            this.txbHost.Location = new System.Drawing.Point(87, 12);
            this.txbHost.Name = "txbHost";
            this.txbHost.Size = new System.Drawing.Size(100, 20);
            this.txbHost.TabIndex = 1;
            // 
            // txbDatabase
            // 
            this.txbDatabase.Location = new System.Drawing.Point(87, 52);
            this.txbDatabase.Name = "txbDatabase";
            this.txbDatabase.Size = new System.Drawing.Size(100, 20);
            this.txbDatabase.TabIndex = 2;
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(87, 89);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(100, 20);
            this.txbUser.TabIndex = 3;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(87, 127);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(100, 20);
            this.txbPassword.TabIndex = 4;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(43, 18);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 13);
            this.lblHost.TabIndex = 5;
            this.lblHost.Text = "Host :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Database :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password :";
            // 
            // sql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 236);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.txbDatabase);
            this.Controls.Add(this.txbHost);
            this.Controls.Add(this.btnConnect);
            this.Name = "sql";
            this.Text = "MySQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txbHost;
        private System.Windows.Forms.TextBox txbDatabase;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
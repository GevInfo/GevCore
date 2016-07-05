namespace Example_Tchat_Client
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
            this.lbl_IP = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.bt_connect = new System.Windows.Forms.Button();
            this.tb_enter = new System.Windows.Forms.TextBox();
            this.tb_all = new System.Windows.Forms.TextBox();
            this.bt_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(7, 15);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(23, 13);
            this.lbl_IP.TabIndex = 0;
            this.lbl_IP.Text = "IP :";
            // 
            // tb_IP
            // 
            this.tb_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_IP.Location = new System.Drawing.Point(36, 12);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(150, 20);
            this.tb_IP.TabIndex = 1;
            this.tb_IP.Text = "127.0.0.1";
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(54, 38);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(132, 20);
            this.tb_name.TabIndex = 3;
            this.tb_name.Text = "Neross";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(7, 41);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(41, 13);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name :";
            // 
            // bt_connect
            // 
            this.bt_connect.Location = new System.Drawing.Point(54, 74);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(75, 23);
            this.bt_connect.TabIndex = 4;
            this.bt_connect.Text = "Start";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // tb_enter
            // 
            this.tb_enter.Location = new System.Drawing.Point(12, 418);
            this.tb_enter.Name = "tb_enter";
            this.tb_enter.Size = new System.Drawing.Size(395, 20);
            this.tb_enter.TabIndex = 6;
            this.tb_enter.Visible = false;
            // 
            // tb_all
            // 
            this.tb_all.Location = new System.Drawing.Point(12, 12);
            this.tb_all.Multiline = true;
            this.tb_all.Name = "tb_all";
            this.tb_all.ReadOnly = true;
            this.tb_all.Size = new System.Drawing.Size(476, 400);
            this.tb_all.TabIndex = 7;
            this.tb_all.Visible = false;
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(413, 416);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 23);
            this.bt_send.TabIndex = 8;
            this.bt_send.Text = "Send";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Visible = false;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.bt_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 111);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.bt_connect);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tb_IP);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.tb_all);
            this.Controls.Add(this.tb_enter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Example GevCore Tchat";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.TextBox tb_enter;
        private System.Windows.Forms.TextBox tb_all;
        private System.Windows.Forms.Button bt_send;
    }
}


namespace CookUp_Companion
{
    partial class MainForm
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
            this.UserDropMenu = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnUsername = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ProfiliePicture = new System.Windows.Forms.PictureBox();
            this.tbLayoutNavMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnRecipes = new System.Windows.Forms.Button();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnAnnouncement = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.UserDropMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfiliePicture)).BeginInit();
            this.tbLayoutNavMenu.SuspendLayout();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // UserDropMenu
            // 
            this.UserDropMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserDropMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UserDropMenu.Controls.Add(this.pictureBox4);
            this.UserDropMenu.Controls.Add(this.pictureBox3);
            this.UserDropMenu.Controls.Add(this.pictureBox1);
            this.UserDropMenu.Controls.Add(this.btnProfile);
            this.UserDropMenu.Controls.Add(this.btnLogout);
            this.UserDropMenu.Controls.Add(this.btnSetting);
            this.UserDropMenu.Location = new System.Drawing.Point(162, 45);
            this.UserDropMenu.Name = "UserDropMenu";
            this.UserDropMenu.Size = new System.Drawing.Size(175, 143);
            this.UserDropMenu.TabIndex = 9;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::CookUp_Companion.Properties.Resources.logout;
            this.pictureBox4.Location = new System.Drawing.Point(142, 90);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 56);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::CookUp_Companion.Properties.Resources.setting;
            this.pictureBox3.Location = new System.Drawing.Point(142, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::CookUp_Companion.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(142, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.White;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProfile.Location = new System.Drawing.Point(0, 0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(145, 51);
            this.btnProfile.TabIndex = 13;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogout.Location = new System.Drawing.Point(0, 95);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(141, 51);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.White;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSetting.Location = new System.Drawing.Point(0, 48);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(145, 51);
            this.btnSetting.TabIndex = 11;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click_1);
            // 
            // btnUsername
            // 
            this.btnUsername.BackColor = System.Drawing.Color.White;
            this.btnUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsername.FlatAppearance.BorderSize = 0;
            this.btnUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUsername.Location = new System.Drawing.Point(162, -5);
            this.btnUsername.Name = "btnUsername";
            this.btnUsername.Size = new System.Drawing.Size(145, 51);
            this.btnUsername.TabIndex = 9;
            this.btnUsername.Text = "Username";
            this.btnUsername.UseVisualStyleBackColor = false;
            this.btnUsername.Click += new System.EventHandler(this.btnUsername_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::CookUp_Companion.Properties.Resources.down_arrow;
            this.pictureBox2.Location = new System.Drawing.Point(304, -7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // ProfiliePicture
            // 
            this.ProfiliePicture.BackColor = System.Drawing.Color.Transparent;
            this.ProfiliePicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProfiliePicture.Image = global::CookUp_Companion.Properties.Resources.user;
            this.ProfiliePicture.Location = new System.Drawing.Point(0, 0);
            this.ProfiliePicture.Name = "ProfiliePicture";
            this.ProfiliePicture.Size = new System.Drawing.Size(96, 188);
            this.ProfiliePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfiliePicture.TabIndex = 6;
            this.ProfiliePicture.TabStop = false;
            // 
            // tbLayoutNavMenu
            // 
            this.tbLayoutNavMenu.BackColor = System.Drawing.Color.White;
            this.tbLayoutNavMenu.ColumnCount = 6;
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08969F));
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08968F));
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08968F));
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08968F));
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.29843F));
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.40838F));
            this.tbLayoutNavMenu.Controls.Add(this.btnRecipes, 2, 0);
            this.tbLayoutNavMenu.Controls.Add(this.UserPanel, 5, 0);
            this.tbLayoutNavMenu.Controls.Add(this.btnReport, 3, 0);
            this.tbLayoutNavMenu.Controls.Add(this.pbLogo, 0, 0);
            this.tbLayoutNavMenu.Controls.Add(this.btnAnnouncement, 4, 0);
            this.tbLayoutNavMenu.Controls.Add(this.btnUsers, 1, 0);
            this.tbLayoutNavMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLayoutNavMenu.Location = new System.Drawing.Point(0, 0);
            this.tbLayoutNavMenu.Name = "tbLayoutNavMenu";
            this.tbLayoutNavMenu.RowCount = 1;
            this.tbLayoutNavMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutNavMenu.Size = new System.Drawing.Size(1910, 194);
            this.tbLayoutNavMenu.TabIndex = 2;
            // 
            // btnRecipes
            // 
            this.btnRecipes.BackColor = System.Drawing.Color.White;
            this.btnRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipes.FlatAppearance.BorderSize = 0;
            this.btnRecipes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecipes.Location = new System.Drawing.Point(617, 3);
            this.btnRecipes.Name = "btnRecipes";
            this.btnRecipes.Size = new System.Drawing.Size(301, 188);
            this.btnRecipes.TabIndex = 11;
            this.btnRecipes.Text = "Recipes";
            this.btnRecipes.UseVisualStyleBackColor = false;
            this.btnRecipes.Click += new System.EventHandler(this.btnRecipes_Click);
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.UserDropMenu);
            this.UserPanel.Controls.Add(this.ProfiliePicture);
            this.UserPanel.Controls.Add(this.btnUsername);
            this.UserPanel.Controls.Add(this.pictureBox2);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanel.Location = new System.Drawing.Point(1484, 3);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(423, 188);
            this.UserPanel.TabIndex = 10;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(924, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(301, 188);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = global::CookUp_Companion.Properties.Resources.Logo;
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(301, 188);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // btnAnnouncement
            // 
            this.btnAnnouncement.BackColor = System.Drawing.Color.White;
            this.btnAnnouncement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnnouncement.FlatAppearance.BorderSize = 0;
            this.btnAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnouncement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnouncement.Location = new System.Drawing.Point(1231, 3);
            this.btnAnnouncement.Name = "btnAnnouncement";
            this.btnAnnouncement.Size = new System.Drawing.Size(247, 188);
            this.btnAnnouncement.TabIndex = 5;
            this.btnAnnouncement.Text = "Announcement";
            this.btnAnnouncement.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.White;
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.Location = new System.Drawing.Point(307, 0);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(307, 194);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.BackgroundImage = global::CookUp_Companion.Properties.Resources.body;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 194);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1910, 839);
            this.MainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CookUp_Companion.Properties.Resources.body;
            this.ClientSize = new System.Drawing.Size(1910, 1033);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.tbLayoutNavMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.UserDropMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfiliePicture)).EndInit();
            this.tbLayoutNavMenu.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ProfiliePicture;
        private System.Windows.Forms.Panel UserDropMenu;
        private System.Windows.Forms.TableLayoutPanel tbLayoutNavMenu;
        private System.Windows.Forms.Button btnAnnouncement;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnUsername;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRecipes;
        private System.Windows.Forms.Panel MainPanel;
    }
}


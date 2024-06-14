namespace CookUpCompanion.Forms
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
            UserDropMenu = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnProfile = new Button();
            btnLogout = new Button();
            btnSetting = new Button();
            btnUsername = new Button();
            pictureBox2 = new PictureBox();
            ProfiliePicture = new PictureBox();
            tbLayoutNavMenu = new TableLayoutPanel();
            btnRecipes = new Button();
            UserPanel = new Panel();
            btnReport = new Button();
            pbLogo = new PictureBox();
            btnUsers = new Button();
            MainPanel = new Panel();
            UserDropMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProfiliePicture).BeginInit();
            tbLayoutNavMenu.SuspendLayout();
            UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // UserDropMenu
            // 
            UserDropMenu.Anchor = AnchorStyles.None;
            UserDropMenu.BackColor = Color.FromArgb(64, 64, 64);
            UserDropMenu.Controls.Add(pictureBox4);
            UserDropMenu.Controls.Add(pictureBox3);
            UserDropMenu.Controls.Add(pictureBox1);
            UserDropMenu.Controls.Add(btnProfile);
            UserDropMenu.Controls.Add(btnLogout);
            UserDropMenu.Controls.Add(btnSetting);
            UserDropMenu.Location = new Point(142, 42);
            UserDropMenu.Name = "UserDropMenu";
            UserDropMenu.Size = new Size(153, 103);
            UserDropMenu.TabIndex = 9;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.White;
            pictureBox4.Image = Properties.Resources.logout;
            pictureBox4.Location = new Point(124, 68);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 42);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 16;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Image = Properties.Resources.setting;
            pictureBox3.Location = new Point(124, 31);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(29, 38);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(124, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.White;
            btnProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.ForeColor = SystemColors.ActiveCaptionText;
            btnProfile.Location = new Point(0, 0);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(127, 49);
            btnProfile.TabIndex = 13;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = SystemColors.ActiveCaptionText;
            btnLogout.Location = new Point(0, 75);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(127, 43);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnSetting
            // 
            btnSetting.BackColor = Color.White;
            btnSetting.BackgroundImageLayout = ImageLayout.Stretch;
            btnSetting.FlatAppearance.BorderSize = 0;
            btnSetting.FlatStyle = FlatStyle.Flat;
            btnSetting.ForeColor = SystemColors.ActiveCaptionText;
            btnSetting.Location = new Point(0, 40);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(127, 40);
            btnSetting.TabIndex = 11;
            btnSetting.Text = "Setting";
            btnSetting.UseVisualStyleBackColor = false;
            btnSetting.Click += btnSetting_Click_1;
            // 
            // btnUsername
            // 
            btnUsername.BackColor = Color.White;
            btnUsername.BackgroundImageLayout = ImageLayout.Stretch;
            btnUsername.FlatAppearance.BorderSize = 0;
            btnUsername.FlatStyle = FlatStyle.Flat;
            btnUsername.ForeColor = SystemColors.ActiveCaptionText;
            btnUsername.Location = new Point(142, -4);
            btnUsername.Name = "btnUsername";
            btnUsername.Size = new Size(127, 48);
            btnUsername.TabIndex = 9;
            btnUsername.Text = "Username";
            btnUsername.UseVisualStyleBackColor = false;
            btnUsername.Click += btnUsername_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Image = Properties.Resources.down_arrow;
            pictureBox2.Location = new Point(266, -7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 52);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // ProfiliePicture
            // 
            ProfiliePicture.BackColor = Color.Transparent;
            ProfiliePicture.Dock = DockStyle.Left;
            ProfiliePicture.Location = new Point(0, 0);
            ProfiliePicture.Name = "ProfiliePicture";
            ProfiliePicture.Size = new Size(84, 176);
            ProfiliePicture.SizeMode = PictureBoxSizeMode.Zoom;
            ProfiliePicture.TabIndex = 6;
            ProfiliePicture.TabStop = false;
            // 
            // tbLayoutNavMenu
            // 
            tbLayoutNavMenu.BackColor = Color.White;
            tbLayoutNavMenu.ColumnCount = 6;
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.08969F));
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.08968F));
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.08968F));
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.08968F));
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.29843F));
            tbLayoutNavMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.40838F));
            tbLayoutNavMenu.Controls.Add(btnRecipes, 2, 0);
            tbLayoutNavMenu.Controls.Add(UserPanel, 5, 0);
            tbLayoutNavMenu.Controls.Add(btnReport, 3, 0);
            tbLayoutNavMenu.Controls.Add(pbLogo, 0, 0);
            tbLayoutNavMenu.Controls.Add(btnUsers, 1, 0);
            tbLayoutNavMenu.Dock = DockStyle.Top;
            tbLayoutNavMenu.Location = new Point(0, 0);
            tbLayoutNavMenu.Name = "tbLayoutNavMenu";
            tbLayoutNavMenu.RowCount = 1;
            tbLayoutNavMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutNavMenu.Size = new Size(1671, 182);
            tbLayoutNavMenu.TabIndex = 2;
            // 
            // btnRecipes
            // 
            btnRecipes.BackColor = Color.White;
            btnRecipes.Dock = DockStyle.Fill;
            btnRecipes.FlatAppearance.BorderSize = 0;
            btnRecipes.FlatStyle = FlatStyle.Flat;
            btnRecipes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRecipes.Location = new Point(539, 3);
            btnRecipes.Name = "btnRecipes";
            btnRecipes.Size = new Size(262, 176);
            btnRecipes.TabIndex = 11;
            btnRecipes.Text = "Recipes";
            btnRecipes.UseVisualStyleBackColor = false;
            btnRecipes.Click += btnRecipes_Click;
            // 
            // UserPanel
            // 
            UserPanel.Controls.Add(UserDropMenu);
            UserPanel.Controls.Add(ProfiliePicture);
            UserPanel.Controls.Add(btnUsername);
            UserPanel.Controls.Add(pictureBox2);
            UserPanel.Dock = DockStyle.Fill;
            UserPanel.Location = new Point(1297, 3);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(371, 176);
            UserPanel.TabIndex = 10;
            UserPanel.Paint += UserPanel_Paint;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.White;
            btnReport.Dock = DockStyle.Fill;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReport.Location = new Point(807, 3);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(262, 176);
            btnReport.TabIndex = 4;
            btnReport.Text = "Reports";
            btnReport.UseVisualStyleBackColor = false;
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Fill;
            pbLogo.Image = Properties.Resources.Logo;
            pbLogo.Location = new Point(3, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(262, 176);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.White;
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderColor = Color.White;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsers.Location = new Point(268, 0);
            btnUsers.Margin = new Padding(0);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(268, 182);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.BackgroundImage = Properties.Resources.body;
            MainPanel.Dock = DockStyle.Bottom;
            MainPanel.Location = new Point(0, 182);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1671, 609);
            MainPanel.TabIndex = 3;
            MainPanel.Paint += MainPanel_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.body;
            ClientSize = new Size(1671, 791);
            Controls.Add(MainPanel);
            Controls.Add(tbLayoutNavMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            UserDropMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProfiliePicture).EndInit();
            tbLayoutNavMenu.ResumeLayout(false);
            UserPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ProfiliePicture;
        private System.Windows.Forms.Panel UserDropMenu;
        private System.Windows.Forms.TableLayoutPanel tbLayoutNavMenu;
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
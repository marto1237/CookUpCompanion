namespace CookUpCompanion.UserControls
{
    partial class UsersInfoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbFirstname = new Label();
            lbLastName = new Label();
            lbUsername = new Label();
            lbEmail = new Label();
            flpUserInfo = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            MoreOptions = new PictureBox();
            MoreOptionsMenuMenu = new Panel();
            btnChangeRole = new Button();
            btnBanUser = new Button();
            btnMoreInfo = new Button();
            btnLogout = new Button();
            ProfiliePicture = new PictureBox();
            lbRole = new Label();
            flpUserInfo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MoreOptions).BeginInit();
            MoreOptionsMenuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProfiliePicture).BeginInit();
            SuspendLayout();
            // 
            // lbFirstname
            // 
            lbFirstname.Anchor = AnchorStyles.None;
            lbFirstname.AutoSize = true;
            lbFirstname.Location = new Point(546, 41);
            lbFirstname.Name = "lbFirstname";
            lbFirstname.Size = new Size(59, 15);
            lbFirstname.TabIndex = 10;
            lbFirstname.Text = "Firstname";
            // 
            // lbLastName
            // 
            lbLastName.Anchor = AnchorStyles.None;
            lbLastName.AutoSize = true;
            lbLastName.Location = new Point(775, 41);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(58, 15);
            lbLastName.TabIndex = 9;
            lbLastName.Text = "Lastname";
            // 
            // lbUsername
            // 
            lbUsername.Anchor = AnchorStyles.None;
            lbUsername.AutoSize = true;
            lbUsername.Location = new Point(280, 41);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(60, 15);
            lbUsername.TabIndex = 8;
            lbUsername.Text = "Username";
            // 
            // lbEmail
            // 
            lbEmail.Anchor = AnchorStyles.None;
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(1113, 41);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(36, 15);
            lbEmail.TabIndex = 11;
            lbEmail.Text = "Email";
            // 
            // flpUserInfo
            // 
            flpUserInfo.AutoSize = true;
            flpUserInfo.BackColor = Color.White;
            flpUserInfo.ColumnCount = 7;
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.02507F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.03759F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.03759F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.7814F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.07287F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.016194F));
            flpUserInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.62753F));
            flpUserInfo.Controls.Add(tableLayoutPanel1, 6, 0);
            flpUserInfo.Controls.Add(ProfiliePicture, 0, 0);
            flpUserInfo.Controls.Add(lbUsername, 1, 0);
            flpUserInfo.Controls.Add(lbLastName, 3, 0);
            flpUserInfo.Controls.Add(lbFirstname, 2, 0);
            flpUserInfo.Controls.Add(lbEmail, 4, 0);
            flpUserInfo.Controls.Add(lbRole, 5, 0);
            flpUserInfo.Dock = DockStyle.Fill;
            flpUserInfo.Location = new Point(0, 0);
            flpUserInfo.Name = "flpUserInfo";
            flpUserInfo.RowCount = 1;
            flpUserInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            flpUserInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
            flpUserInfo.Size = new Size(1786, 97);
            flpUserInfo.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(MoreOptions, 1, 0);
            tableLayoutPanel1.Controls.Add(MoreOptionsMenuMenu, 0, 0);
            tableLayoutPanel1.Location = new Point(1507, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(196, 91);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // MoreOptions
            // 
            MoreOptions.Anchor = AnchorStyles.None;
            MoreOptions.Image = Properties.Resources.dots;
            MoreOptions.Location = new Point(159, 23);
            MoreOptions.Name = "MoreOptions";
            MoreOptions.Size = new Size(34, 45);
            MoreOptions.SizeMode = PictureBoxSizeMode.Zoom;
            MoreOptions.TabIndex = 13;
            MoreOptions.TabStop = false;
            MoreOptions.Click += MoreOptions_Click_1;
            // 
            // MoreOptionsMenuMenu
            // 
            MoreOptionsMenuMenu.Anchor = AnchorStyles.None;
            MoreOptionsMenuMenu.BackColor = Color.FromArgb(64, 64, 64);
            MoreOptionsMenuMenu.Controls.Add(btnChangeRole);
            MoreOptionsMenuMenu.Controls.Add(btnBanUser);
            MoreOptionsMenuMenu.Controls.Add(btnMoreInfo);
            MoreOptionsMenuMenu.Controls.Add(btnLogout);
            MoreOptionsMenuMenu.Location = new Point(8, 8);
            MoreOptionsMenuMenu.Name = "MoreOptionsMenuMenu";
            MoreOptionsMenuMenu.Size = new Size(140, 74);
            MoreOptionsMenuMenu.TabIndex = 14;
            // 
            // btnChangeRole
            // 
            btnChangeRole.BackColor = Color.White;
            btnChangeRole.BackgroundImageLayout = ImageLayout.Stretch;
            btnChangeRole.FlatAppearance.BorderSize = 0;
            btnChangeRole.FlatStyle = FlatStyle.Flat;
            btnChangeRole.ForeColor = SystemColors.ActiveCaptionText;
            btnChangeRole.Location = new Point(0, 52);
            btnChangeRole.Name = "btnChangeRole";
            btnChangeRole.Size = new Size(140, 22);
            btnChangeRole.TabIndex = 15;
            btnChangeRole.Text = "Change role";
            btnChangeRole.UseVisualStyleBackColor = false;
            btnChangeRole.Click += btnChangeRole_Click;
            // 
            // btnBanUser
            // 
            btnBanUser.BackColor = Color.White;
            btnBanUser.BackgroundImageLayout = ImageLayout.Stretch;
            btnBanUser.FlatAppearance.BorderSize = 0;
            btnBanUser.FlatStyle = FlatStyle.Flat;
            btnBanUser.ForeColor = SystemColors.ActiveCaptionText;
            btnBanUser.Location = new Point(0, 29);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(140, 23);
            btnBanUser.TabIndex = 14;
            btnBanUser.Text = "Ban user";
            btnBanUser.UseVisualStyleBackColor = false;
            btnBanUser.Click += btnBanUser_Click;
            // 
            // btnMoreInfo
            // 
            btnMoreInfo.BackColor = Color.White;
            btnMoreInfo.BackgroundImageLayout = ImageLayout.Stretch;
            btnMoreInfo.FlatAppearance.BorderSize = 0;
            btnMoreInfo.FlatStyle = FlatStyle.Flat;
            btnMoreInfo.ForeColor = SystemColors.ActiveCaptionText;
            btnMoreInfo.Location = new Point(0, 0);
            btnMoreInfo.Name = "btnMoreInfo";
            btnMoreInfo.Size = new Size(140, 33);
            btnMoreInfo.TabIndex = 13;
            btnMoreInfo.Text = "More info";
            btnMoreInfo.UseVisualStyleBackColor = false;
            btnMoreInfo.Click += btnMoreInfo_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = SystemColors.ActiveCaptionText;
            btnLogout.Location = new Point(0, 89);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(123, 48);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // ProfiliePicture
            // 
            ProfiliePicture.BackColor = Color.Transparent;
            ProfiliePicture.Dock = DockStyle.Fill;
            ProfiliePicture.Image = Properties.Resources.user;
            ProfiliePicture.Location = new Point(3, 3);
            ProfiliePicture.Name = "ProfiliePicture";
            ProfiliePicture.Size = new Size(171, 91);
            ProfiliePicture.SizeMode = PictureBoxSizeMode.Zoom;
            ProfiliePicture.TabIndex = 7;
            ProfiliePicture.TabStop = false;
            // 
            // lbRole
            // 
            lbRole.Anchor = AnchorStyles.None;
            lbRole.AutoSize = true;
            lbRole.Location = new Point(1418, 41);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(30, 15);
            lbRole.TabIndex = 12;
            lbRole.Text = "Role";
            // 
            // UsersInfoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flpUserInfo);
            Name = "UsersInfoControl";
            Size = new Size(1786, 97);
            flpUserInfo.ResumeLayout(false);
            flpUserInfo.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MoreOptions).EndInit();
            MoreOptionsMenuMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ProfiliePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lbFirstname;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.PictureBox ProfiliePicture;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TableLayoutPanel flpUserInfo;
        private System.Windows.Forms.PictureBox MoreOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel MoreOptionsMenuMenu;
        private System.Windows.Forms.Button btnMoreInfo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBanUser;
        private System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.Label lbRole;
    }
}

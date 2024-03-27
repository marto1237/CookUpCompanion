namespace CookUp_Companion.Forms
{
    partial class Users
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
            this.tbLayoutNavMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnChangeUserRoles = new System.Windows.Forms.Button();
            this.btnSuspendUser = new System.Windows.Forms.Button();
            this.btnBannedUsers = new System.Windows.Forms.Button();
            this.pUserInfo = new System.Windows.Forms.Panel();
            this.btnUserInformation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpUsersInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.userSearchBar1 = new CookUp_Companion.UserControls.UserSearchBar();
            this.tbLayoutNavMenu.SuspendLayout();
            this.pUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLayoutNavMenu
            // 
            this.tbLayoutNavMenu.BackColor = System.Drawing.Color.White;
            this.tbLayoutNavMenu.ColumnCount = 1;
            this.tbLayoutNavMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbLayoutNavMenu.Controls.Add(this.btnChangeUserRoles, 0, 1);
            this.tbLayoutNavMenu.Controls.Add(this.btnSuspendUser, 0, 2);
            this.tbLayoutNavMenu.Controls.Add(this.btnBannedUsers, 0, 3);
            this.tbLayoutNavMenu.Controls.Add(this.pUserInfo, 0, 0);
            this.tbLayoutNavMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbLayoutNavMenu.Location = new System.Drawing.Point(0, 0);
            this.tbLayoutNavMenu.Name = "tbLayoutNavMenu";
            this.tbLayoutNavMenu.RowCount = 4;
            this.tbLayoutNavMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbLayoutNavMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbLayoutNavMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbLayoutNavMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbLayoutNavMenu.Size = new System.Drawing.Size(379, 1080);
            this.tbLayoutNavMenu.TabIndex = 5;
            // 
            // btnChangeUserRoles
            // 
            this.btnChangeUserRoles.BackColor = System.Drawing.Color.White;
            this.btnChangeUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeUserRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeUserRoles.Location = new System.Drawing.Point(3, 273);
            this.btnChangeUserRoles.Name = "btnChangeUserRoles";
            this.btnChangeUserRoles.Size = new System.Drawing.Size(373, 264);
            this.btnChangeUserRoles.TabIndex = 0;
            this.btnChangeUserRoles.Text = "Change Users roles";
            this.btnChangeUserRoles.UseVisualStyleBackColor = false;
            // 
            // btnSuspendUser
            // 
            this.btnSuspendUser.BackColor = System.Drawing.Color.White;
            this.btnSuspendUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSuspendUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuspendUser.Location = new System.Drawing.Point(3, 543);
            this.btnSuspendUser.Name = "btnSuspendUser";
            this.btnSuspendUser.Size = new System.Drawing.Size(373, 264);
            this.btnSuspendUser.TabIndex = 1;
            this.btnSuspendUser.Text = "Suspend User";
            this.btnSuspendUser.UseVisualStyleBackColor = false;
            // 
            // btnBannedUsers
            // 
            this.btnBannedUsers.BackColor = System.Drawing.Color.White;
            this.btnBannedUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBannedUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBannedUsers.Location = new System.Drawing.Point(3, 813);
            this.btnBannedUsers.Name = "btnBannedUsers";
            this.btnBannedUsers.Size = new System.Drawing.Size(373, 264);
            this.btnBannedUsers.TabIndex = 2;
            this.btnBannedUsers.Text = "Banned Users";
            this.btnBannedUsers.UseVisualStyleBackColor = false;
            // 
            // pUserInfo
            // 
            this.pUserInfo.Controls.Add(this.btnUserInformation);
            this.pUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pUserInfo.Location = new System.Drawing.Point(3, 3);
            this.pUserInfo.Name = "pUserInfo";
            this.pUserInfo.Size = new System.Drawing.Size(373, 264);
            this.pUserInfo.TabIndex = 3;
            // 
            // btnUserInformation
            // 
            this.btnUserInformation.BackColor = System.Drawing.Color.White;
            this.btnUserInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInformation.Location = new System.Drawing.Point(0, 0);
            this.btnUserInformation.Name = "btnUserInformation";
            this.btnUserInformation.Size = new System.Drawing.Size(373, 264);
            this.btnUserInformation.TabIndex = 0;
            this.btnUserInformation.Text = "User Information";
            this.btnUserInformation.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1292, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1749, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // flpUsersInfo
            // 
            this.flpUsersInfo.AutoScroll = true;
            this.flpUsersInfo.BackColor = System.Drawing.Color.White;
            this.flpUsersInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpUsersInfo.Location = new System.Drawing.Point(379, 148);
            this.flpUsersInfo.Name = "flpUsersInfo";
            this.flpUsersInfo.Size = new System.Drawing.Size(1541, 932);
            this.flpUsersInfo.TabIndex = 10;
            // 
            // userSearchBar1
            // 
            this.userSearchBar1.BackColor = System.Drawing.Color.White;
            this.userSearchBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userSearchBar1.Location = new System.Drawing.Point(379, 0);
            this.userSearchBar1.Name = "userSearchBar1";
            this.userSearchBar1.Size = new System.Drawing.Size(1541, 148);
            this.userSearchBar1.TabIndex = 9;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.flpUsersInfo);
            this.Controls.Add(this.userSearchBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLayoutNavMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.tbLayoutNavMenu.ResumeLayout(false);
            this.pUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbLayoutNavMenu;
        private System.Windows.Forms.Panel pUserInfo;
        private System.Windows.Forms.Button btnUserInformation;
        private System.Windows.Forms.Button btnChangeUserRoles;
        private System.Windows.Forms.Button btnSuspendUser;
        private System.Windows.Forms.Button btnBannedUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UserControls.UserSearchBar userSearchBar1;
        private System.Windows.Forms.FlowLayoutPanel flpUsersInfo;
    }
}
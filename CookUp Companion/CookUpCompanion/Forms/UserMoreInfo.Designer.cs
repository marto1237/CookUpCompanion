namespace CookUpCompanion.Forms
{
    partial class UserMoreInfo
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
            pbUserProfile = new PictureBox();
            lbFirstName = new Label();
            lbLastName = new Label();
            lbEmail = new Label();
            lbRole = new Label();
            lbUserFirstname = new Label();
            lbUserLastName = new Label();
            lbUserEmail = new Label();
            lbUserRole = new Label();
            btnDeleteAccount = new Button();
            lbUserRecipes = new LinkLabel();
            lbUserComments = new LinkLabel();
            lbUsername = new Label();
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).BeginInit();
            SuspendLayout();
            // 
            // pbUserProfile
            // 
            pbUserProfile.Anchor = AnchorStyles.None;
            pbUserProfile.Location = new Point(78, 39);
            pbUserProfile.Name = "pbUserProfile";
            pbUserProfile.Size = new Size(210, 185);
            pbUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pbUserProfile.TabIndex = 0;
            pbUserProfile.TabStop = false;
            // 
            // lbFirstName
            // 
            lbFirstName.Anchor = AnchorStyles.None;
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFirstName.Location = new Point(109, 356);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(101, 28);
            lbFirstName.TabIndex = 1;
            lbFirstName.Text = "Firstname:";
            // 
            // lbLastName
            // 
            lbLastName.Anchor = AnchorStyles.None;
            lbLastName.AutoSize = true;
            lbLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbLastName.Location = new Point(112, 465);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(98, 28);
            lbLastName.TabIndex = 2;
            lbLastName.Text = "Lastname:";
            // 
            // lbEmail
            // 
            lbEmail.Anchor = AnchorStyles.None;
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEmail.Location = new Point(546, 356);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(63, 28);
            lbEmail.TabIndex = 3;
            lbEmail.Text = "Email:";
            // 
            // lbRole
            // 
            lbRole.Anchor = AnchorStyles.None;
            lbRole.AutoSize = true;
            lbRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbRole.Location = new Point(546, 465);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(54, 28);
            lbRole.TabIndex = 4;
            lbRole.Text = "Role:";
            // 
            // lbUserFirstname
            // 
            lbUserFirstname.Anchor = AnchorStyles.None;
            lbUserFirstname.AutoSize = true;
            lbUserFirstname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserFirstname.Location = new Point(266, 356);
            lbUserFirstname.Name = "lbUserFirstname";
            lbUserFirstname.Size = new Size(141, 28);
            lbUserFirstname.TabIndex = 5;
            lbUserFirstname.Text = "User Firstname";
            // 
            // lbUserLastName
            // 
            lbUserLastName.Anchor = AnchorStyles.None;
            lbUserLastName.AutoSize = true;
            lbUserLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserLastName.Location = new Point(266, 465);
            lbUserLastName.Name = "lbUserLastName";
            lbUserLastName.Size = new Size(138, 28);
            lbUserLastName.TabIndex = 6;
            lbUserLastName.Text = "User Lastname";
            // 
            // lbUserEmail
            // 
            lbUserEmail.Anchor = AnchorStyles.None;
            lbUserEmail.AutoSize = true;
            lbUserEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserEmail.Location = new Point(649, 356);
            lbUserEmail.Name = "lbUserEmail";
            lbUserEmail.Size = new Size(103, 28);
            lbUserEmail.TabIndex = 7;
            lbUserEmail.Text = "User Email";
            // 
            // lbUserRole
            // 
            lbUserRole.Anchor = AnchorStyles.None;
            lbUserRole.AutoSize = true;
            lbUserRole.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserRole.Location = new Point(649, 465);
            lbUserRole.Name = "lbUserRole";
            lbUserRole.Size = new Size(94, 28);
            lbUserRole.TabIndex = 8;
            lbUserRole.Text = "User Role";
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Anchor = AnchorStyles.None;
            btnDeleteAccount.BackColor = Color.Red;
            btnDeleteAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteAccount.Location = new Point(1051, 50);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(207, 57);
            btnDeleteAccount.TabIndex = 10;
            btnDeleteAccount.Text = "Delete";
            btnDeleteAccount.UseVisualStyleBackColor = false;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // lbUserRecipes
            // 
            lbUserRecipes.AutoSize = true;
            lbUserRecipes.BackColor = Color.Chartreuse;
            lbUserRecipes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserRecipes.ForeColor = SystemColors.ActiveCaptionText;
            lbUserRecipes.Location = new Point(998, 356);
            lbUserRecipes.Name = "lbUserRecipes";
            lbUserRecipes.Padding = new Padding(6);
            lbUserRecipes.Size = new Size(133, 40);
            lbUserRecipes.TabIndex = 11;
            lbUserRecipes.TabStop = true;
            lbUserRecipes.Text = "User Recipes";
            lbUserRecipes.LinkClicked += lbUserRecipes_LinkClicked;
            // 
            // lbUserComments
            // 
            lbUserComments.AutoSize = true;
            lbUserComments.BackColor = Color.Chartreuse;
            lbUserComments.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserComments.ForeColor = SystemColors.ActiveCaptionText;
            lbUserComments.Location = new Point(998, 453);
            lbUserComments.Name = "lbUserComments";
            lbUserComments.Padding = new Padding(6);
            lbUserComments.Size = new Size(162, 40);
            lbUserComments.TabIndex = 12;
            lbUserComments.TabStop = true;
            lbUserComments.Text = "User Comments";
            lbUserComments.LinkClicked += lbUserComments_LinkClicked;
            // 
            // lbUsername
            // 
            lbUsername.Anchor = AnchorStyles.None;
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(522, 117);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(178, 41);
            lbUsername.TabIndex = 13;
            lbUsername.Text = "Userername";
            // 
            // UserMoreInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 605);
            Controls.Add(lbUsername);
            Controls.Add(lbUserComments);
            Controls.Add(lbUserRecipes);
            Controls.Add(btnDeleteAccount);
            Controls.Add(lbUserRole);
            Controls.Add(lbUserEmail);
            Controls.Add(lbUserLastName);
            Controls.Add(lbUserFirstname);
            Controls.Add(lbRole);
            Controls.Add(lbEmail);
            Controls.Add(lbLastName);
            Controls.Add(lbFirstName);
            Controls.Add(pbUserProfile);
            Name = "UserMoreInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserMoreInfo";
            ((System.ComponentModel.ISupportInitialize)pbUserProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbUserProfile;
        private Label lbFirstName;
        private Label lbLastName;
        private Label lbEmail;
        private Label lbRole;
        private Label lbUserFirstname;
        private Label lbUserLastName;
        private Label lbUserEmail;
        private Label lbUserRole;
        private Button btnDeleteAccount;
        private LinkLabel lbUserRecipes;
        private LinkLabel lbUserComments;
        private Label lbUsername;
    }
}
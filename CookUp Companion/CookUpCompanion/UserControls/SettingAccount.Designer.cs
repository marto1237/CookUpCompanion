namespace CookUpCompanion.UserControls
{
    partial class SettingAccount
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
            this.pSettingAccount = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbEditProfile = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbArrowEmail = new System.Windows.Forms.Label();
            this.btnPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbArrowPassword = new System.Windows.Forms.Label();
            this.pSettingAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSettingAccount
            // 
            this.pSettingAccount.Controls.Add(this.lbArrowPassword);
            this.pSettingAccount.Controls.Add(this.label1);
            this.pSettingAccount.Controls.Add(this.btnPassword);
            this.pSettingAccount.Controls.Add(this.lbArrowEmail);
            this.pSettingAccount.Controls.Add(this.lbEmail);
            this.pSettingAccount.Controls.Add(this.btnAccount);
            this.pSettingAccount.Controls.Add(this.lbEditProfile);
            this.pSettingAccount.Controls.Add(this.btnBack);
            this.pSettingAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSettingAccount.Location = new System.Drawing.Point(0, 0);
            this.pSettingAccount.Name = "pSettingAccount";
            this.pSettingAccount.Size = new System.Drawing.Size(646, 385);
            this.pSettingAccount.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(16, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 56);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<-";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbEditProfile
            // 
            this.lbEditProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEditProfile.AutoSize = true;
            this.lbEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProfile.Location = new System.Drawing.Point(235, 33);
            this.lbEditProfile.Name = "lbEditProfile";
            this.lbEditProfile.Size = new System.Drawing.Size(124, 32);
            this.lbEditProfile.TabIndex = 2;
            this.lbEditProfile.Text = "Account";
            // 
            // btnAccount
            // 
            this.btnAccount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAccount.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Location = new System.Drawing.Point(61, 119);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(494, 67);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "Email";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEmail.AutoSize = true;
            this.lbEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbEmail.Location = new System.Drawing.Point(299, 139);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(98, 26);
            this.lbEmail.TabIndex = 4;
            this.lbEmail.Text = "UserEmail";
            // 
            // lbArrowEmail
            // 
            this.lbArrowEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbArrowEmail.AutoSize = true;
            this.lbArrowEmail.BackColor = System.Drawing.Color.Transparent;
            this.lbArrowEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArrowEmail.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbArrowEmail.Location = new System.Drawing.Point(502, 134);
            this.lbArrowEmail.Name = "lbArrowEmail";
            this.lbArrowEmail.Size = new System.Drawing.Size(30, 32);
            this.lbArrowEmail.TabIndex = 8;
            this.lbArrowEmail.Text = ">";
            // 
            // btnPassword
            // 
            this.btnPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPassword.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassword.Location = new System.Drawing.Point(61, 234);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(494, 67);
            this.btnPassword.TabIndex = 9;
            this.btnPassword.Text = "Password";
            this.btnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassword.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(299, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reset password";
            // 
            // lbArrowPassword
            // 
            this.lbArrowPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbArrowPassword.AutoSize = true;
            this.lbArrowPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbArrowPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArrowPassword.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbArrowPassword.Location = new System.Drawing.Point(502, 249);
            this.lbArrowPassword.Name = "lbArrowPassword";
            this.lbArrowPassword.Size = new System.Drawing.Size(30, 32);
            this.lbArrowPassword.TabIndex = 11;
            this.lbArrowPassword.Text = ">";
            // 
            // SettingAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pSettingAccount);
            this.Name = "SettingAccount";
            this.Size = new System.Drawing.Size(646, 385);
            this.pSettingAccount.ResumeLayout(false);
            this.pSettingAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSettingAccount;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbEditProfile;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbArrowPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Label lbArrowEmail;
    }
}

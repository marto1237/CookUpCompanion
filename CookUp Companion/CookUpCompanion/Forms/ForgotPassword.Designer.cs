namespace CookUpCompanion.Forms
{
    partial class ForgotPassword
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
            btnResetPassword = new Button();
            lbReturnToLogin = new Label();
            tbConfirmPassword = new TextBox();
            tbEmail = new TextBox();
            lbEmail = new Label();
            lbConfirmPassword = new Label();
            lbForgotPassword = new Label();
            tbNewPassword = new TextBox();
            lbNewPassword = new Label();
            SuspendLayout();
            // 
            // btnResetPassword
            // 
            btnResetPassword.Anchor = AnchorStyles.None;
            btnResetPassword.BackColor = Color.ForestGreen;
            btnResetPassword.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetPassword.Location = new Point(726, 917);
            btnResetPassword.Margin = new Padding(3, 4, 3, 4);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(470, 91);
            btnResetPassword.TabIndex = 13;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // lbReturnToLogin
            // 
            lbReturnToLogin.Anchor = AnchorStyles.None;
            lbReturnToLogin.AutoSize = true;
            lbReturnToLogin.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbReturnToLogin.ForeColor = Color.YellowGreen;
            lbReturnToLogin.Location = new Point(797, 824);
            lbReturnToLogin.Name = "lbReturnToLogin";
            lbReturnToLogin.Size = new Size(321, 46);
            lbReturnToLogin.TabIndex = 12;
            lbReturnToLogin.Text = "Return to Log In";
            lbReturnToLogin.Click += lbReturnToLogin_Click;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.Anchor = AnchorStyles.None;
            tbConfirmPassword.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbConfirmPassword.ForeColor = SystemColors.InfoText;
            tbConfirmPassword.Location = new Point(982, 641);
            tbConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PasswordChar = '*';
            tbConfirmPassword.Size = new Size(391, 56);
            tbConfirmPassword.TabIndex = 11;
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.None;
            tbEmail.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.ForeColor = SystemColors.InfoText;
            tbEmail.Location = new Point(982, 340);
            tbEmail.Margin = new Padding(3, 4, 3, 4);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(391, 56);
            tbEmail.TabIndex = 10;
            // 
            // lbEmail
            // 
            lbEmail.Anchor = AnchorStyles.None;
            lbEmail.AutoSize = true;
            lbEmail.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = SystemColors.Window;
            lbEmail.Location = new Point(641, 328);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(196, 67);
            lbEmail.TabIndex = 9;
            lbEmail.Text = "Email:";
            // 
            // lbConfirmPassword
            // 
            lbConfirmPassword.Anchor = AnchorStyles.None;
            lbConfirmPassword.AutoSize = true;
            lbConfirmPassword.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbConfirmPassword.ForeColor = SystemColors.Window;
            lbConfirmPassword.Location = new Point(304, 629);
            lbConfirmPassword.Name = "lbConfirmPassword";
            lbConfirmPassword.Size = new Size(533, 67);
            lbConfirmPassword.TabIndex = 8;
            lbConfirmPassword.Text = "Confirm Password:";
            // 
            // lbForgotPassword
            // 
            lbForgotPassword.Anchor = AnchorStyles.None;
            lbForgotPassword.AutoSize = true;
            lbForgotPassword.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbForgotPassword.ForeColor = SystemColors.ControlLightLight;
            lbForgotPassword.Location = new Point(759, 137);
            lbForgotPassword.Name = "lbForgotPassword";
            lbForgotPassword.Size = new Size(479, 67);
            lbForgotPassword.TabIndex = 7;
            lbForgotPassword.Text = "Forgot Password";
            // 
            // tbNewPassword
            // 
            tbNewPassword.Anchor = AnchorStyles.None;
            tbNewPassword.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNewPassword.ForeColor = SystemColors.InfoText;
            tbNewPassword.Location = new Point(982, 497);
            tbNewPassword.Margin = new Padding(3, 4, 3, 4);
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.PasswordChar = '*';
            tbNewPassword.Size = new Size(391, 56);
            tbNewPassword.TabIndex = 15;
            // 
            // lbNewPassword
            // 
            lbNewPassword.Anchor = AnchorStyles.None;
            lbNewPassword.AutoSize = true;
            lbNewPassword.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbNewPassword.ForeColor = SystemColors.Window;
            lbNewPassword.Location = new Point(411, 483);
            lbNewPassword.Name = "lbNewPassword";
            lbNewPassword.Size = new Size(426, 67);
            lbNewPassword.TabIndex = 14;
            lbNewPassword.Text = "New Password";
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1902, 1055);
            Controls.Add(tbNewPassword);
            Controls.Add(lbNewPassword);
            Controls.Add(btnResetPassword);
            Controls.Add(lbReturnToLogin);
            Controls.Add(tbConfirmPassword);
            Controls.Add(tbEmail);
            Controls.Add(lbEmail);
            Controls.Add(lbConfirmPassword);
            Controls.Add(lbForgotPassword);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lbReturnToLogin;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.Label lbForgotPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lbNewPassword;
    }
}
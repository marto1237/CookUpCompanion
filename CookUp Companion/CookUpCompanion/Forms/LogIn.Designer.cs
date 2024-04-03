namespace CookUpCompanion.Forms
{
    partial class LogIn
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
            lbLogIn = new Label();
            lbPassword = new Label();
            lbUsername = new Label();
            tbEmail = new TextBox();
            tbPassword = new TextBox();
            lbForgotPassword = new Label();
            btnLogIn = new Button();
            revealPassword = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)revealPassword).BeginInit();
            SuspendLayout();
            // 
            // lbLogIn
            // 
            lbLogIn.Anchor = AnchorStyles.None;
            lbLogIn.AutoSize = true;
            lbLogIn.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLogIn.ForeColor = SystemColors.ControlLightLight;
            lbLogIn.Location = new Point(843, 127);
            lbLogIn.Name = "lbLogIn";
            lbLogIn.Size = new Size(194, 67);
            lbLogIn.TabIndex = 0;
            lbLogIn.Text = "Log In";
            // 
            // lbPassword
            // 
            lbPassword.Anchor = AnchorStyles.None;
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbPassword.ForeColor = SystemColors.Window;
            lbPassword.Location = new Point(546, 641);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(291, 67);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Password";
            // 
            // lbUsername
            // 
            lbUsername.Anchor = AnchorStyles.None;
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Microsoft Sans Serif", 34.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUsername.ForeColor = SystemColors.Window;
            lbUsername.Location = new Point(546, 399);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(196, 67);
            lbUsername.TabIndex = 2;
            lbUsername.Text = "Email:";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = AnchorStyles.None;
            tbEmail.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbEmail.ForeColor = SystemColors.InfoText;
            tbEmail.Location = new Point(997, 410);
            tbEmail.Margin = new Padding(3, 4, 3, 4);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(391, 56);
            tbEmail.TabIndex = 3;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.None;
            tbPassword.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.ForeColor = SystemColors.InfoText;
            tbPassword.Location = new Point(997, 653);
            tbPassword.Margin = new Padding(3, 4, 3, 4);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(391, 56);
            tbPassword.TabIndex = 4;
            // 
            // lbForgotPassword
            // 
            lbForgotPassword.Anchor = AnchorStyles.None;
            lbForgotPassword.AutoSize = true;
            lbForgotPassword.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbForgotPassword.ForeColor = Color.YellowGreen;
            lbForgotPassword.Location = new Point(809, 788);
            lbForgotPassword.Name = "lbForgotPassword";
            lbForgotPassword.Size = new Size(333, 46);
            lbForgotPassword.TabIndex = 5;
            lbForgotPassword.Text = "Forgot password";
            lbForgotPassword.Click += lbForgotPassword_Click;
            // 
            // btnLogIn
            // 
            btnLogIn.Anchor = AnchorStyles.None;
            btnLogIn.BackColor = Color.ForestGreen;
            btnLogIn.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogIn.Location = new Point(738, 881);
            btnLogIn.Margin = new Padding(3, 4, 3, 4);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(470, 91);
            btnLogIn.TabIndex = 6;
            btnLogIn.Text = "Log in";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // revealPassword
            // 
            revealPassword.Anchor = AnchorStyles.None;
            revealPassword.Image = Properties.Resources.eye;
            revealPassword.Location = new Point(1411, 641);
            revealPassword.Margin = new Padding(3, 4, 3, 4);
            revealPassword.Name = "revealPassword";
            revealPassword.Size = new Size(58, 71);
            revealPassword.SizeMode = PictureBoxSizeMode.Zoom;
            revealPassword.TabIndex = 7;
            revealPassword.TabStop = false;
            revealPassword.MouseDown += revealPassword_MouseDown;
            revealPassword.MouseUp += revealPassword_MouseUp;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1902, 1055);
            Controls.Add(revealPassword);
            Controls.Add(btnLogIn);
            Controls.Add(lbForgotPassword);
            Controls.Add(tbPassword);
            Controls.Add(tbEmail);
            Controls.Add(lbUsername);
            Controls.Add(lbPassword);
            Controls.Add(lbLogIn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)revealPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbLogIn;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbForgotPassword;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.PictureBox revealPassword;
    }
}
namespace CookUpCompanion.Forms
{
    partial class UnbanUser
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
            lbUnbanUser = new Label();
            label1 = new Label();
            lbUserUsername = new Label();
            btnUnban = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lbUnbanUser
            // 
            lbUnbanUser.Anchor = AnchorStyles.None;
            lbUnbanUser.AutoSize = true;
            lbUnbanUser.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbUnbanUser.Location = new Point(273, 41);
            lbUnbanUser.Name = "lbUnbanUser";
            lbUnbanUser.Size = new Size(219, 50);
            lbUnbanUser.TabIndex = 0;
            lbUnbanUser.Text = "Unban user";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(167, 166);
            label1.Name = "label1";
            label1.Size = new Size(457, 28);
            label1.TabIndex = 1;
            label1.Text = "Are you sure you want to actvate the banned user ?";
            // 
            // lbUserUsername
            // 
            lbUserUsername.Anchor = AnchorStyles.None;
            lbUserUsername.AutoSize = true;
            lbUserUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserUsername.Location = new Point(347, 245);
            lbUserUsername.Name = "lbUserUsername";
            lbUserUsername.Size = new Size(99, 28);
            lbUserUsername.TabIndex = 2;
            lbUserUsername.Text = "Username";
            // 
            // btnUnban
            // 
            btnUnban.Anchor = AnchorStyles.None;
            btnUnban.BackColor = Color.Chartreuse;
            btnUnban.FlatStyle = FlatStyle.Popup;
            btnUnban.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnban.Location = new Point(185, 370);
            btnUnban.Name = "btnUnban";
            btnUnban.Size = new Size(123, 44);
            btnUnban.TabIndex = 3;
            btnUnban.Text = "Unban";
            btnUnban.UseVisualStyleBackColor = false;
            btnUnban.Click += btnUnban_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.OrangeRed;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(429, 370);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(123, 44);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // UnbanUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(btnUnban);
            Controls.Add(lbUserUsername);
            Controls.Add(label1);
            Controls.Add(lbUnbanUser);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UnbanUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UnbanUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbUnbanUser;
        private Label label1;
        private Label lbUserUsername;
        private Button btnUnban;
        private Button btnClose;
    }
}
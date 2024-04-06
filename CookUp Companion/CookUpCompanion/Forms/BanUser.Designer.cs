namespace CookUpCompanion.Forms
{
    partial class BanUser
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
            lbBanUser = new Label();
            lbNotification = new Label();
            lbUserNames = new Label();
            label1 = new Label();
            rbInappropriateBehavior = new RadioButton();
            rbContentBan = new RadioButton();
            rBAccountSuspension = new RadioButton();
            lbReason = new Label();
            rtbReason = new RichTextBox();
            btnBan = new Button();
            SuspendLayout();
            // 
            // lbBanUser
            // 
            lbBanUser.Anchor = AnchorStyles.None;
            lbBanUser.AutoSize = true;
            lbBanUser.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBanUser.Location = new Point(36, 83);
            lbBanUser.Name = "lbBanUser";
            lbBanUser.Size = new Size(176, 50);
            lbBanUser.TabIndex = 0;
            lbBanUser.Text = "Ban User";
            // 
            // lbNotification
            // 
            lbNotification.Anchor = AnchorStyles.None;
            lbNotification.AutoSize = true;
            lbNotification.BackColor = Color.BlanchedAlmond;
            lbNotification.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNotification.ForeColor = SystemColors.ActiveCaptionText;
            lbNotification.Location = new Point(36, 188);
            lbNotification.Name = "lbNotification";
            lbNotification.Padding = new Padding(6);
            lbNotification.Size = new Size(239, 43);
            lbNotification.TabIndex = 1;
            lbNotification.Text = "You are about to ban";
            // 
            // lbUserNames
            // 
            lbUserNames.Anchor = AnchorStyles.None;
            lbUserNames.AutoSize = true;
            lbUserNames.BackColor = Color.BlanchedAlmond;
            lbUserNames.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUserNames.ForeColor = SystemColors.ActiveCaptionText;
            lbUserNames.Location = new Point(270, 188);
            lbUserNames.Name = "lbUserNames";
            lbUserNames.Padding = new Padding(6);
            lbUserNames.Size = new Size(130, 43);
            lbUserNames.TabIndex = 2;
            lbUserNames.Text = "John Cena";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 284);
            label1.Name = "label1";
            label1.Size = new Size(430, 38);
            label1.TabIndex = 3;
            label1.Text = "Why are you banning this user?";
            // 
            // rbInappropriateBehavior
            // 
            rbInappropriateBehavior.Anchor = AnchorStyles.None;
            rbInappropriateBehavior.AutoSize = true;
            rbInappropriateBehavior.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbInappropriateBehavior.Location = new Point(36, 368);
            rbInappropriateBehavior.Name = "rbInappropriateBehavior";
            rbInappropriateBehavior.Size = new Size(235, 32);
            rbInappropriateBehavior.TabIndex = 4;
            rbInappropriateBehavior.TabStop = true;
            rbInappropriateBehavior.Text = "Inappropriate behavior";
            rbInappropriateBehavior.UseVisualStyleBackColor = true;
            rbInappropriateBehavior.CheckedChanged += rbInappropriateBehavior_CheckedChanged;
            // 
            // rbContentBan
            // 
            rbContentBan.Anchor = AnchorStyles.None;
            rbContentBan.AutoSize = true;
            rbContentBan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbContentBan.Location = new Point(36, 428);
            rbContentBan.Name = "rbContentBan";
            rbContentBan.Size = new Size(140, 32);
            rbContentBan.TabIndex = 5;
            rbContentBan.TabStop = true;
            rbContentBan.Text = "Content Ban";
            rbContentBan.UseVisualStyleBackColor = true;
            rbContentBan.CheckedChanged += rbContentBan_CheckedChanged;
            // 
            // rBAccountSuspension
            // 
            rBAccountSuspension.Anchor = AnchorStyles.None;
            rBAccountSuspension.AutoSize = true;
            rBAccountSuspension.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rBAccountSuspension.Location = new Point(36, 490);
            rBAccountSuspension.Name = "rBAccountSuspension";
            rBAccountSuspension.Size = new Size(209, 32);
            rBAccountSuspension.TabIndex = 6;
            rBAccountSuspension.TabStop = true;
            rBAccountSuspension.Text = "Account Suspension";
            rBAccountSuspension.UseVisualStyleBackColor = true;
            rBAccountSuspension.CheckedChanged += rBAccountSuspension_CheckedChanged;
            // 
            // lbReason
            // 
            lbReason.Anchor = AnchorStyles.None;
            lbReason.AutoSize = true;
            lbReason.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbReason.Location = new Point(36, 544);
            lbReason.Name = "lbReason";
            lbReason.Size = new Size(90, 31);
            lbReason.TabIndex = 7;
            lbReason.Text = "Reason";
            // 
            // rtbReason
            // 
            rtbReason.Anchor = AnchorStyles.None;
            rtbReason.Location = new Point(46, 587);
            rtbReason.Name = "rtbReason";
            rtbReason.Size = new Size(881, 88);
            rtbReason.TabIndex = 8;
            rtbReason.Text = "";
            // 
            // btnBan
            // 
            btnBan.Anchor = AnchorStyles.None;
            btnBan.BackColor = Color.Red;
            btnBan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBan.Location = new Point(442, 689);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(92, 49);
            btnBan.TabIndex = 9;
            btnBan.Text = "Ban";
            btnBan.UseVisualStyleBackColor = false;
            btnBan.Click += btnBan_Click;
            // 
            // BanUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1053, 750);
            Controls.Add(btnBan);
            Controls.Add(rtbReason);
            Controls.Add(lbReason);
            Controls.Add(rBAccountSuspension);
            Controls.Add(rbContentBan);
            Controls.Add(rbInappropriateBehavior);
            Controls.Add(label1);
            Controls.Add(lbUserNames);
            Controls.Add(lbNotification);
            Controls.Add(lbBanUser);
            Name = "BanUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BanUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbBanUser;
        private Label lbNotification;
        private Label lbUserNames;
        private Label label1;
        private RadioButton rbInappropriateBehavior;
        private RadioButton rbContentBan;
        private RadioButton rBAccountSuspension;
        private Label lbReason;
        private RichTextBox rtbReason;
        private Button btnBan;
    }
}
namespace CookUpCompanion.Forms
{
    partial class ChangeRole
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
            lbRoles = new Label();
            label2 = new Label();
            lbUsername = new Label();
            cbRoles = new ComboBox();
            btnUpdateRole = new Button();
            SuspendLayout();
            // 
            // lbRoles
            // 
            lbRoles.Anchor = AnchorStyles.None;
            lbRoles.AutoSize = true;
            lbRoles.Location = new Point(552, 194);
            lbRoles.Name = "lbRoles";
            lbRoles.Size = new Size(45, 20);
            lbRoles.TabIndex = 0;
            lbRoles.Text = "Roles";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 45);
            label2.Name = "label2";
            label2.Size = new Size(254, 41);
            label2.TabIndex = 1;
            label2.Text = "Change user role";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(88, 248);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(99, 28);
            lbUsername.TabIndex = 2;
            lbUsername.Text = "Username";
            // 
            // cbRoles
            // 
            cbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(504, 248);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(151, 28);
            cbRoles.TabIndex = 3;
            // 
            // btnUpdateRole
            // 
            btnUpdateRole.BackColor = Color.DeepSkyBlue;
            btnUpdateRole.Location = new Point(287, 378);
            btnUpdateRole.Name = "btnUpdateRole";
            btnUpdateRole.Size = new Size(192, 48);
            btnUpdateRole.TabIndex = 4;
            btnUpdateRole.Text = "Update Role";
            btnUpdateRole.UseVisualStyleBackColor = false;
            btnUpdateRole.Click += btnUpdateRole_Click;
            // 
            // ChangeRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateRole);
            Controls.Add(cbRoles);
            Controls.Add(lbUsername);
            Controls.Add(label2);
            Controls.Add(lbRoles);
            Name = "ChangeRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangeRole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbRoles;
        private Label label2;
        private Label lbUsername;
        private ComboBox cbRoles;
        private Button btnUpdateRole;
    }
}
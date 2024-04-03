namespace CookUpCompanion.UserControls
{
    partial class UserSearchBar
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
            tbSearchUser = new TextBox();
            lbNumUser = new Label();
            pSearchIcon = new PictureBox();
            cbTypeOfUser = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pSearchIcon).BeginInit();
            SuspendLayout();
            // 
            // tbSearchUser
            // 
            tbSearchUser.Anchor = AnchorStyles.None;
            tbSearchUser.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchUser.Location = new Point(293, 97);
            tbSearchUser.Margin = new Padding(3, 4, 3, 4);
            tbSearchUser.Name = "tbSearchUser";
            tbSearchUser.Size = new Size(496, 41);
            tbSearchUser.TabIndex = 0;
            // 
            // lbNumUser
            // 
            lbNumUser.Anchor = AnchorStyles.None;
            lbNumUser.AutoSize = true;
            lbNumUser.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNumUser.Location = new Point(261, 22);
            lbNumUser.Name = "lbNumUser";
            lbNumUser.Size = new Size(144, 29);
            lbNumUser.TabIndex = 1;
            lbNumUser.Text = "Users(1337)";
            // 
            // pSearchIcon
            // 
            pSearchIcon.Anchor = AnchorStyles.None;
            pSearchIcon.BackColor = Color.White;
            pSearchIcon.Image = Properties.Resources.magnifying_glass;
            pSearchIcon.Location = new Point(251, 91);
            pSearchIcon.Margin = new Padding(3, 4, 3, 4);
            pSearchIcon.Name = "pSearchIcon";
            pSearchIcon.Size = new Size(36, 51);
            pSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pSearchIcon.TabIndex = 15;
            pSearchIcon.TabStop = false;
            // 
            // cbTypeOfUser
            // 
            cbTypeOfUser.Anchor = AnchorStyles.None;
            cbTypeOfUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbTypeOfUser.FormattingEnabled = true;
            cbTypeOfUser.Items.AddRange(new object[] { "All Users", "Banned Users" });
            cbTypeOfUser.Location = new Point(1111, 101);
            cbTypeOfUser.Name = "cbTypeOfUser";
            cbTypeOfUser.Size = new Size(300, 39);
            cbTypeOfUser.TabIndex = 16;
            cbTypeOfUser.SelectedIndexChanged += cbTypeOfUser_SelectedIndexChanged;
            // 
            // UserSearchBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(cbTypeOfUser);
            Controls.Add(pSearchIcon);
            Controls.Add(lbNumUser);
            Controls.Add(tbSearchUser);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UserSearchBar";
            Size = new Size(1491, 185);
            Load += UserSearchBar_Load;
            Enter += UserSearchBar_Enter;
            Leave += UserSearchBar_Leave;
            ((System.ComponentModel.ISupportInitialize)pSearchIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbSearchUser;
        private System.Windows.Forms.Label lbNumUser;
        private System.Windows.Forms.PictureBox pSearchIcon;
        private ComboBox cbTypeOfUser;
    }
}

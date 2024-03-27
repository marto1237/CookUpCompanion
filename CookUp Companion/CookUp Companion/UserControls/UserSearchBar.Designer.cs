namespace CookUp_Companion.UserControls
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
            this.tbSearchUser = new System.Windows.Forms.TextBox();
            this.lbNumUser = new System.Windows.Forms.Label();
            this.pSearchIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pSearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchUser
            // 
            this.tbSearchUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchUser.Location = new System.Drawing.Point(73, 81);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.Size = new System.Drawing.Size(496, 41);
            this.tbSearchUser.TabIndex = 0;
            // 
            // lbNumUser
            // 
            this.lbNumUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNumUser.AutoSize = true;
            this.lbNumUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumUser.Location = new System.Drawing.Point(13, 18);
            this.lbNumUser.Name = "lbNumUser";
            this.lbNumUser.Size = new System.Drawing.Size(144, 29);
            this.lbNumUser.TabIndex = 1;
            this.lbNumUser.Text = "Users(1337)";
            // 
            // pSearchIcon
            // 
            this.pSearchIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pSearchIcon.BackColor = System.Drawing.Color.White;
            this.pSearchIcon.Image = global::CookUp_Companion.Properties.Resources.magnifying_glass;
            this.pSearchIcon.Location = new System.Drawing.Point(31, 81);
            this.pSearchIcon.Name = "pSearchIcon";
            this.pSearchIcon.Size = new System.Drawing.Size(36, 41);
            this.pSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pSearchIcon.TabIndex = 15;
            this.pSearchIcon.TabStop = false;
            // 
            // UserSearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pSearchIcon);
            this.Controls.Add(this.lbNumUser);
            this.Controls.Add(this.tbSearchUser);
            this.Name = "UserSearchBar";
            this.Size = new System.Drawing.Size(994, 148);
            this.Load += new System.EventHandler(this.UserSearchBar_Load);
            this.Enter += new System.EventHandler(this.UserSearchBar_Enter);
            this.Leave += new System.EventHandler(this.UserSearchBar_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pSearchIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearchUser;
        private System.Windows.Forms.Label lbNumUser;
        private System.Windows.Forms.PictureBox pSearchIcon;
    }
}

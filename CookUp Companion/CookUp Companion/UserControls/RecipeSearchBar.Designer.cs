namespace CookUp_Companion.UserControls
{
    partial class RecipeSearchBar
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
            this.lbNumUser = new System.Windows.Forms.Label();
            this.tbSearchUser = new System.Windows.Forms.TextBox();
            this.pSearchIcon = new System.Windows.Forms.PictureBox();
            this.lbImage = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbCreator = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pSearchIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumUser
            // 
            this.lbNumUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNumUser.AutoSize = true;
            this.lbNumUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumUser.Location = new System.Drawing.Point(94, 0);
            this.lbNumUser.Name = "lbNumUser";
            this.lbNumUser.Size = new System.Drawing.Size(102, 29);
            this.lbNumUser.TabIndex = 17;
            this.lbNumUser.Text = "Recipes";
            // 
            // tbSearchUser
            // 
            this.tbSearchUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchUser.Location = new System.Drawing.Point(562, 3);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.Size = new System.Drawing.Size(496, 41);
            this.tbSearchUser.TabIndex = 16;
            // 
            // pSearchIcon
            // 
            this.pSearchIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pSearchIcon.BackColor = System.Drawing.Color.White;
            this.pSearchIcon.Image = global::CookUp_Companion.Properties.Resources.magnifying_glass;
            this.pSearchIcon.Location = new System.Drawing.Point(520, 3);
            this.pSearchIcon.Name = "pSearchIcon";
            this.pSearchIcon.Size = new System.Drawing.Size(36, 41);
            this.pSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pSearchIcon.TabIndex = 18;
            this.pSearchIcon.TabStop = false;
            // 
            // lbImage
            // 
            this.lbImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbImage.AutoSize = true;
            this.lbImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImage.Location = new System.Drawing.Point(109, 59);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(54, 20);
            this.lbImage.TabIndex = 19;
            this.lbImage.Text = "Image";
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(388, 59);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(41, 20);
            this.lbTitle.TabIndex = 20;
            this.lbTitle.Text = "Title";
            // 
            // lbCreator
            // 
            this.lbCreator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCreator.AutoSize = true;
            this.lbCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreator.Location = new System.Drawing.Point(669, 59);
            this.lbCreator.Name = "lbCreator";
            this.lbCreator.Size = new System.Drawing.Size(65, 20);
            this.lbCreator.TabIndex = 21;
            this.lbCreator.Text = "Creator";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(936, 59);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(46, 20);
            this.lbTime.TabIndex = 22;
            this.lbTime.Text = "Time";
            // 
            // RecipeSearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbCreator);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.pSearchIcon);
            this.Controls.Add(this.lbNumUser);
            this.Controls.Add(this.tbSearchUser);
            this.Name = "RecipeSearchBar";
            this.Size = new System.Drawing.Size(1116, 92);
            ((System.ComponentModel.ISupportInitialize)(this.pSearchIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pSearchIcon;
        private System.Windows.Forms.Label lbNumUser;
        private System.Windows.Forms.TextBox tbSearchUser;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbCreator;
        private System.Windows.Forms.Label lbTime;
    }
}

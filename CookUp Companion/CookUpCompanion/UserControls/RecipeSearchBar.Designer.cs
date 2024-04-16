namespace CookUpCompanion.UserControls
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
            lbNumRecipes = new Label();
            tbSearchRecipe = new TextBox();
            pSearchIcon = new PictureBox();
            lbImage = new Label();
            lbTitle = new Label();
            lbCreator = new Label();
            lbTime = new Label();
            lbCookingTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pSearchIcon).BeginInit();
            SuspendLayout();
            // 
            // lbNumRecipes
            // 
            lbNumRecipes.Anchor = AnchorStyles.None;
            lbNumRecipes.AutoSize = true;
            lbNumRecipes.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNumRecipes.Location = new Point(348, 6);
            lbNumRecipes.Name = "lbNumRecipes";
            lbNumRecipes.Size = new Size(170, 29);
            lbNumRecipes.TabIndex = 17;
            lbNumRecipes.Text = "Recipes(1337)";
            // 
            // tbSearchRecipe
            // 
            tbSearchRecipe.Anchor = AnchorStyles.None;
            tbSearchRecipe.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchRecipe.Location = new Point(833, 6);
            tbSearchRecipe.Margin = new Padding(3, 4, 3, 4);
            tbSearchRecipe.Name = "tbSearchRecipe";
            tbSearchRecipe.Size = new Size(496, 41);
            tbSearchRecipe.TabIndex = 16;
            tbSearchRecipe.TextChanged += tbSearchRecipe_TextChanged;
            tbSearchRecipe.Enter += tbSearchRecipe_Enter;
            tbSearchRecipe.Leave += tbSearchRecipe_Leave;
            // 
            // pSearchIcon
            // 
            pSearchIcon.Anchor = AnchorStyles.None;
            pSearchIcon.BackColor = Color.White;
            pSearchIcon.Image = Properties.Resources.magnifying_glass;
            pSearchIcon.Location = new Point(791, 6);
            pSearchIcon.Margin = new Padding(3, 4, 3, 4);
            pSearchIcon.Name = "pSearchIcon";
            pSearchIcon.Size = new Size(36, 51);
            pSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pSearchIcon.TabIndex = 18;
            pSearchIcon.TabStop = false;
            pSearchIcon.Click += pSearchIcon_Click;
            // 
            // lbImage
            // 
            lbImage.Anchor = AnchorStyles.None;
            lbImage.AutoSize = true;
            lbImage.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbImage.Location = new Point(40, 76);
            lbImage.Name = "lbImage";
            lbImage.Size = new Size(54, 20);
            lbImage.TabIndex = 19;
            lbImage.Text = "Image";
            // 
            // lbTitle
            // 
            lbTitle.Anchor = AnchorStyles.None;
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(383, 76);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(41, 20);
            lbTitle.TabIndex = 20;
            lbTitle.Text = "Title";
            // 
            // lbCreator
            // 
            lbCreator.Anchor = AnchorStyles.None;
            lbCreator.AutoSize = true;
            lbCreator.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCreator.Location = new Point(727, 76);
            lbCreator.Name = "lbCreator";
            lbCreator.Size = new Size(65, 20);
            lbCreator.TabIndex = 21;
            lbCreator.Text = "Creator";
            // 
            // lbTime
            // 
            lbTime.Anchor = AnchorStyles.None;
            lbTime.AutoSize = true;
            lbTime.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTime.Location = new Point(990, 76);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(86, 20);
            lbTime.TabIndex = 22;
            lbTime.Text = "Prep Time";
            // 
            // lbCookingTime
            // 
            lbCookingTime.Anchor = AnchorStyles.None;
            lbCookingTime.AutoSize = true;
            lbCookingTime.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCookingTime.Location = new Point(1236, 76);
            lbCookingTime.Name = "lbCookingTime";
            lbCookingTime.Size = new Size(111, 20);
            lbCookingTime.TabIndex = 23;
            lbCookingTime.Text = "Cooking Time";
            // 
            // RecipeSearchBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbCookingTime);
            Controls.Add(lbTime);
            Controls.Add(lbCreator);
            Controls.Add(lbTitle);
            Controls.Add(lbImage);
            Controls.Add(pSearchIcon);
            Controls.Add(lbNumRecipes);
            Controls.Add(tbSearchRecipe);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RecipeSearchBar";
            Size = new Size(1658, 118);
            Load += RecipeSearchBar_Load;
            ((System.ComponentModel.ISupportInitialize)pSearchIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pSearchIcon;
        private System.Windows.Forms.Label lbNumRecipes;
        private System.Windows.Forms.TextBox tbSearchRecipe;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbCreator;
        private System.Windows.Forms.Label lbTime;
        private Label lbCookingTime;
    }
}

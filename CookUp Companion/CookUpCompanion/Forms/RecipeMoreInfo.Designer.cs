namespace CookUpCompanion.Forms
{
    partial class RecipeMoreInfo
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
            pbRecipePicture = new PictureBox();
            lbCreator = new Label();
            lbRecipeName = new Label();
            rtbDescription = new RichTextBox();
            lbIngredients = new Label();
            flpIngredients = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).BeginInit();
            SuspendLayout();
            // 
            // pbRecipePicture
            // 
            pbRecipePicture.Anchor = AnchorStyles.None;
            pbRecipePicture.Image = Properties.Resources.Logo;
            pbRecipePicture.Location = new Point(42, 40);
            pbRecipePicture.Name = "pbRecipePicture";
            pbRecipePicture.Size = new Size(358, 338);
            pbRecipePicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbRecipePicture.TabIndex = 0;
            pbRecipePicture.TabStop = false;
            // 
            // lbCreator
            // 
            lbCreator.Anchor = AnchorStyles.None;
            lbCreator.AutoSize = true;
            lbCreator.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCreator.Location = new Point(522, 40);
            lbCreator.Name = "lbCreator";
            lbCreator.Size = new Size(67, 28);
            lbCreator.TabIndex = 1;
            lbCreator.Text = "Cretor";
            // 
            // lbRecipeName
            // 
            lbRecipeName.Anchor = AnchorStyles.None;
            lbRecipeName.AutoSize = true;
            lbRecipeName.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRecipeName.Location = new Point(522, 105);
            lbRecipeName.Name = "lbRecipeName";
            lbRecipeName.Size = new Size(221, 46);
            lbRecipeName.TabIndex = 2;
            lbRecipeName.Text = "Recipe name";
            // 
            // rtbDescription
            // 
            rtbDescription.Anchor = AnchorStyles.None;
            rtbDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.Location = new Point(522, 181);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(572, 197);
            rtbDescription.TabIndex = 3;
            rtbDescription.Text = "";
            // 
            // lbIngredients
            // 
            lbIngredients.Anchor = AnchorStyles.None;
            lbIngredients.AutoSize = true;
            lbIngredients.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIngredients.Location = new Point(269, 409);
            lbIngredients.Name = "lbIngredients";
            lbIngredients.Size = new Size(203, 46);
            lbIngredients.TabIndex = 4;
            lbIngredients.Text = "Ingredients";
            // 
            // flpIngredients
            // 
            flpIngredients.Location = new Point(23, 484);
            flpIngredients.Name = "flpIngredients";
            flpIngredients.Size = new Size(720, 471);
            flpIngredients.TabIndex = 5;
            // 
            // RecipeMoreInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 985);
            Controls.Add(flpIngredients);
            Controls.Add(lbIngredients);
            Controls.Add(rtbDescription);
            Controls.Add(lbRecipeName);
            Controls.Add(lbCreator);
            Controls.Add(pbRecipePicture);
            Name = "RecipeMoreInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecipeMoreInfo";
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbRecipePicture;
        private Label lbCreator;
        private Label lbRecipeName;
        private RichTextBox rtbDescription;
        private Label lbIngredients;
        private FlowLayoutPanel flpIngredients;
    }
}
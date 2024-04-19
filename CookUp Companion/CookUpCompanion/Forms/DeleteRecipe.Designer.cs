namespace CookUpCompanion.Forms
{
    partial class DeleteRecipe
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
            lbIngredients = new Label();
            flpIngredients = new FlowLayoutPanel();
            lbCreator = new Label();
            LBtbRecipeName = new Label();
            lbDescription = new Label();
            lbInstructions = new Label();
            btnClose = new Button();
            btnDeleteRecipe = new Button();
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).BeginInit();
            SuspendLayout();
            // 
            // pbRecipePicture
            // 
            pbRecipePicture.Anchor = AnchorStyles.None;
            pbRecipePicture.Image = Properties.Resources.Logo;
            pbRecipePicture.Location = new Point(68, 12);
            pbRecipePicture.Name = "pbRecipePicture";
            pbRecipePicture.Size = new Size(408, 358);
            pbRecipePicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbRecipePicture.TabIndex = 1;
            pbRecipePicture.TabStop = false;
            // 
            // lbIngredients
            // 
            lbIngredients.Anchor = AnchorStyles.None;
            lbIngredients.AutoSize = true;
            lbIngredients.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIngredients.Location = new Point(335, 400);
            lbIngredients.Name = "lbIngredients";
            lbIngredients.Size = new Size(203, 46);
            lbIngredients.TabIndex = 5;
            lbIngredients.Text = "Ingredients";
            // 
            // flpIngredients
            // 
            flpIngredients.Anchor = AnchorStyles.None;
            flpIngredients.Location = new Point(68, 461);
            flpIngredients.Name = "flpIngredients";
            flpIngredients.Size = new Size(720, 471);
            flpIngredients.TabIndex = 6;
            // 
            // lbCreator
            // 
            lbCreator.Anchor = AnchorStyles.None;
            lbCreator.AutoSize = true;
            lbCreator.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCreator.Location = new Point(574, 23);
            lbCreator.Name = "lbCreator";
            lbCreator.Size = new Size(67, 28);
            lbCreator.TabIndex = 7;
            lbCreator.Text = "Cretor";
            // 
            // LBtbRecipeName
            // 
            LBtbRecipeName.Anchor = AnchorStyles.None;
            LBtbRecipeName.AutoSize = true;
            LBtbRecipeName.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBtbRecipeName.Location = new Point(574, 96);
            LBtbRecipeName.Name = "LBtbRecipeName";
            LBtbRecipeName.Size = new Size(173, 38);
            LBtbRecipeName.TabIndex = 8;
            LBtbRecipeName.Text = "RecipeName";
            // 
            // lbDescription
            // 
            lbDescription.Anchor = AnchorStyles.None;
            lbDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDescription.Location = new Point(574, 172);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(560, 264);
            lbDescription.TabIndex = 9;
            lbDescription.Text = "Description";
            // 
            // lbInstructions
            // 
            lbInstructions.Anchor = AnchorStyles.None;
            lbInstructions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbInstructions.Location = new Point(814, 461);
            lbInstructions.Name = "lbInstructions";
            lbInstructions.Size = new Size(532, 471);
            lbInstructions.TabIndex = 10;
            lbInstructions.Text = "Instructions";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.OrangeRed;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(1216, 23);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(85, 48);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Anchor = AnchorStyles.None;
            btnDeleteRecipe.BackColor = Color.Crimson;
            btnDeleteRecipe.FlatStyle = FlatStyle.Popup;
            btnDeleteRecipe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteRecipe.Location = new Point(639, 978);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(375, 65);
            btnDeleteRecipe.TabIndex = 12;
            btnDeleteRecipe.Text = "Delete recipe";
            btnDeleteRecipe.UseVisualStyleBackColor = false;
            btnDeleteRecipe.Click += btnDeleteRecipe_Click;
            // 
            // DeleteRecipe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1358, 1055);
            Controls.Add(btnDeleteRecipe);
            Controls.Add(btnClose);
            Controls.Add(lbInstructions);
            Controls.Add(lbDescription);
            Controls.Add(LBtbRecipeName);
            Controls.Add(lbCreator);
            Controls.Add(flpIngredients);
            Controls.Add(lbIngredients);
            Controls.Add(pbRecipePicture);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DeleteRecipe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DeleteRecipe";
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbRecipePicture;
        private Label lbIngredients;
        private FlowLayoutPanel flpIngredients;
        private Label lbCreator;
        private Label LBtbRecipeName;
        private Label lbDescription;
        private Label lbInstructions;
        private Button btnClose;
        private Button btnDeleteRecipe;
    }
}
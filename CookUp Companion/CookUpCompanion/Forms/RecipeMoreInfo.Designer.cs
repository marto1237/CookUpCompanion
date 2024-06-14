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
            rtbDescription = new RichTextBox();
            lbIngredients = new Label();
            flpIngredients = new FlowLayoutPanel();
            rtbInstructions = new RichTextBox();
            btnSave = new Button();
            btnClose = new Button();
            tbRecipeName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).BeginInit();
            SuspendLayout();
            // 
            // pbRecipePicture
            // 
            pbRecipePicture.Anchor = AnchorStyles.None;
            pbRecipePicture.Image = Properties.Resources.Logo;
            pbRecipePicture.Location = new Point(42, 75);
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
            lbCreator.Location = new Point(522, 75);
            lbCreator.Name = "lbCreator";
            lbCreator.Size = new Size(67, 28);
            lbCreator.TabIndex = 1;
            lbCreator.Text = "Cretor";
            // 
            // rtbDescription
            // 
            rtbDescription.Anchor = AnchorStyles.None;
            rtbDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.Location = new Point(522, 216);
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
            lbIngredients.Location = new Point(269, 444);
            lbIngredients.Name = "lbIngredients";
            lbIngredients.Size = new Size(203, 46);
            lbIngredients.TabIndex = 4;
            lbIngredients.Text = "Ingredients";
            // 
            // flpIngredients
            // 
            flpIngredients.AutoScroll = true;
            flpIngredients.Location = new Point(23, 484);
            flpIngredients.Name = "flpIngredients";
            flpIngredients.Size = new Size(720, 471);
            flpIngredients.TabIndex = 5;
            // 
            // rtbInstructions
            // 
            rtbInstructions.Location = new Point(781, 484);
            rtbInstructions.Name = "rtbInstructions";
            rtbInstructions.Size = new Size(471, 471);
            rtbInstructions.TabIndex = 6;
            rtbInstructions.Text = "";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.Chartreuse;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(541, 999);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 44);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.BackColor = Color.OrangeRed;
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(750, 999);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(123, 44);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // tbRecipeName
            // 
            tbRecipeName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbRecipeName.Location = new Point(781, 150);
            tbRecipeName.Name = "tbRecipeName";
            tbRecipeName.Size = new Size(302, 34);
            tbRecipeName.TabIndex = 9;
            // 
            // RecipeMoreInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 1055);
            Controls.Add(tbRecipeName);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(rtbInstructions);
            Controls.Add(flpIngredients);
            Controls.Add(lbIngredients);
            Controls.Add(rtbDescription);
            Controls.Add(lbCreator);
            Controls.Add(pbRecipePicture);
            FormBorderStyle = FormBorderStyle.None;
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
        private RichTextBox rtbDescription;
        private Label lbIngredients;
        private FlowLayoutPanel flpIngredients;
        private RichTextBox rtbInstructions;
        private Button btnSave;
        private Button btnClose;
        private TextBox tbRecipeName;
    }
}
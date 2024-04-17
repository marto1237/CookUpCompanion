namespace CookUpCompanion.UserControls
{
    partial class IngredientInfo
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
            pbIngredient = new PictureBox();
            lbIngredient = new Label();
            lbUnit = new Label();
            lbQuantitiy = new Label();
            ((System.ComponentModel.ISupportInitialize)pbIngredient).BeginInit();
            SuspendLayout();
            // 
            // pbIngredient
            // 
            pbIngredient.Anchor = AnchorStyles.None;
            pbIngredient.Image = Properties.Resources.Logo;
            pbIngredient.Location = new Point(0, 0);
            pbIngredient.Name = "pbIngredient";
            pbIngredient.Size = new Size(185, 143);
            pbIngredient.SizeMode = PictureBoxSizeMode.Zoom;
            pbIngredient.TabIndex = 0;
            pbIngredient.TabStop = false;
            // 
            // lbIngredient
            // 
            lbIngredient.AutoSize = true;
            lbIngredient.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbIngredient.Location = new Point(191, 58);
            lbIngredient.Name = "lbIngredient";
            lbIngredient.Size = new Size(143, 23);
            lbIngredient.TabIndex = 1;
            lbIngredient.Text = "ingredient name";
            // 
            // lbUnit
            // 
            lbUnit.AutoSize = true;
            lbUnit.Location = new Point(537, 65);
            lbUnit.Name = "lbUnit";
            lbUnit.Size = new Size(34, 20);
            lbUnit.TabIndex = 2;
            lbUnit.Text = "unit";
            // 
            // lbQuantitiy
            // 
            lbQuantitiy.AutoSize = true;
            lbQuantitiy.Location = new Point(491, 65);
            lbQuantitiy.Name = "lbQuantitiy";
            lbQuantitiy.Size = new Size(17, 20);
            lbQuantitiy.TabIndex = 3;
            lbQuantitiy.Text = "2";
            // 
            // IngredientInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbQuantitiy);
            Controls.Add(lbUnit);
            Controls.Add(lbIngredient);
            Controls.Add(pbIngredient);
            Name = "IngredientInfo";
            Size = new Size(676, 143);
            ((System.ComponentModel.ISupportInitialize)pbIngredient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbIngredient;
        private Label lbIngredient;
        private Label lbUnit;
        private Label lbQuantitiy;
    }
}

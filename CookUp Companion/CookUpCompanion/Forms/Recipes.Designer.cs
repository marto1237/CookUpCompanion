namespace CookUpCompanion.Forms
{
    partial class Recipes
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
            paginationControl1 = new UserControls.paginationControl();
            flpRecipesInfo = new FlowLayoutPanel();
            recipeSearchBar1 = new UserControls.RecipeSearchBar();
            SuspendLayout();
            // 
            // paginationControl1
            // 
            paginationControl1.BackColor = SystemColors.ControlLightLight;
            paginationControl1.Dock = DockStyle.Bottom;
            paginationControl1.Location = new Point(0, 729);
            paginationControl1.Margin = new Padding(3, 2, 3, 2);
            paginationControl1.Name = "paginationControl1";
            paginationControl1.Size = new Size(1664, 96);
            paginationControl1.TabIndex = 10;
            // 
            // flpRecipesInfo
            // 
            flpRecipesInfo.AutoScroll = true;
            flpRecipesInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpRecipesInfo.FlowDirection = FlowDirection.TopDown;
            flpRecipesInfo.Location = new Point(0, 108);
            flpRecipesInfo.Name = "flpRecipesInfo";
            flpRecipesInfo.Size = new Size(1864, 624);
            flpRecipesInfo.TabIndex = 0;
            flpRecipesInfo.WrapContents = false;
            // 
            // recipeSearchBar1
            // 
            recipeSearchBar1.BackColor = SystemColors.ControlLightLight;
            recipeSearchBar1.Dock = DockStyle.Top;
            recipeSearchBar1.Location = new Point(0, 0);
            recipeSearchBar1.Name = "recipeSearchBar1";
            recipeSearchBar1.Size = new Size(1664, 108);
            recipeSearchBar1.TabIndex = 11;
            // 
            // Recipes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1664, 825);
            Controls.Add(recipeSearchBar1);
            Controls.Add(paginationControl1);
            Controls.Add(flpRecipesInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Recipes";
            Text = "Recipes";
            Load += Recipes_Load;
            ResumeLayout(false);
        }

        #endregion
        private UserControls.paginationControl paginationControl1;
        private FlowLayoutPanel flpRecipesInfo;
        private UserControls.RecipeSearchBar recipeSearchBar1;
    }
}
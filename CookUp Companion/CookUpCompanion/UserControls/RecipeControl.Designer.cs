﻿namespace CookUpCompanion.UserControls
{
    partial class RecipeControl
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
            pbRecipePicture = new PictureBox();
            lbRecipeName = new Label();
            lbRecipeCreator = new Label();
            lbCookTime = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            MoreOptions = new PictureBox();
            MoreOptionsMenuMenu = new Panel();
            btnDeleteRecipe = new Button();
            btnMoreInfo = new Button();
            btnLogout = new Button();
            lbPrepTime = new Label();
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MoreOptions).BeginInit();
            MoreOptionsMenuMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pbRecipePicture
            // 
            pbRecipePicture.Anchor = AnchorStyles.None;
            pbRecipePicture.Image = Properties.Resources.Logo;
            pbRecipePicture.Location = new Point(127, 2);
            pbRecipePicture.Name = "pbRecipePicture";
            pbRecipePicture.Size = new Size(213, 118);
            pbRecipePicture.SizeMode = PictureBoxSizeMode.Zoom;
            pbRecipePicture.TabIndex = 0;
            pbRecipePicture.TabStop = false;
            // 
            // lbRecipeName
            // 
            lbRecipeName.Anchor = AnchorStyles.None;
            lbRecipeName.AutoSize = true;
            lbRecipeName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbRecipeName.Location = new Point(367, 52);
            lbRecipeName.Name = "lbRecipeName";
            lbRecipeName.Size = new Size(91, 17);
            lbRecipeName.TabIndex = 1;
            lbRecipeName.Text = "Recipe name";
            // 
            // lbRecipeCreator
            // 
            lbRecipeCreator.Anchor = AnchorStyles.None;
            lbRecipeCreator.AutoSize = true;
            lbRecipeCreator.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbRecipeCreator.Location = new Point(742, 52);
            lbRecipeCreator.Name = "lbRecipeCreator";
            lbRecipeCreator.Size = new Size(101, 17);
            lbRecipeCreator.TabIndex = 3;
            lbRecipeCreator.Text = "Recipe creator";
            // 
            // lbCookTime
            // 
            lbCookTime.Anchor = AnchorStyles.None;
            lbCookTime.AutoSize = true;
            lbCookTime.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbCookTime.Location = new Point(1233, 52);
            lbCookTime.Name = "lbCookTime";
            lbCookTime.Size = new Size(71, 17);
            lbCookTime.TabIndex = 4;
            lbCookTime.Text = "CookTime";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(MoreOptions, 1, 0);
            tableLayoutPanel1.Controls.Add(MoreOptionsMenuMenu, 0, 0);
            tableLayoutPanel1.Location = new Point(1334, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(196, 91);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // MoreOptions
            // 
            MoreOptions.Anchor = AnchorStyles.None;
            MoreOptions.Image = Properties.Resources.dots;
            MoreOptions.Location = new Point(159, 23);
            MoreOptions.Name = "MoreOptions";
            MoreOptions.Size = new Size(34, 45);
            MoreOptions.SizeMode = PictureBoxSizeMode.Zoom;
            MoreOptions.TabIndex = 13;
            MoreOptions.TabStop = false;
            MoreOptions.Click += MoreOptions_Click;
            // 
            // MoreOptionsMenuMenu
            // 
            MoreOptionsMenuMenu.Anchor = AnchorStyles.None;
            MoreOptionsMenuMenu.BackColor = Color.FromArgb(64, 64, 64);
            MoreOptionsMenuMenu.Controls.Add(btnDeleteRecipe);
            MoreOptionsMenuMenu.Controls.Add(btnMoreInfo);
            MoreOptionsMenuMenu.Controls.Add(btnLogout);
            MoreOptionsMenuMenu.Location = new Point(8, 16);
            MoreOptionsMenuMenu.Name = "MoreOptionsMenuMenu";
            MoreOptionsMenuMenu.Size = new Size(140, 59);
            MoreOptionsMenuMenu.TabIndex = 14;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.BackColor = Color.White;
            btnDeleteRecipe.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteRecipe.FlatAppearance.BorderSize = 0;
            btnDeleteRecipe.FlatStyle = FlatStyle.Flat;
            btnDeleteRecipe.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteRecipe.Location = new Point(0, 29);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(140, 30);
            btnDeleteRecipe.TabIndex = 15;
            btnDeleteRecipe.Text = "Delete Recipe";
            btnDeleteRecipe.UseVisualStyleBackColor = false;
            btnDeleteRecipe.Click += btnDeleteRecipe_Click;
            // 
            // btnMoreInfo
            // 
            btnMoreInfo.BackColor = Color.White;
            btnMoreInfo.BackgroundImageLayout = ImageLayout.Stretch;
            btnMoreInfo.FlatAppearance.BorderSize = 0;
            btnMoreInfo.FlatStyle = FlatStyle.Flat;
            btnMoreInfo.ForeColor = SystemColors.ActiveCaptionText;
            btnMoreInfo.Location = new Point(0, 0);
            btnMoreInfo.Name = "btnMoreInfo";
            btnMoreInfo.Size = new Size(140, 32);
            btnMoreInfo.TabIndex = 13;
            btnMoreInfo.Text = "More info";
            btnMoreInfo.UseVisualStyleBackColor = false;
            btnMoreInfo.Click += btnMoreInfo_Click_1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = SystemColors.ActiveCaptionText;
            btnLogout.Location = new Point(0, 89);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(123, 48);
            btnLogout.TabIndex = 12;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // lbPrepTime
            // 
            lbPrepTime.Anchor = AnchorStyles.None;
            lbPrepTime.AutoSize = true;
            lbPrepTime.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPrepTime.Location = new Point(1022, 52);
            lbPrepTime.Name = "lbPrepTime";
            lbPrepTime.Size = new Size(69, 17);
            lbPrepTime.TabIndex = 11;
            lbPrepTime.Text = "PrepTime";
            // 
            // RecipeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbPrepTime);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lbCookTime);
            Controls.Add(lbRecipeCreator);
            Controls.Add(lbRecipeName);
            Controls.Add(pbRecipePicture);
            Name = "RecipeControl";
            Size = new Size(1786, 124);
            ((System.ComponentModel.ISupportInitialize)pbRecipePicture).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MoreOptions).EndInit();
            MoreOptionsMenuMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbRecipePicture;
        private System.Windows.Forms.Label lbRecipeName;
        private System.Windows.Forms.Label lbRecipeCreator;
        private System.Windows.Forms.Label lbCookTime;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox MoreOptions;
        private Panel MoreOptionsMenuMenu;
        private Button btnDeleteRecipe;
        private Button btnMoreInfo;
        private Button btnLogout;
        private Label lbPrepTime;
    }
}

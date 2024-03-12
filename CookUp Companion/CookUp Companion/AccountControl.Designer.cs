namespace CookUp_Companion
{
    partial class AccountControl
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
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbFamilyName = new System.Windows.Forms.Label();
            this.btnEditPrifile = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pAccount = new System.Windows.Forms.Panel();
            this.btnNewRecipe = new System.Windows.Forms.Button();
            this.lbRecipes = new System.Windows.Forms.Label();
            this.ProfilePicture = new System.Windows.Forms.PictureBox();
            this.pbAddNewRecipe = new System.Windows.Forms.PictureBox();
            this.pAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewRecipe)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.Location = new System.Drawing.Point(842, 80);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(168, 36);
            this.lbFirstName.TabIndex = 1;
            this.lbFirstName.Text = "First Name";
            // 
            // lbFamilyName
            // 
            this.lbFamilyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbFamilyName.AutoSize = true;
            this.lbFamilyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFamilyName.Location = new System.Drawing.Point(1089, 80);
            this.lbFamilyName.Name = "lbFamilyName";
            this.lbFamilyName.Size = new System.Drawing.Size(197, 36);
            this.lbFamilyName.TabIndex = 2;
            this.lbFamilyName.Text = "Family Name";
            // 
            // btnEditPrifile
            // 
            this.btnEditPrifile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditPrifile.BackColor = System.Drawing.Color.Transparent;
            this.btnEditPrifile.FlatAppearance.BorderSize = 0;
            this.btnEditPrifile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPrifile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPrifile.Location = new System.Drawing.Point(1394, 80);
            this.btnEditPrifile.Name = "btnEditPrifile";
            this.btnEditPrifile.Size = new System.Drawing.Size(164, 41);
            this.btnEditPrifile.TabIndex = 3;
            this.btnEditPrifile.Text = "Edit Profile";
            this.btnEditPrifile.UseVisualStyleBackColor = false;
            this.btnEditPrifile.Click += new System.EventHandler(this.btnEditPrifile_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(1768, 110);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(31, 551);
            this.vScrollBar1.TabIndex = 5;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // pAccount
            // 
            this.pAccount.BackColor = System.Drawing.Color.Transparent;
            this.pAccount.Controls.Add(this.btnNewRecipe);
            this.pAccount.Controls.Add(this.lbRecipes);
            this.pAccount.Controls.Add(this.ProfilePicture);
            this.pAccount.Controls.Add(this.vScrollBar1);
            this.pAccount.Controls.Add(this.lbFirstName);
            this.pAccount.Controls.Add(this.btnEditPrifile);
            this.pAccount.Controls.Add(this.pbAddNewRecipe);
            this.pAccount.Controls.Add(this.lbFamilyName);
            this.pAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAccount.Location = new System.Drawing.Point(0, 0);
            this.pAccount.Name = "pAccount";
            this.pAccount.Size = new System.Drawing.Size(1910, 839);
            this.pAccount.TabIndex = 6;
            // 
            // btnNewRecipe
            // 
            this.btnNewRecipe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNewRecipe.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNewRecipe.FlatAppearance.BorderSize = 0;
            this.btnNewRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRecipe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewRecipe.Location = new System.Drawing.Point(952, 611);
            this.btnNewRecipe.Name = "btnNewRecipe";
            this.btnNewRecipe.Size = new System.Drawing.Size(215, 50);
            this.btnNewRecipe.TabIndex = 7;
            this.btnNewRecipe.Text = "Create a new recipe";
            this.btnNewRecipe.UseVisualStyleBackColor = false;
            // 
            // lbRecipes
            // 
            this.lbRecipes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbRecipes.AutoSize = true;
            this.lbRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecipes.Location = new System.Drawing.Point(842, 533);
            this.lbRecipes.Name = "lbRecipes";
            this.lbRecipes.Size = new System.Drawing.Size(406, 32);
            this.lbRecipes.TabIndex = 6;
            this.lbRecipes.Text = "No recipes published just yet";
            // 
            // ProfilePicture
            // 
            this.ProfilePicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProfilePicture.Image = global::CookUp_Companion.Properties.Resources.user;
            this.ProfilePicture.InitialImage = global::CookUp_Companion.Properties.Resources.user;
            this.ProfilePicture.Location = new System.Drawing.Point(571, 16);
            this.ProfilePicture.Name = "ProfilePicture";
            this.ProfilePicture.Size = new System.Drawing.Size(166, 163);
            this.ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProfilePicture.TabIndex = 0;
            this.ProfilePicture.TabStop = false;
            // 
            // pbAddNewRecipe
            // 
            this.pbAddNewRecipe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbAddNewRecipe.Image = global::CookUp_Companion.Properties.Resources._774b1c8f2a87e981cf30;
            this.pbAddNewRecipe.InitialImage = global::CookUp_Companion.Properties.Resources.user;
            this.pbAddNewRecipe.Location = new System.Drawing.Point(867, 227);
            this.pbAddNewRecipe.Name = "pbAddNewRecipe";
            this.pbAddNewRecipe.Size = new System.Drawing.Size(368, 265);
            this.pbAddNewRecipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddNewRecipe.TabIndex = 4;
            this.pbAddNewRecipe.TabStop = false;
            // 
            // AccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pAccount);
            this.Name = "AccountControl";
            this.Size = new System.Drawing.Size(1910, 839);
            this.pAccount.ResumeLayout(false);
            this.pAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewRecipe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ProfilePicture;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbFamilyName;
        private System.Windows.Forms.Button btnEditPrifile;
        private System.Windows.Forms.PictureBox pbAddNewRecipe;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel pAccount;
        private System.Windows.Forms.Label lbRecipes;
        private System.Windows.Forms.Button btnNewRecipe;
    }
}

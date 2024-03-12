namespace CookUp_Companion
{
    partial class EditProfile
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
            this.components = new System.ComponentModel.Container();
            this.pEditProfile = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbBio = new System.Windows.Forms.RichTextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbFamillyName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.pProfilePicture = new System.Windows.Forms.PictureBox();
            this.lbEditProfile = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // pEditProfile
            // 
            this.pEditProfile.BackColor = System.Drawing.Color.Transparent;
            this.pEditProfile.Controls.Add(this.btnSave);
            this.pEditProfile.Controls.Add(this.rtbBio);
            this.pEditProfile.Controls.Add(this.tbUsername);
            this.pEditProfile.Controls.Add(this.tbFamillyName);
            this.pEditProfile.Controls.Add(this.tbFirstName);
            this.pEditProfile.Controls.Add(this.pProfilePicture);
            this.pEditProfile.Controls.Add(this.lbEditProfile);
            this.pEditProfile.Controls.Add(this.btnBack);
            this.pEditProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pEditProfile.Location = new System.Drawing.Point(0, 0);
            this.pEditProfile.Name = "pEditProfile";
            this.pEditProfile.Size = new System.Drawing.Size(590, 792);
            this.pEditProfile.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(190, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(196, 42);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // rtbBio
            // 
            this.rtbBio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rtbBio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBio.Location = new System.Drawing.Point(160, 415);
            this.rtbBio.Name = "rtbBio";
            this.rtbBio.Size = new System.Drawing.Size(266, 122);
            this.rtbBio.TabIndex = 6;
            this.rtbBio.Text = "Bio";
            this.rtbBio.Click += new System.EventHandler(this.rtbBio_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(160, 357);
            this.tbUsername.Multiline = true;
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(266, 35);
            this.tbUsername.TabIndex = 5;
            this.tbUsername.Text = "Username";
            this.tbUsername.Click += new System.EventHandler(this.tbUsername_Click);
            // 
            // tbFamillyName
            // 
            this.tbFamillyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFamillyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFamillyName.Location = new System.Drawing.Point(160, 293);
            this.tbFamillyName.Multiline = true;
            this.tbFamillyName.Name = "tbFamillyName";
            this.tbFamillyName.Size = new System.Drawing.Size(266, 35);
            this.tbFamillyName.TabIndex = 4;
            this.tbFamillyName.Text = "FamillyName";
            this.tbFamillyName.Click += new System.EventHandler(this.tbFamillyName_Click);
            // 
            // tbFirstName
            // 
            this.tbFirstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.Location = new System.Drawing.Point(160, 239);
            this.tbFirstName.Multiline = true;
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(266, 34);
            this.tbFirstName.TabIndex = 3;
            this.tbFirstName.Text = "First Name";
            this.tbFirstName.Click += new System.EventHandler(this.tbFirstName_Click);
            // 
            // pProfilePicture
            // 
            this.pProfilePicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pProfilePicture.Image = global::CookUp_Companion.Properties.Resources.user;
            this.pProfilePicture.Location = new System.Drawing.Point(236, 89);
            this.pProfilePicture.Name = "pProfilePicture";
            this.pProfilePicture.Size = new System.Drawing.Size(133, 133);
            this.pProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pProfilePicture.TabIndex = 2;
            this.pProfilePicture.TabStop = false;
            // 
            // lbEditProfile
            // 
            this.lbEditProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbEditProfile.AutoSize = true;
            this.lbEditProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditProfile.Location = new System.Drawing.Point(230, 36);
            this.lbEditProfile.Name = "lbEditProfile";
            this.lbEditProfile.Size = new System.Drawing.Size(165, 32);
            this.lbEditProfile.TabIndex = 1;
            this.lbEditProfile.Text = "Edit Profile";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(18, 36);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 61);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<-";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // EditProfile
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pEditProfile);
            this.Name = "EditProfile";
            this.Size = new System.Drawing.Size(590, 736);
            this.pEditProfile.ResumeLayout(false);
            this.pEditProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pEditProfile;
        private System.Windows.Forms.PictureBox pProfilePicture;
        private System.Windows.Forms.Label lbEditProfile;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbBio;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbFamillyName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

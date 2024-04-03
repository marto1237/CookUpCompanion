namespace CookUpCompanion.Forms
{
    partial class Users
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
            label1 = new Label();
            label2 = new Label();
            flpUsersInfo = new FlowLayoutPanel();
            userSearchBar1 = new UserControls.UserSearchBar();
            paginationControl1 = new UserControls.paginationControl();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1292, 418);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1749, 434);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // flpUsersInfo
            // 
            flpUsersInfo.AutoScroll = true;
            flpUsersInfo.BackColor = Color.White;
            flpUsersInfo.Dock = DockStyle.Fill;
            flpUsersInfo.Location = new Point(0, 185);
            flpUsersInfo.Margin = new Padding(3, 4, 3, 4);
            flpUsersInfo.Name = "flpUsersInfo";
            flpUsersInfo.Size = new Size(1920, 917);
            flpUsersInfo.TabIndex = 10;
            // 
            // userSearchBar1
            // 
            userSearchBar1.BackColor = Color.White;
            userSearchBar1.Dock = DockStyle.Top;
            userSearchBar1.Location = new Point(0, 0);
            userSearchBar1.Margin = new Padding(3, 5, 3, 5);
            userSearchBar1.Name = "userSearchBar1";
            userSearchBar1.Size = new Size(1920, 185);
            userSearchBar1.TabIndex = 9;
            // 
            // paginationControl1
            // 
            paginationControl1.BackColor = SystemColors.ControlLightLight;
            paginationControl1.Dock = DockStyle.Bottom;
            paginationControl1.Location = new Point(0, 974);
            paginationControl1.Name = "paginationControl1";
            paginationControl1.Size = new Size(1920, 128);
            paginationControl1.TabIndex = 11;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1920, 1102);
            Controls.Add(paginationControl1);
            Controls.Add(flpUsersInfo);
            Controls.Add(userSearchBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Users";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users";
            Load += Users_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private UserControls.UserSearchBar userSearchBar1;
        private System.Windows.Forms.FlowLayoutPanel flpUsersInfo;
        private UserControls.paginationControl paginationControl1;
    }
}
namespace CookUpCompanion.UserControls
{
    partial class paginationControl
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
            btnPrevious = new Button();
            btnNext = new Button();
            lbPageNum = new Label();
            btnGoToCertainPage = new Button();
            PageIndexNumtb = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)PageIndexNumtb).BeginInit();
            SuspendLayout();
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.None;
            btnPrevious.BackColor = Color.YellowGreen;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Location = new Point(339, 41);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "Prev";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.None;
            btnNext.BackColor = Color.YellowGreen;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(1005, 41);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lbPageNum
            // 
            lbPageNum.Anchor = AnchorStyles.None;
            lbPageNum.AutoSize = true;
            lbPageNum.Location = new Point(690, 9);
            lbPageNum.Name = "lbPageNum";
            lbPageNum.Size = new Size(45, 20);
            lbPageNum.TabIndex = 2;
            lbPageNum.Text = "Page ";
            // 
            // btnGoToCertainPage
            // 
            btnGoToCertainPage.Anchor = AnchorStyles.None;
            btnGoToCertainPage.BackColor = Color.OliveDrab;
            btnGoToCertainPage.FlatStyle = FlatStyle.Flat;
            btnGoToCertainPage.Location = new Point(680, 70);
            btnGoToCertainPage.Name = "btnGoToCertainPage";
            btnGoToCertainPage.Size = new Size(68, 29);
            btnGoToCertainPage.TabIndex = 4;
            btnGoToCertainPage.Text = "Go";
            btnGoToCertainPage.UseVisualStyleBackColor = false;
            btnGoToCertainPage.Click += btnGoToCertainPage_Click;
            // 
            // PageIndexNumtb
            // 
            PageIndexNumtb.Anchor = AnchorStyles.None;
            PageIndexNumtb.Location = new Point(680, 32);
            PageIndexNumtb.Name = "PageIndexNumtb";
            PageIndexNumtb.Size = new Size(68, 27);
            PageIndexNumtb.TabIndex = 5;
            PageIndexNumtb.TextAlign = HorizontalAlignment.Center;
            // 
            // paginationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PageIndexNumtb);
            Controls.Add(btnGoToCertainPage);
            Controls.Add(lbPageNum);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Name = "paginationControl";
            Size = new Size(1445, 102);
            ((System.ComponentModel.ISupportInitialize)PageIndexNumtb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrevious;
        private Button btnNext;
        private Label lbPageNum;
        private Button btnGoToCertainPage;
        private NumericUpDown PageIndexNumtb;
    }
}

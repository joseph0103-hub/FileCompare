namespace FileCompare
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblAppName = new System.Windows.Forms.Label();
            splitMain = new System.Windows.Forms.SplitContainer();
            pnlLeftList = new System.Windows.Forms.Panel();
            lvwLeftDir = new System.Windows.Forms.ListView();
            colLeftName = new System.Windows.Forms.ColumnHeader();
            colLeftSize = new System.Windows.Forms.ColumnHeader();
            colLeftDate = new System.Windows.Forms.ColumnHeader();
            pnlLeftTop = new System.Windows.Forms.Panel();
            txtLeftDir = new System.Windows.Forms.TextBox();
            btnLeftDir = new System.Windows.Forms.Button();
            pnlRightList = new System.Windows.Forms.Panel();
            lvwRightDir = new System.Windows.Forms.ListView();
            colRightName = new System.Windows.Forms.ColumnHeader();
            colRightSize = new System.Windows.Forms.ColumnHeader();
            colRightDate = new System.Windows.Forms.ColumnHeader();
            pnlRightTop = new System.Windows.Forms.Panel();
            txtRightDir = new System.Windows.Forms.TextBox();
            btnRightDir = new System.Windows.Forms.Button();
            pnlArrowLeft = new System.Windows.Forms.Panel();
            btnCopyFromLeft = new System.Windows.Forms.Button();
            pnlArrowRight = new System.Windows.Forms.Panel();
            btnCopyFromRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlLeftList.SuspendLayout();
            pnlLeftTop.SuspendLayout();
            pnlRightList.SuspendLayout();
            pnlRightTop.SuspendLayout();
            pnlArrowLeft.SuspendLayout();
            pnlArrowRight.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new System.Drawing.Font("맑은 고딕", 24F);
            lblAppName.ForeColor = System.Drawing.Color.RoyalBlue;
            lblAppName.Location = new System.Drawing.Point(27, 12);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new System.Drawing.Size(211, 45);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "File Compare";
            // 
            // splitMain
            // 
            splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            splitMain.IsSplitterFixed = true;
            splitMain.Location = new System.Drawing.Point(16, 44);
            splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            splitMain.Panel1.Controls.Add(pnlLeftList);
            splitMain.Panel1.Controls.Add(pnlLeftTop);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            splitMain.Panel2.Controls.Add(pnlRightList);
            splitMain.Panel2.Controls.Add(pnlRightTop);
            splitMain.Size = new System.Drawing.Size(760, 538);
            splitMain.SplitterDistance = 370;
            splitMain.SplitterWidth = 1;
            splitMain.TabIndex = 1;
            // 
            // pnlLeftList
            // 
            pnlLeftList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlLeftList.Controls.Add(lvwLeftDir);
            pnlLeftList.Location = new System.Drawing.Point(5, 94);
            pnlLeftList.Name = "pnlLeftList";
            pnlLeftList.Size = new System.Drawing.Size(357, 436);
            pnlLeftList.TabIndex = 1;
            // 
            // lvwLeftDir
            // 
            lvwLeftDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colLeftName, colLeftSize, colLeftDate });
            lvwLeftDir.Location = new System.Drawing.Point(1, 1);
            lvwLeftDir.Name = "lvwLeftDir";
            lvwLeftDir.Size = new System.Drawing.Size(353, 432);
            lvwLeftDir.TabIndex = 0;
            lvwLeftDir.UseCompatibleStateImageBehavior = false;
            // 
            // colLeftName
            // 
            colLeftName.Text = "이름";
            colLeftName.Width = 170;
            // 
            // colLeftSize
            // 
            colLeftSize.Text = "크기";
            // 
            // colLeftDate
            // 
            colLeftDate.Text = "수정일";
            colLeftDate.Width = 120;
            // 
            // pnlLeftTop
            // 
            pnlLeftTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlLeftTop.Controls.Add(txtLeftDir);
            pnlLeftTop.Controls.Add(btnLeftDir);
            pnlLeftTop.Location = new System.Drawing.Point(5, 50);
            pnlLeftTop.Name = "pnlLeftTop";
            pnlLeftTop.Size = new System.Drawing.Size(357, 42);
            pnlLeftTop.TabIndex = 0;
            // 
            // txtLeftDir
            // 
            txtLeftDir.Location = new System.Drawing.Point(10, 10);
            txtLeftDir.Name = "txtLeftDir";
            txtLeftDir.ReadOnly = true;
            txtLeftDir.Size = new System.Drawing.Size(260, 23);
            txtLeftDir.TabIndex = 0;
            // 
            // btnLeftDir
            // 
            btnLeftDir.Location = new System.Drawing.Point(276, 9);
            btnLeftDir.Name = "btnLeftDir";
            btnLeftDir.Size = new System.Drawing.Size(70, 23);
            btnLeftDir.TabIndex = 1;
            btnLeftDir.Text = "폴더선택";
            btnLeftDir.UseVisualStyleBackColor = true;
            btnLeftDir.Click += btnLeftDir_Click;
            // 
            // pnlRightList
            // 
            pnlRightList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlRightList.Controls.Add(lvwRightDir);
            pnlRightList.Location = new System.Drawing.Point(12, 94);
            pnlRightList.Name = "pnlRightList";
            pnlRightList.Size = new System.Drawing.Size(357, 436);
            pnlRightList.TabIndex = 1;
            // 
            // lvwRightDir
            // 
            lvwRightDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { colRightName, colRightSize, colRightDate });
            lvwRightDir.Location = new System.Drawing.Point(1, 1);
            lvwRightDir.Name = "lvwRightDir";
            lvwRightDir.Size = new System.Drawing.Size(353, 432);
            lvwRightDir.TabIndex = 0;
            lvwRightDir.UseCompatibleStateImageBehavior = false;
            // 
            // colRightName
            // 
            colRightName.Text = "이름";
            colRightName.Width = 170;
            // 
            // colRightSize
            // 
            colRightSize.Text = "크기";
            // 
            // colRightDate
            // 
            colRightDate.Text = "수정일";
            colRightDate.Width = 120;
            // 
            // pnlRightTop
            // 
            pnlRightTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlRightTop.Controls.Add(txtRightDir);
            pnlRightTop.Controls.Add(btnRightDir);
            pnlRightTop.Location = new System.Drawing.Point(12, 50);
            pnlRightTop.Name = "pnlRightTop";
            pnlRightTop.Size = new System.Drawing.Size(357, 42);
            pnlRightTop.TabIndex = 0;
            // 
            // txtRightDir
            // 
            txtRightDir.Location = new System.Drawing.Point(10, 10);
            txtRightDir.Name = "txtRightDir";
            txtRightDir.ReadOnly = true;
            txtRightDir.Size = new System.Drawing.Size(260, 23);
            txtRightDir.TabIndex = 0;
            // 
            // btnRightDir
            // 
            btnRightDir.Location = new System.Drawing.Point(276, 9);
            btnRightDir.Name = "btnRightDir";
            btnRightDir.Size = new System.Drawing.Size(70, 23);
            btnRightDir.TabIndex = 1;
            btnRightDir.Text = "폴더선택";
            btnRightDir.UseVisualStyleBackColor = true;
            btnRightDir.Click += btnRightDir_Click;
            // 
            // pnlArrowLeft
            // 
            pnlArrowLeft.Controls.Add(btnCopyFromLeft);
            pnlArrowLeft.Location = new System.Drawing.Point(300, 48);
            pnlArrowLeft.Name = "pnlArrowLeft";
            pnlArrowLeft.Size = new System.Drawing.Size(78, 35);
            pnlArrowLeft.TabIndex = 2;
            // 
            // btnCopyFromLeft
            // 
            btnCopyFromLeft.Location = new System.Drawing.Point(7, 5);
            btnCopyFromLeft.Name = "btnCopyFromLeft";
            btnCopyFromLeft.Size = new System.Drawing.Size(62, 23);
            btnCopyFromLeft.TabIndex = 0;
            btnCopyFromLeft.Text = ">>>";
            btnCopyFromLeft.UseVisualStyleBackColor = true;
            btnCopyFromLeft.Click += btnCopyFromLeft_Click;
            // 
            // pnlArrowRight
            // 
            pnlArrowRight.Controls.Add(btnCopyFromRight);
            pnlArrowRight.Location = new System.Drawing.Point(396, 48);
            pnlArrowRight.Name = "pnlArrowRight";
            pnlArrowRight.Size = new System.Drawing.Size(78, 35);
            pnlArrowRight.TabIndex = 3;
            // 
            // btnCopyFromRight
            // 
            btnCopyFromRight.Location = new System.Drawing.Point(7, 5);
            btnCopyFromRight.Name = "btnCopyFromRight";
            btnCopyFromRight.Size = new System.Drawing.Size(62, 23);
            btnCopyFromRight.TabIndex = 0;
            btnCopyFromRight.Text = "<<<";
            btnCopyFromRight.UseVisualStyleBackColor = true;
            btnCopyFromRight.Click += btnCopyFromRight_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(792, 596);
            Controls.Add(pnlArrowRight);
            Controls.Add(pnlArrowLeft);
            Controls.Add(lblAppName);
            Controls.Add(splitMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "File Compare v1.0";
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlLeftList.ResumeLayout(false);
            pnlLeftTop.ResumeLayout(false);
            pnlLeftTop.PerformLayout();
            pnlRightList.ResumeLayout(false);
            pnlRightTop.ResumeLayout(false);
            pnlRightTop.PerformLayout();
            pnlArrowLeft.ResumeLayout(false);
            pnlArrowRight.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlLeftTop;
        private System.Windows.Forms.TextBox txtLeftDir;
        private System.Windows.Forms.Button btnLeftDir;
        private System.Windows.Forms.Panel pnlLeftList;
        private System.Windows.Forms.ListView lvwLeftDir;
        private System.Windows.Forms.ColumnHeader colLeftName;
        private System.Windows.Forms.ColumnHeader colLeftSize;
        private System.Windows.Forms.ColumnHeader colLeftDate;
        private System.Windows.Forms.Panel pnlRightTop;
        private System.Windows.Forms.TextBox txtRightDir;
        private System.Windows.Forms.Button btnRightDir;
        private System.Windows.Forms.Panel pnlRightList;
        private System.Windows.Forms.ListView lvwRightDir;
        private System.Windows.Forms.ColumnHeader colRightName;
        private System.Windows.Forms.ColumnHeader colRightSize;
        private System.Windows.Forms.ColumnHeader colRightDate;
        private System.Windows.Forms.Panel pnlArrowLeft;
        private System.Windows.Forms.Button btnCopyFromLeft;
        private System.Windows.Forms.Panel pnlArrowRight;
        private System.Windows.Forms.Button btnCopyFromRight;
    }
}

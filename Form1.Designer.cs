namespace KeywordExtraction
{
    partial class ProgessTitleLabel
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FileReadBnt = new System.Windows.Forms.Button();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.csvCreatBnt = new System.Windows.Forms.Button();
            this.AskAiBnt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.FailTitleLabel = new System.Windows.Forms.Label();
            this.FailCountLabel = new System.Windows.Forms.Label();
            this.ResendTitleLabel = new System.Windows.Forms.Label();
            this.ResendLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileReadBnt
            // 
            this.FileReadBnt.Location = new System.Drawing.Point(46, 41);
            this.FileReadBnt.Name = "FileReadBnt";
            this.FileReadBnt.Size = new System.Drawing.Size(75, 23);
            this.FileReadBnt.TabIndex = 0;
            this.FileReadBnt.Text = "讀取檔案";
            this.FileReadBnt.UseVisualStyleBackColor = true;
            this.FileReadBnt.Click += new System.EventHandler(this.FileReadBnt_Click);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(155, 41);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(588, 22);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // csvCreatBnt
            // 
            this.csvCreatBnt.Location = new System.Drawing.Point(257, 333);
            this.csvCreatBnt.Name = "csvCreatBnt";
            this.csvCreatBnt.Size = new System.Drawing.Size(289, 85);
            this.csvCreatBnt.TabIndex = 3;
            this.csvCreatBnt.Text = "產出回報檔案";
            this.csvCreatBnt.UseVisualStyleBackColor = true;
            this.csvCreatBnt.Click += new System.EventHandler(this.csvCreatBnt_Click);
            // 
            // AskAiBnt
            // 
            this.AskAiBnt.Location = new System.Drawing.Point(46, 126);
            this.AskAiBnt.Name = "AskAiBnt";
            this.AskAiBnt.Size = new System.Drawing.Size(239, 108);
            this.AskAiBnt.TabIndex = 4;
            this.AskAiBnt.Text = "取得關鍵詞數值比重";
            this.AskAiBnt.UseVisualStyleBackColor = true;
            this.AskAiBnt.Click += new System.EventHandler(this.AskAiBnt_ClickAsync);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.Location = new System.Drawing.Point(328, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "處理進度:";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Font = new System.Drawing.Font("新細明體", 20F);
            this.ProgressLabel.Location = new System.Drawing.Point(497, 117);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(39, 27);
            this.ProgressLabel.TabIndex = 6;
            this.ProgressLabel.Text = "無";
            // 
            // FailTitleLabel
            // 
            this.FailTitleLabel.AutoSize = true;
            this.FailTitleLabel.Font = new System.Drawing.Font("新細明體", 20F);
            this.FailTitleLabel.Location = new System.Drawing.Point(328, 165);
            this.FailTitleLabel.Name = "FailTitleLabel";
            this.FailTitleLabel.Size = new System.Drawing.Size(127, 27);
            this.FailTitleLabel.TabIndex = 7;
            this.FailTitleLabel.Text = "回應失效:";
            // 
            // FailCountLabel
            // 
            this.FailCountLabel.AutoSize = true;
            this.FailCountLabel.Font = new System.Drawing.Font("新細明體", 20F);
            this.FailCountLabel.Location = new System.Drawing.Point(511, 165);
            this.FailCountLabel.Name = "FailCountLabel";
            this.FailCountLabel.Size = new System.Drawing.Size(25, 27);
            this.FailCountLabel.TabIndex = 8;
            this.FailCountLabel.Text = "0";
            // 
            // ResendTitleLabel
            // 
            this.ResendTitleLabel.AutoSize = true;
            this.ResendTitleLabel.Font = new System.Drawing.Font("新細明體", 20F);
            this.ResendTitleLabel.Location = new System.Drawing.Point(328, 207);
            this.ResendTitleLabel.Name = "ResendTitleLabel";
            this.ResendTitleLabel.Size = new System.Drawing.Size(127, 27);
            this.ResendTitleLabel.TabIndex = 9;
            this.ResendTitleLabel.Text = "重新發送:";
            // 
            // ResendLabel
            // 
            this.ResendLabel.AutoSize = true;
            this.ResendLabel.Font = new System.Drawing.Font("新細明體", 20F);
            this.ResendLabel.Location = new System.Drawing.Point(511, 207);
            this.ResendLabel.Name = "ResendLabel";
            this.ResendLabel.Size = new System.Drawing.Size(25, 27);
            this.ResendLabel.TabIndex = 10;
            this.ResendLabel.Text = "0";
            // 
            // ProgessTitleLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResendLabel);
            this.Controls.Add(this.ResendTitleLabel);
            this.Controls.Add(this.FailCountLabel);
            this.Controls.Add(this.FailTitleLabel);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AskAiBnt);
            this.Controls.Add(this.csvCreatBnt);
            this.Controls.Add(this.FilePathTextBox);
            this.Controls.Add(this.FileReadBnt);
            this.Name = "ProgessTitleLabel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileReadBnt;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button csvCreatBnt;
        private System.Windows.Forms.Button AskAiBnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label FailTitleLabel;
        private System.Windows.Forms.Label FailCountLabel;
        private System.Windows.Forms.Label ResendTitleLabel;
        private System.Windows.Forms.Label ResendLabel;
    }
}


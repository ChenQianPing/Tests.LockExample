namespace Tests.LockExample
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLock = new System.Windows.Forms.ListBox();
            this.btnLock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLock
            // 
            this.lbLock.FormattingEnabled = true;
            this.lbLock.ItemHeight = 12;
            this.lbLock.Location = new System.Drawing.Point(12, 12);
            this.lbLock.Name = "lbLock";
            this.lbLock.Size = new System.Drawing.Size(686, 424);
            this.lbLock.TabIndex = 0;
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(244, 449);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(148, 42);
            this.btnLock.TabIndex = 1;
            this.btnLock.Text = "开始自动随机取款";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 503);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.lbLock);
            this.Name = "Form1";
            this.Text = "Lock语句示例";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLock;
        private System.Windows.Forms.Button btnLock;
    }
}


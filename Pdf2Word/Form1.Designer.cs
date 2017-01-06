namespace Pdf2Word
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label_Status = new System.Windows.Forms.Label();
            this.Processing_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(185, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert PDF to Word";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(183, 98);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(71, 12);
            this.label_Status.TabIndex = 1;
            this.label_Status.Text = "Status: n/a";
            // 
            // Processing_txt
            // 
            this.Processing_txt.AutoSize = true;
            this.Processing_txt.Location = new System.Drawing.Point(185, 123);
            this.Processing_txt.Name = "Processing_txt";
            this.Processing_txt.Size = new System.Drawing.Size(0, 12);
            this.Processing_txt.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(551, 203);
            this.Controls.Add(this.Processing_txt);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pdf2Word";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Label Processing_txt;
    }
}


namespace HiroTerm
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbDebug = new System.Windows.Forms.RichTextBox();
            this.timer1000 = new System.Windows.Forms.Timer(this.components);
            this.btn = new System.Windows.Forms.Button();
            this.timer10 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtbDebug
            // 
            this.rtbDebug.Location = new System.Drawing.Point(350, 297);
            this.rtbDebug.Name = "rtbDebug";
            this.rtbDebug.Size = new System.Drawing.Size(236, 96);
            this.rtbDebug.TabIndex = 30;
            this.rtbDebug.Text = "";
            // 
            // timer1000
            // 
            this.timer1000.Enabled = true;
            this.timer1000.Interval = 1000;
            this.timer1000.Tick += new System.EventHandler(this.timer1000_Tick);
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(603, 297);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 31;
            this.btn.Text = "button1";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // timer10
            // 
            this.timer10.Tick += new System.EventHandler(this.timer10_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.rtbDebug);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbDebug;
        private System.Windows.Forms.Timer timer1000;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Timer timer10;
    }
}


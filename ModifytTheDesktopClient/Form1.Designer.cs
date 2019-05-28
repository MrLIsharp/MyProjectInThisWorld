namespace ModifytTheDesktopClient
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
            this.UploadImage = new System.Windows.Forms.Button();
            this.RandomMTD = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // UploadImage
            // 
            this.UploadImage.Location = new System.Drawing.Point(13, 13);
            this.UploadImage.Name = "UploadImage";
            this.UploadImage.Size = new System.Drawing.Size(84, 29);
            this.UploadImage.TabIndex = 0;
            this.UploadImage.Text = "上传图片";
            this.UploadImage.UseVisualStyleBackColor = true;
            this.UploadImage.Click += new System.EventHandler(this.UploadImage_Click);
            // 
            // RandomMTD
            // 
            this.RandomMTD.Location = new System.Drawing.Point(137, 13);
            this.RandomMTD.Name = "RandomMTD";
            this.RandomMTD.Size = new System.Drawing.Size(84, 29);
            this.RandomMTD.TabIndex = 1;
            this.RandomMTD.Text = "随机桌面";
            this.RandomMTD.UseVisualStyleBackColor = true;
            this.RandomMTD.Click += new System.EventHandler(this.RandomMTD_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 52);
            this.Controls.Add(this.RandomMTD);
            this.Controls.Add(this.UploadImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.Text = "隨機換壁紙";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UploadImage;
        private System.Windows.Forms.Button RandomMTD;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}


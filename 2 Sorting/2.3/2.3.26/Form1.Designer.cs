﻿namespace _2._3._26
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputN = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.InputM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "N:";
            // 
            // InputN
            // 
            this.InputN.Location = new System.Drawing.Point(99, 96);
            this.InputN.Name = "InputN";
            this.InputN.Size = new System.Drawing.Size(100, 44);
            this.InputN.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "绘图";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(54, 173);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 36);
            this.ErrorLabel.TabIndex = 3;
            // 
            // InputM
            // 
            this.InputM.Location = new System.Drawing.Point(260, 96);
            this.InputM.Name = "InputM";
            this.InputM.Size = new System.Drawing.Size(100, 44);
            this.InputM.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "M:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(705, 236);
            this.Controls.Add(this.InputM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InputN);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "2.3.26";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.TextBox InputM;
        private System.Windows.Forms.Label label2;
    }
}


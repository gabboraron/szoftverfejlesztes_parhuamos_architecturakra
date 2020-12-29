namespace ThreadSafeCall2WindowsFormControls
{
    partial class Form1
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
            this.setTextUnsafeBtn = new System.Windows.Forms.Button();
            this.setTextSafeBtn = new System.Windows.Forms.Button();
            this.setTextBackgroundWorkerBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // setTextUnsafeBtn
            // 
            this.setTextUnsafeBtn.Location = new System.Drawing.Point(14, 86);
            this.setTextUnsafeBtn.Name = "setTextUnsafeBtn";
            this.setTextUnsafeBtn.Size = new System.Drawing.Size(75, 23);
            this.setTextUnsafeBtn.TabIndex = 0;
            this.setTextUnsafeBtn.Text = "Unsafe Call";
            this.setTextUnsafeBtn.UseVisualStyleBackColor = true;
            this.setTextUnsafeBtn.Click += new System.EventHandler(this.setTextUnsafeBtn_Click);
            // 
            // setTextSafeBtn
            // 
            this.setTextSafeBtn.Location = new System.Drawing.Point(95, 86);
            this.setTextSafeBtn.Name = "setTextSafeBtn";
            this.setTextSafeBtn.Size = new System.Drawing.Size(75, 23);
            this.setTextSafeBtn.TabIndex = 1;
            this.setTextSafeBtn.Text = "Safe Call";
            this.setTextSafeBtn.UseVisualStyleBackColor = true;
            this.setTextSafeBtn.Click += new System.EventHandler(this.setTextSafeBtn_Click);
            // 
            // setTextBackgroundWorkerBtn
            // 
            this.setTextBackgroundWorkerBtn.Location = new System.Drawing.Point(183, 86);
            this.setTextBackgroundWorkerBtn.Name = "setTextBackgroundWorkerBtn";
            this.setTextBackgroundWorkerBtn.Size = new System.Drawing.Size(99, 23);
            this.setTextBackgroundWorkerBtn.TabIndex = 2;
            this.setTextBackgroundWorkerBtn.Text = "Safe BW Call";
            this.setTextBackgroundWorkerBtn.UseVisualStyleBackColor = true;
            this.setTextBackgroundWorkerBtn.Click += new System.EventHandler(this.setTextBackgroundWorkerBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 20);
            this.textBox1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 133);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.setTextBackgroundWorkerBtn);
            this.Controls.Add(this.setTextSafeBtn);
            this.Controls.Add(this.setTextUnsafeBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setTextUnsafeBtn;
        private System.Windows.Forms.Button setTextSafeBtn;
        private System.Windows.Forms.Button setTextBackgroundWorkerBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}



namespace TimeTrackingClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.checkOutLabel = new System.Windows.Forms.Label();
            this.checkInLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.checkOutInput = new System.Windows.Forms.TextBox();
            this.checkInInput = new System.Windows.Forms.TextBox();
            this.exitAppBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exitAppBtn);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.submitBtn);
            this.groupBox1.Controls.Add(this.checkOutLabel);
            this.groupBox1.Controls.Add(this.checkInLabel);
            this.groupBox1.Controls.Add(this.welcomeLabel);
            this.groupBox1.Controls.Add(this.checkOutInput);
            this.groupBox1.Controls.Add(this.checkInInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 306);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Tracking";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(18, 66);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(72, 15);
            this.dateLabel.TabIndex = 13;
            this.dateLabel.Text = "Today\'s date";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(18, 228);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(216, 30);
            this.submitBtn.TabIndex = 12;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // checkOutLabel
            // 
            this.checkOutLabel.AutoSize = true;
            this.checkOutLabel.Location = new System.Drawing.Point(18, 171);
            this.checkOutLabel.Name = "checkOutLabel";
            this.checkOutLabel.Size = new System.Drawing.Size(61, 15);
            this.checkOutLabel.TabIndex = 11;
            this.checkOutLabel.Text = "Check out";
            // 
            // checkInLabel
            // 
            this.checkInLabel.AutoSize = true;
            this.checkInLabel.Location = new System.Drawing.Point(18, 121);
            this.checkInLabel.Name = "checkInLabel";
            this.checkInLabel.Size = new System.Drawing.Size(53, 15);
            this.checkInLabel.TabIndex = 10;
            this.checkInLabel.Text = "Check in";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.Location = new System.Drawing.Point(65, 32);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(49, 21);
            this.welcomeLabel.TabIndex = 9;
            this.welcomeLabel.Text = "Hello,";
            // 
            // checkOutInput
            // 
            this.checkOutInput.Location = new System.Drawing.Point(18, 189);
            this.checkOutInput.Name = "checkOutInput";
            this.checkOutInput.Size = new System.Drawing.Size(216, 23);
            this.checkOutInput.TabIndex = 8;
            // 
            // checkInInput
            // 
            this.checkInInput.Location = new System.Drawing.Point(18, 139);
            this.checkInInput.Name = "checkInInput";
            this.checkInInput.Size = new System.Drawing.Size(216, 23);
            this.checkInInput.TabIndex = 7;
            // 
            // exitAppBtn
            // 
            this.exitAppBtn.Location = new System.Drawing.Point(18, 264);
            this.exitAppBtn.Name = "exitAppBtn";
            this.exitAppBtn.Size = new System.Drawing.Size(216, 30);
            this.exitAppBtn.TabIndex = 14;
            this.exitAppBtn.Text = "Exit";
            this.exitAppBtn.UseVisualStyleBackColor = true;
            this.exitAppBtn.Click += new System.EventHandler(this.exitAppBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 326);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Time Tracking Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label checkOutLabel;
        private System.Windows.Forms.Label checkInLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.TextBox checkOutInput;
        private System.Windows.Forms.TextBox checkInInput;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button exitAppBtn;
    }
}


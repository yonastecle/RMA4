namespace RMA_SystemSoftware
{
    partial class delegateMessageBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_delg_reason = new System.Windows.Forms.TextBox();
            this.DelegateButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_RMA_No = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reason for Delegation:";
            // 
            // textBox_delg_reason
            // 
            this.textBox_delg_reason.Location = new System.Drawing.Point(161, 65);
            this.textBox_delg_reason.Multiline = true;
            this.textBox_delg_reason.Name = "textBox_delg_reason";
            this.textBox_delg_reason.Size = new System.Drawing.Size(282, 109);
            this.textBox_delg_reason.TabIndex = 1;
            // 
            // DelegateButton
            // 
            this.DelegateButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelegateButton.Location = new System.Drawing.Point(199, 190);
            this.DelegateButton.Name = "DelegateButton";
            this.DelegateButton.Size = new System.Drawing.Size(75, 23);
            this.DelegateButton.TabIndex = 2;
            this.DelegateButton.Text = "Submit";
            this.DelegateButton.UseVisualStyleBackColor = true;
            this.DelegateButton.Click += new System.EventHandler(this.DelegateButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(325, 190);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "RMA# :";
            // 
            // label_RMA_No
            // 
            this.label_RMA_No.AutoSize = true;
            this.label_RMA_No.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_RMA_No.ForeColor = System.Drawing.Color.DarkRed;
            this.label_RMA_No.Location = new System.Drawing.Point(80, 37);
            this.label_RMA_No.Name = "label_RMA_No";
            this.label_RMA_No.Size = new System.Drawing.Size(153, 16);
            this.label_RMA_No.TabIndex = 5;
            this.label_RMA_No.Text = "Reason for Delegation:";
            // 
            // delegateMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 259);
            this.Controls.Add(this.label_RMA_No);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DelegateButton);
            this.Controls.Add(this.textBox_delg_reason);
            this.Controls.Add(this.label1);
            this.Name = "delegateMessageBox";
            this.Text = "Delegate Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_delg_reason;
        private System.Windows.Forms.Button DelegateButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_RMA_No;
    }
}
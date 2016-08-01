namespace RMA_SystemSoftware
{
    partial class DialogBox
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
            this.label_statusType = new System.Windows.Forms.Label();
            this.textBox_reason = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_RMA_No = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_statusType
            // 
            this.label_statusType.AutoSize = true;
            this.label_statusType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_statusType.Location = new System.Drawing.Point(41, 82);
            this.label_statusType.Name = "label_statusType";
            this.label_statusType.Size = new System.Drawing.Size(153, 16);
            this.label_statusType.TabIndex = 0;
            this.label_statusType.Text = "Reason for Delegation:";
            // 
            // textBox_reason
            // 
            this.textBox_reason.Location = new System.Drawing.Point(44, 123);
            this.textBox_reason.Multiline = true;
            this.textBox_reason.Name = "textBox_reason";
            this.textBox_reason.Size = new System.Drawing.Size(282, 109);
            this.textBox_reason.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(83, 266);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(213, 266);
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
            this.label_RMA_No.Size = new System.Drawing.Size(44, 16);
            this.label_RMA_No.TabIndex = 5;
            this.label_RMA_No.Text = "RMA#";
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 313);
            this.Controls.Add(this.label_RMA_No);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.textBox_reason);
            this.Controls.Add(this.label_statusType);
            this.Name = "DialogBox";
            this.Text = "Delegate Request";
            this.Load += new System.EventHandler(this.delegateMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_statusType;
        private System.Windows.Forms.TextBox textBox_reason;
        private System.Windows.Forms.Button SubmitButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_RMA_No;
    }
}
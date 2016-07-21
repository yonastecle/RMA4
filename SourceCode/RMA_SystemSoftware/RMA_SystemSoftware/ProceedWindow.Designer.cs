namespace RMA_SystemSoftware
{
    partial class ProceedWindow
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
            this.delegateButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // delegateButton
            // 
            this.delegateButton.Location = new System.Drawing.Point(197, 112);
            this.delegateButton.Name = "delegateButton";
            this.delegateButton.Size = new System.Drawing.Size(75, 23);
            this.delegateButton.TabIndex = 5;
            this.delegateButton.Text = "Delegate";
            this.delegateButton.UseVisualStyleBackColor = true;
            this.delegateButton.Click += new System.EventHandler(this.delegateButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(66, 112);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 4;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 53);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(362, 18);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Would you like to proceed with the assigned request ?";
            // 
            // ProceedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 175);
            this.Controls.Add(this.delegateButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.lblMessage);
            this.Name = "ProceedWindow";
            this.Text = "Proceed?";
            this.Load += new System.EventHandler(this.ProceedWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delegateButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label lblMessage;
    }
}
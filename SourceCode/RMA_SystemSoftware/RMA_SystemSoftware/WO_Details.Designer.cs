namespace RMA_SystemSoftware
{
    partial class WO_Details
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
            this.dataGridView_WODetails = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WODetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_WODetails
            // 
            this.dataGridView_WODetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WODetails.Location = new System.Drawing.Point(0, 33);
            this.dataGridView_WODetails.Name = "dataGridView_WODetails";
            this.dataGridView_WODetails.Size = new System.Drawing.Size(1012, 391);
            this.dataGridView_WODetails.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(926, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // WO_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1013, 424);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dataGridView_WODetails);
            this.Name = "WO_Details";
            this.Text = "WO_Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WODetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        public System.Windows.Forms.DataGridView dataGridView_WODetails;
    }
}
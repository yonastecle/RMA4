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
            this.textBox_rmaNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WODetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_WODetails
            // 
            this.dataGridView_WODetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WODetails.Location = new System.Drawing.Point(2, 65);
            this.dataGridView_WODetails.Name = "dataGridView_WODetails";
            this.dataGridView_WODetails.Size = new System.Drawing.Size(1010, 359);
            this.dataGridView_WODetails.TabIndex = 0;
            // 
            // textBox_rmaNo
            // 
            this.textBox_rmaNo.Location = new System.Drawing.Point(156, 21);
            this.textBox_rmaNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_rmaNo.Multiline = true;
            this.textBox_rmaNo.Name = "textBox_rmaNo";
            this.textBox_rmaNo.Size = new System.Drawing.Size(255, 23);
            this.textBox_rmaNo.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Enter RMA#:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(926, 19);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Go Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(435, 19);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(76, 25);
            this.SearchButton.TabIndex = 40;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // WO_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1013, 424);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.textBox_rmaNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dataGridView_WODetails);
            this.Name = "WO_Details";
            this.Text = "WO_Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WODetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView_WODetails;
        private System.Windows.Forms.TextBox textBox_rmaNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button SearchButton;
    }
}
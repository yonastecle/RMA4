﻿namespace RMA_SystemSoftware
{
    partial class Technician
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
            this.components = new System.ComponentModel.Container();
            this.SearchButton = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label_helloEmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.ViewHistoryButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.label_currentStatus = new System.Windows.Forms.Label();
            this.radioButton_refund = new System.Windows.Forms.RadioButton();
            this.radioButton_repair = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_rmaNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenButton = new System.Windows.Forms.Button();
            this.delegateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_replace = new System.Windows.Forms.RadioButton();
            this.dataGrid_ShowDetails = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox_newRequest = new System.Windows.Forms.ListBox();
            this.dataGrid_Tech_WOQueue = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ShowDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Tech_WOQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(791, 20);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 23);
            this.SearchButton.TabIndex = 27;
            this.SearchButton.Text = "Search RMA";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.Location = new System.Drawing.Point(920, 23);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(45, 17);
            this.linkLabel3.TabIndex = 26;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Help?";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label_helloEmp
            // 
            this.label_helloEmp.AutoSize = true;
            this.label_helloEmp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_helloEmp.ForeColor = System.Drawing.Color.DarkRed;
            this.label_helloEmp.Location = new System.Drawing.Point(89, 25);
            this.label_helloEmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_helloEmp.Name = "label_helloEmp";
            this.label_helloEmp.Size = new System.Drawing.Size(117, 18);
            this.label_helloEmp.TabIndex = 25;
            this.label_helloEmp.Text = "EmployeeName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hello";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(973, 22);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(57, 17);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Logout!";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(156, 238);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(207, 21);
            this.comboBox_status.TabIndex = 39;
            this.comboBox_status.SelectionChangeCommitted += new System.EventHandler(this.comboBox_status_SelectionChangeCommitted);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(390, 238);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 31);
            this.updateButton.TabIndex = 38;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // ViewHistoryButton
            // 
            this.ViewHistoryButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewHistoryButton.Location = new System.Drawing.Point(207, 180);
            this.ViewHistoryButton.Name = "ViewHistoryButton";
            this.ViewHistoryButton.Size = new System.Drawing.Size(99, 31);
            this.ViewHistoryButton.TabIndex = 37;
            this.ViewHistoryButton.Text = "View History";
            this.ViewHistoryButton.UseVisualStyleBackColor = true;
            this.ViewHistoryButton.Click += new System.EventHandler(this.ViewHistoryButton_Click);
            // 
            // showButton
            // 
            this.showButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showButton.Location = new System.Drawing.Point(70, 180);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(113, 31);
            this.showButton.TabIndex = 36;
            this.showButton.Text = "Show Details";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // label_currentStatus
            // 
            this.label_currentStatus.AutoSize = true;
            this.label_currentStatus.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.label_currentStatus.Location = new System.Drawing.Point(157, 110);
            this.label_currentStatus.Name = "label_currentStatus";
            this.label_currentStatus.Size = new System.Drawing.Size(90, 16);
            this.label_currentStatus.TabIndex = 35;
            this.label_currentStatus.Text = "Request Status";
            // 
            // radioButton_refund
            // 
            this.radioButton_refund.AutoSize = true;
            this.radioButton_refund.Location = new System.Drawing.Point(320, 72);
            this.radioButton_refund.Name = "radioButton_refund";
            this.radioButton_refund.Size = new System.Drawing.Size(60, 17);
            this.radioButton_refund.TabIndex = 34;
            this.radioButton_refund.TabStop = true;
            this.radioButton_refund.Text = "Refund";
            this.radioButton_refund.UseVisualStyleBackColor = true;
            this.radioButton_refund.CheckedChanged += new System.EventHandler(this.radioButton_refund_CheckedChanged);
            // 
            // radioButton_repair
            // 
            this.radioButton_repair.AutoSize = true;
            this.radioButton_repair.Location = new System.Drawing.Point(146, 71);
            this.radioButton_repair.Name = "radioButton_repair";
            this.radioButton_repair.Size = new System.Drawing.Size(56, 17);
            this.radioButton_repair.TabIndex = 33;
            this.radioButton_repair.TabStop = true;
            this.radioButton_repair.Text = "Repair";
            this.radioButton_repair.UseVisualStyleBackColor = true;
            this.radioButton_repair.CheckedChanged += new System.EventHandler(this.radioButton_repair_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Update Status:";
            // 
            // textBox_rmaNo
            // 
            this.textBox_rmaNo.Location = new System.Drawing.Point(146, 28);
            this.textBox_rmaNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_rmaNo.Name = "textBox_rmaNo";
            this.textBox_rmaNo.Size = new System.Drawing.Size(234, 20);
            this.textBox_rmaNo.TabIndex = 31;
            this.textBox_rmaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_rmaNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Current Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Request Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Enter RMA#:";
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenButton.Location = new System.Drawing.Point(207, 141);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(99, 31);
            this.OpenButton.TabIndex = 40;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // delegateButton
            // 
            this.delegateButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delegateButton.Location = new System.Drawing.Point(330, 180);
            this.delegateButton.Name = "delegateButton";
            this.delegateButton.Size = new System.Drawing.Size(101, 31);
            this.delegateButton.TabIndex = 41;
            this.delegateButton.Text = "Delegate";
            this.delegateButton.UseVisualStyleBackColor = true;
            this.delegateButton.Click += new System.EventHandler(this.delegateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_replace);
            this.groupBox1.Controls.Add(this.delegateButton);
            this.groupBox1.Controls.Add(this.OpenButton);
            this.groupBox1.Controls.Add(this.comboBox_status);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.dataGrid_ShowDetails);
            this.groupBox1.Controls.Add(this.ViewHistoryButton);
            this.groupBox1.Controls.Add(this.showButton);
            this.groupBox1.Controls.Add(this.label_currentStatus);
            this.groupBox1.Controls.Add(this.radioButton_refund);
            this.groupBox1.Controls.Add(this.radioButton_repair);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_rmaNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 503);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track/Update RMA";
            // 
            // radioButton_replace
            // 
            this.radioButton_replace.AutoSize = true;
            this.radioButton_replace.Location = new System.Drawing.Point(232, 71);
            this.radioButton_replace.Name = "radioButton_replace";
            this.radioButton_replace.Size = new System.Drawing.Size(65, 17);
            this.radioButton_replace.TabIndex = 42;
            this.radioButton_replace.TabStop = true;
            this.radioButton_replace.Text = "Replace";
            this.radioButton_replace.UseVisualStyleBackColor = true;
            this.radioButton_replace.CheckedChanged += new System.EventHandler(this.radioButton_replace_CheckedChanged);
            // 
            // dataGrid_ShowDetails
            // 
            this.dataGrid_ShowDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_ShowDetails.Location = new System.Drawing.Point(6, 294);
            this.dataGrid_ShowDetails.Name = "dataGrid_ShowDetails";
            this.dataGrid_ShowDetails.Size = new System.Drawing.Size(482, 190);
            this.dataGrid_ShowDetails.TabIndex = 43;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(801, 166);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(85, 26);
            this.RefreshButton.TabIndex = 46;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(546, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 18);
            this.label8.TabIndex = 47;
            this.label8.Text = "New Requests";
            // 
            // listBox_newRequest
            // 
            this.listBox_newRequest.FormattingEnabled = true;
            this.listBox_newRequest.Location = new System.Drawing.Point(545, 103);
            this.listBox_newRequest.Name = "listBox_newRequest";
            this.listBox_newRequest.Size = new System.Drawing.Size(225, 147);
            this.listBox_newRequest.TabIndex = 44;
            this.listBox_newRequest.SelectedIndexChanged += new System.EventHandler(this.listBox_newRequest_SelectedIndexChanged);
            this.listBox_newRequest.DoubleClick += new System.EventHandler(this.listBox_newRequest_DoubleClick);
            // 
            // dataGrid_Tech_WOQueue
            // 
            this.dataGrid_Tech_WOQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Tech_WOQueue.Location = new System.Drawing.Point(522, 323);
            this.dataGrid_Tech_WOQueue.Name = "dataGrid_Tech_WOQueue";
            this.dataGrid_Tech_WOQueue.Size = new System.Drawing.Size(561, 319);
            this.dataGrid_Tech_WOQueue.TabIndex = 48;
            this.dataGrid_Tech_WOQueue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_Tech_WOQueue_CellContentClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(532, 296);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 18);
            this.label2.TabIndex = 49;
            this.label2.Text = "Your Work Order Details";
            // 
            // Technician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1088, 669);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid_Tech_WOQueue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.listBox_newRequest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.label_helloEmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel2);
            this.Name = "Technician";
            this.Text = "Technician";
            this.Load += new System.EventHandler(this.Technician_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_ShowDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Tech_WOQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label_helloEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button ViewHistoryButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Label label_currentStatus;
        private System.Windows.Forms.RadioButton radioButton_refund;
        private System.Windows.Forms.RadioButton radioButton_repair;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_rmaNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button delegateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGrid_ShowDetails;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox_newRequest;
        private System.Windows.Forms.DataGridView dataGrid_Tech_WOQueue;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RadioButton radioButton_replace;
        private System.Windows.Forms.Label label2;
    }
}
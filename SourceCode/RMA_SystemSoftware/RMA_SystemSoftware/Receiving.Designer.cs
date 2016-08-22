namespace RMA_SystemSoftware
{
    partial class Receiving
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
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_helloEmp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.textBox_rmaNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RadioB_repair = new System.Windows.Forms.RadioButton();
            this.RadioB_refund = new System.Windows.Forms.RadioButton();
            this.label_currentStatus = new System.Windows.Forms.Label();
            this.button_Show = new System.Windows.Forms.Button();
            this.button_viewHistory = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.ViewAllButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioB_replace = new System.Windows.Forms.RadioButton();
            this.button_verified = new System.Windows.Forms.Button();
            this.listBox_Open = new System.Windows.Forms.ListBox();
            this.listBox_Received = new System.Windows.Forms.ListBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_Wait = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.timer_AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(1018, 33);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(57, 17);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Logout!";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hello";
            // 
            // label_helloEmp
            // 
            this.label_helloEmp.AutoSize = true;
            this.label_helloEmp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_helloEmp.ForeColor = System.Drawing.Color.DarkRed;
            this.label_helloEmp.Location = new System.Drawing.Point(94, 33);
            this.label_helloEmp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_helloEmp.Name = "label_helloEmp";
            this.label_helloEmp.Size = new System.Drawing.Size(117, 18);
            this.label_helloEmp.TabIndex = 3;
            this.label_helloEmp.Text = "EmployeeName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter RMA#:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Request Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current Status:";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.Location = new System.Drawing.Point(965, 34);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(45, 17);
            this.linkLabel3.TabIndex = 10;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Help?";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // textBox_rmaNo
            // 
            this.textBox_rmaNo.Location = new System.Drawing.Point(151, 20);
            this.textBox_rmaNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_rmaNo.Name = "textBox_rmaNo";
            this.textBox_rmaNo.Size = new System.Drawing.Size(207, 22);
            this.textBox_rmaNo.TabIndex = 11;
            this.textBox_rmaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_rmaNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Update Status:";
            // 
            // RadioB_repair
            // 
            this.RadioB_repair.AutoSize = true;
            this.RadioB_repair.Location = new System.Drawing.Point(151, 93);
            this.RadioB_repair.Name = "RadioB_repair";
            this.RadioB_repair.Size = new System.Drawing.Size(58, 20);
            this.RadioB_repair.TabIndex = 14;
            this.RadioB_repair.TabStop = true;
            this.RadioB_repair.Text = "Repair";
            this.RadioB_repair.UseVisualStyleBackColor = true;
            this.RadioB_repair.CheckedChanged += new System.EventHandler(this.RadioB_repair_CheckedChanged);
            // 
            // RadioB_refund
            // 
            this.RadioB_refund.AutoSize = true;
            this.RadioB_refund.Location = new System.Drawing.Point(286, 93);
            this.RadioB_refund.Name = "RadioB_refund";
            this.RadioB_refund.Size = new System.Drawing.Size(60, 20);
            this.RadioB_refund.TabIndex = 15;
            this.RadioB_refund.TabStop = true;
            this.RadioB_refund.Text = "Refund";
            this.RadioB_refund.UseVisualStyleBackColor = true;
            this.RadioB_refund.CheckedChanged += new System.EventHandler(this.RadioB_refund_CheckedChanged);
            // 
            // label_currentStatus
            // 
            this.label_currentStatus.AutoSize = true;
            this.label_currentStatus.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.label_currentStatus.Location = new System.Drawing.Point(156, 60);
            this.label_currentStatus.Name = "label_currentStatus";
            this.label_currentStatus.Size = new System.Drawing.Size(90, 16);
            this.label_currentStatus.TabIndex = 16;
            this.label_currentStatus.Text = "Request Status";
            // 
            // button_Show
            // 
            this.button_Show.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Show.Location = new System.Drawing.Point(415, 266);
            this.button_Show.Name = "button_Show";
            this.button_Show.Size = new System.Drawing.Size(122, 23);
            this.button_Show.TabIndex = 17;
            this.button_Show.Text = "Show Details";
            this.button_Show.UseVisualStyleBackColor = true;
            this.button_Show.Click += new System.EventHandler(this.button_Show_Click);
            // 
            // button_viewHistory
            // 
            this.button_viewHistory.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewHistory.Location = new System.Drawing.Point(415, 307);
            this.button_viewHistory.Name = "button_viewHistory";
            this.button_viewHistory.Size = new System.Drawing.Size(122, 23);
            this.button_viewHistory.TabIndex = 18;
            this.button_viewHistory.Text = "View History";
            this.button_viewHistory.UseVisualStyleBackColor = true;
            this.button_viewHistory.Click += new System.EventHandler(this.button_viewHistory_Click);
            // 
            // button_Update
            // 
            this.button_Update.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.ForeColor = System.Drawing.Color.Red;
            this.button_Update.Location = new System.Drawing.Point(159, 210);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(113, 32);
            this.button_Update.TabIndex = 19;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Location = new System.Drawing.Point(151, 180);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(207, 24);
            this.comboBox_Status.TabIndex = 21;
            // 
            // ViewAllButton
            // 
            this.ViewAllButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAllButton.Location = new System.Drawing.Point(415, 102);
            this.ViewAllButton.Name = "ViewAllButton";
            this.ViewAllButton.Size = new System.Drawing.Size(122, 37);
            this.ViewAllButton.TabIndex = 22;
            this.ViewAllButton.Text = "View All Requests";
            this.ViewAllButton.UseVisualStyleBackColor = true;
            this.ViewAllButton.Click += new System.EventHandler(this.ViewAllButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioB_replace);
            this.groupBox1.Controls.Add(this.button_verified);
            this.groupBox1.Controls.Add(this.comboBox_Status);
            this.groupBox1.Controls.Add(this.button_Update);
            this.groupBox1.Controls.Add(this.label_currentStatus);
            this.groupBox1.Controls.Add(this.RadioB_refund);
            this.groupBox1.Controls.Add(this.RadioB_repair);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_rmaNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(36, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 259);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track/Update RMA";
            // 
            // RadioB_replace
            // 
            this.RadioB_replace.AutoSize = true;
            this.RadioB_replace.Location = new System.Drawing.Point(215, 93);
            this.RadioB_replace.Name = "RadioB_replace";
            this.RadioB_replace.Size = new System.Drawing.Size(65, 20);
            this.RadioB_replace.TabIndex = 23;
            this.RadioB_replace.TabStop = true;
            this.RadioB_replace.Text = "Replace";
            this.RadioB_replace.UseVisualStyleBackColor = true;
            this.RadioB_replace.CheckedChanged += new System.EventHandler(this.RadioB_replace_CheckedChanged);
            // 
            // button_verified
            // 
            this.button_verified.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_verified.ForeColor = System.Drawing.Color.Red;
            this.button_verified.Location = new System.Drawing.Point(159, 119);
            this.button_verified.Name = "button_verified";
            this.button_verified.Size = new System.Drawing.Size(113, 39);
            this.button_verified.TabIndex = 22;
            this.button_verified.Text = "Verified!!";
            this.button_verified.UseVisualStyleBackColor = true;
            this.button_verified.Click += new System.EventHandler(this.button_verified_Click);
            // 
            // listBox_Open
            // 
            this.listBox_Open.FormattingEnabled = true;
            this.listBox_Open.ItemHeight = 15;
            this.listBox_Open.Location = new System.Drawing.Point(562, 110);
            this.listBox_Open.Name = "listBox_Open";
            this.listBox_Open.Size = new System.Drawing.Size(148, 199);
            this.listBox_Open.TabIndex = 25;
            this.listBox_Open.SelectedIndexChanged += new System.EventHandler(this.listBox_Open_SelectedIndexChanged);
            // 
            // listBox_Received
            // 
            this.listBox_Received.FormattingEnabled = true;
            this.listBox_Received.ItemHeight = 15;
            this.listBox_Received.Location = new System.Drawing.Point(736, 110);
            this.listBox_Received.Name = "listBox_Received";
            this.listBox_Received.Size = new System.Drawing.Size(143, 199);
            this.listBox_Received.TabIndex = 26;
            this.listBox_Received.SelectedIndexChanged += new System.EventHandler(this.listBox_Received_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(756, 325);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(85, 26);
            this.button_refresh.TabIndex = 27;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(559, 89);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Open RMAs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(733, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Received RMAs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 367);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1039, 260);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(914, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "Awaiting Client";
            // 
            // listBox_Wait
            // 
            this.listBox_Wait.FormattingEnabled = true;
            this.listBox_Wait.ItemHeight = 15;
            this.listBox_Wait.Location = new System.Drawing.Point(917, 110);
            this.listBox_Wait.Name = "listBox_Wait";
            this.listBox_Wait.Size = new System.Drawing.Size(143, 199);
            this.listBox_Wait.TabIndex = 31;
            this.listBox_Wait.SelectedIndexChanged += new System.EventHandler(this.listBox_Wait_SelectedIndexChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(851, 29);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(85, 26);
            this.SearchButton.TabIndex = 33;
            this.SearchButton.Text = "Search RMA";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // timer_AutoRefresh
            // 
            this.timer_AutoRefresh.Enabled = true;
            this.timer_AutoRefresh.Interval = 60000;
            this.timer_AutoRefresh.Tick += new System.EventHandler(this.timer_AutoRefresh_Tick);
            // 
            // Receiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1118, 639);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox_Wait);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_viewHistory);
            this.Controls.Add(this.listBox_Received);
            this.Controls.Add(this.button_Show);
            this.Controls.Add(this.listBox_Open);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.ViewAllButton);
            this.Controls.Add(this.label_helloEmp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel2);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Receiving";
            this.Text = "Receiving";
            this.Load += new System.EventHandler(this.Receiving_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_helloEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TextBox textBox_rmaNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton RadioB_repair;
        private System.Windows.Forms.RadioButton RadioB_refund;
        private System.Windows.Forms.Label label_currentStatus;
        private System.Windows.Forms.Button button_Show;
        private System.Windows.Forms.Button button_viewHistory;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Button ViewAllButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_Open;
        private System.Windows.Forms.ListBox listBox_Received;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_verified;
        private System.Windows.Forms.RadioButton RadioB_replace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_Wait;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Timer timer_AutoRefresh;
    }
}
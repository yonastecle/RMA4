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
            this.label_rmaNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.textBox_rmaNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_currentStatus = new System.Windows.Forms.Label();
            this.button_viewHistory = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.ViewAllButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_comment = new System.Windows.Forms.Button();
            this.button_splitRma = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_quantity = new System.Windows.Forms.Label();
            this.textBox_reason = new System.Windows.Forms.TextBox();
            this.label_reason = new System.Windows.Forms.Label();
            this.textbox_desp = new System.Windows.Forms.TextBox();
            this.label_descp = new System.Windows.Forms.Label();
            this.label_customerName = new System.Windows.Forms.Label();
            this.label_requestType = new System.Windows.Forms.Label();
            this.listBox_Open = new System.Windows.Forms.ListBox();
            this.listBox_Received = new System.Windows.Forms.ListBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_Wait = new System.Windows.Forms.ListBox();
            this.timer_AutoRefresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(987, 33);
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
            // label_rmaNum
            // 
            this.label_rmaNum.AutoSize = true;
            this.label_rmaNum.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rmaNum.Location = new System.Drawing.Point(37, 24);
            this.label_rmaNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_rmaNum.Name = "label_rmaNum";
            this.label_rmaNum.Size = new System.Drawing.Size(102, 15);
            this.label_rmaNum.TabIndex = 4;
            this.label_rmaNum.Text = "Enter Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 212);
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
            this.label5.Location = new System.Drawing.Point(30, 159);
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
            this.linkLabel3.Location = new System.Drawing.Point(934, 34);
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
            this.textBox_rmaNo.Location = new System.Drawing.Point(147, 21);
            this.textBox_rmaNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_rmaNo.Name = "textBox_rmaNo";
            this.textBox_rmaNo.Size = new System.Drawing.Size(237, 22);
            this.textBox_rmaNo.TabIndex = 11;
            this.textBox_rmaNo.Text = "RMA123 or Serial No";
            this.textBox_rmaNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_rmaNo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Update Status:";
            // 
            // label_currentStatus
            // 
            this.label_currentStatus.AutoSize = true;
            this.label_currentStatus.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_currentStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.label_currentStatus.Location = new System.Drawing.Point(144, 158);
            this.label_currentStatus.Name = "label_currentStatus";
            this.label_currentStatus.Size = new System.Drawing.Size(90, 16);
            this.label_currentStatus.TabIndex = 16;
            this.label_currentStatus.Text = "Request Status";
            // 
            // button_viewHistory
            // 
            this.button_viewHistory.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewHistory.Location = new System.Drawing.Point(400, 280);
            this.button_viewHistory.Name = "button_viewHistory";
            this.button_viewHistory.Size = new System.Drawing.Size(99, 32);
            this.button_viewHistory.TabIndex = 18;
            this.button_viewHistory.Text = "View History";
            this.button_viewHistory.UseVisualStyleBackColor = true;
            this.button_viewHistory.Click += new System.EventHandler(this.button_viewHistory_Click);
            // 
            // button_Update
            // 
            this.button_Update.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.ForeColor = System.Drawing.Color.Red;
            this.button_Update.Location = new System.Drawing.Point(400, 174);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(99, 32);
            this.button_Update.TabIndex = 19;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Location = new System.Drawing.Point(145, 179);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(237, 24);
            this.comboBox_Status.TabIndex = 21;
            // 
            // ViewAllButton
            // 
            this.ViewAllButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewAllButton.Location = new System.Drawing.Point(593, 355);
            this.ViewAllButton.Name = "ViewAllButton";
            this.ViewAllButton.Size = new System.Drawing.Size(129, 37);
            this.ViewAllButton.TabIndex = 22;
            this.ViewAllButton.Text = "View All Requests";
            this.ViewAllButton.UseVisualStyleBackColor = true;
            this.ViewAllButton.Click += new System.EventHandler(this.ViewAllButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_comment);
            this.groupBox1.Controls.Add(this.button_splitRma);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_quantity);
            this.groupBox1.Controls.Add(this.textBox_reason);
            this.groupBox1.Controls.Add(this.label_reason);
            this.groupBox1.Controls.Add(this.textbox_desp);
            this.groupBox1.Controls.Add(this.label_descp);
            this.groupBox1.Controls.Add(this.label_customerName);
            this.groupBox1.Controls.Add(this.label_requestType);
            this.groupBox1.Controls.Add(this.comboBox_Status);
            this.groupBox1.Controls.Add(this.button_Update);
            this.groupBox1.Controls.Add(this.label_currentStatus);
            this.groupBox1.Controls.Add(this.button_viewHistory);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_rmaNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label_rmaNum);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(46, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 334);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track & Update RMA";
            // 
            // button_comment
            // 
            this.button_comment.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_comment.Location = new System.Drawing.Point(400, 242);
            this.button_comment.Name = "button_comment";
            this.button_comment.Size = new System.Drawing.Size(99, 32);
            this.button_comment.TabIndex = 34;
            this.button_comment.Text = "Add Comment";
            this.button_comment.UseVisualStyleBackColor = true;
            // 
            // button_splitRma
            // 
            this.button_splitRma.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_splitRma.Location = new System.Drawing.Point(400, 18);
            this.button_splitRma.Name = "button_splitRma";
            this.button_splitRma.Size = new System.Drawing.Size(99, 32);
            this.button_splitRma.TabIndex = 33;
            this.button_splitRma.Text = "Split RMA";
            this.button_splitRma.UseVisualStyleBackColor = true;
            this.button_splitRma.Click += new System.EventHandler(this.button_splitRma_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "Customer Name:";
            // 
            // label_quantity
            // 
            this.label_quantity.AutoSize = true;
            this.label_quantity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_quantity.Location = new System.Drawing.Point(422, 114);
            this.label_quantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_quantity.Name = "label_quantity";
            this.label_quantity.Size = new System.Drawing.Size(33, 15);
            this.label_quantity.TabIndex = 31;
            this.label_quantity.Text = "x 10";
            // 
            // textBox_reason
            // 
            this.textBox_reason.Location = new System.Drawing.Point(145, 231);
            this.textBox_reason.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_reason.Multiline = true;
            this.textBox_reason.Name = "textBox_reason";
            this.textBox_reason.Size = new System.Drawing.Size(237, 97);
            this.textBox_reason.TabIndex = 30;
            this.textBox_reason.Text = "Whatever is enteresd when RMA is created";
            // 
            // label_reason
            // 
            this.label_reason.AutoSize = true;
            this.label_reason.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_reason.Location = new System.Drawing.Point(78, 259);
            this.label_reason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_reason.Name = "label_reason";
            this.label_reason.Size = new System.Drawing.Size(59, 15);
            this.label_reason.TabIndex = 29;
            this.label_reason.Text = "Reason:";
            // 
            // textbox_desp
            // 
            this.textbox_desp.Location = new System.Drawing.Point(147, 78);
            this.textbox_desp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textbox_desp.Multiline = true;
            this.textbox_desp.Name = "textbox_desp";
            this.textbox_desp.Size = new System.Drawing.Size(235, 77);
            this.textbox_desp.TabIndex = 28;
            this.textbox_desp.Text = "Product Description";
            // 
            // label_descp
            // 
            this.label_descp.AutoSize = true;
            this.label_descp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_descp.Location = new System.Drawing.Point(50, 101);
            this.label_descp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_descp.Name = "label_descp";
            this.label_descp.Size = new System.Drawing.Size(87, 15);
            this.label_descp.TabIndex = 27;
            this.label_descp.Text = "Description:";
            // 
            // label_customerName
            // 
            this.label_customerName.AutoSize = true;
            this.label_customerName.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_customerName.ForeColor = System.Drawing.Color.DarkRed;
            this.label_customerName.Location = new System.Drawing.Point(147, 54);
            this.label_customerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_customerName.Name = "label_customerName";
            this.label_customerName.Size = new System.Drawing.Size(59, 16);
            this.label_customerName.TabIndex = 25;
            this.label_customerName.Text = "Customer";
            // 
            // label_requestType
            // 
            this.label_requestType.AutoSize = true;
            this.label_requestType.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_requestType.ForeColor = System.Drawing.Color.DarkRed;
            this.label_requestType.Location = new System.Drawing.Point(144, 212);
            this.label_requestType.Name = "label_requestType";
            this.label_requestType.Size = new System.Drawing.Size(33, 16);
            this.label_requestType.TabIndex = 24;
            this.label_requestType.Text = "Type";
            // 
            // listBox_Open
            // 
            this.listBox_Open.FormattingEnabled = true;
            this.listBox_Open.ItemHeight = 15;
            this.listBox_Open.Location = new System.Drawing.Point(583, 105);
            this.listBox_Open.Name = "listBox_Open";
            this.listBox_Open.Size = new System.Drawing.Size(148, 244);
            this.listBox_Open.TabIndex = 25;
            this.listBox_Open.SelectedIndexChanged += new System.EventHandler(this.listBox_Open_SelectedIndexChanged);
            // 
            // listBox_Received
            // 
            this.listBox_Received.FormattingEnabled = true;
            this.listBox_Received.ItemHeight = 15;
            this.listBox_Received.Location = new System.Drawing.Point(753, 105);
            this.listBox_Received.Name = "listBox_Received";
            this.listBox_Received.Size = new System.Drawing.Size(143, 244);
            this.listBox_Received.TabIndex = 26;
            this.listBox_Received.SelectedIndexChanged += new System.EventHandler(this.listBox_Received_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(938, 355);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(97, 37);
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
            this.label8.Location = new System.Drawing.Point(611, 82);
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
            this.label9.Location = new System.Drawing.Point(764, 82);
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
            this.dataGridView1.Location = new System.Drawing.Point(46, 419);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1012, 224);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(930, 84);
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
            this.listBox_Wait.Location = new System.Drawing.Point(915, 105);
            this.listBox_Wait.Name = "listBox_Wait";
            this.listBox_Wait.Size = new System.Drawing.Size(143, 244);
            this.listBox_Wait.TabIndex = 31;
            this.listBox_Wait.SelectedIndexChanged += new System.EventHandler(this.listBox_Wait_SelectedIndexChanged);
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
            this.ClientSize = new System.Drawing.Size(1092, 664);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox_Wait);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.listBox_Received);
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
        private System.Windows.Forms.Label label_rmaNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TextBox textBox_rmaNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_currentStatus;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_Wait;
        private System.Windows.Forms.Timer timer_AutoRefresh;
        private System.Windows.Forms.Label label_customerName;
        private System.Windows.Forms.Label label_requestType;
        private System.Windows.Forms.Label label_quantity;
        private System.Windows.Forms.TextBox textBox_reason;
        private System.Windows.Forms.Label label_reason;
        private System.Windows.Forms.TextBox textbox_desp;
        private System.Windows.Forms.Label label_descp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_comment;
        private System.Windows.Forms.Button button_splitRma;
    }
}
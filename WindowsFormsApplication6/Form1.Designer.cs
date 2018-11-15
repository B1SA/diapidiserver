namespace WindowsFormsApplication6
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
            this.DIS_Connect = new System.Windows.Forms.Button();
            this.DIS_CreateBP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DIS_CardType = new System.Windows.Forms.ComboBox();
            this.DIS_GetBpList = new System.Windows.Forms.Button();
            this.DIS_BPCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DIA_CardType = new System.Windows.Forms.ComboBox();
            this.DIA_GetBpList = new System.Windows.Forms.Button();
            this.DIA_BPCode = new System.Windows.Forms.TextBox();
            this.DIA_Connect = new System.Windows.Forms.Button();
            this.DIA_CreateBP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DIS_Connect
            // 
            this.DIS_Connect.Location = new System.Drawing.Point(6, 19);
            this.DIS_Connect.Name = "DIS_Connect";
            this.DIS_Connect.Size = new System.Drawing.Size(178, 23);
            this.DIS_Connect.TabIndex = 0;
            this.DIS_Connect.Text = "Connect";
            this.DIS_Connect.UseVisualStyleBackColor = true;
            this.DIS_Connect.Click += new System.EventHandler(this.DISConnect_Click);
            // 
            // DIS_CreateBP
            // 
            this.DIS_CreateBP.Location = new System.Drawing.Point(6, 73);
            this.DIS_CreateBP.Name = "DIS_CreateBP";
            this.DIS_CreateBP.Size = new System.Drawing.Size(75, 20);
            this.DIS_CreateBP.TabIndex = 1;
            this.DIS_CreateBP.Text = "Create BP";
            this.DIS_CreateBP.UseVisualStyleBackColor = true;
            this.DIS_CreateBP.Click += new System.EventHandler(this.DIS_CreateBP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DIS_CardType);
            this.groupBox1.Controls.Add(this.DIS_GetBpList);
            this.groupBox1.Controls.Add(this.DIS_BPCode);
            this.groupBox1.Controls.Add(this.DIS_Connect);
            this.groupBox1.Controls.Add(this.DIS_CreateBP);
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 102);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DI Server";
            // 
            // DIS_CardType
            // 
            this.DIS_CardType.FormattingEnabled = true;
            this.DIS_CardType.Items.AddRange(new object[] {
            "Lid",
            "Customer",
            "Supplier"});
            this.DIS_CardType.Location = new System.Drawing.Point(84, 50);
            this.DIS_CardType.Name = "DIS_CardType";
            this.DIS_CardType.Size = new System.Drawing.Size(97, 21);
            this.DIS_CardType.TabIndex = 4;
            this.DIS_CardType.SelectedIndexChanged += new System.EventHandler(this.DIS_CardType_SelectedIndexChanged);
            // 
            // DIS_GetBpList
            // 
            this.DIS_GetBpList.Location = new System.Drawing.Point(6, 50);
            this.DIS_GetBpList.Name = "DIS_GetBpList";
            this.DIS_GetBpList.Size = new System.Drawing.Size(75, 21);
            this.DIS_GetBpList.TabIndex = 3;
            this.DIS_GetBpList.Text = "Get BP List";
            this.DIS_GetBpList.UseVisualStyleBackColor = true;
            this.DIS_GetBpList.Click += new System.EventHandler(this.DIS_GetBpList_Click);
            // 
            // DIS_BPCode
            // 
            this.DIS_BPCode.Location = new System.Drawing.Point(84, 73);
            this.DIS_BPCode.Name = "DIS_BPCode";
            this.DIS_BPCode.Size = new System.Drawing.Size(97, 20);
            this.DIS_BPCode.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DIA_CardType);
            this.groupBox2.Controls.Add(this.DIA_GetBpList);
            this.groupBox2.Controls.Add(this.DIA_BPCode);
            this.groupBox2.Controls.Add(this.DIA_Connect);
            this.groupBox2.Controls.Add(this.DIA_CreateBP);
            this.groupBox2.Location = new System.Drawing.Point(240, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 102);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DI API";
            // 
            // DIA_CardType
            // 
            this.DIA_CardType.FormattingEnabled = true;
            this.DIA_CardType.Items.AddRange(new object[] {
            "Lid",
            "Customer",
            "Supplier"});
            this.DIA_CardType.Location = new System.Drawing.Point(84, 50);
            this.DIA_CardType.Name = "DIA_CardType";
            this.DIA_CardType.Size = new System.Drawing.Size(97, 21);
            this.DIA_CardType.TabIndex = 4;
            // 
            // DIA_GetBpList
            // 
            this.DIA_GetBpList.Location = new System.Drawing.Point(6, 50);
            this.DIA_GetBpList.Name = "DIA_GetBpList";
            this.DIA_GetBpList.Size = new System.Drawing.Size(75, 21);
            this.DIA_GetBpList.TabIndex = 3;
            this.DIA_GetBpList.Text = "Get BP List";
            this.DIA_GetBpList.UseVisualStyleBackColor = true;
            this.DIA_GetBpList.Click += new System.EventHandler(this.DIA_GetBpList_Click);
            // 
            // DIA_BPCode
            // 
            this.DIA_BPCode.Location = new System.Drawing.Point(84, 73);
            this.DIA_BPCode.Name = "DIA_BPCode";
            this.DIA_BPCode.Size = new System.Drawing.Size(97, 20);
            this.DIA_BPCode.TabIndex = 2;
            // 
            // DIA_Connect
            // 
            this.DIA_Connect.Location = new System.Drawing.Point(6, 19);
            this.DIA_Connect.Name = "DIA_Connect";
            this.DIA_Connect.Size = new System.Drawing.Size(178, 23);
            this.DIA_Connect.TabIndex = 0;
            this.DIA_Connect.Text = "Connect";
            this.DIA_Connect.UseVisualStyleBackColor = true;
            this.DIA_Connect.Click += new System.EventHandler(this.DIA_Connect_Click);
            // 
            // DIA_CreateBP
            // 
            this.DIA_CreateBP.Location = new System.Drawing.Point(6, 73);
            this.DIA_CreateBP.Name = "DIA_CreateBP";
            this.DIA_CreateBP.Size = new System.Drawing.Size(75, 20);
            this.DIA_CreateBP.TabIndex = 1;
            this.DIA_CreateBP.Text = "Create BP";
            this.DIA_CreateBP.UseVisualStyleBackColor = true;
            this.DIA_CreateBP.Click += new System.EventHandler(this.DIA_CreateBP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 131);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "DI Server x DIAPI - Sample LSRetail";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DIS_Connect;
        private System.Windows.Forms.Button DIS_CreateBP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DIS_BPCode;
        private System.Windows.Forms.Button DIS_GetBpList;
        private System.Windows.Forms.ComboBox DIS_CardType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox DIA_CardType;
        private System.Windows.Forms.Button DIA_GetBpList;
        private System.Windows.Forms.TextBox DIA_BPCode;
        private System.Windows.Forms.Button DIA_Connect;
        private System.Windows.Forms.Button DIA_CreateBP;
    }
}


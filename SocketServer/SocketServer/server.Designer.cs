namespace SocketServer
{
    partial class server
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbIp = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.tbShowMsg = new System.Windows.Forms.TextBox();
            this.cboIpPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbIp
            // 
            this.lbIp.Location = new System.Drawing.Point(27, 13);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(18, 22);
            this.lbIp.TabIndex = 0;
            this.lbIp.Text = "IP:";
            // 
            // tbIp
            // 
            this.tbIp.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbIp.Location = new System.Drawing.Point(51, 10);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(132, 27);
            this.tbIp.TabIndex = 1;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(206, 13);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(41, 12);
            this.lbPort.TabIndex = 2;
            this.lbPort.Text = "Port：";
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbPort.Location = new System.Drawing.Point(249, 9);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 27);
            this.tbPort.TabIndex = 3;
            // 
            // btConnect
            // 
            this.btConnect.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btConnect.Location = new System.Drawing.Point(388, 7);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(96, 23);
            this.btConnect.TabIndex = 4;
            this.btConnect.Text = "開始監聽";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConect_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(580, 326);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 7;
            this.btSend.Text = "發送";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbShowMsg
            // 
            this.tbShowMsg.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbShowMsg.Location = new System.Drawing.Point(51, 58);
            this.tbShowMsg.Multiline = true;
            this.tbShowMsg.Name = "tbShowMsg";
            this.tbShowMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbShowMsg.Size = new System.Drawing.Size(500, 191);
            this.tbShowMsg.TabIndex = 8;
            // 
            // cboIpPort
            // 
            this.cboIpPort.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboIpPort.FormattingEnabled = true;
            this.cboIpPort.Location = new System.Drawing.Point(580, 267);
            this.cboIpPort.Name = "cboIpPort";
            this.cboIpPort.Size = new System.Drawing.Size(226, 24);
            this.cboIpPort.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(578, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "選擇用戶：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(51, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "顯示數據區：";
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(51, 267);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(500, 104);
            this.tbSend.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "發送數據區：";
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(580, 355);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 51;
            this.btnOut.Text = "导出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click_1);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(829, 433);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboIpPort);
            this.Controls.Add(this.tbShowMsg);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.lbIp);
            this.Name = "server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbIp;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.TextBox tbShowMsg;
        private System.Windows.Forms.ComboBox cboIpPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOut;

    }
}


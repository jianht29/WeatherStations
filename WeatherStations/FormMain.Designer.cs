namespace WeatherStations
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxMqtt = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.formsPlotQy = new ScottPlot.FormsPlot();
            this.formsPlotFs = new ScottPlot.FormsPlot();
            this.formsPlotSd = new ScottPlot.FormsPlot();
            this.formsPlotWd = new ScottPlot.FormsPlot();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelDqy = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelFs = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelWd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.groupBoxMqtt.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMqtt
            // 
            this.groupBoxMqtt.Controls.Add(this.textBoxPort);
            this.groupBoxMqtt.Controls.Add(this.label5);
            this.groupBoxMqtt.Controls.Add(this.textBoxPwd);
            this.groupBoxMqtt.Controls.Add(this.label3);
            this.groupBoxMqtt.Controls.Add(this.textBoxUid);
            this.groupBoxMqtt.Controls.Add(this.label2);
            this.groupBoxMqtt.Controls.Add(this.textBoxServer);
            this.groupBoxMqtt.Controls.Add(this.label1);
            this.groupBoxMqtt.Controls.Add(this.buttonConnect);
            this.groupBoxMqtt.Location = new System.Drawing.Point(12, 12);
            this.groupBoxMqtt.Name = "groupBoxMqtt";
            this.groupBoxMqtt.Size = new System.Drawing.Size(641, 59);
            this.groupBoxMqtt.TabIndex = 20;
            this.groupBoxMqtt.TabStop = false;
            this.groupBoxMqtt.Text = "MQTT服务器设置";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPort.Location = new System.Drawing.Point(239, 23);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(51, 23);
            this.textBoxPort.TabIndex = 28;
            this.textBoxPort.Text = "1883";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(203, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "端口";
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPwd.Location = new System.Drawing.Point(452, 23);
            this.textBoxPwd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(63, 23);
            this.textBoxPwd.TabIndex = 26;
            this.textBoxPwd.Text = "dfrobot";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(416, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "密码";
            // 
            // textBoxUid
            // 
            this.textBoxUid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUid.Location = new System.Drawing.Point(346, 23);
            this.textBoxUid.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxUid.Name = "textBoxUid";
            this.textBoxUid.Size = new System.Drawing.Size(64, 23);
            this.textBoxUid.TabIndex = 24;
            this.textBoxUid.Text = "siot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(296, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 23;
            this.label2.Text = "用户名";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxServer.Location = new System.Drawing.Point(57, 23);
            this.textBoxServer.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(140, 23);
            this.textBoxServer.TabIndex = 22;
            this.textBoxServer.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "服务器";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConnect.Location = new System.Drawing.Point(528, 19);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(104, 31);
            this.buttonConnect.TabIndex = 20;
            this.buttonConnect.Text = "连接服务器";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.formsPlotQy);
            this.groupBoxData.Controls.Add(this.formsPlotFs);
            this.groupBoxData.Controls.Add(this.formsPlotSd);
            this.groupBoxData.Controls.Add(this.formsPlotWd);
            this.groupBoxData.Controls.Add(this.panel4);
            this.groupBoxData.Controls.Add(this.panel3);
            this.groupBoxData.Controls.Add(this.panel2);
            this.groupBoxData.Controls.Add(this.panel1);
            this.groupBoxData.Location = new System.Drawing.Point(12, 72);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Size = new System.Drawing.Size(641, 501);
            this.groupBoxData.TabIndex = 21;
            this.groupBoxData.TabStop = false;
            // 
            // formsPlotQy
            // 
            this.formsPlotQy.Location = new System.Drawing.Point(319, 297);
            this.formsPlotQy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formsPlotQy.Name = "formsPlotQy";
            this.formsPlotQy.Size = new System.Drawing.Size(312, 196);
            this.formsPlotQy.TabIndex = 25;
            // 
            // formsPlotFs
            // 
            this.formsPlotFs.Location = new System.Drawing.Point(10, 297);
            this.formsPlotFs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formsPlotFs.Name = "formsPlotFs";
            this.formsPlotFs.Size = new System.Drawing.Size(312, 196);
            this.formsPlotFs.TabIndex = 24;
            // 
            // formsPlotSd
            // 
            this.formsPlotSd.Location = new System.Drawing.Point(320, 97);
            this.formsPlotSd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formsPlotSd.Name = "formsPlotSd";
            this.formsPlotSd.Size = new System.Drawing.Size(312, 196);
            this.formsPlotSd.TabIndex = 23;
            // 
            // formsPlotWd
            // 
            this.formsPlotWd.Location = new System.Drawing.Point(9, 97);
            this.formsPlotWd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formsPlotWd.Name = "formsPlotWd";
            this.formsPlotWd.Size = new System.Drawing.Size(312, 196);
            this.formsPlotWd.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.labelDqy);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(481, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(151, 75);
            this.panel4.TabIndex = 21;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel4_Paint);
            // 
            // labelDqy
            // 
            this.labelDqy.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDqy.Location = new System.Drawing.Point(-1, 43);
            this.labelDqy.Name = "labelDqy";
            this.labelDqy.Size = new System.Drawing.Size(151, 23);
            this.labelDqy.TabIndex = 11;
            this.labelDqy.Text = "102311.5";
            this.labelDqy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(7, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "大气压 Pa";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.labelFs);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(324, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 75);
            this.panel3.TabIndex = 19;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // labelFs
            // 
            this.labelFs.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFs.Location = new System.Drawing.Point(-1, 43);
            this.labelFs.Name = "labelFs";
            this.labelFs.Size = new System.Drawing.Size(151, 23);
            this.labelFs.TabIndex = 11;
            this.labelFs.Text = "1.2";
            this.labelFs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(7, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "风速 m/s";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.labelSd);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(167, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 75);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // labelSd
            // 
            this.labelSd.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSd.Location = new System.Drawing.Point(-1, 43);
            this.labelSd.Name = "labelSd";
            this.labelSd.Size = new System.Drawing.Size(151, 23);
            this.labelSd.TabIndex = 11;
            this.labelSd.Text = "45.0";
            this.labelSd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(7, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "湿度 %";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelWd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(10, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 75);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // labelWd
            // 
            this.labelWd.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWd.Location = new System.Drawing.Point(-1, 43);
            this.labelWd.Name = "labelWd";
            this.labelWd.Size = new System.Drawing.Size(151, 23);
            this.labelWd.TabIndex = 11;
            this.labelWd.Text = "26.3";
            this.labelWd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "温度 ℃";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.labelInfo);
            this.groupBoxInfo.Location = new System.Drawing.Point(12, 573);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(641, 62);
            this.groupBoxInfo.TabIndex = 22;
            this.groupBoxInfo.TabStop = false;
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelInfo.Location = new System.Drawing.Point(3, 10);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(635, 49);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "没有连接到MQTT服务器，请先连接MQTT服务器";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 646);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.groupBoxData);
            this.Controls.Add(this.groupBoxMqtt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "在线数字气象站 - 没有连接到MQTT服务器，请先连接MQTT服务器";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxMqtt.ResumeLayout(false);
            this.groupBoxMqtt.PerformLayout();
            this.groupBoxData.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxMqtt;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelDqy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelFs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelSd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWd;
        private System.Windows.Forms.Label label4;
        private ScottPlot.FormsPlot formsPlotWd;
        private ScottPlot.FormsPlot formsPlotQy;
        private ScottPlot.FormsPlot formsPlotFs;
        private ScottPlot.FormsPlot formsPlotSd;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label labelInfo;
    }
}


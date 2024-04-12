/*
使用MQTTnet和ScottPlot开发的“在线数字气象站”物联网可视化项目。

1.MQTTnet是一个高性能的.NET库。用于连接MQTT服务器，订阅主题和向主题发布消息。

MQTTnet相关的资源链接：

GitHub：https://github.com/dotnet/MQTTnet
NuGet：https://www.nuget.org/packages/MQTTnet/

2.ScottPlot是一个免费、开源的.NET绘图库，专为快速、简洁的数据可视化而设计。它提供了丰富的图表类型，包括折线图、散点图、柱状图等，并且支持交互式操作。

ScottPlot相关的网络链接：

官方网站：https://scottplot.net/
GitHub：https://github.com/ScottPlot/ScottPlot

3.SIoT是一个为教育定制的跨平台的开源MQTT服务器程序。建议使用SIoT1.3作为MQTT服务器进行本示例程序的测试。

SIoT相关的网络链接：

使用手册：https://siot.readthedocs.io/zh-cn/latest/
Gitee：https://gitee.com/vvlink/SIoT
GitHub：https://github.com/vvlink/SIoT/
*/
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet.Server;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherStations
{
    public partial class FormMain : Form
    {
        public static IMqttClient MqttClient;
        /// <summary>
        /// MQTT服务器的IP地址或域名
        /// </summary>
        public string Mqtt_Server = "127.0.0.1";
        /// <summary>
        /// MQTT服务器的端口，一般为1883
        /// </summary>
        public int Mqtt_Port = 1883;
        /// <summary>
        /// MQTT服务器的用户名
        /// </summary>
        public string Mqtt_UserName = "siot";
        /// <summary>
        /// MQTT服务器的密码
        /// </summary>
        public string Mqtt_PassWord = "dfrobot";
        /// <summary>
        /// MQTT客户端的ID
        /// </summary>
        public string Mqtt_ClientId = "MyClient";

        // ScottPlot图表数据
        public List<DateTime> WdTimes = new List<DateTime>();
        public List<double> WdDatas = new List<double>();
        public List<DateTime> SdTimes = new List<DateTime>();
        public List<double> SdDatas = new List<double>();
        public List<DateTime> FsTimes = new List<DateTime>();
        public List<double> FsDatas = new List<double>();
        public List<DateTime> QyTimes = new List<DateTime>();
        public List<double> QyDatas = new List<double>();

        /// <summary>
        /// 使用指定的参数连接MQTT服务器
        /// </summary>
        public void MqttClientStart()
        {
            // MQTT连接参数
            var mqttClientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(Mqtt_Server, Mqtt_Port)	// MQTT服务器的IP和端口号
                .WithCredentials(Mqtt_UserName, Mqtt_PassWord)      // MQTT服务器的用户名和密码
                .WithClientId(Mqtt_ClientId + Guid.NewGuid().ToString("N"))	// 自动设置客户端ID的后缀，以免出现重复
                .WithCleanSession();

            var mqttClientOptions = mqttClientOptionsBuilder.Build();
            MqttClient = new MqttFactory().CreateMqttClient();

            // 客户端连接成功事件
            MqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
            // 客户端连接关闭事件
            MqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
            // 收到订阅消息事件
            MqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
            // 连接MQTT服务器
            try
            {
                MqttClient.ConnectAsync(mqttClientOptions);
            }
            catch (Exception ex)
            {
                labelInfo.Text = ex.Message;
            }
        }

        /// <summary>
        /// 断开已经连接的MQTT服务器
        /// </summary>
        public void MqttClientStop()
        {
            if (MqttClient != null && MqttClient.IsConnected)
            {
                var mqttClientDisconnectOptions = new MqttFactory().CreateClientDisconnectOptionsBuilder().Build();
                MqttClient.DisconnectAsync(mqttClientDisconnectOptions, CancellationToken.None);
                MqttClient.Dispose();
                MqttClient = null;
            }
        }

        /// <summary>
        /// 当MQTT服务器连接被断开时发生的事件
        /// </summary>
        private Task MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            this.Invoke(new Action(() =>
            {
                this.Text = "在线数字气象站 - 没有连接到MQTT服务器，请先连接MQTT服务器";
                labelInfo.Text = "没有连接到MQTT服务器，请先连接MQTT服务器";
                labelInfo.ForeColor = Color.SteelBlue;
                buttonConnect.Text = "连接服务器";
            }));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 当MQTT服务器成功连接时发生的事件
        /// </summary>
        private Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            this.Invoke(new Action(() =>
                        {
                            this.Text = "在线数字气象站 - 连接到MQTT服务器";
                            labelInfo.Text = "已经成功连接到MQTT服务器";
                            labelInfo.ForeColor = Color.SeaGreen;
                            buttonConnect.Text = "断开服务器";
                        }));
            // 订阅消息主题
            // MqttQualityOfServiceLevel: （QoS）:
            // AtMostOnce 0: 最多一次，接收者不确认收到消息，并且消息不被发送者存储和重新发送提供与底层 TCP 协议相同的保证。
            // AtLeastOnce 1: 保证一条消息至少有一次会传递给接收方。发送方存储消息，直到它从接收方收到确认收到消息的数据包。一条消息可以多次发送或传递。
            // ExactlyOnce 2: 保证每条消息仅由预期的收件人接收一次。级别2是最安全和最慢的服务质量级别，保证由发送方和接收方之间的至少两个请求/响应（四次握手）。
            //MqttClient.SubscribeAsync("Project/Topic1", MqttQualityOfServiceLevel.AtLeastOnce);
            //MqttClient.SubscribeAsync("Project/Topic2", MqttQualityOfServiceLevel.AtLeastOnce);
            //MqttClient.SubscribeAsync("Project/Topic3", MqttQualityOfServiceLevel.AtLeastOnce);

            MqttClient.SubscribeAsync("WeatherStation/WenDu", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("WeatherStation/ShiDu", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("WeatherStation/FengSu", MqttQualityOfServiceLevel.AtLeastOnce);
            MqttClient.SubscribeAsync("WeatherStation/QiYa", MqttQualityOfServiceLevel.AtLeastOnce);

            return Task.CompletedTask;
        }

        /// <summary>
        /// 当从MQTT服务器收到订阅消息的事件
        /// </summary>
        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            this.Invoke(new Action(() =>
            {
                switch (arg.ApplicationMessage.Topic)
                {
                    case "WeatherStation/WenDu":
                        labelWd.Text = Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()).ToString("F1");
                        WdTimes.Add(DateTime.Now);
                        WdDatas.Add(Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()));

                        double[] wdDataX = WdTimes.Select(x => x.ToOADate()).ToArray();
                        double[] wdDataY = WdDatas.Select(y => Math.Round(y, 1)).ToArray();
                        formsPlotWd.Reset();
                        formsPlotWd.Plot.YAxis.Label("温度 ℃");
                        formsPlotWd.Plot.AddScatterLines(wdDataX, wdDataY);
                        formsPlotWd.Plot.XAxis.DateTimeFormat(true);
                        formsPlotWd.Plot.Style(Style.Gray1);
                        formsPlotWd.Render();
                        break;
                    case "WeatherStation/ShiDu":
                        labelSd.Text = Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()).ToString("F1");
                        SdTimes.Add(DateTime.Now);
                        SdDatas.Add(Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()));

                        double[] sdDataX = SdTimes.Select(x => x.ToOADate()).ToArray();
                        double[] sdDataY = SdDatas.Select(y => Math.Round(y, 1)).ToArray();
                        formsPlotSd.Reset();
                        formsPlotSd.Plot.YAxis.Label("湿度 %");
                        formsPlotSd.Plot.AddScatterLines(sdDataX, sdDataY);
                        formsPlotSd.Plot.XAxis.DateTimeFormat(true);
                        formsPlotSd.Render();
                        break;
                    case "WeatherStation/FengSu":
                        labelFs.Text = Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()).ToString("F1");
                        FsTimes.Add(DateTime.Now);
                        FsDatas.Add(Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()));

                        double[] fsDataX = FsTimes.Select(x => x.ToOADate()).ToArray();
                        double[] fsDataY = FsDatas.Select(y => Math.Round(y, 1)).ToArray();
                        formsPlotFs.Reset();
                        formsPlotFs.Plot.YAxis.Label("风速 m/s");
                        formsPlotFs.Plot.AddScatterLines(fsDataX, fsDataY);
                        formsPlotFs.Plot.XAxis.DateTimeFormat(true);
                        formsPlotFs.Render();
                        break;
                    case "WeatherStation/QiYa":
                        labelDqy.Text = Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()).ToString("F1");
                        QyTimes.Add(DateTime.Now);
                        QyDatas.Add(Convert.ToDouble(arg.ApplicationMessage.ConvertPayloadToString()) / 1000);

                        double[] qyDataX = QyTimes.Select(x => x.ToOADate()).ToArray();
                        double[] qyDataY = QyDatas.Select(y => Math.Round(y, 1)).ToArray();
                        formsPlotQy.Reset();
                        formsPlotQy.Plot.YAxis.Label("大气压 KPa");
                        formsPlotQy.Plot.AddScatterLines(qyDataX, qyDataY);
                        formsPlotQy.Plot.XAxis.DateTimeFormat(true);
                        formsPlotQy.Render();
                        break;
                    default:
                        break;
                }

            }));

            return Task.CompletedTask;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            // 建议使用SIoT1.3作为MQTT服务器进行测试
            // 使用手册：https://siot.readthedocs.io/zh-cn/latest/
            // Gitee：https://gitee.com/vvlink/SIoT
            // GitHub：https://github.com/vvlink/SIoT/

            // MQTTnet相关资源链接
            // GitHub：https://github.com/dotnet/MQTTnet
            // NuGet：https://www.nuget.org/packages/MQTTnet/

            if (buttonConnect.Text == "连接服务器")
            {
                // 可以在任意位置重新设置需要连接的MQTT服务参数
                Mqtt_Server = this.textBoxServer.Text;
                Int32.TryParse(this.textBoxPort.Text, out Mqtt_Port);
                Mqtt_UserName = this.textBoxUid.Text;
                Mqtt_PassWord = this.textBoxPwd.Text;
                Mqtt_ClientId = "WeatherStations_";

                // 使用MQTTnet连接MQTT服务器
                MqttClientStop();
                MqttClientStart();
                buttonConnect.Text = "断开服务器";
            }
            else
            {
                MqttClientStop();
                buttonConnect.Text = "连接服务器";
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel_Paint(e, panel1, Color.LightGray);
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel_Paint(e, panel2, Color.LightGray);
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel_Paint(e, panel3, Color.LightGray);
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {
            Panel_Paint(e, panel4, Color.LightGray);
        }

        public void Panel_Paint(PaintEventArgs e, Panel p, Color c)
        {
            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle,
                        c, 1, ButtonBorderStyle.Solid, //左边
                        c, 10, ButtonBorderStyle.Solid, //上边
                        c, 1, ButtonBorderStyle.Solid, //右边
                        c, 1, ButtonBorderStyle.Solid);//底边
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            formsPlotWd.Plot.YAxis.Label("温度 ℃");
            formsPlotSd.Plot.YAxis.Label("湿度 %");
            formsPlotFs.Plot.YAxis.Label("风速 m/s");
            formsPlotQy.Plot.YAxis.Label("大气压 KPa");
            formsPlotWd.Plot.Style(Style.Control);
            formsPlotSd.Plot.Style(Style.Control);
            formsPlotFs.Plot.Style(Style.Control);
            formsPlotQy.Plot.Style(Style.Control);
            formsPlotWd.Render();
            formsPlotSd.Render();
            formsPlotFs.Render();
            formsPlotQy.Render();
        }
    }
}

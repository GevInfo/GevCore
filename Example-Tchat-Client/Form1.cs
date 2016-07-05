using Example_Tchat_Client.Frame;
using GevCore.Network;
using GevCore.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_Tchat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClientHost client;

        private void bt_connect_Click(object sender, EventArgs e)
        {
            var newclient = new SimpleClient();
            client = new ClientHost(newclient);
            client.name = tb_name.Text;
            client.AddFrame(new IdentificationFrame());
            newclient.Start(tb_IP.Text, 400);

            Thread.Sleep(500);

            if (!newclient.Runing)
                MessageBox.Show("Connection Failed !");
        }

        #region Connected
        delegate void FormConnectedCallBack();

        public void ForThread()
        {
            Size = new Size(520, 490);
            bt_connect.Visible = false;
            lbl_IP.Visible = false;
            lbl_name.Visible = false;
            tb_IP.Visible = false;
            tb_name.Visible = false;
            bt_connect.Enabled = false;

            bt_send.Visible = true;
            tb_all.Visible = true;
            tb_enter.Visible = true;

            AcceptButton = bt_send;
        }

        public void FormConnected()
        {
            if (InvokeRequired && bt_connect.InvokeRequired && bt_send.InvokeRequired && lbl_IP.InvokeRequired && lbl_name.InvokeRequired &&
                tb_all.InvokeRequired && tb_enter.InvokeRequired && tb_IP.InvokeRequired && tb_name.InvokeRequired)
            {
                FormConnectedCallBack d = new FormConnectedCallBack(ForThread);
                this.Invoke(d, new object[] { });
            }
            else
                ForThread();
        }
        #endregion

        #region Tchat
        private void bt_send_Click(object sender, EventArgs e)
        {
            client.Send(new SimpleMessage(tb_enter.Text));
            tb_enter.Text = "";
        }

        delegate void TextReceiveCallback(SenderMessage msg);

        public void SetText(SenderMessage msg)
        {
            if (tb_all.InvokeRequired)
            {
                TextReceiveCallback d = new TextReceiveCallback(SetText);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.tb_all.Text += string.Format("{0} : {1} {2}", msg.name ,msg.text, Environment.NewLine);
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            ProtocolTypeManager.Initialize();
            MessageReceiver.Initialize();
        }

    }
}

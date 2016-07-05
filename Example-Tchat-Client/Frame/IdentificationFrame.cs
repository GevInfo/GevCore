using GevCore.Dispatcher;
using GevCore.Network;
using GevCore.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_Tchat_Client.Frame
{
    public class IdentificationFrame
    {
        [MessageHandler(HelloConnectMessage.Id)]
        private void HandleHelloConnectMessage(ClientHost client, HelloConnectMessage msg)
        {
            client.Send(new IdentificationMessage(client.name));
        }

        [MessageHandler(IdentificationSuccesMessage.Id)]
        private void HandleIdentificationSuccesMessage(ClientHost client, IdentificationSuccesMessage msg)
        {
            Program.ActualForm.FormConnected();
            client.RemoveFrame(typeof(IdentificationFrame));
            client.AddFrame(new ChannelFrame());
        }

        [MessageHandler(IdentificationErrorMessage.Id)]
        private void HandleIdentificationErrorMessage(ClientHost client, IdentificationErrorMessage msg)
        {
            MessageBox.Show("This name is taken.");
        }
    }
}

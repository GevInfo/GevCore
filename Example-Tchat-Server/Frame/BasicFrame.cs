using Example_Tchat_Server.Network;
using GevCore.Dispatcher;
using GevCore.Network;
using GevCore.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server.Frame
{
    public class BasicFrame
    {
        [MessageHandler(SimpleMessage.Id)]
        private void HandleSimpleMessage(ClientHost client, SimpleMessage msg)
        {
            AuthServer.Instance.SendToAll(new SenderMessage(client.name, msg.text));
        }

        [MessageHandler(IdentificationMessage.Id)]
        private void HandleIdentificationMessage(ClientHost client, IdentificationMessage msg)
        {
            if (AuthServer.Instance.HasClientName(msg.name))
            {
                client.Send(new IdentificationErrorMessage());
                client.Dispose();
            }
            else
            {
                client.name = msg.name;
                client.Send(new IdentificationSuccesMessage());
            }
        }
    }
}

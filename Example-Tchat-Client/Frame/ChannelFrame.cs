using GevCore.Dispatcher;
using GevCore.Network;
using GevCore.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Client.Frame
{
    public class ChannelFrame
    {
        [MessageHandler(SenderMessage.Id)]
        private void HandleSenderMessage(ClientHost client, SenderMessage msg)
        {
            Program.ActualForm.SetText(msg);
        }
    }
}

using Example_Tchat_Server.Frame;
using Example_Tchat_Server.Utils;
using GevCore.Extensions;
using GevCore.Network;
using GevCore.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Example_Tchat_Server.Network
{
    public class AuthServer : DataManager<AuthServer>
    {
        #region Vars
        private SimpleServer m_server;
        private List<ClientHost> m_clients;
        #endregion

        #region Constructor
        public AuthServer()
        {
            m_server = new SimpleServer();
            m_clients = new List<ClientHost>();
        }
        #endregion

        #region Event
        private void AccepteClient(Socket client)
        {
            var newClient = new SimpleClient(client);
            ClientHost currentClient = new ClientHost(newClient);
            currentClient.Disconnected += ClientDisconnected;

            currentClient.AddFrame(new BasicFrame());
            currentClient.Send(new HelloConnectMessage());

            m_clients.Add(currentClient);
        }

        private void ClientDisconnected(object sender, ClientHost.DisconnectedArgs e)
        {
            m_clients.Remove(e.Host);
        }
        #endregion

        #region Public Function
        public void Start()
        {
            m_server.Start(400);
            m_server.ConnectionAccepted += AccepteClient;

            MyConsole.Write(string.Format("Listening on port {0}.", 400));
        }

        public void RemoveClient(ClientHost client)
        {
            m_clients.Remove(client);
        }

        public void SendToAll(NetworkMessage message)
        {
            foreach (var client in m_clients)
                client.Send(message);
        }

        public void SendToAllExcept(NetworkMessage msg, ClientHost except)
        {
            foreach (var client in m_clients)
                if (client != except)
                    client.Send(msg);
        }

        public int GetClientsCount()
        {
            return m_clients.Count;
        }

        public bool HasClientName(string name)
        {
            return m_clients.FirstOrDefault(x => x.name == name) != null;
        }
        #endregion
    }
}

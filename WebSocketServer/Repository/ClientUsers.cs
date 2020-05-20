using System;
using System.Collections.Generic;
using System.Net.WebSockets;

namespace WebSocketServer.Repository
{
    public class ClientUsers:IClientUsers
    {
        public ClientUsers()
        {
            this.clients = new  Lazy<Dictionary<string,WebSocket>>(() => new Dictionary<string, WebSocket>()).Value;
        }

        public Dictionary<string, WebSocket> clients { get; set; }
    }
}
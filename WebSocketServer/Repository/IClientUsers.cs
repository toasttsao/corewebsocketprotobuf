using System.Collections.Generic;
using System.Net.WebSockets;

namespace WebSocketServer.Repository
{
    public interface IClientUsers
    {
        
          Dictionary<string, WebSocket> clients { get; set; }
    }
}
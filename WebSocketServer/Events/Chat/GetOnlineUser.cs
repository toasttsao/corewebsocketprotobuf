using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using WebSocketServer.Repository;

namespace WebSocketServer.Events.Chat
{
    public class GetOnlineUser:IChartEvent
    {
        public EMessageType MessageType { get; set; } = EMessageType.GetOnlineUsers;
        private readonly IClientUsers _client;

        public GetOnlineUser(IClientUsers client)
        {
            _client = client;
        }

        public async Task MessageSend(chatMessageRequest userInfoRequest)
        {
            var response = new chatMessageResponse {MsgType = messageTypes.GetOnlineUsers};
            var users= _client.clients.Select(s => s.Key);
            response.Users.Add(users);
           response.Cnt = _client.clients.Count();
           var outputBuffer =new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);

           foreach (var item in _client.clients.Values)
           {
               await item.SendAsync(outputBuffer, WebSocketMessageType.Binary, true, CancellationToken.None);
           }
       
        }
    }
}
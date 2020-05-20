using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using WebSocketServer.Repository;

namespace WebSocketServer.Events.Chat
{
    public class Personal:IChartEvent
    {
        private readonly IClientUsers _client;

        public Personal(IClientUsers client)
        {
            _client = client;
        }
        public EMessageType MessageType { get; set; } = EMessageType.Personal;
        public async Task MessageSend(chatMessageRequest userInfoRequest)
        {
            var response = new chatMessageResponse
            {
                MsgType = messageTypes.Person,
                Message = $"{userInfoRequest.User} 私底下對你說: {userInfoRequest.Message}" 
            };
     

            var outputBuffer =new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);

            var user = _client.clients.FirstOrDefault(w => w.Key == userInfoRequest.Touser);
            if (user.Value== null)
            {
                return;
            }

            await user.Value.SendAsync(outputBuffer, WebSocketMessageType.Binary, true, CancellationToken.None);



        }
    }
}
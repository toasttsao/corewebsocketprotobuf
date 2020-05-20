using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using WebSocketServer.Repository;

namespace WebSocketServer.Events.Chat
{
    /// <summary>
    /// 公開聊天
    /// </summary>
    public class BrocastAll:IChartEvent
    {
        private readonly IClientUsers _client;
        public BrocastAll(IClientUsers client)
        {
            _client = client;
        }

        public EMessageType MessageType { get; set; } = EMessageType.All;
        public async Task MessageSend(chatMessageRequest userInfoRequest)
        {
            
            var response =new chatMessageResponse()
            {
                MsgType = messageTypes.All,
                Message =$"{userInfoRequest.User} 說:{userInfoRequest.Message}" 
            };
            
            var outputBuffer =new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);
            //廣播濾掉自己的發言
            var all_client = _client.clients.Where(w => w.Key != userInfoRequest.User).Select(s => s.Value);
            
            foreach (var item in  all_client)
            {
                
                await item.SendAsync(outputBuffer, WebSocketMessageType.Binary, true, CancellationToken.None);
            }
           
        }
    }
}
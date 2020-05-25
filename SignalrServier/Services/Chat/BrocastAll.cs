using Google.Protobuf;
using Microsoft.AspNetCore.SignalR;
using SignalrServier.Hubs;
using SignalrServier.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServier.Services.Chat
{
    public class BrocastAll : IChartEvent
    {
        public EMessageType MessageType { get; set; } = EMessageType.All;



        public async Task MessageSend(IHubCallerClients clients, chatMessageRequest userInfoRequest)
        {
            
            var response = new chatMessageResponse()
            {
                SelfconnetionId = userInfoRequest.SelfconnetionId,
                MsgType = messageTypes.All,
                Message =userInfoRequest.Message
            };

            
            var outputBuffer = new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);
            await clients.All.SendAsync("brocaste", outputBuffer);

        }
    }
}

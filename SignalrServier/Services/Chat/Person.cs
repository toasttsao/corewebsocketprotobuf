using System;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.AspNetCore.SignalR;

namespace SignalrServier.Services.Chat
{
    public class Person: IChartEvent
    {
        public EMessageType MessageType { get; set; } = EMessageType.Personal;
        public async Task MessageSend(IHubCallerClients clients, chatMessageRequest userInfoRequest)
        {
            var response = new chatMessageResponse()
            {
                SelfconnetionId = userInfoRequest.SelfconnetionId,
                
                MsgType = messageTypes.Person,
                Message =userInfoRequest.Message
            };

            
            var outputBuffer = new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);
            await clients.Client(userInfoRequest.OtherconnetionId).SendAsync("person", outputBuffer);
        }
    }
}
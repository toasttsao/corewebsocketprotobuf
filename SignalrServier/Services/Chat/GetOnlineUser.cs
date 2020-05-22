using Google.Protobuf;
using Microsoft.AspNetCore.SignalR;
using SignalrServier.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServier.Services.Chat
{
    public class GetOnlineUser : IChartEvent
    {
        public EMessageType MessageType { get; set; } = EMessageType.GetOnlineUsers;
        private readonly IClientUsers _clientUsers;

        public GetOnlineUser(IClientUsers clientUsers) {
            _clientUsers = clientUsers;
        }

        public async Task MessageSend(IHubCallerClients clients, chatMessageRequest userInfoRequest)
        {
            var response = new chatMessageResponse { MsgType = messageTypes.GetOnlineUsers };
            var users = _clientUsers.clients.Select(s => s.Key);
            response.Users.Add(users);
            response.Cnt = _clientUsers.clients.Count();
            response.SelfconnetionId = userInfoRequest.SelfconnetionId;
     
            var outputBuffer = new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);

            await clients.All.SendAsync("getonlineUser", outputBuffer);

        }
    }
}

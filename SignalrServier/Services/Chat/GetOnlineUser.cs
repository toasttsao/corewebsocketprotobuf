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
        private readonly IUserManger _clientUsers;

        public GetOnlineUser(IUserManger clientUsers) {
            _clientUsers = clientUsers;
        }

        public async Task MessageSend(IHubCallerClients clients, chatMessageRequest userInfoRequest)
        {
            var response = new chatMessageResponse { MsgType = messageTypes.GetOnlineUsers };
            var userRepository= await  _clientUsers.GetOnlineUser();
            var userCntRepository= await  _clientUsers.GetOnlineUserCnt();
            var users = userRepository.Select(s=>new chatMessageResponse.Types.user()
            {
                ConnectionId = s.Key,
                Name = s.Value
            });

                response.Users.AddRange(users); 
                response.Cnt = userCntRepository;
                response.SelfconnetionId = userInfoRequest.SelfconnetionId;
            var outputBuffer = new ArraySegment<byte>(response.ToByteArray(), 0, (int)response.ToByteArray().Length);

            await clients.All.SendAsync("getonlineUser", outputBuffer);

        }
    }
}

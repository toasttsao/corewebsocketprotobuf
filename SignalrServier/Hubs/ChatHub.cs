using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalrServier.Extensions;
using SignalrServier.Repository;
using SignalrServier.Services.Chat;

namespace SignalrServier.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IEnumerable<IChartEvent> _chartEvents;
        private readonly IUserIdProvider _userIdProvider;
        private readonly IUserManger _userManger;

        public ChatHub(IEnumerable<IChartEvent> chartEvents, IUserIdProvider userIdProvider, IUserManger userManger)
        {
            _chartEvents = chartEvents;
            _userIdProvider = userIdProvider;
            _userManger = userManger;
        }

        public async Task Send(string strByteArray)
        {
            var myByteArray = Convert.FromBase64String(strByteArray);
            var buffer = new ArraySegment<byte>(myByteArray);
            var byteArrayContent = await buffer.ConvertToStreamAsync(buffer.Count);
            var user_req = chatMessageRequest.Parser.ParseFrom(byteArrayContent);

            var instance = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType) user_req.MsgType);

            await instance.MessageSend(Clients, user_req);
        }


        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var name = httpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(JwtRegisteredClaimNames.Sid))?.Value;

            await _userManger.AddUser(Context.ConnectionId, name);

            var instance = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType) 0);
            var user_req = new chatMessageRequest {MsgType = 0};
            await instance.MessageSend(Clients, user_req);


            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            var name = httpContext.User.Claims.FirstOrDefault(o => o.Type.Equals(JwtRegisteredClaimNames.Sid))?.Value;
            await _userManger.RemoveUser(Context.ConnectionId, name);

            var client_user_cnt = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType) 0);
            var user_req = new chatMessageRequest {MsgType = messageTypes.GetOnlineUsers};
            await client_user_cnt.MessageSend(Clients, user_req);

            var client_user_msg = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType) 1);
            var user_req_msg = new chatMessageRequest
            {
                MsgType = messageTypes.All,
                Message = $"{name}已離線 bye~~"
            };

            await client_user_msg.MessageSend(Clients, user_req_msg);

            await base.OnDisconnectedAsync(exception);
        }

        protected override void Dispose(bool disposing)
        {
        }
    }
}
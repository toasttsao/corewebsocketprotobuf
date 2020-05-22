using Microsoft.AspNetCore.SignalR;
using SignalrServier.Repository;
using System;
using System.Threading.Tasks;
using SignalrServier.Extensions;
using System.Collections.Generic;
using SignalrServier.Services.Chat;
using System.Linq;
using StackExchange.Redis;

namespace SignalrServier.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IEnumerable<IChartEvent> _chartEvents;
        private readonly IUserIdProvider _userIdProvider;
         private readonly IUserManger _userManger;
        public ChatHub( IEnumerable<IChartEvent> chartEvents, IUserIdProvider userIdProvider, IUserManger userManger) {
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


                var instance = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType)1);


               await instance.MessageSend(Clients, user_req);

        }





        public override async Task OnConnectedAsync() {


             var httpContext = Context.GetHttpContext();
             var name =  httpContext.Request.Query["username"];
             await  _userManger.AddUser(this.Context.ConnectionId, name);
           
    
           
            var instance = _chartEvents.FirstOrDefault(w => w.MessageType == (EMessageType)0);
            var user_req = new chatMessageRequest() { MsgType = 0 };
            await instance.MessageSend(Clients, user_req);


            await base.OnConnectedAsync();
        }
     
        public override async Task OnDisconnectedAsync(Exception exception) {
            var httpContext = Context.GetHttpContext();
            var name = httpContext.Request.Query["username"];
           await  _userManger.RemoveUser(this.Context.ConnectionId, name);

            await base.OnDisconnectedAsync(exception);
        }
    
        protected override void Dispose(bool disposing) {
        
        }

    }
}


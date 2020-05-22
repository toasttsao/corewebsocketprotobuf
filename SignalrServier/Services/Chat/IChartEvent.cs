using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServier.Services.Chat
{
   public interface IChartEvent
    {
        EMessageType MessageType { get; set; }
        Task MessageSend(IHubCallerClients clients, chatMessageRequest userInfoRequest);
    }
}

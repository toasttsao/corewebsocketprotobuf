using System.Threading.Tasks;

namespace WebSocketServer.Events.Chat
{
    public interface  IChartEvent
    {
        EMessageType MessageType { get; set; }
        Task MessageSend(chatMessageRequest userInfoRequest);
    }
}
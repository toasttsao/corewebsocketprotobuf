using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSocketServer.Events.Chat;
using WebSocketServer.Extensions;
using WebSocketServer.Repository;

namespace WebSocketServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IClientUsers, ClientUsers>();
            services.AddSingleton<IChartEvent, BrocastAll>();
            services.AddSingleton<IChartEvent, GetOnlineUser>();
            services.AddSingleton<IChartEvent, Personal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024,
               // AllowedOrigins = { "https://localhost:44333/" }
            });
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var users = context.RequestServices.GetService<IClientUsers>();

                        var user_name = context.Request.Query["user"];
                        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        users.clients.Add(user_name, webSocket);


                        var buffer = new ArraySegment<byte>(new byte[1024 * 4]);
                        var result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                        while (!result.CloseStatus.HasValue)
                        {
                            var chartImps = context.RequestServices.GetServices<IChartEvent>();
                            var byteArrayContent = await buffer.ConvertToStreamAsync(result.Count);
                            var user_req = chatMessageRequest.Parser.ParseFrom(byteArrayContent);
                            var msg_type = (EMessageType) user_req.MsgType;

                            var instance = chartImps.FirstOrDefault(s => s.MessageType == msg_type);

                            if (instance != null) await instance.MessageSend(user_req);

                            result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                        }

                        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
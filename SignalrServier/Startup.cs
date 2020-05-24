using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalrServier.Hubs;
using SignalrServier.Repository;
using SignalrServier.Services.Chat;
using StackExchange.Redis;


namespace SignalrServier
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR()
                .AddStackExchangeRedis(o =>
                {
                    o.ConnectionFactory = async writer =>
                    {
                        var config = new ConfigurationOptions
                        {
                            AbortOnConnectFail = false,
                            DefaultDatabase = 0
                        };
                        
                        config.EndPoints.Add(IPAddress.Loopback, 6379);
                        config.SetDefaultPorts();
                        var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
                        connection.ConnectionFailed += (_, e) =>
                        {
                            Console.WriteLine("Redis GG");
                        };

                        if (!connection.IsConnected)
                        {
                            Console.WriteLine("Not Connected");
                        }
                        
                        return connection;
                    };
                });
            services.AddSingleton<IUserManger, CacheUserManger>();
            services.AddSingleton<IClientUsers, ClientUsers>();

            services.AddSingleton<IChartEvent, BrocastAll>();
            services.AddSingleton<IChartEvent, GetOnlineUser>();
            services.AddSingleton<IConnectionMultiplexer>( s => ConnectionMultiplexer.Connect(Configuration.GetValue<string>("storage:redis:master")));

            services.AddCors(op =>
            {
                op.AddPolicy("CorsPolicy", set =>
                {
                    set.SetIsOriginAllowed(origin => true)
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapHub<ChatHub>("/chat");
            });

     
        }
    }
}

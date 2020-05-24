using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
    
        public void ConfigureServices(IServiceCollection services)
        {
            //加入JWT驗證
            services.AddAuthentication(
                    opt =>
                    {
                        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(
                    opt =>
                    {
                        opt.RequireHttpsMetadata = false;
                        opt.SaveToken = true;
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = false,
                            ValidateIssuer = true,
                            ValidIssuer = Configuration.GetValue<string>("Jwt:JwtIssuer"),
                            ValidAudience = Configuration.GetValue<string>("Jwt:JwtAudience"),
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:JwtKey"))),
                            ClockSkew = TimeSpan.Zero // remove delay of token when expire
                        };
                        opt.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var accessToken = context.Request.Query["access_token"];
                         
                                // If the request is for our hub...
                                var path = context.HttpContext.Request.Path;
                                if (!string.IsNullOrEmpty(accessToken) &&
                                    (path.StartsWithSegments("/chat")))
                                {
                                    // Read the token out of the query string
                                    context.Token = accessToken;
                                }
                                return Task.CompletedTask;
                            }
                        };
                    });
            
            services.AddSignalR()
                    //加入Redis Back plan
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
                            Console.WriteLine("Redis Not Connected");
                        }
                        
                        return connection;
                    };
                });
            
            
            services.AddSingleton<IConnectionMultiplexer>( s => ConnectionMultiplexer.Connect(Configuration.GetValue<string>("storage:redis:master")));
          
 
            services.AddSingleton<IUserManger, CacheUserManger>();
            services.AddSingleton<IChartEvent, BrocastAll>();
            services.AddSingleton<IChartEvent, GetOnlineUser>();
            services.AddSingleton<IChartEvent, Person>();
     

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
            });
            
       

       
        }
    }
}

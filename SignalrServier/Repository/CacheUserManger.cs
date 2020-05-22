using System.Threading.Tasks;
using StackExchange.Redis;

namespace SignalrServier.Repository
{
    public class CacheUserManger:IUserManger
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public CacheUserManger(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public Task GetOnlineUser()
        {
            //todo 帶實作
            throw new System.NotImplementedException();
        }

        public async Task AddUser(string connect_id, string user_name)
        {
            var db =  _connectionMultiplexer.GetDatabase(0);
           
          await  db.StringIncrementAsync("usercnt");
          await  db.HashSetAsync("users", new [] {
                new HashEntry(connect_id,user_name)
            });
            
 
        }

        public async Task RemoveUser(string connect_id, string user_name)
        {
            var db =  _connectionMultiplexer.GetDatabase(0);
            await  db.StringDecrementAsync("usercnt");
            await  db.HashDeleteAsync("users",connect_id);
        }
    }
}
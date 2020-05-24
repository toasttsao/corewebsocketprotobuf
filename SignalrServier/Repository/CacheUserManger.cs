using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace SignalrServier.Repository
{
    /// <summary>
    /// 將使用者資訊放置Redis中
    /// </summary>
    public class CacheUserManger:IUserManger
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public CacheUserManger(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public async Task<int> GetOnlineUserCnt()
        {
            var db =  _connectionMultiplexer.GetDatabase(0);

            return Convert.ToInt32(await db.StringGetAsync("usercnt"));
        }

        public async Task <Dictionary<RedisValue,RedisValue>> GetOnlineUser()
        {
       
            var db =  _connectionMultiplexer.GetDatabase(0);
            var record =await  db.HashGetAllAsync("users");
            var result=   record.ToDictionary();


            return result;
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
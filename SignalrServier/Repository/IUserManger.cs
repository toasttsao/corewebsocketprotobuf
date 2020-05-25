using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace SignalrServier.Repository
{
    public interface IUserManger
    {
        
        

        Task <int>  GetOnlineUserCnt();
        Task <Dictionary<RedisValue,RedisValue>>  GetOnlineUser();
        
        Task AddUser(string connect_id,string user_name);
        
        Task RemoveUser(string connect_id,string user_name);
    }
}
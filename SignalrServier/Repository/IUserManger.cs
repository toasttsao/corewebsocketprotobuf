using System.Threading.Tasks;

namespace SignalrServier.Repository
{
    public interface IUserManger
    {
        
        
        Task GetOnlineUser();
        
        Task AddUser(string connect_id,string user_name);
        
        Task RemoveUser(string connect_id,string user_name);
    }
}
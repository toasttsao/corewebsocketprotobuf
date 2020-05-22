using System;
using System.Collections.Generic;


namespace SignalrServier.Repository
{
    public class ClientUsers : IClientUsers
    {
        public ClientUsers()
        {
            this.clients = new Lazy<Dictionary<string, string>>(() => new Dictionary<string, string>()).Value;
        }

        public Dictionary<string, string> clients { get; set; }
    }
}
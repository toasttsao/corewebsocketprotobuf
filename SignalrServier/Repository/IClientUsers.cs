using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrServier.Repository
{
    public interface IClientUsers
    {

        Dictionary<string,string> clients { get; set; }
    }
}


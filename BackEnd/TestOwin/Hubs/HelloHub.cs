using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOwin.Hubs
{
    class HelloHub:Hub
    {
        public void Send(string msg)
        {
            Clients.All.hello(Context.ConnectionId, msg);
        }
    }
}

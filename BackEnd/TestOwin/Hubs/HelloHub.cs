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
        public async Task Send(string msg)
        {
            await Clients.All.SendAsync("Hello", Context.ConnectionId, msg);
        }
    }
}

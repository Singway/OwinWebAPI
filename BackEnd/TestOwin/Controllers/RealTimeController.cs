using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TestOwin.Hubs;

namespace TestOwin.Controllers
{
    public  class RealTimeController : ApiController
    {
        private static readonly HelloHub hub =new HelloHub();
        public void Send(string msg)
        {
            hub.Send(msg);
        }
    }
}

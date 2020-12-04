using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Web;

namespace TestSocket
{
    public static class SocketLibrary
    {
        public readonly static Dictionary<string, WebSocket> sockets = new Dictionary<string, WebSocket>();
    }
}
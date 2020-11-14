using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;

namespace TestSocket.Controllers
{
    [RoutePrefix("api/socket")]
    public class SocketController : ApiController
    {
        private static  WebSocket webSocket;
        [HttpGet, Route("get")]
        public HttpResponseMessage Get()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(ProcessWSMsg);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.SwitchingProtocols);
        }

        [HttpGet, Route("send")]
        public async Task Send()
        {
            string msg = "测试数据";
            var bytes = Encoding.UTF8.GetBytes(msg);
            await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, new CancellationToken());
        }

        private async Task ProcessWSMsg(AspNetWebSocketContext arg)
        {
            //获取当前的WebSocket对象
            webSocket = arg.WebSocket;

            /*
             * 我们定义一个常数，它将表示接收到的数据的大小。 它是由我们建立的，我们可以设定任何值。 我们知道在这种情况下，发送的数据的大小非常小。
            */
            const int maxMessageSize = 1024;

            //received bits的缓冲区
            var receivedDataBuffer = new ArraySegment<byte>(new byte[maxMessageSize]);

            var cancellationToken = new CancellationToken();

            //检查WebSocket状态
            while (webSocket.State == WebSocketState.Open)
            {
                //读取数据 
                WebSocketReceiveResult webSocketReceiveResult = await webSocket.ReceiveAsync(receivedDataBuffer, cancellationToken);

                //如果输入帧为取消帧，发送close命令
                if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken);
                }
                else
                {
                    byte[] payloadData = receivedDataBuffer.Array.Where(b => b != 0).ToArray();

                    //因为我们知道这是一个字符串，我们转换它
                    string receiveString = Encoding.UTF8.GetString(payloadData, 0, payloadData.Length);

                    //将字符串转换为字节数组. 
                    var newString = string.Format("Hello, " + receiveString + " ! Time {0}", DateTime.Now.ToString());
                    byte[] bytes = Encoding.UTF8.GetBytes(newString);

                    //发回数据
                    await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, cancellationToken);
                }

            }
        }



    }
}

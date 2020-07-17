using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Owin;
using TestOwin.Controllers;

namespace TestOwin
{
    public  class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            //创建Web API 的配置
            var config = new HttpConfiguration();
            //启动标记路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );
            //将路有配置附加到appBuilder
            app.UseWebApi(config);
        }
    }
}

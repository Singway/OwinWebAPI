using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url: baseAddress))
            {
                HttpClient client = new HttpClient();
                Console.WriteLine(baseAddress);
                Console.ReadLine();
            }
        }
    }
}

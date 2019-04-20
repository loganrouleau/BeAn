using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;
using SimpleWebServer;

// Playing around with a server example (copied from https://codehosting.net/blog/BlogEngine/post/Simple-C-Web-Server)
class Program
{
    static void Main(string[] args)
    {
        WebServer ws = new WebServer(SendResponse, "http://localhost:8080/test/");
        ws.Run();
        Console.WriteLine("A simple webserver. Press a key to quit.");
        Console.ReadKey();
        ws.Stop();
    }

    public static string SendResponse(HttpListenerRequest request)
    {
        return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
    }
}
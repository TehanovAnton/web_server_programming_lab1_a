using System;
using System.Web;
using System.Collections.Specialized;
using System.Collections;
using System.Text.Json;
using System.IO;

namespace lab1_a.handlers
{
    public class PutHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            HttpRequest req = context.Request;

            Hashtable parameters = new Hashtable();
            using (StreamReader requestStream = new StreamReader(req.InputStream))
            {
                string requestBody = requestStream.ReadToEnd();
                parameters = JsonSerializer.Deserialize<Hashtable>(requestBody);
            }

            string response = $"Put-Http-TAV:ParmA = {parameters["a"]}, ParmB = {parameters["b"]}";

            res.ContentType = "text/plain";
            res.Write(response);
        }
    }
}

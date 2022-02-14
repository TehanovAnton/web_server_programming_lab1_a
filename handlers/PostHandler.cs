using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.IO;
using System.Text.Json;


namespace lab1_a
{
    public class PostHandler : IHttpHandler
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

            string response = $"Post-Http-TAV:ParmA = {parameters["a"]}, ParmB = {parameters["b"]}";

            res.ContentType = "text/plain";
            res.Write(response);
        }        
    }
}

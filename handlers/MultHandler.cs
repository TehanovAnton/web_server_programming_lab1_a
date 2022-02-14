using System;
using System.IO;
using System.Web;
using System.Collections;
using System.Text.Json;

namespace lab1_a.handlers
{
    public class MultHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            HttpResponse res = context.Response;

            if (req.HttpMethod == "GET")
            {
                string multXhr = File.ReadAllText(@"C:\Users\Anton\source\3к-2с\программирование_интернет_серверов\лабораторные\lab1_ a\lab1_a\pages\MultXhr.html");

                res.ContentType = "text/html";
                res.Write(multXhr);
            }
            else if (req.HttpMethod == "POST")
            {
                Hashtable parameters = new Hashtable();
                using (StreamReader requestStream = new StreamReader(req.InputStream))
                {
                    string body = requestStream.ReadToEnd();
                    parameters = JsonSerializer.Deserialize<Hashtable>(body);
                }

                int multParams = 1;
                foreach(string key in parameters.Keys)
                {
                    string value = parameters[key].ToString();
                    multParams *= int.Parse(value);
                }
                
                res.Write(multParams);
            }
        }
    }
}

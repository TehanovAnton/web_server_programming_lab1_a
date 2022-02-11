using System;
using System.Collections.Specialized;
using System.Web;
using System.IO;


namespace lab1_a
{
    public class IISHandler2 : IHttpHandler
    {        
        public bool IsReusable
        {            
            get { return true; }
        }

        public NameValueCollection Params(HttpRequest request)
        {
            return request.Params;
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            HttpRequest req = context.Request;

            NameValueCollection parameters = Params(req);
            string response = $"Post-Http-TAV:ParmA = {parameters["a"]}, ParmB = {parameters["b"]}";

            res.ContentType = "text/plain";
            res.Write(response);
        }        
    }
}

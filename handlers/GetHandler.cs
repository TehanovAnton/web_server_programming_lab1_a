using System;
using System.Web;
using System.Collections.Specialized;

namespace lab1_a.handlers
{
    public class GetHandler : IHttpHandler
    {        
        public bool IsReusable
        {            
            get { return true; }
        }

        public NameValueCollection QueryString(HttpRequest request)
        {
            return request.QueryString;
        }
         
        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;
            HttpRequest req = context.Request;

            NameValueCollection queryString = QueryString(req);
            String response = $"Get-Http-TAV:ParmA = {queryString["a"]}, ParmB = {queryString["b"]}";

            res.ContentType = "text/plain";
            res.Write(response);
        }
    }
}

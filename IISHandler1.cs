using System;
using System.Web;
using System.Collections.Specialized;

namespace lab1_a
{
    public class IISHandler1 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        
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

            res.Write(response);
        }
    }
}

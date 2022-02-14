using System;
using System.Web;
using System.IO;

namespace lab1_a.handlers
{
    public class SumParametersForm : IHttpHandler
    {
        public bool IsReusable
        {            
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse res = context.Response;

            string sumParametersPage = File.ReadAllText(@"C:\Users\Anton\source\3к-2с\программирование_интернет_серверов\лабораторные\lab1_ a\lab1_a\pages\SumParameters.html");

            res.ContentType = "text/html";
            res.Write(sumParametersPage);
        }
    }
}

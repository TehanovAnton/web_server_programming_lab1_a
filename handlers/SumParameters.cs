using System;
using System.IO;
using System.Collections;
using System.Text.Json;
using System.Web;

namespace lab1_a.handlers
{
    public class SumParameters : IHttpHandler
    {        
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            HttpResponse res = context.Response;

            int sumParameters = 0;
            foreach (string key in req.Form.Keys)
            {
                string value = req.Form[key].ToString();
                sumParameters += int.Parse(value);
            }

            res.Write(sumParameters);
        }
    }
}

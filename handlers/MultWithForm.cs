using System;
using System.IO;
using System.Collections;
using System.Text.Json;
using System.Web;

namespace lab1_a.handlers
{
    public class MultWithForm : IHttpHandler
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
                string multXhr = File.ReadAllText(@"C:\Users\Anton\source\3к-2с\программирование_интернет_серверов\лабораторные\lab1_ a\lab1_a\pages\MultWithForm.html");

                res.ContentType = "text/html";
                res.Write(multXhr);
            }
            else if (req.HttpMethod == "POST")
            {
                int multParams = 1;
                foreach (string key in req.Form.Keys)
                {
                    string value = req.Form[key].ToString();
                    multParams *= int.Parse(value);
                }

                res.ContentType = "text/plain";
                res.Write(multParams);
            }
        }
    }
}

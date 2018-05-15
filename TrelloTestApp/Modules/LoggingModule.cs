using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;

namespace TrelloTestApp.Modules
{
    public class LoggingModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleBeginRequest;
            //context.EndRequest += HandleEndRequest;
        }

        public void Dispose()
        {
        }

        private void HandleBeginRequest(object src, EventArgs args)
        {
            HttpContext context = HttpContext.Current;
            HttpRequest request = context.Request;

            StringBuilder headers = new StringBuilder();
            foreach (string key in request.Headers)
            {
                headers.AppendFormat("{0}: {1}\n", key, request.Headers[key]);
            }

            StreamReader reader = new StreamReader(request.InputStream);
            string body = reader.ReadToEnd();

            Trace.TraceInformation($"Url: {request.Url}, Method: {request.HttpMethod}\n" +
                                   "Headers:\n" +
                                   headers + "\n" +
                                   body);
        }
        private void HandleEndRequest(object src, EventArgs args)
        {
        }
    }
}
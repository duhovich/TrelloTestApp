using System;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using System.Diagnostics;
using System.Linq;

namespace TrelloTestApp.Controllers
{
    public class TrelloWebHookHandler : WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            Trace.TraceInformation(DateTime.Now.ToShortTimeString() + Environment.NewLine);
            Trace.TraceInformation(Receiver + Environment.NewLine);
            Trace.TraceInformation(context.Actions.First() + Environment.NewLine);
            Trace.TraceInformation(context.Data + Environment.NewLine);

            return Task.FromResult(true);
        }
    }
}
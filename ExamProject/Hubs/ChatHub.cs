using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExamProject.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, int company, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, company, message);
        }
    }
}
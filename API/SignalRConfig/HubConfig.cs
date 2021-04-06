using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SignalRConfig
{
    public class HubConfig : Hub
    {
        public async Task askServer(string message)
        {
            message = "Нови студент се пријавио за пројекат: " + message;
            await Clients.All.SendAsync("askServerResponse", message);
        }
    }
}

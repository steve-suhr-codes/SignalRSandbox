using Microsoft.AspNetCore.SignalR;

namespace SignalRSandbox.Hubs
{
	public class TimeHub : Hub
	{
        public async Task SendTime(string currentTime)
        {
            await Clients.All.SendAsync("ReceiveTime", currentTime);
        }
    }
}


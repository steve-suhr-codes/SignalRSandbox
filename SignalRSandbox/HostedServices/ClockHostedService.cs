using System;
using Microsoft.AspNetCore.SignalR;
using SignalRSandbox.Hubs;

namespace SignalRSandbox.HostedServices
{
	public class ClockHostedService : IHostedService, IDisposable
	{
        private IHubContext<TimeHub> _hubContext;
        private Timer _timer;

		public ClockHostedService(IHubContext<TimeHub> hubContext)
		{
            _hubContext = hubContext;
		}

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CalculateTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void CalculateTime(object state)
        {
            var time = DateTime.Now.TimeOfDay.ToString();
            _hubContext.Clients.All.SendAsync("ReceiveTime", time);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}


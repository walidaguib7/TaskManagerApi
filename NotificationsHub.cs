using Microsoft.AspNetCore.SignalR;

namespace TasksApi
{
    public class NotificationsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}

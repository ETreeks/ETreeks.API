using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace ETreeks.API.Hubs
{
    public class NotificationHub : Hub
    {


        public async Task RegisterUser(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
           
           Console.WriteLine($"User {userId} added to group {userId} with connection ID {Context.ConnectionId}");
        }

        public async Task SendNotificationToUser(string userId, string message)
        {
            await Clients.Group(userId).SendAsync("ReceiveNotification", message);
            Console.WriteLine($"Notification sent to user {userId}: {message}");
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.GetHttpContext().Request.Query["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
                Console.WriteLine($"User {userId} removed from group {userId} with connection ID {Context.ConnectionId}");
            }

            await base.OnDisconnectedAsync(exception);
        }

    }
}

using System.Threading.Tasks;

namespace ScrumKit.Poker.Hub
{
    public class PokerHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync().ConfigureAwait(false);

            var caller = Clients.Caller;

            // TODO
        }
    }
}

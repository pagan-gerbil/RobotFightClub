using Microsoft.AspNetCore.SignalR;
using RobotRightClub.Engine.BoardActions;

namespace RobotFightClub.Server
{
    public class RobotFightClubHub : Hub<IRobotFightClubClient>
    {
        public void BroadcastAction(BoardAction action)
        {
            // need to trim this to just the clients in a single session
            Clients.All.Broadcast(action);
        }
    }
}

using RobotRightClub.Engine.BoardActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public interface IActionBroadcaster
    {
        void Broadcast(BoardAction action);
    }
}

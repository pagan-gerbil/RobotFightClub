using RobotRightClub.Engine.BoardActions;
using RobotRightClub.Engine.InputActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public interface IActionBroadcaster
    {
        void Broadcast(BoardAction action);
        void RequestInput(IEnumerable<InputAction> availableInputs);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine.InputActions
{
    public abstract class InputAction
    {
        public InputAction(Player controllingPlayer)
        {
            ControllingPlayer = controllingPlayer;
        }

        public Player ControllingPlayer { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public class GameSession
    {
        private readonly IActionBroadcaster _actionBroadcaster;

        public GameSession(IActionBroadcaster actionBroadcaster)
        {
            _actionBroadcaster = actionBroadcaster;
            Board = new Board(_actionBroadcaster);
        }

        public Board Board { get; private set; }
        public Player FirstPlayer { get; } = new Player("First Player");
        public Player SecondPlayer { get; } = new Player("Second Player");
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public class GameSession
    {
        public Board Board { get; } = new Board();

        public Player FirstPlayer { get; } = new Player("First Player");
        public Player SecondPlayer { get; } = new Player("Second Player");
    }
}

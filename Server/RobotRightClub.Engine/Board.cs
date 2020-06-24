using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public class Board
    {
        private BoardSpace[,] _spaces = new BoardSpace[10, 6];

        public Board()
        {
            SetupSpaces();
        }

        private void SetupSpaces()
        {
            // move this into 'setup cards' later

            
        }

        public BoardSpace GetSpace(int row, int column)
        {
            return _spaces[row, column];
        }
    }
}

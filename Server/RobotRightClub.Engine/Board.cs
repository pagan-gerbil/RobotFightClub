using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public class Board
    {
        private BoardSpace[,] _spaces = new BoardSpace[6, 10];

        public Board()
        {
            SetupSpaces();
        }

        private void SetupSpaces()
        {
            // move this whole method into 'setup cards' later
            for (var row = 0; row < 6; row++)
                for (var column = 0; column < 10; column++)
                    _spaces[row, column] = new BoardSpace();

            _spaces[0, 1].AddToken(BoardToken.RobotStart);
            _spaces[0, 3].AddToken(BoardToken.Obstacle);
            _spaces[0, 6].AddToken(BoardToken.Obstacle);
            _spaces[0, 9].AddToken(BoardToken.ActivationPad);
            _spaces[1, 2].AddToken(BoardToken.RobotStart);
            _spaces[1, 7].AddToken(BoardToken.RobotStart);
            _spaces[1, 8].AddToken(BoardToken.RobotStart);
            _spaces[2, 1].AddToken(BoardToken.Obstacle);
            _spaces[3, 1].AddToken(BoardToken.Obstacle);
            _spaces[2, 4].AddToken(BoardToken.ActivationPad);
            _spaces[2, 5].AddToken(BoardToken.ActivationPad);
            _spaces[2, 6].AddToken(BoardToken.Obstacle);
            _spaces[3, 7].AddToken(BoardToken.Obstacle);
            _spaces[2, 7].AddToken(BoardToken.Obstacle);
            _spaces[3, 2].AddToken(BoardToken.RobotStart);
            _spaces[4, 0].AddToken(BoardToken.ActivationPad);
            _spaces[4, 3].AddToken(BoardToken.Obstacle);
            _spaces[4, 4].AddToken(BoardToken.ActivationPad);
            _spaces[4, 7].AddToken(BoardToken.RobotStart);
            _spaces[4, 8].AddToken(BoardToken.RobotStart);
            _spaces[5, 2].AddToken(BoardToken.RobotStart);
            _spaces[5, 6].AddToken(BoardToken.ActivationPad);
            _spaces[5, 8].AddToken(BoardToken.Obstacle);
        }

        public BoardSpace GetSpace(int row, int column)
        {
            return _spaces[row, column];
        }
    }
}

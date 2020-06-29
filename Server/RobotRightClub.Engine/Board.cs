using RobotRightClub.Engine.BoardActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine
{
    public class Board
    {
        private BoardSpace[,] _spaces = new BoardSpace[6, 10];
        private IActionBroadcaster _actionBroadcaster;

        public Board(IActionBroadcaster actionBroadcaster)
        {
            _actionBroadcaster = actionBroadcaster;
            SetupSpaces();
        }

        private void SetupSpaces()
        {
            // move this whole method into 'setup cards' later
            for (var row = 0; row < 6; row++)
                for (var column = 0; column < 10; column++)
                    _spaces[row, column] = new BoardSpace();

            RunAction(new AddTokenAction(0, 1, BoardToken.RobotStart));
            RunAction(new AddTokenAction(0, 3, BoardToken.Obstacle));
            RunAction(new AddTokenAction(0, 6, BoardToken.Obstacle));
            RunAction(new AddTokenAction(0, 9, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(1, 2, BoardToken.RobotStart));
            RunAction(new AddTokenAction(1, 7, BoardToken.RobotStart));
            RunAction(new AddTokenAction(1, 8, BoardToken.RobotStart));
            RunAction(new AddTokenAction(2, 1, BoardToken.Obstacle));
            RunAction(new AddTokenAction(3, 1, BoardToken.Obstacle));
            RunAction(new AddTokenAction(2, 4, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(2, 5, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(2, 6, BoardToken.Obstacle));
            RunAction(new AddTokenAction(3, 7, BoardToken.Obstacle));
            RunAction(new AddTokenAction(2, 7, BoardToken.Obstacle));
            RunAction(new AddTokenAction(3, 2, BoardToken.RobotStart));
            RunAction(new AddTokenAction(4, 0, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(4, 3, BoardToken.Obstacle));
            RunAction(new AddTokenAction(4, 4, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(4, 7, BoardToken.RobotStart));
            RunAction(new AddTokenAction(4, 8, BoardToken.RobotStart));
            RunAction(new AddTokenAction(5, 2, BoardToken.RobotStart));
            RunAction(new AddTokenAction(5, 6, BoardToken.ActivationPad));
            RunAction(new AddTokenAction(5, 8, BoardToken.Obstacle));
        }

        public BoardSpace GetSpace(int row, int column)
        {
            return _spaces[row, column];
        }

        public void RunAction(BoardAction action)
        {
            action.Execute(this);
        }
    }
}

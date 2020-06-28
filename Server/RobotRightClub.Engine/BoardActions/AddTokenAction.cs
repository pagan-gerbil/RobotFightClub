using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine.BoardActions
{
    public class AddTokenAction : BoardAction
    {
        public BoardToken Token { get; }
        public int Row { get; }
        public int Column { get; }

        public AddTokenAction(int row, int column, BoardToken token)
        {
            Token = token;
            Row = row;
            Column = column;
        }

        internal override void Execute(Board board)
        {
            board.GetSpace(Row, Column).AddToken(Token);
        }
    }
}

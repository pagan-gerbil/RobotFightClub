using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRightClub.Engine.InputActions
{
    public class SelectBoardSpaceAction : InputAction
    {
        public SelectBoardSpaceAction(Player controllingPlayer, int targetRow, int targetColumn)
            : base (controllingPlayer)
        {
            TargetRow = targetRow;
            TargetColumn = targetColumn;
        }

        public int TargetRow { get; private set; }
        public int TargetColumn { get; private set; }
    }
}

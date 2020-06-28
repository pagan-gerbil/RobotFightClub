using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RobotRightClub.Engine
{
    public class BoardSpace
    {
        public IEnumerable<BoardToken> BoardTokens { get { return _boardTokens; } }

        private List<BoardToken> _boardTokens = new List<BoardToken>();

        public bool CanMove()
        {
            return !_boardTokens.Any(x => x.Equals(BoardToken.Obstacle));
        }

        public void AddToken(BoardToken token)
        {
            _boardTokens.Add(token);
        }
    }
}

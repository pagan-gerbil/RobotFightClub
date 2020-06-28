using NUnit.Framework;
using RobotRightClub.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotFightClub.Engine.Tests
{
    [TestFixture]
    public class BoardSpaceTests
    {
        [TestCase(true)]
        [TestCase(true, BoardToken.ActivationPad)]
        [TestCase(true, BoardToken.RobotStart)]
        [TestCase(true)]
        [TestCase(false, BoardToken.Obstacle)]
        [TestCase(false, BoardToken.Obstacle, BoardToken.ActivationPad, BoardToken.RobotStart)]
        [TestCase(false, BoardToken.ActivationPad, BoardToken.Obstacle)]
        [TestCase(false, BoardToken.Obstacle, BoardToken.RobotStart)]
        public void CanMoveShouldReturnCorrectlyForTokens(bool expected, params BoardToken[] tokens)
        {
            var space = new BoardSpace();
            foreach(var token in tokens)
            {
                space.AddToken(token);
            }

            Assert.That(space.CanMove(), Is.EqualTo(expected));
        }
    }
}

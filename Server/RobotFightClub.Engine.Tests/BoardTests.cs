using Moq;
using NUnit.Framework;
using RobotRightClub.Engine;
using RobotRightClub.Engine.BoardActions;
using RobotRightClub.Engine.InputActions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RobotFightClub.Engine.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void ShouldSetupBoardSpacesCorrectlyForQuickStart()
        {
            var mockBroadcaster = new Mock<IActionBroadcaster>();
            var board = new Board(mockBroadcaster.Object);

            for (var row = 0; row < 6; row++)
            {
                for (var column = 0; column < 10; column++)
                {
                    Assert.That(board.GetSpace(row, column), Is.TypeOf<BoardSpace>());
                }
            }

            Assert.That(board.GetSpace(0, 9).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            Assert.That(board.GetSpace(2, 4).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            Assert.That(board.GetSpace(2, 5).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            Assert.That(board.GetSpace(4, 0).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            Assert.That(board.GetSpace(4, 4).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            Assert.That(board.GetSpace(5, 6).BoardTokens, Is.EquivalentTo(new[] { BoardToken.ActivationPad }));
            mockBroadcaster.Verify(mock => mock.Broadcast(It.Is<AddTokenAction>(with => with.Token.Equals(BoardToken.ActivationPad))), Times.Exactly(6));

            Assert.That(board.GetSpace(0, 1).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(1, 2).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(1, 7).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(1, 8).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(3, 2).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(4, 7).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(4, 8).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            Assert.That(board.GetSpace(5, 2).BoardTokens, Is.EquivalentTo(new[] { BoardToken.RobotStart }));
            mockBroadcaster.Verify(mock => mock.Broadcast(It.Is<AddTokenAction>(with => with.Token.Equals(BoardToken.RobotStart))), Times.Exactly(8));

            Assert.That(board.GetSpace(0, 3).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(0, 6).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(2, 1).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(2, 6).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(2, 7).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(3, 1).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(3, 7).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(4, 3).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            Assert.That(board.GetSpace(5, 8).BoardTokens, Is.EquivalentTo(new[] { BoardToken.Obstacle }));
            mockBroadcaster.Verify(mock => mock.Broadcast(It.Is<AddTokenAction>(with => with.Token.Equals(BoardToken.Obstacle))), Times.Exactly(9));
        }

        [Test]
        public void ShouldSendInputActionsForFirstPlayerToSelectRobotStartSpace()
        {
            var mockBroadcaster = new Mock<IActionBroadcaster>();
            var board = new Board(mockBroadcaster.Object);

            mockBroadcaster.Verify(
                mock => mock.RequestInput(
                    It.Is<IEnumerable<SelectBoardSpaceAction>>(
                        with => with.Count() == 4))); 
        }
    }
}

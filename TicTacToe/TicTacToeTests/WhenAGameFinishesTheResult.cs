using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    public class WhenAGameFinishesTheResult
    {
        [Test]
        public void ShouldBeInconclusiveIfThereIsNoWinnerAndEmptyTiles()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.O, new Square(1,2));
            board.PlaceToken(Token.X, new Square(3,1));
            board.PlaceToken(Token.O, new Square(3,2));
            board.PlaceToken(Token.X, new Square(1,3));

            Assert.AreEqual(Token.Inconclusive, board.GetGameResult());
        }

        [Test]
        public void ShouldBeADrawIfAllTilesAreTakenAndThereIsNoWinner()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.X, new Square(1,1));
            board.PlaceToken(Token.O, new Square(2,1));
            board.PlaceToken(Token.X, new Square(3,1));
            board.PlaceToken(Token.O, new Square(1,2));
            board.PlaceToken(Token.X, new Square(3,2));
            board.PlaceToken(Token.O, new Square(2,2));
            board.PlaceToken(Token.X, new Square(1,3));
            board.PlaceToken(Token.O, new Square(3,3));
            board.PlaceToken(Token.X, new Square(2,3));

            Assert.AreEqual(Token.Empty, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForXIfXHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.X, new Square(1,1));
            board.PlaceToken(Token.O, new Square(2,3));
            board.PlaceToken(Token.X, new Square(3,1));
            board.PlaceToken(Token.O, new Square(3,2));
            board.PlaceToken(Token.X, new Square(2,1));

            Assert.AreEqual(Token.X, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.O, new Square(1,1));
            board.PlaceToken(Token.X, new Square(3,1));
            board.PlaceToken(Token.O, new Square(3,3));
            board.PlaceToken(Token.X, new Square(1,2));
            board.PlaceToken(Token.O, new Square(2,2));

            Assert.AreEqual(Token.O, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowVertically()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.O, new Square(1,2));
            board.PlaceToken(Token.X, new Square(3,1));
            board.PlaceToken(Token.O, new Square(3,2));
            board.PlaceToken(Token.X, new Square(1,3));
            board.PlaceToken(Token.O, new Square(2,2));

            Assert.AreEqual(Token.O, board.GetGameResult());
        }
    }
}
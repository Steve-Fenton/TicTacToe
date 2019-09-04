using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    public class WhenAGameFinishesTheResult
    {
        [Test]
        public void ShouldBeInconclusiveIfThereIsNoWinnerAndEmptyTiles()
        {
            var board = Board.Create();
            board.PlaceToken("B1", Token.O);
            board.PlaceToken("A3", Token.X);
            board.PlaceToken("B3", Token.O);
            board.PlaceToken("C1", Token.X);

            Assert.AreEqual(Token.Inconclusive, board.GetGameResult());
        }

        [Test]
        public void ShouldBeADrawIfAllTilesAreTakenAndThereIsNoWinner()
        {
            var board = Board.Create();
            board.PlaceToken("A1", Token.X);
            board.PlaceToken("A2", Token.O);
            board.PlaceToken("A3", Token.X);
            board.PlaceToken("B1", Token.O);
            board.PlaceToken("B3", Token.X);
            board.PlaceToken("B2", Token.O);
            board.PlaceToken("C1", Token.X);
            board.PlaceToken("C3", Token.O);
            board.PlaceToken("C2", Token.X);

            Assert.AreEqual(Token.Empty, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForXIfXHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken("A1", Token.X);
            board.PlaceToken("C2", Token.O);
            board.PlaceToken("A3", Token.X);
            board.PlaceToken("B3", Token.O);
            board.PlaceToken("A2", Token.X);

            Assert.AreEqual(Token.X, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken("A1", Token.O);
            board.PlaceToken("A3", Token.X);
            board.PlaceToken("C3", Token.O);
            board.PlaceToken("B1", Token.X);
            board.PlaceToken("B2", Token.O);

            Assert.AreEqual(Token.O, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowVertically()
        {
            var board = Board.Create();
            board.PlaceToken("B1", Token.O);
            board.PlaceToken("A3", Token.X);
            board.PlaceToken("B3", Token.O);
            board.PlaceToken("C1", Token.X);
            board.PlaceToken("B2", Token.O);

            Assert.AreEqual(Token.O, board.GetGameResult());
        }
    }
}
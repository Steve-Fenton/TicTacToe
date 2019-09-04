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
            board.PlaceToken("{1,2}", Token.O);
            board.PlaceToken("{3,1}", Token.X);
            board.PlaceToken("{3,2}", Token.O);
            board.PlaceToken("{1,3}", Token.X);

            Assert.AreEqual(Token.Inconclusive, board.GetGameResult());
        }

        [Test]
        public void ShouldBeADrawIfAllTilesAreTakenAndThereIsNoWinner()
        {
            var board = Board.Create();
            board.PlaceToken("{1,1}", Token.X);
            board.PlaceToken("{2,1}", Token.O);
            board.PlaceToken("{3,1}", Token.X);
            board.PlaceToken("{1,2}", Token.O);
            board.PlaceToken("{3,2}", Token.X);
            board.PlaceToken("{2,2}", Token.O);
            board.PlaceToken("{1,3}", Token.X);
            board.PlaceToken("{3,3}", Token.O);
            board.PlaceToken("{2,3}", Token.X);

            Assert.AreEqual(Token.Empty, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForXIfXHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken("{1,1}", Token.X);
            board.PlaceToken("{2,3}", Token.O);
            board.PlaceToken("{3,1}", Token.X);
            board.PlaceToken("{3,2}", Token.O);
            board.PlaceToken("{2,1}", Token.X);

            Assert.AreEqual(Token.X, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken("{1,1}", Token.O);
            board.PlaceToken("{3,1}", Token.X);
            board.PlaceToken("{3,3}", Token.O);
            board.PlaceToken("{1,2}", Token.X);
            board.PlaceToken("{2,2}", Token.O);

            Assert.AreEqual(Token.O, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowVertically()
        {
            var board = Board.Create();
            board.PlaceToken("{1,2}", Token.O);
            board.PlaceToken("{3,1}", Token.X);
            board.PlaceToken("{3,2}", Token.O);
            board.PlaceToken("{1,3}", Token.X);
            board.PlaceToken("{2,2}", Token.O);

            Assert.AreEqual(Token.O, board.GetGameResult());
        }
    }
}
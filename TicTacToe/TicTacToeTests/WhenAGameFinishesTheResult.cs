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
            board.PlaceToken(Token.O, new Tile(1,2));
            board.PlaceToken(Token.X, new Tile(3,1));
            board.PlaceToken(Token.O, new Tile(3,2));
            board.PlaceToken(Token.X, new Tile(1,3));

            Assert.AreEqual(Token.Inconclusive, board.GetGameResult());
        }

        [Test]
        public void ShouldBeADrawIfAllTilesAreTakenAndThereIsNoWinner()
        {
            var board = Board.Create();
            board.PlaceToken(Token.X, new Tile(1,1));
            board.PlaceToken(Token.O, new Tile(2,1));
            board.PlaceToken(Token.X, new Tile(3,1));
            board.PlaceToken(Token.O, new Tile(1,2));
            board.PlaceToken(Token.X, new Tile(3,2));
            board.PlaceToken(Token.O, new Tile(2,2));
            board.PlaceToken(Token.X, new Tile(1,3));
            board.PlaceToken(Token.O, new Tile(3,3));
            board.PlaceToken(Token.X, new Tile(2,3));

            Assert.AreEqual(Token.Empty, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForXIfXHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken(Token.X, new Tile(1,1));
            board.PlaceToken(Token.O, new Tile(2,3));
            board.PlaceToken(Token.X, new Tile(3,1));
            board.PlaceToken(Token.O, new Tile(3,2));
            board.PlaceToken(Token.X, new Tile(2,1));

            Assert.AreEqual(Token.X, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowDiagonally()
        {
            var board = Board.Create();
            board.PlaceToken(Token.O, new Tile(1,1));
            board.PlaceToken(Token.X, new Tile(3,1));
            board.PlaceToken(Token.O, new Tile(3,3));
            board.PlaceToken(Token.X, new Tile(1,2));
            board.PlaceToken(Token.O, new Tile(2,2));

            Assert.AreEqual(Token.O, board.GetGameResult());
        }

        [Test]
        public void ShouldBeAWinForOIfOHasThreeTilesInARowVertically()
        {
            var board = Board.Create();
            board.PlaceToken(Token.O, new Tile(1,2));
            board.PlaceToken(Token.X, new Tile(3,1));
            board.PlaceToken(Token.O, new Tile(3,2));
            board.PlaceToken(Token.X, new Tile(1,3));
            board.PlaceToken(Token.O, new Tile(2,2));

            Assert.AreEqual(Token.O, board.GetGameResult());
        }
    }
}
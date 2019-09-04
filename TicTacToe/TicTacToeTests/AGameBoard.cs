using NUnit.Framework;
using TicTacToe;

namespace Tests
{
    //TODO: Refactoring... are any of the classes finished? They should mov/e to their own file... and that file should probably be in the 
    // --> REFACTORING: Replace "B2" with Grid Position class GridPosition { column, row }
    // --> NEW FEATURE: Players taking turns... Validating whose turn it is...
    public class AGameBoard
    {

        [Test]
        public void ShouldHaveNineTiles()
        {
            var board = Board.Create();

            Assert.AreEqual(9, board.GetTileCount());
        }

        [Test]
        public void ShouldHaveUniqueTileNames()
        {
            var board = Board.Create();

            Assert.AreEqual("{1,1},{2,1},{3,1},{1,2},{2,2},{3,2},{1,3},{2,3},{3,3}", board.GetTileNames());
        }

        [Test]
        public void ShouldRememberWhereWePutTokens()
        {
            var board = Board.Create();
            board.PlaceToken("{2,2}", Token.X);
            board.PlaceToken("{1,3}", Token.O);

            Assert.AreEqual(Token.X, board.GetToken("{2,2}"));
            Assert.AreEqual(Token.O, board.GetToken("{1,3}"));
        }

        [Test]
        public void ShouldPreventMultipleTokensOnATile()
        {
            var board = Board.Create();
            board.PlaceToken("{2,2}", Token.X);
            Assert.Throws<TileTakenException>(() => board.PlaceToken("{2,2}", Token.X));
        }
    }
}
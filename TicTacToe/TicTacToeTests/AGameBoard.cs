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
        public void CodeBasedMemory()
        {
            Assert.Fail("You decided you were going to replace the hard coded string (A1, B2, etc) with a class or struct!");
        }

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

            Assert.AreEqual("A1,A2,A3,B1,B2,B3,C1,C2,C3", board.GetTileNames());
        }

        [Test]
        public void ShouldRememberWhereWePutTokens()
        {
            var board = Board.Create();
            board.PlaceToken("B2", Token.X);
            board.PlaceToken("C1", Token.O);

            Assert.AreEqual(Token.X, board.GetToken("B2"));
            Assert.AreEqual(Token.O, board.GetToken("C1"));
        }

        [Test]
        public void ShouldPreventMultipleTokensOnATile()
        {
            var board = Board.Create();
            board.PlaceToken("B2", Token.X);
            Assert.Throws<TileTakenException>(() => board.PlaceToken("B2", Token.X));
        }
    }
}
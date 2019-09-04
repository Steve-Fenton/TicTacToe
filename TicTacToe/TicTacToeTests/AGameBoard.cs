using NUnit.Framework;
using System.Linq;
using TicTacToe;

namespace Tests
{
    //TODO: Refactoring... are any of the classes finished? They should mov/e to their own file... and that file should probably be in the 
    // --> NEW FEATURE: Players taking turns... Validating whose turn it is...
    public class AGameBoard
    {
        [Test]
        public void MindRepopulation()
        {
            Assert.Fail("Rename the Tile struct to Square");
            Assert.Fail("Introduce players");
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

            Assert.AreEqual("{1,1},{2,1},{3,1},{1,2},{2,2},{3,2},{1,3},{2,3},{3,3}",
                string.Join(",", board.GetTileKeys().Select(t => $"{{{t.x},{t.y}}}")));
        }

        [Test]
        public void ShouldRememberWhereWePutTokens()
        {
            var board = Board.Create();
            board.PlaceToken(Token.X, new Tile(2,2));
            board.PlaceToken(Token.O, new Tile(1,3));

            Assert.AreEqual(Token.X, board.GetToken(new Tile(2,2)));
            Assert.AreEqual(Token.O, board.GetToken(new Tile(1,3)));
        }

        [Test]
        public void ShouldPreventMultipleTokensOnATile()
        {
            var board = Board.Create();
            board.PlaceToken(Token.X, new Tile(2,2));
            Assert.Throws<TileTakenException>(() => board.PlaceToken(Token.X, new Tile(2,2)));
        }
    }
}
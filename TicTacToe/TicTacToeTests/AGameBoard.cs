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
        public void ShouldHaveNineTiles()
        {
            var board = Board.Create(3,3);

            Assert.AreEqual(9, board.Rows * board.Columns);
        }

        [Test]
        public void ShouldHaveUniqueTileNames()
        {
            var board = Board.Create(3,3);

            Assert.AreEqual("{1,1},{2,1},{3,1},{1,2},{2,2},{3,2},{1,3},{2,3},{3,3}",
                string.Join(",", board.GetTileKeys().Select(t => $"{{{t.x},{t.y}}}")));
        }

        [Test]
        public void ShouldRememberWhereWePutTokens()
        {
            var board = Board.Create(3,3);
            board.PlaceToken(Token.X, new Square(2,2));
            board.PlaceToken(Token.O, new Square(1,3));

            Assert.AreEqual(Token.X, board.GetToken(new Square(2,2)));
            Assert.AreEqual(Token.O, board.GetToken(new Square(1,3)));
        }

        [TestCase("X","O")]
        [TestCase("O", "X")]
        public void ShouldPreventMultipleTokensOnATile(string tokenNameX,string tokenNameO)
        {
            var board = Board.Create(3,3);
            board.PlaceToken(MapTokenName(tokenNameX), new Square(2,2));
            Assert.Throws<TileTakenException>(() => board.PlaceToken(MapTokenName(tokenNameO), new Square(2,2)));
        }


        [TestCase("X")]
        [TestCase("O")]
        public void ShouldPreventRepetitiveTokens(string tokenName)
        {
            Token token = MapTokenName(tokenName);

            var board = Board.Create(3,3);
            board.PlaceToken(token, new Square(2, 1));
            Assert.Throws<TokenRepeatException>(() => board.PlaceToken(token, new Square(2, 2)));
        }

        private Token MapTokenName(string tokenName)
        {
            Token token = (tokenName == "X")
                 ? Token.X
                 : Token.O;
            return token;
        }
    }
}
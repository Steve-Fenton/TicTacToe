using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    // This should be called Square, a Tile is a square plus a token
    public struct Square
    {
        public int x, y;

        public Square(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }

    public class Board
    {
        private IDictionary<Square, Token> _tiles = new Dictionary<Square, Token>
        {
            // TODO: Candidate for algo/generation
            { new Square(1,1), Token.Empty },
            { new Square(2,1), Token.Empty },
            { new Square(3,1), Token.Empty },
            { new Square(1,2), Token.Empty },
            { new Square(2,2), Token.Empty },
            { new Square(3,2), Token.Empty },
            { new Square(1,3), Token.Empty },
            { new Square(2,3), Token.Empty },
            { new Square(3,3), Token.Empty },
        };

        public static Board Create()
        {
            return new Board();
        }

        public int GetTileCount()
        {
            return _tiles.Count;
        }

        public IEnumerable<Square> GetTileKeys()
        {
            return _tiles.Select(tile => tile.Key);
        }

        public Token GetToken(Square tile)
        {
            return _tiles[tile];
        }

        public void PlaceToken(Token token, Square tile)
        {
            if (_tiles[tile] != Token.Empty)
            {
                throw new TileTakenException();
            }

            _tiles[tile] = token;
        }

        public Token GetGameResult()
        {
            // TODO: Candidate for algo/generation
            List<List<Square>> winLines = new List<List<Square>>
            {
                new List<Square> { new Square(1,1), new Square(2,1), new Square(3,1) },
                new List<Square> { new Square(1,2), new Square(2,2), new Square(3,2) },
                new List<Square> { new Square(1,3), new Square(2,3), new Square(3,3) },
                new List<Square> { new Square(1,1), new Square(1,2), new Square(1,3) },
                new List<Square> { new Square(2,1), new Square(2,2), new Square(2,3) },
                new List<Square> { new Square(3,1), new Square(3,2), new Square(3,3) },
                new List<Square> { new Square(1,1), new Square(2,2), new Square(3,3) },
                new List<Square> { new Square(3,1), new Square(2,2), new Square(1,3) }
            };

            foreach (var winLine in winLines)
            {
                var firstToken = GetToken(winLine[0]);

                if (firstToken == Token.Empty)
                {
                    continue;
                }

                bool isWinningLine = true;
                foreach (var tile in winLine)
                {
                    if (GetToken(tile) != firstToken)
                    {
                        isWinningLine = false;
                        break;
                    }
                }

                if (isWinningLine)
                {
                    return firstToken;
                }
            }

            return IsInconclusive()
                ? Token.Inconclusive
                : Token.Empty;
        }

        private bool IsInconclusive()
        {
            bool isInconclusive = false;

            var cells = _tiles.Select(tile => tile.Key);

            foreach (var cell in cells)
            {
                if (GetToken(cell) == Token.Empty)
                {
                    isInconclusive = true;
                }
            }

            return isInconclusive;
        }

        private static string TileToString(Square tile)
        {
            return "{" + tile.x + "," + tile.y + "}";
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    // This should be called Square, a Tile is a square plus a token
    public struct Tile
    {
        public int x, y;

        public Tile(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }

    public class Board
    {
        private IDictionary<Tile, Token> _tiles = new Dictionary<Tile, Token>
        {
            // TODO: Candidate for algo/generation
            { new Tile(1,1), Token.Empty },
            { new Tile(2,1), Token.Empty },
            { new Tile(3,1), Token.Empty },
            { new Tile(1,2), Token.Empty },
            { new Tile(2,2), Token.Empty },
            { new Tile(3,2), Token.Empty },
            { new Tile(1,3), Token.Empty },
            { new Tile(2,3), Token.Empty },
            { new Tile(3,3), Token.Empty },
        };

        public static Board Create()
        {
            return new Board();
        }

        public int GetTileCount()
        {
            return _tiles.Count;
        }

        public IEnumerable<Tile> GetTileKeys()
        {
            return _tiles.Select(tile => tile.Key);
        }

        public Token GetToken(Tile tile)
        {
            return _tiles[tile];
        }

        public void PlaceToken(Token token, Tile tile)
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
            List<List<Tile>> winLines = new List<List<Tile>>
            {
                new List<Tile> { new Tile(1,1), new Tile(2,1), new Tile(3,1) },
                new List<Tile> { new Tile(1,2), new Tile(2,2), new Tile(3,2) },
                new List<Tile> { new Tile(1,3), new Tile(2,3), new Tile(3,3) },
                new List<Tile> { new Tile(1,1), new Tile(1,2), new Tile(1,3) },
                new List<Tile> { new Tile(2,1), new Tile(2,2), new Tile(2,3) },
                new List<Tile> { new Tile(3,1), new Tile(3,2), new Tile(3,3) },
                new List<Tile> { new Tile(1,1), new Tile(2,2), new Tile(3,3) },
                new List<Tile> { new Tile(3,1), new Tile(2,2), new Tile(1,3) }
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

        private static string TileToString(Tile tile)
        {
            return "{" + tile.x + "," + tile.y + "}";
        }
    }
}
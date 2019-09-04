using System.Collections.Generic;

namespace TicTacToe
{
    //public struct Tile
    //{
    //    public int x, y;

    //    public Tile(int x1, int y1)
    //    {
    //        x = x1;
    //        y = y1;
    //    }
    //}
    public class Board
    {
        private IDictionary<string, Token> _tiles = new Dictionary<string, Token>
        {
            // TODO: Candidate for algo/generation
            { "A1", Token.Empty },
            { "A2", Token.Empty },
            { "A3", Token.Empty },
            { "B1", Token.Empty },
            { "B2", Token.Empty },
            { "B3", Token.Empty },
            { "C1", Token.Empty },
            { "C2", Token.Empty },
            { "C3", Token.Empty },
        };

        public static Board Create()
        {
            return new Board();
        }

        public int GetTileCount()
        {
            return _tiles.Count;
        }

        public string GetTileNames()
        {
            return string.Join(",", _tiles.Keys);
        }

        public Token GetToken(string tileName)
        {
            return _tiles[tileName];
        }

        public void PlaceToken(string tileName, Token token)
        {
            if(_tiles[tileName] != Token.Empty)
            {
                throw new TileTakenException();
            }
            _tiles[tileName] = token;
        }

        public Token GetGameResult()
        {
            // TODO: Candidate for algo/generation
            List<List<string>> winLines = new List<List<string>>
            {
                new List<string> { "A1", "A2", "A3" },
                new List<string> { "B1", "B2", "B3" },
                new List<string> { "C1", "C2", "C3" },
                new List<string> { "A1", "B1", "C1" },
                new List<string> { "A2", "B2", "C2" },
                new List<string> { "A3", "B3", "C3" },
                new List<string> { "A1", "B2", "C3" },
                new List<string> { "A3", "B2", "C1" }
            };

            foreach (var winLine in winLines)
            {
                var a = GetToken(winLine[0]);

                if (a == Token.Empty)
                {
                    continue;
                }

                bool result = true;
                foreach (var tileName in winLine)
                {
                    if (GetToken(tileName) != a)
                    {
                        result = false;
                        break;
                    }
                }

                if (result)
                {
                    return a;
                }
            }

            List<string> cells = new List<string>
            {
                "A1", "A2", "A3", "B1", "B2", "B3","C1", "C2", "C3"
            };

            foreach (var cell in cells)
            {
                if (GetToken(cell) == Token.Empty)
                {
                    return Token.Inconclusive;
                }
            }

            return Token.Empty;
        }
    }
}
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
            { "{1,1}", Token.Empty },
            { "{2,1}", Token.Empty },
            { "{3,1}", Token.Empty },
            { "{1,2}", Token.Empty },
            { "{2,2}", Token.Empty },
            { "{3,2}", Token.Empty },
            { "{1,3}", Token.Empty },
            { "{2,3}", Token.Empty },
            { "{3,3}", Token.Empty },
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
            if (_tiles[tileName] != Token.Empty)
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
                new List<string> { "{1,1}", "{2,1}", "{3,1}" },
                new List<string> { "{1,2}", "{2,2}", "{3,2}" },
                new List<string> { "{1,3}", "{2,3}", "{3,3}" },
                new List<string> { "{1,1}", "{1,2}", "{1,3}" },
                new List<string> { "{2,1}", "{2,2}", "{2,3}" },
                new List<string> { "{3,1}", "{3,2}", "{3,3}" },
                new List<string> { "{1,1}", "{2,2}", "{3,3}" },
                new List<string> { "{3,1}", "{2,2}", "{1,3}" }
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
                "{1,1}",
                "{2,1}",
                "{3,1}",
                "{1,2}",
                "{2,2}",
                "{3,2}",
                "{1,3}",
                "{2,3}",
                "{3,3}"
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
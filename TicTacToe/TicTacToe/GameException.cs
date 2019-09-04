using System;

namespace TicTacToe
{
    public class GameException
        : ApplicationException
    {
        public GameException(string message)
            : base(message) { }
    }
}
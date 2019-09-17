namespace TicTacToe
{
    public class TokenRepeatException
        : GameException
    {
        public TokenRepeatException()
            : base("Same Token cannot be sequential") { }
    }
}
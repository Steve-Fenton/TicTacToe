namespace TicTacToe
{
    public class TileTakenException
        : GameException
    {
        public TileTakenException()
            : base("Tile Is Taken") { }
    }
}
namespace TicTacToe
{
    public class Token
    {
        private class EmptyToken : Token
        {
        }

        private class InconclusiveToken : Token
        {
        }

        private class XToken : Token
        {
        }

        private class OToken : Token
        {
        }

        private static readonly Token _empty = new EmptyToken();
        private static readonly Token _inconclusive = new InconclusiveToken();
        private static readonly Token _x = new XToken();
        private static readonly Token _o = new OToken();

        public static Token Empty
        {
            get
            {
                return _empty;
            }
        }

        public static Token Inconclusive
        {
            get
            {
                return _inconclusive;
            }

        }

        public static Token X
        {
            get
            {
                return _x;
            }
        }

        public static Token O
        {
            get
            {
                return _o;
            }
        }
    }
}
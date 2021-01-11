namespace SharpChess
{
    public class Piece
    {
        #region Variables

        public IPiece Client { get; set; }
        public PieceData Data;

        #endregion Variables


        #region Constructor

        public Piece()
        {
           // Client = client;
        }

        #endregion Constructor
    }
}
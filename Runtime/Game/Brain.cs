namespace SharpChess
{
    public class Brain
    {
        #region Variables

        private readonly IGame _game;
        private readonly IBoard _board;

        #endregion Variables


        #region Constructor

        public Brain(IGame game, IBoard board)
        {
            _game = game;
            _board = board;
        }

        #endregion Constructor


        #region Update

        public void DoClientPieceStage(IPiece piece)
        {
            
        }

        public void DoClientAttemptPieceMove(IPiece piece, ISquare targetSquare)
        {
            
        }

        #endregion Update
    }
}
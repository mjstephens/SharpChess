namespace SharpChess
{
    public class CoreSimulation
    {
        #region Variables

        private readonly IBoard _board;
        private readonly IClientSimulation _clientSim;

        #endregion Variables


        #region Constructor

        public CoreSimulation(IBoard board, IClientSimulation clientSim)
        {
            _board = board;
            _clientSim = clientSim;
        }

        #endregion Constructor


        #region Update

        public void DoClientPieceStage(IPiece piece)
        {
            
        }

        public void DoClientAttemptPieceMove(IPiece piece, ISquare targetSquare)
        {
            _clientSim.DoPieceMoveValid(piece, targetSquare);
        }

        #endregion Update
    }
}
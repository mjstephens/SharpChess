namespace SharpChess
{
    public interface IGame
    {
        #region Construction

        ISquare CreateSquareClient(DataBoardPosition position);
        IPiece CreatePieceClient(string pieceID, Square currentSquare);

        #endregion Construction


        #region Initialization

        void StartGame(CoreSimulation simulation);

        #endregion Initialization


        #region Game

        /// <summary>
        /// 
        /// </summary>
        /// <param name="square"></param>
        /// <param name="type"></param>
        void DoPingSquare(ISquare square, SquarePingType type);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        void DoPieceMoveValidationResult(MoveResultData data);
        
        /// <summary>
        /// Directs the client that a piece has been captured.
        /// </summary>
        /// <param name="capturedPiece"></param>
        /// <param name="attackingPiece"></param>
        void DoPieceCaptured(IPiece capturedPiece, IPiece attackingPiece);

        #endregion Game
    }
}
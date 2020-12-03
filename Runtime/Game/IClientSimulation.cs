namespace SharpChess
{
    /// <summary>
    /// Defines implementation for the client-side simulation class.
    /// </summary>
    public interface IClientSimulation
    {
        /// <summary>
        /// Directs the client that the piece that was trying to move was moving to an invalid square.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="square"></param>
        void DoPieceMoveInvalid(IPiece piece, ISquare square);
        
        /// <summary>
        /// Directs the client that the moving piece can continue and actually move.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="square"></param>
        void DoPieceMoveValid(IPiece piece, ISquare square);
        
        /// <summary>
        /// Directs the client that a piece has been captured.
        /// </summary>
        /// <param name="capturedPiece"></param>
        /// <param name="attackingPiece"></param>
        void DoPieceCaptured(IPiece capturedPiece, IPiece attackingPiece);
    }
}
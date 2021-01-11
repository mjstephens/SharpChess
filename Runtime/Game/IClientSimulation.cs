namespace SharpChess
{
    /// <summary>
    /// Defines implementation for the client-side simulation class.
    /// </summary>
    public interface IClientSimulation
    {
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <param name="square"></param>
        // /// <param name="type"></param>
        // void DoPingSquare(ISquare square, SquarePingType type);
        //
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <param name="valid"></param>
        // /// <param name="data"></param>
        // void DoPieceMoveValidationResult(bool valid, MoveData data);
        //
        // /// <summary>
        // /// Directs the client that a piece has been captured.
        // /// </summary>
        // /// <param name="capturedPiece"></param>
        // /// <param name="attackingPiece"></param>
        // void DoPieceCaptured(IPiece capturedPiece, IPiece attackingPiece);
    }

    public enum SquarePingType
    {
        Test
    }
}
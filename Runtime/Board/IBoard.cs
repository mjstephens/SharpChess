namespace SharpChess
{
    public interface IBoard
    {
        ISquare[] Squares { get; }
        IPiece[] Pieces { get; }
    }
}
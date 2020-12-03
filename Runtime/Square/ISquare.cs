using Data;

namespace SharpChess
{
    public interface ISquare
    {
        /// <summary>
        /// The grid layout position this square occupies on the board
        /// </summary>
        DataBoardPosition Position { get; }
        
        /// <summary>
        /// The piece currently occupying this square - null if empty
        /// </summary>
        IPiece CurrentPiece { get; set; }
    }
}
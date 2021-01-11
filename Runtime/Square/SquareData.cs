namespace SharpChess
{
    public struct SquareData
    {
        /// <summary>
        /// The index this square occupies in the board squares array
        /// </summary>
        public int BoardIndex { get; set; }
        
        /// <summary>
        /// The grid layout position this square occupies on the board
        /// </summary>
        public DataBoardPosition Position { get; set; }
        
        /// <summary>
        /// The piece currently occupying this square - null if empty
        /// </summary>
        public Piece CurrentPiece { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public SquareCacheData CacheData { get; set; }
    }
}
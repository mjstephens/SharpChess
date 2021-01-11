namespace SharpChess
{
    public interface IPiece
    {
        #region Properties

        /// <summary>
        /// We use this for easy access to the Piece class from IPiece
        /// </summary>
        int id { get; set; }

        #endregion Properties
        
        
        #region Methods

        /// <summary>
        /// Directs the client piece to move to the given square
        /// </summary>
        /// <param name="square"></param>
        void MovePieceToSquare(ISquare square);

        #endregion Methods
    }
}
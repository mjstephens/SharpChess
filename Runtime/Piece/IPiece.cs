namespace SharpChess
{
    public interface IPiece
    {
        #region Properties

        /// <summary>
        /// The square at which this piece currently resides (null if taken)
        /// </summary>
        ISquare CurrentSquare { get; }
        
        /// <summary>
        /// Defines how the piece can move across squares
        /// </summary>
        DataMoveRuleBase[] MovementRules { get; }
        
        /// <summary>
        /// Special movement properties for this piece
        /// </summary>
        DataMovementProperties MovementProperties { get; }
        
        /// <summary>
        /// The team to which this piece belongs
        /// </summary>
        int Team { get; }

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
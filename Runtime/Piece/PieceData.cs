namespace SharpChess
{
    public struct PieceData
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string PieceTypeID;

        /// <summary>
        /// The team to which this piece belongs
        /// </summary>
        public int Team;

        /// <summary>
        /// The square at which this piece currently resides (null if taken)
        /// </summary>
        public Square CurrentSquare;

        /// <summary>
        /// Defines how the piece can move across squares
        /// </summary>
        public DataMoveRuleBase[] MovementRules;

        /// <summary>
        /// Special movement properties for this piece
        /// </summary>
        public DataMovementProperties MovementProperties;

        #endregion Properties
    }
}
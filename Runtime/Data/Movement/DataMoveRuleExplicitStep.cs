namespace SharpChess
{
    public struct DataMoveRuleExplicitStep
    {
        /// <summary>
        /// Defines the index of the NEIGHBOR SQUARE in the neighbor cache array
        /// Starting front-left, clockwise, 0-8
        /// </summary>
        public int DirectionIndex;
        public int Distance;
    }
}
namespace SharpChess
{
    public struct ConfigurationDataPiece
    {
        public string ID;
        public int Team;
        public DataBoardPosition StartingPosition;
        public DataMoveRuleBase[] MoveRules;
        public DataMovementProperties MoveProperties;
    }
}
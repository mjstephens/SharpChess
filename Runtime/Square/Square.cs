namespace SharpChess
{
    public class Square
    {
        #region Variables

        public ISquare Client { get; set; }
        public SquareData Data;

        #endregion Variables


        #region Constructor

        public Square(DataBoardPosition position)
        {
            Data.Position = position;
        }

        #endregion Constructor
    }
}
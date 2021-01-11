using System;

namespace SharpChess
{
    public class Board
    {
        #region Variables

        /// <summary>
        /// The data for this board, including squares
        /// </summary>
        public readonly BoardData Data;

        #endregion Variables


        #region Construction

        internal Board(ConfigurationDataBoard boardData)
        {
            // Create board data
            Data = new BoardData();
            Data.Dimensions = new Tuple<int, int>(boardData.BoardWidth, boardData.BoardHeight);
            Data.Squares = CreateSquares(Data.Dimensions);
            SetSquaresCacheData(Data);
        }

        private static Square[] CreateSquares(Tuple<int, int> boardDimensions)
        {
            Square[] squares = new Square[boardDimensions.Item1 * boardDimensions.Item2];
            for (int i = 0; i < boardDimensions.Item1; i++)
            {
                for (int y = 0; y < boardDimensions.Item2; y++)
                {
                    DataBoardPosition position = new DataBoardPosition
                    {
                        File = i,
                        Rank = y
                    };

                    // Create and add square
                    int index = i + (boardDimensions.Item1 * y);
                    squares[index] = new Square(position)
                    {
                        Client = GameConstructor.CreateSquareClient(position),
                        Data =
                        {
                            BoardIndex = index
                        }
                    };
                    squares[index].Client.id = index;
                }
            }

            return squares;
        }

        private static void SetSquaresCacheData(BoardData data)
        {
            foreach (Square square in data.Squares)
            {
                square.Data.CacheData = BoardCacheUtility.GatherCacheDataForSquare(square, data);
            }
        }

        #endregion Construction


        #region Utility

        internal SquareCacheData GetSquareCache(ISquare square)
        {
            return Data.Squares[square.id].Data.CacheData;
        }

        #endregion Utility
    }
}
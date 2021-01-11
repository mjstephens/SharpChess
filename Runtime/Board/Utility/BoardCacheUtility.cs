using System.Collections.Generic;

namespace SharpChess
{
    public static class BoardCacheUtility
    {
        #region Construction

        public static SquareCacheData GatherCacheDataForSquare(Square square, BoardData boardData)
        {
            SquareCacheData data = new SquareCacheData
            {
                NeighborSquareIndices = GetNeighborIndicesForSquare(square, boardData),
                FileSquareIndices = GetFileIndicesForSquare(square, boardData),
                RankSquareIndices = GetRankIndicesForSquare(square, boardData),
                DiagonalSquareIndices = GetDiagonalIndicesForSquare(square, boardData)
            };

            return data;
        }

        private static List<int> GetNeighborIndicesForSquare(Square square, BoardData boardData)
        {
            List<Square> squares = BoardPositionUtility.SurroundingSquares(square.Data.Position, boardData);
           // squares = ClearNullAndSelfSquares(squares, square);
            return GatherIndicesForSquares(squares);
        }
        
        private static List<int> GetFileIndicesForSquare(Square square, BoardData boardData)
        {
            List<Square> squares = BoardPositionUtility.FileSquares(square.Data.Position, boardData);
            squares = ClearNullAndSelfSquares(squares, square);
            return GatherIndicesForSquares(squares);
        }
        
        private static List<int> GetRankIndicesForSquare(Square square, BoardData boardData)
        {
            List<Square> squares = BoardPositionUtility.RankSquares(square.Data.Position, boardData);
            squares = ClearNullAndSelfSquares(squares, square);
            return GatherIndicesForSquares(squares);
        }

        private static List<int> GetDiagonalIndicesForSquare(Square square, BoardData boardData)
        {
            List<Square> squares = BoardPositionUtility.DiagonalSquares(square.Data.Position, boardData);
            squares = ClearNullAndSelfSquares(squares, square);
            return GatherIndicesForSquares(squares);
        }

        #endregion Construction
        
        
        #region Utility

        private static List<Square> ClearNullAndSelfSquares(List<Square> squares, Square self)
        {
            for (int i = squares.Count - 1; i >= 0; i--)
            {
                if (squares[i] == null || squares[i] == self)
                {
                    squares.RemoveAt(i);
                }
            }

            return squares;
        }

        private static List<int> GatherIndicesForSquares(List<Square> squares)
        {
            int[] indices = new int[squares.Count];
            for (int i = 0; i < indices.Length; i++)
            {
                if (squares[i] == null)
                {
                    indices[i] = -1;
                }
                else
                {
                    indices[i] = squares[i].Data.BoardIndex;
                }
            }

            return new List<int>(indices);
        }

        #endregion Utility
    }
}
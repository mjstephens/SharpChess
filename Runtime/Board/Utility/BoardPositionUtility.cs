using System.Collections.Generic;

namespace SharpChess
{
    public static class BoardPositionUtility
    {
        #region Utility
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="file"></param>
        /// <param name="boardData"></param>
        /// <returns></returns>
        public static Square GetSquareForCoordinates(int file, int rank, BoardData boardData)
        {
            Square square = null;
            foreach (Square s in boardData.Squares)
            {
                if (s.Data.Position.Rank == rank && s.Data.Position.File == file)
                {
                    square = s;
                    break;
                }
            }

            return square;
        }

        /// <summary>
        /// Returns all of the squares immediately surrounding the root square
        /// </summary>
        /// <param name="rootPosition"></param>
        /// <param name="boardData"></param>
        /// <returns></returns>
        internal static List<Square> SurroundingSquares(DataBoardPosition rootPosition, BoardData boardData)
        {
            // List of squares we will be returning; clockwise starting from upper-left
            List<Square> squares = new List<Square>
            {
                GetSquareForCoordinates(rootPosition.File - 1, rootPosition.Rank + 1, boardData),
                GetSquareForCoordinates(rootPosition.File, rootPosition.Rank + 1, boardData),
                GetSquareForCoordinates(rootPosition.File + 1, rootPosition.Rank + 1, boardData),
                GetSquareForCoordinates(rootPosition.File + 1, rootPosition.Rank, boardData),
                GetSquareForCoordinates(rootPosition.File + 1, rootPosition.Rank - 1, boardData),
                GetSquareForCoordinates(rootPosition.File, rootPosition.Rank - 1, boardData),
                GetSquareForCoordinates(rootPosition.File - 1, rootPosition.Rank - 1, boardData),
                GetSquareForCoordinates(rootPosition.File - 1, rootPosition.Rank, boardData)
            };

            return squares;
        }

        /// <summary>
        /// Returns all squares in the same rank as the rootPosition
        /// </summary>
        /// <param name="rootPosition"></param>
        /// <param name="boardData"></param>
        /// <returns></returns>
        internal static List<Square> RankSquares(DataBoardPosition rootPosition, BoardData boardData)
        {
            // List of squares we will be returning; 
            List<Square> squares = new List<Square>();
            
            // Start from leftmost file, add all squares in the rank
            for (int i = 0; i < boardData.Dimensions.Item1; i++)
            {
                squares.Add(GetSquareForCoordinates(i, rootPosition.Rank, boardData));
            }

            return squares;
        }
        
        /// <summary>
        /// Returns all squares in the same file as the rootPosition
        /// </summary>
        /// <param name="rootPosition"></param>
        /// <param name="boardData"></param>
        /// <returns></returns>
        internal static List<Square> FileSquares(DataBoardPosition rootPosition, BoardData boardData)
        {
            // List of squares we will be returning; 
            List<Square> squares = new List<Square>();
            
            // Start from bottommost rank, add all squares in the file
            for (int i = 0; i < boardData.Dimensions.Item2; i++)
            {
                squares.Add(GetSquareForCoordinates(rootPosition.File, i, boardData));
            }

            return squares;
        }
        
        /// <summary>
        /// Returns all squares in the same diagonals as the rootPosition
        /// </summary>
        /// <param name="rootPosition"></param>
        /// <param name="boardData"></param>
        /// <returns></returns>
        internal static List<Square> DiagonalSquares(DataBoardPosition rootPosition, BoardData boardData)
        {
            // List of squares we will be returning; 
            List<Square> squares = new List<Square>();
            
            // Lower-left diagonal
            DataBoardPosition runningPosition = rootPosition;
            bool hasReachedEdge = runningPosition.File <= 0 || runningPosition.Rank <= 0;
            while (!hasReachedEdge)
            {
                runningPosition.File--;
                runningPosition.Rank--;
                if (runningPosition.File <= 0 || runningPosition.Rank <= 0)
                {
                    hasReachedEdge = true;
                }
                
                squares.Add(GetSquareForCoordinates(runningPosition.File, runningPosition.Rank, boardData));
            }
            
            // Upper-right diagonal
            runningPosition = rootPosition;
            hasReachedEdge = runningPosition.File >= boardData.Dimensions.Item1 ||
                             runningPosition.Rank >= boardData.Dimensions.Item2;
            while (!hasReachedEdge)
            {
                runningPosition.File++;
                runningPosition.Rank++;
                if (runningPosition.File >= boardData.Dimensions.Item1 || runningPosition.Rank >= boardData.Dimensions.Item2)
                {
                    hasReachedEdge = true;
                }
                
                squares.Add(GetSquareForCoordinates(runningPosition.File, runningPosition.Rank, boardData));
            }
            
            // Lower-right diagonal
            runningPosition = rootPosition;
            hasReachedEdge = runningPosition.File >= boardData.Dimensions.Item1 || runningPosition.Rank <= 0;
            while (!hasReachedEdge)
            {
                runningPosition.File++;
                runningPosition.Rank--;
                if (runningPosition.File >= boardData.Dimensions.Item1 || runningPosition.Rank <= 0)
                {
                    hasReachedEdge = true;
                }
                
                squares.Add(GetSquareForCoordinates(runningPosition.File, runningPosition.Rank, boardData));
            }
            
            // Upper-left diagonal
            runningPosition = rootPosition;
            hasReachedEdge = runningPosition.File <= 0 || runningPosition.Rank >= boardData.Dimensions.Item2;
            while (!hasReachedEdge)
            {
                runningPosition.File--;
                runningPosition.Rank++;
                if (runningPosition.File <= 0 || runningPosition.Rank >= boardData.Dimensions.Item2)
                {
                    hasReachedEdge = true;
                }
                
                squares.Add(GetSquareForCoordinates(runningPosition.File, runningPosition.Rank, boardData));
            }

            return squares;
        }

        #endregion Utility
    }
}
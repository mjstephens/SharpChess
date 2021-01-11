using System.Collections.Generic;
using UnityEngine;

namespace SharpChess
{
    /// <summary>
    /// Responsible for confirming or denying the legality of attempted moves.
    /// </summary>
    public static class MovementValidator
    {
        #region Variables

        

        #endregion Variables


        #region Validation

        /// <summary>
        /// Determines whether or not an attempted move is valid
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MoveResultData MoveIsValid(MoveData data)
        {
            // Pretending that pieces can only move diagonal for now; anything in the way prevents movement
            Square currentSquare = data.Piece.Data.CurrentSquare;
            HashSet<int> validMovementIndices = 
                SetValidMovementIndices(currentSquare, data.Board, data.Piece.Data.MovementRules);

            MoveResultData result = new MoveResultData
            {
                Success = validMovementIndices.Contains(data.Square.Data.BoardIndex),
                Piece = data.Piece.Client,
                TargetSquare = data.Square.Client
            };

            return result;
        }

        private static HashSet<int> SetValidMovementIndices(
            Square square, 
            BoardData board,  
            DataMoveRuleBase[] moveRules)
        {
            HashSet<int> runningSquares = new HashSet<int>();
            for (int i = 0; i < moveRules.Length; i++)
            {
                switch (moveRules[i])
                {
                    case DataMoveRuleDirectional D:
                        runningSquares.UnionWith(GetIndicesForDirectionalStepping(square, board, D));
                        break;
                    case DataMoveRuleExplicit E:
                        runningSquares.UnionWith(GetIndicesForExplicitMovement(square, E));
                        break;
                }
            }

            return runningSquares;
        }
        
        #endregion Validation


        #region Stepping

        private static HashSet<int> GetIndicesForDirectionalStepping(
            Square square, 
            BoardData board, 
            DataMoveRuleDirectional rule)
        {
            HashSet <int> indices = new HashSet<int>();
            switch (rule.Direction)
            {
                case MoveDirectionType.File:
                    indices = GetIndicesForDirectionalFileStepping(square, board, rule);
                    break;
                case MoveDirectionType.Rank:
                    indices = GetIndicesForDirectionalRankStepping(square, board, rule);
                    break;
                case MoveDirectionType.Diagonal:
                    indices = GetIndicesForDirectionalDiagonalStepping(square, board, rule);
                    break;
            }

            return indices;
        }
        
        private static HashSet<int> GetIndicesForDirectionalFileStepping(
            Square square, 
            BoardData board,
            DataMoveRuleDirectional rule)
        {
            HashSet <int> indices = new HashSet<int>();
            
            // North and south
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 1));
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 5));
            
            return indices;
        }
        
        private static HashSet<int> GetIndicesForDirectionalRankStepping(
            Square square, 
            BoardData board,
            DataMoveRuleDirectional rule)
        {
            HashSet <int> indices = new HashSet<int>();
            
            // East and West
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 3));
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 7));
            
            return indices;
        }
        
        private static HashSet<int> GetIndicesForDirectionalDiagonalStepping(
            Square square, 
            BoardData board,
            DataMoveRuleDirectional rule)
        {
            HashSet <int> indices = new HashSet<int>();
            
            // Diagonals
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 0));
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 2));
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 4));
            indices.UnionWith(GetNeighborSquareChain(square, board, rule.MaxDistance, 6));
            
            return indices;
        }
        
        private static HashSet<int> GetNeighborSquareChain(Square sourceSquare, BoardData board, int maxDistance, int neighborIndex)
        {
            HashSet <int> indices = new HashSet<int>();
            int squaresCounted = 0;
            Square runningSquare = sourceSquare;
            int distance = maxDistance <= 0 ? int.MaxValue : maxDistance;
                
            while (squaresCounted < distance)
            {
                Square thisSquare = GetNeighborSquare(runningSquare, board, neighborIndex);
                if (thisSquare != null && SquareIsEmpty(thisSquare))
                {
                    indices.Add(thisSquare.Data.BoardIndex);
                    runningSquare = thisSquare;
                }
                else
                {
                    break;
                }
                
                squaresCounted++;
            }
            Debug.Log(squaresCounted);

            return indices;
        }

        private static Square GetNeighborSquare(Square sourceSquare, BoardData board, int neighborIndex)
        {
            Square square = null;
            int index = sourceSquare.Data.CacheData.NeighborSquareIndices[neighborIndex];
            if (index != -1)
            {
                square = board.Squares[index];
            }
            
            return square;
        }

        #endregion Stepping


        #region Movement

        // private static HashSet<int> GetIndicesForDirectionalMovement(Square square, DataMoveRuleDirectional rule)
        // {
        //     HashSet <int> indices = new HashSet<int>();
        //     switch (rule.Direction)
        //     {
        //         case MoveDirectionType.File:
        //             indices = square.Data.CacheData.FileSquareIndices;
        //             break;
        //         case MoveDirectionType.Rank:
        //             indices = square.Data.CacheData.RankSquareIndices;
        //             break;
        //         case MoveDirectionType.Diagonal:
        //             indices = square.Data.CacheData.DiagonalSquareIndices;
        //             break;
        //     }
        //
        //     return indices;
        // }
        
        private static HashSet<int> GetIndicesForExplicitMovement(Square square, DataMoveRuleExplicit rule)
        {
            HashSet<int> indices = new HashSet<int>();
            foreach (DataMoveRuleExplicitStep step in rule.Steps)
            {
                
            }

            return indices;
        }

        #endregion Movement


        #region Valid

        private static bool SquareIsValidForPiece(Square square, Piece piece)
        {
            bool valid = SquareIsEmpty(square);
            if (!valid)
            {
                valid = SquareIsOccupiedByEnemy(square, piece.Data.Team);
            }

            return valid;
        }
        
        private static bool SquareIsEmpty(Square square)
        {
            return square.Data.CurrentPiece == null;
        }

        private static bool SquareIsOccupiedByEnemy(Square square, int pieceTeam)
        {
            return square.Data.CurrentPiece.Data.Team != pieceTeam;
        }

        #endregion Valid
    }
}
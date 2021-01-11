namespace SharpChess
{
    public static class GameConstructor
    {
        #region Variables

        private static IGame _client;

        #endregion Variables
        
        
        #region Creation

        public static CoreSimulation CreateGame(
            ConfigurationDataBoard boardData, 
            ConfigurationDataPiece[] piecesData, 
            IGame client)
        {
            // Set the client
            _client = client;
            
            // Creates the board and the squares
            Board board = new Board(boardData);
            
            // Create the pieces
            Piece[] pieces = CreatePieces(piecesData, board);
            
            // Create simulation
            return new CoreSimulation(client, board, pieces);
        }

        private static Piece[] CreatePieces(ConfigurationDataPiece[] piecesData, Board board)
        {
            Piece[] pieces = new Piece[piecesData.Length];
            for (int i = 0; i < pieces.Length; i++)
            {
                ConfigurationDataPiece configSource = piecesData[i];
                pieces[i] = new Piece
                {
                    Data = new PieceData
                    {
                        PieceTypeID = configSource.ID,
                        Team = configSource.Team,
                        CurrentSquare = BoardPositionUtility.GetSquareForCoordinates(
                            configSource.StartingPosition.File, configSource.StartingPosition.Rank, board.Data),
                        MovementRules = configSource.MoveRules,
                        MovementProperties = configSource.MoveProperties
                    }
                };
                
                // Set the piece for the current square
                pieces[i].Data.CurrentSquare.Data.CurrentPiece = pieces[i];
                
                // Create client
                pieces[i].Client = CreatePieceClient(pieces[i].Data.PieceTypeID, pieces[i].Data.CurrentSquare);
                pieces[i].Client.id = i;
            }
            return pieces;
        }

        #endregion Creation


        #region Clients

        public static ISquare CreateSquareClient(DataBoardPosition position)
        {
            return _client.CreateSquareClient(position);
        }
        
        private static IPiece CreatePieceClient(string pieceID, Square currentSquare)
        {
            return _client.CreatePieceClient(pieceID, currentSquare);
        }
 
        #endregion Clients
    }
}
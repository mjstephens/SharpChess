namespace SharpChess
{
    public class CoreSimulation
    {
        #region Variables

        /// <summary>
        /// The board being used for the simulation
        /// </summary>
        private readonly Board _board;

        /// <summary>
        /// 
        /// </summary>
        private readonly Piece[] _pieces;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly IGame _gameClient;

        #endregion Variables


        #region Constructor

        public CoreSimulation(IGame game, Board board, Piece[] pieces)
        {
            _gameClient = game;
            _board = board;
            _pieces = pieces;
        }

        #endregion Constructor


        #region Initialization

        public void Start()
        {
            _gameClient.StartGame(this);
        }

        #endregion Initialization


        #region Update

        public void DoClientPingSquare(ISquare square)
        {
            foreach (int i in _board.GetSquareCache(square).DiagonalSquareIndices)
            {
                _board.Data.Squares[i].Client.PingSquare(SquarePingType.Test);
            }
        }

        public void DoClientPieceStage(IPiece piece)
        {
            
        }

        public void DoClientAttemptPieceMove(IPiece piece, ISquare targetSquare)
        {
            //
            Piece p = _pieces[piece.id];
            Square s = _board.Data.Squares[targetSquare.id];
            
            // Gather move data
            MoveData moveData = new MoveData
            {
                Board = _board.Data,
                Piece = p,
                Square = s
            };
            
            // Send result to client simulation
            MoveResultData result = MovementValidator.MoveIsValid(moveData);
            if (result.Success)
            {
                p.Data.CurrentSquare.Data.CurrentPiece = null;
                p.Data.CurrentSquare = s;
                s.Data.CurrentPiece = p;
            }
            
            _gameClient.DoPieceMoveValidationResult(result);
        }

        #endregion Update
    }
}
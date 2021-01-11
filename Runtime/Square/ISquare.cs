
namespace SharpChess
{
    /// <summary>
    /// Client interface for squares
    /// </summary>
    public interface ISquare
    {
        #region Properties

        /// <summary>
        /// We use this for easy access to the Square class from ISquare
        /// </summary>
        int id { get; set;  }

        #endregion Properties
        
        
        #region Methods

        /// <summary>
        /// Squares can be pinged for a variety of reasons
        /// </summary>
        /// <param name="type"></param>
        void PingSquare(SquarePingType type);

        #endregion Methods

    }
}
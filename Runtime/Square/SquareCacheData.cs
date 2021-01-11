using System.Collections.Generic;

namespace SharpChess
{
    public struct SquareCacheData
    {
        public List<int> NeighborSquareIndices;
        public List<int> FileSquareIndices;
        public List<int> RankSquareIndices;
        public List<int> DiagonalSquareIndices;
    }
}
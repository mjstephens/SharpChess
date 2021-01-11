using System;

namespace SharpChess
{
    public struct BoardData
    {
        public Tuple<int, int> Dimensions;
        public Square[] Squares;
    }
}
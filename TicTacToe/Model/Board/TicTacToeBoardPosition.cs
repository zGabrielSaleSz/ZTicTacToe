using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model.Board
{
    public class TicTacToeBoardPosition
    {
        public TicTacToeBoardPosition()
        {

        }
        public TicTacToeBoardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public int Row;
        public int Column;
    }
}

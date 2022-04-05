using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model.Board;

namespace TicTacToe.Model.Players
{
    public class Play : TicTacToeBoardPosition
    {
        public Play()
        {

        }
        public Play(int row, int column) : base(row,column)
        {

        }
        public Play(int row, int column, Model.Board.IconType iconType)
        {
            Row = row;
            Column = column;
            Icon = iconType;
        }
        public IconType Icon;
    }
}

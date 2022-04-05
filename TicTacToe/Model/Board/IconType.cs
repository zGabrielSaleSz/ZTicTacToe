using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model.Board
{
    public enum IconType
    {
        Circle = 1,
        Cross = 2
    }
    public static class IconTypeExtension
    {
        public static string GetDescription(this IconType? iconType)
        {
            if (iconType == IconType.Circle)
                return "O";
            if(iconType == IconType.Cross)
                return "X";
            return " ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model.Board
{
    public class BoardIcon : IEquatable<BoardIcon>
    {
        public IconType? Icon { get; private set; }
        public BoardIcon()
        {

        }
        public BoardIcon(IconType icon)
        {
            Icon = icon;
        }
        public void SetIcon(IconType icon)
        {
            if (Icon.HasValue)
                throw new Exception("This place is busy!");
            this.Icon = icon;
        }
        public string GetIcon()
        {
            if (!Icon.HasValue)
                return " ";
            if (Icon == IconType.Circle)
                return "O";
            else return "X";
        }


        public bool Equals(BoardIcon other)
        {
            if (!this.Icon.HasValue && !other.Icon.HasValue)
                return true;
            if(this.Icon.HasValue && other.Icon.HasValue)
            {
                return this.Icon.Value == other.Icon.Value;
            }
            return false;
        }
    }
}

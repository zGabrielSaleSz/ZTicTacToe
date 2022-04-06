using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model.Board;

namespace TicTacToe.Model.Players
{
    public abstract class Player
    {
        public Player()
        {
            
        }

        public abstract Play RequestPlay(TicTacToeBoard board);
        public abstract string GetName();
        public abstract void NotifyInvalidPlay();
    }
}

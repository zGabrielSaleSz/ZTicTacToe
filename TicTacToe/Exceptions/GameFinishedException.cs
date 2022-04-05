using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Exceptions
{
    public class GameFinishedException : Exception
    {
        public GameFinishedException() : base("Game is already finished")
        {

        }
    }
}

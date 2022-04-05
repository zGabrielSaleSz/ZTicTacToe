using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Exceptions
{
    public class InvalidPlayException : Exception
    {
        public InvalidPlayException() : base("Invalid attempt of play")
        {
        }
    }
}

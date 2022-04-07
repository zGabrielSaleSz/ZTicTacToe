using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model;
using TicTacToe.Model.Board;

namespace TicTacToe.ConsoleApp.Drawers
{
    public class BoardDrawer
    {
        private TicTacToeBoard Board;
        public BoardDrawer(TicTacToeBoard tableBoard)
        {
            Board = tableBoard;
        }
        public void DisplayConsole()
        {
            List<string> currentRow = new List<string>(Board.Size);
            Console.WriteLine("-----------------------------");
            for (int row = 0; row < Board.Size; row++)
            {
                for (int column = 0; column < Board.Size; column++)
                {
                    currentRow.Add(Board.BoardPlaces[row, column].GetDescription());
                }
                DisplayRow(currentRow);
                Console.WriteLine("-----------------------------");
                currentRow.Clear();
            }
        }

        private void DisplayRow(IEnumerable<string> currentRow)
        {
            Console.WriteLine(string.Join('|', currentRow.Select(c => c)));
        }
    }
}

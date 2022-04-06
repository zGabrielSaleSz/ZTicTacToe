using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.ConsoleApp.Drawers;
using TicTacToe.Model;
using TicTacToe.Model.Board;
using TicTacToe.Model.Players;

namespace TicTacToe.ConsoleApp
{
    public class ConsolePlayer : Player
    {
        public string Name { get; }
        public ConsolePlayer(string name)
        {
            Name = name;
        }

        public override Play RequestPlay(TicTacToeBoard board)
        {
            BoardDrawer drawer = new BoardDrawer(board);
            drawer.DisplayConsole();

            Console.WriteLine($"{Name}, it's your turn:");
            string options = Console.ReadLine();
            string[] optionsSplited = options.Split(" ");
            Play play = new Play();
            play.Row = Convert.ToInt32(optionsSplited[0]);
            play.Column = Convert.ToInt32(optionsSplited[1]);
            return play;
        }

        public override string GetName()
        {
            return Name;
        }

        public override void NotifyInvalidPlay()
        {
            Console.WriteLine("Invalid play attempt, please check the Board before your next play!");
        }
    }
}

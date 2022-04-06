using System;
using TicTacToe.Model.Players;
using TicTacToe.Model.Board;
using TicTacToe.ConsoleApp.Drawers;
using TicTacToe.Model;

namespace TicTacToe.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TicTacToeBoard board = new TicTacToeBoard();
            //BoardDrawer boardDrawer = new BoardDrawer(board);

            //ScoreBoard scoreBoard = new ScoreBoard();
            //ScoreBoardDrawer scoreBoardDrawer = new ScoreBoardDrawer(scoreBoard);
            //scoreBoard.AddVictory(new ConsolePlayer("Gabriel"));

            //boardDrawer.DisplayConsole();
            //board.Play(new Play(1, 1, IconType.Circle));
            //board.Play(new Play(1, 2, IconType.Cross));
            //boardDrawer.DisplayConsole();

            Game game = new Game(new ConsolePlayer("Jhonathan"), new ConsolePlayer("Gabriel"), 1);
            ScoreBoardDrawer drawer = new ScoreBoardDrawer(game.ScoreBoard);

            game.StartGame(IconType.Circle);
            Console.ReadKey();
        }

    }
}

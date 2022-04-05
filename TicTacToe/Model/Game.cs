using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model.Board;
using TicTacToe.Model.Players;

namespace TicTacToe.Model
{
    public class Game
    {
        public Game(Player playerX, Player playerO, int victoriesToWin) 
        {
            RespectiveIcons = new Dictionary<IconType, Player>();
            RespectiveIcons.Add(IconType.Cross, playerX);
            RespectiveIcons.Add(IconType.Circle, playerO);
        }

        private Dictionary<IconType, Player> RespectiveIcons;

        private IconType PlayerStartedLastRound { get; set; }
        private IconType Turn { get; set; }

        public void StartGame(IconType startsInFirstRound)
        {
            PlayerStartedLastRound = startsInFirstRound;
            Turn = startsInFirstRound;
            SetFirstPlayer(startsInFirstRound);
            StartRound();
        }

        private void StartRound()
        {
            TicTacToeBoard board = new TicTacToeBoard();
            ScoreBoard scoreBoard = new ScoreBoard();
            while (!board.Finished)
            {
                Player player = GetNextPlayer();
                Play play = player.RequestPlay(board);
                play.Icon = Turn;
                board.Play(play);
            }
            if (board.IsTied())
            {
                scoreBoard.AddTie();
            }
            else 
            {
                IconType winner = board.Winner.Value;

            }
        }

        private void SetFirstPlayer(IconType iconType)
        {
            Turn = iconType;
        }

        private Player GetNextPlayer()
        {
            Player player = RespectiveIcons[Turn];
            ChangeTurn();
            return player;
        }

        private void ChangeTurn()
        {
            int nextTurn = (int)Turn + 1;
            int maxIcons = Enum.GetValues(typeof(IconType)).Cast<int>().Max();
            Turn = (IconType)(nextTurn/maxIcons);
        }
    }
}

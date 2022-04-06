using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Exceptions;
using TicTacToe.Model.Board;
using TicTacToe.Model.Players;

namespace TicTacToe.Model
{
    public class Game
    {
        public Game(Player playerX, Player playerO, int victoriesToWin) 
        {
            ScoreBoard = new ScoreBoard();
            RespectiveIcons = new Dictionary<IconType, Player>();
            RespectiveIcons.Add(IconType.Cross, playerX);
            RespectiveIcons.Add(IconType.Circle, playerO);

            ScoreBoard.AddPlayer(playerX);
            ScoreBoard.AddPlayer(playerO);
            ScoreBoard.RequestUpdate();
        }
        public int CurrentRound { get; private set; }

        private TicTacToeBoard Board;
        public ScoreBoard ScoreBoard { get; private set; }

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
            Board = new TicTacToeBoard();
            while (!Board.Finished)
            {
                bool validMove = false;
                Player player = GetNextPlayer();
                while (!validMove)
                {
                    Play play = player.RequestPlay(Board);
                    play.Icon = Turn;
                    try
                    {
                        Board.Play(play);
                        validMove = true;
                    }
                    catch (InvalidPlayException _)
                    {
                        player.NotifyInvalidPlay();
                    }
                    catch
                    {
                        throw;
                    }
                }
                ChangeTurn();

            }
            if (Board.IsTied())
            {
                ScoreBoard.AddTie();
            }
            else 
            {
                IconType winner = Board.Winner.Value;
                ScoreBoard.AddVictory(RespectiveIcons[winner]);
            }
        }

        private void SetFirstPlayer(IconType iconType)
        {
            Turn = iconType;
        }

        private Player GetNextPlayer()
        {
            Player player = RespectiveIcons[Turn];
            return player;
        }

        private void ChangeTurn()
        {
            if (Turn == IconType.Circle)
                Turn = IconType.Cross;
            else
                Turn = IconType.Circle;
        }
    }
}

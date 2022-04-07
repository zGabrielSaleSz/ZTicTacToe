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
        public int CurrentRound { get; private set; }
        public ScoreBoard ScoreBoard { get; private set; }
        private TicTacToeBoard Board;

        private Dictionary<IconType, Player> Players;
        private IconType PlayerStartedLastRound { get; set; }
        private IconType Turn { get; set; }
        private int VictoriesToWin;

        public Game(Player playerX, Player playerO, int victoriesToWin) 
        {
            VictoriesToWin = victoriesToWin;
            ScoreBoard = new ScoreBoard();
            Players = new Dictionary<IconType, Player>();
            Players.Add(IconType.Cross, playerX);
            Players.Add(IconType.Circle, playerO);

            ScoreBoard.AddPlayer(playerX);
            ScoreBoard.AddPlayer(playerO);
            ScoreBoard.RequestUpdate();
        }
        

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
            ProcessCurrentRound();
            UpdateRoundResult();
        }

        private void UpdateRoundResult()
        {
            if (Board.IsTied())
            {
                ScoreBoard.AddTie();
                Players.Select(r => r.Value).ToList().ForEach(player =>
                {
                    player.NotifyRoundResult(RoundResult.Tie);
                });
            }
            else
            {
                IconType winner = Board.Winner.Value;
                ScoreBoard.AddVictory(Players[winner]);
                Players[winner].NotifyRoundResult(RoundResult.Victory);
                Players.Where(v => v.Key != winner).Select(p => p.Value).ToList().ForEach(defeatedPlayer =>
                {
                    defeatedPlayer.NotifyRoundResult(RoundResult.Defeat);
                });
            }
        }

        private void ProcessCurrentRound()
        {
            while (!Board.Finished)
            {
                bool validMove = false;
                Player player = GetCurrentPlayer();
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
        }

        private void SetFirstPlayer(IconType iconType)
        {
            Turn = iconType;
        }

        private Player GetCurrentPlayer()
        {
            Player player = Players[Turn];
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

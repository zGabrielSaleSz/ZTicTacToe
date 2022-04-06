using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model.Players;

namespace TicTacToe.Model.Board
{
    public class ScoreBoard
    {
        public delegate void OnUpdateScoreBoard();
        public event OnUpdateScoreBoard OnUpdate;
        public Dictionary<Player, int> Victories { get; private set; }
        public int Ties { get; private set; } = 0;

        public ScoreBoard()
        {
            Victories = new Dictionary<Player, int>();
        }
        public void AddPlayer(Player player)
        {
            Victories.Add(player, 0);
        }
        public void AddVictory(Player player)
        {
            if (!Victories.ContainsKey(player))
                AddPlayer(player);
            Victories[player]++;
            RequestUpdate();
        }
        public void AddTie()
        {
            this.Ties++;
            RequestUpdate();
        }
        public void RequestUpdate()
        {
            if (OnUpdate != null)
                OnUpdate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Model.Board;

namespace TicTacToe.ConsoleApp.Drawers
{
    public class ScoreBoardDrawer
    {
        private const int BoardCaracteresSize = 50;
        private const int SpaceAround = 2;
        private const int Columns = 2;
        private const int SpaceToWrite = BoardCaracteresSize - (SpaceAround * 2);
        private const int ColumnWidth = SpaceToWrite / Columns;
      

        public readonly string ThikDivision;
        public readonly string ThinDivision;
        public ScoreBoard ScoreBoard { get; }
        public ScoreBoardDrawer(ScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard;
            ScoreBoard.OnUpdate += ScoreBoard_OnUpdate;
            ThikDivision = "".PadLeft(BoardCaracteresSize, '=');
            ThinDivision = "".PadLeft(BoardCaracteresSize, '-');
        }

        private void ScoreBoard_OnUpdate()
        {
            Draw();
        }

        public void Draw()
        {
            Console.WriteLine(ThikDivision);
            WriteSingle("Scores");
            Console.WriteLine(ThikDivision);
            WriteKeyValue("Player", "Victories");
            Console.WriteLine(ThikDivision);
            foreach (var player in ScoreBoard.Victories)
            {
                WriteKeyValue(player.Key.GetName(), BuildValue(player.Value.ToString()));
                Console.WriteLine(ThinDivision);
            }
            Console.WriteLine(ThinDivision);
            WriteKeyValue("Ties", ScoreBoard.Ties.ToString());
            Console.WriteLine(ThikDivision);
        }
        private void WriteSingle(string content)
        {
            Console.WriteLine($"| {BuildTitle(content)} |");
        }

        private void WriteKeyValue(string key, string value)
        {
            Console.WriteLine($"| {BuildKey(key)}{BuildValue(value)} |");
        }

        private string BuildTitle(string content)
        {
            return PaddingBoth(content, SpaceToWrite);
        }

        private string BuildKey(string content)
        {
            return PaddingRight(content, ColumnWidth);
        }
        private string BuildValue(string content)
        {
            return PaddingLeft(content, ColumnWidth);
        }

        public string PaddingLeft(string content, int lenght)
        {
            if (content.Length >= lenght)
                return content.Substring(0, lenght);
            return content.PadLeft(lenght, ' ');
        }
        public string PaddingRight(string content, int lenght)
        {
            if (content.Length >= lenght)
                return content.Substring(0, lenght);
            return content.PadRight(lenght, ' ');
        }
        public string PaddingBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);
        }
    }
}

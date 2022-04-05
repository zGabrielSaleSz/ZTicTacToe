using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Exceptions;
using TicTacToe.Model.Board;
using TicTacToe.Model.Players;

namespace TicTacToe.Model.Board
{
    public class TicTacToeBoard
    {
        public IconType?[,] BoardPlaces { get; private set; }
        public int Size { get; private set; }
        public bool Finished { get; private set; }
        public bool Tie { get; private set; }
        public IconType? Winner { get; private set; }

        public TicTacToeBoard(int size = 3)
        {
            Finished = false;
            Tie = false;
            Size = size;
            Winner = null;
            Initialize(size);

        }

        private void Initialize(int size)
        {
            BoardPlaces = new IconType?[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    BoardPlaces[i, j] = null;
                }
            }
        }

       
        public void Play(Play play)
        {
            if (Finished)
                throw new GameFinishedException();
            if (BoardPlaces[play.Row, play.Column].HasValue)
                throw new InvalidPlayException();

            BoardPlaces[play.Row, play.Column] = play.Icon;
            UpdateWinner();
        }

        private void UpdateWinner()
        {
            CheckForWinnerInRows();
            CheckForWinnerInColumns();
            CheckForWinnerDiagonal();
            CheckAvailablePlays();
        }

        private void CheckAvailablePlays()
        {
            foreach(var i in  Enumerable.Range(0, GetLastIndex()))
            {
                foreach(var j in Enumerable.Range(0, GetLastIndex()))
                {
                    if (!BoardPlaces[i, j].HasValue)
                        return;
                }
            }
            SetTie();
        }

        private void CheckForWinnerInRows()
        {
            foreach (int i in Enumerable.Range(0, GetLastIndex()))
            {
                HasWinnerInRow(i);
                if (Finished)
                    return;
            }
        }

        private void CheckForWinnerInColumns()
        {
            foreach (int i in Enumerable.Range(0, GetLastIndex()))
            {
                HasWinnerInColumn(i);
                if (Finished)
                    return;
            }
        }

        private void CheckForWinnerDiagonal()
        {
            HasWinnerDiagonalLeftToRight();
            if (Finished)
                return;
            HasWinnerDiagonalRightToLeft();
        }

        private void HasWinnerDiagonalLeftToRight()
        {
            if (!BoardPlaces[0, 0].HasValue)
                return;

            IconType expectedWinner = BoardPlaces[0, 0].Value;
            foreach (int i in Enumerable.Range(1, GetLastIndex()))
            {
                if (expectedWinner != BoardPlaces[i, i])
                    return;
            }
            SetWinner(expectedWinner);
        }

        private void HasWinnerDiagonalRightToLeft()
        {
            int lastIndex = GetLastIndex();
            if (!BoardPlaces[0, lastIndex].HasValue)
                return;
            IconType expectedWinner = BoardPlaces[0, lastIndex].Value;
            foreach (int i in Enumerable.Range(1, GetLastIndex()))
            {
                int reversedIndex = lastIndex - i;
                if (expectedWinner != BoardPlaces[i, reversedIndex])
                    return;
            }
            SetWinner(expectedWinner);
        }

        private void HasWinnerInRow(int rowNumber)
        {
            if (!BoardPlaces[rowNumber, 0].HasValue)
                return;

            IconType expectedWinner = BoardPlaces[rowNumber, 0].Value;
            foreach(int i in Enumerable.Range(1, GetLastIndex())) 
            {
                if (expectedWinner != BoardPlaces[rowNumber, i])
                    return;
            }
            SetWinner(expectedWinner);
        }
     
        private void HasWinnerInColumn(int columnNumber)
        {
            if (!BoardPlaces[0, columnNumber].HasValue)
                return;

            IconType expectedWinner = BoardPlaces[0, columnNumber].Value;
            foreach (int i in Enumerable.Range(1, GetLastIndex()))
            {
                if (expectedWinner != BoardPlaces[i, columnNumber])
                    return;
            }
            SetWinner(expectedWinner);
        }

        private int GetLastIndex()
        {
            return Size - 1;
        }

        public bool IsFinished()
        {
            return Finished;
        }

        public bool IsTied()
        {
            return Tie;
        }

        private void SetWinner(IconType iconType)
        {
            Finished = true;
            Winner = iconType;
        }

        private void SetTie()
        {
            Finished = true;
        }
    }
}

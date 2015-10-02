﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Field : IField
    {
        private Random random;

        private int numberOfMines;
        private string[,] mineFiled;
        private int rows;
        private int cols;
        private int revialedCells;

        public int NumberOfMines
        {
            get
            {
                return this.numberOfMines;
            }
            private set
            {
                this.numberOfMines = value;
            }
        }

        public string[,] MineField
        {
            get
            {
                return this.mineFiled;
            }
            private set
            {
                this.mineFiled = value;
            }
        }

        public int Rows
        {
            get { return this.rows; }
            private set { this.rows = value; }
        }

        public int Cols
        {
            get { return this.cols; }
            private set { this.cols = value; }
        }

        public int RevialedCells
        {
            get { return this.revialedCells; }
            set { this.revialedCells = value; }
        }

        public Field(int rows, int cols, int numbOfMines)
        {
            this.NumberOfMines = numbOfMines;
            this.Rows = rows;
            this.Cols = cols;
            this.mineFiled = new string[this.Rows, this.Cols];
            this.RevialedCells = 0;
        }


        public void Initialize()
        {
            this.random = new Random();
            this.RevialedCells = 0;
            GetDefaultField();
            FillWithRandomMines();
        }

        public bool IsMoveInBounds(int row, int col)
        {
            var output = (row >= 0) && (row < this.Rows) && (col >= 0) && (col < this.Cols);
            return output;
        }

        public bool IsCellCkicled(int row, int col)
        {
            var output = this.mineFiled[row, col] != "" || this.mineFiled[row, col] != "*";
            return output;
        }

        public void RevealNumber(int row, int col)
        {
           
            if (this.mineFiled[row, col] == "")
            {
                int[] dRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
                int[] dCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
                int minesCounter = 0;

                for (int direction = 0; direction < 8; direction++)
                {
                    int newRow = dRow[direction] + row;
                    int newCol = dCol[direction] + col;
                    if (IsMoveInBounds(newRow, newCol))
                    {
                        if (this.MineField[newRow, newCol] == "*")
                        {
                            minesCounter++;
                        }
                    }

                }
                this.mineFiled[row, col] = Convert.ToString(minesCounter);
                this.RevialedCells++;
            }
          
        }

        private void GetDefaultField()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.mineFiled[i, j] = "";
                }
            }
        }

        private void FillWithRandomMines()
        {
            int minesCounter = 0;
            while (minesCounter < NumberOfMines)
            {
                int randomRow = this.random.Next(0, this.Rows);
                int randomCol = this.random.Next(0, this.cols);
                if (this.mineFiled[randomRow, randomCol] == "")
                {
                    this.mineFiled[randomRow, randomCol] += "*";
                    minesCounter++;
                }
            }
        }
    }
}

namespace Minesweeper
{
    using System;

    public class Field : IField
    {
        private readonly Cell cel = new Cell();

        private Random random;  
        private int numberOfMines;
        private Cell[,] mineField;
        private int rows;
        private int cols;
        private int revealedCells;

        /// <summary>
        /// An object Field that holds number of mines, rows, cols, mine field and number of revealedCells.
        /// </summary>
        /// <param name="rows">Number of Rows.</param>
        /// <param name="cols">Number of Cols.</param>
        /// <param name="numbOfMines">Number of mines.</param>
        public Field(int rows, int cols, int numbOfMines)
        {
            this.NumberOfMines = numbOfMines;
            this.Rows = rows;
            this.Cols = cols;
            this.mineField = new Cell[this.Rows, this.Cols];
            this.RevealedCells = 0;
        }

        /// <summary>
        /// Number of mines.
        /// </summary>
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

        /// <summary>
        /// An array that holds the values of each cell in the mine field. The Values can be either "", "*" or the number of mines around this cell.
        /// </summary>
        public Cell[,] MineField
        {
            get
            {
                return this.mineField;
            }

            private set
            {
                this.mineField = value;
            }
        }

        /// <summary>
        /// Number of Rows.
        /// </summary>
        public int Rows
        {
            get { return this.rows; }
            private set { this.rows = value; }
        }

        /// <summary>
        /// Number of Cols.
        /// </summary>
        public int Cols
        {
            get { return this.cols; }
            private set { this.cols = value; }
        }

        /// <summary>
        /// A variable that holds the number of the cells that are being revealed.
        /// </summary>
        public int RevealedCells
        {
            get { return this.revealedCells; }
            set { this.revealedCells = value; }
        }

        /// <summary>
        /// Initialises the Field.
        /// </summary>
        public void Initialize()
        {
            this.RevealedCells = 0;
            this.GetDefaultField();
            this.FillWithRandomMines();
        }

        /// <summary>
        /// Checks if a given move is in bounds and returns a bool that is true if the given move is in bounds and false if the given move is not in bounds.
        /// </summary>
        /// <param name="row">The Row that the user entered.</param>
        /// <param name="col">The Col that the user entered.</param>
        /// <returns>A bool that is true if the given move is in bounds and false if the given move is not in bounds.</returns>
        public bool IsMoveInBounds(int row, int col)
        {
            var output = (row >= 0) && (row < this.Rows) && (col >= 0) && (col < this.Cols);
            return output;
        }

        /// <summary>
        /// Checks if a given cell is already clicked and returns a bool that is true if the given cell is already clicked and false if the cell is still closed.
        /// </summary>
        /// <param name="row">The Row that the user entered.</param>
        /// <param name="col">The Col that the user entered.</param>
        /// <returns>A bool that is true if the given cell is already clicked and false if the cell is still closed.</returns>
        public bool IsCellClickled(int row, int col)
        {
            return this.mineField[row, col].Value != string.Empty && !this.mineField[row, col].IsBomb;           
        }

        /// <summary>
        /// Reveals the number of mines that lay around a given cell. Checks every cell around the given cell and counts the number of mines around it.
        /// </summary>
        /// <param name="row">Given row.</param>
        /// <param name="col">Given col.</param>
        public void RevialCell(int row, int col)
        {
            if (this.mineField[row, col].Value == string.Empty)
            {
                int[] directionRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
                int[] directionCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
                int minesCounter = 0;

                for (int direction = 0; direction < directionRow.Length; direction++)
                {
                    int newRow = directionRow[direction] + row;
                    int newCol = directionCol[direction] + col;
                    if (this.IsMoveInBounds(newRow, newCol))
                    {
                        if (this.MineField[newRow, newCol].IsBomb)
                        {
                            minesCounter++;
                        }
                    }
                }

                this.mineField[row, col].Value = Convert.ToString(minesCounter);
                this.RevealedCells++;
            }
        }

        /// <summary>
        /// Gets default field that is full with empty strings.
        /// </summary>
        public void GetDefaultField()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.mineField[i, j] = this.cel.Clone();
                }
            }
        }

        /// <summary>
        /// Adds mines at random positions to the field.
        /// </summary>
        private void FillWithRandomMines()
        {
            this.random = new Random();
            int minesCounter = 0;
            while (minesCounter < this.NumberOfMines)
            {
                int randomRow = this.random.Next(0, this.Rows);
                int randomCol = this.random.Next(0, this.cols);
                if (!this.mineField[randomRow, randomCol].IsBomb)
                {
                    this.mineField[randomRow, randomCol].IsBomb = true;
                    this.mineField[randomRow, randomCol].Value = "*";
                    minesCounter++;
                }
            }
        }
    }
}

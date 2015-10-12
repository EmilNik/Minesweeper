namespace Minesweeper
{
    public interface IField
    { 
        int NumberOfMines { get; set; }

        int RevealedCells { get; set; }

        Cell[,] MineField { get; set; }

        void Initialize();

        bool IsMoveInBounds(int row, int col);

        bool IsCellClickled(int row, int col);

        void RevialCell(int row, int col);

        void GetDefaultField();
    }
}

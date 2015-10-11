namespace Minesweeper
{
    using System;

    public interface IField
    {
        void Initialize();

        bool IsMoveInBounds(int row, int col);

        bool IsCellClickled(int row, int col);

        void RevialCell(int row, int col);

        void GetDefaultField();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public interface IField
    {
        void Initialize();

        bool IsMoveInBounds(int row, int col);

        bool IsCellCkicled(int row, int col);

        void RevealNumber(int row, int col);
    }
}

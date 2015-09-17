namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public interface IPrinter
    {
        void PrintScoreBoard(IScoreBoard scoreBoard);
    }
}

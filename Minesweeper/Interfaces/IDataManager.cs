namespace Minesweeper.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IDataManager
    {
        Dictionary<string, int> Read();

        void Write(Dictionary<string, int> scoreBoard);
    }
}

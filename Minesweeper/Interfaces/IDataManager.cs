using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Interfaces
{
    public interface IDataManager
    {
        Dictionary<string, int> Read();

        void Write(Dictionary<string, int> scoreBoard);
    }
}

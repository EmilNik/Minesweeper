using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public abstract class CellPrototype
    {
        public abstract Cell Clone();
    }
}

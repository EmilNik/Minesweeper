using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    public interface ICommand
    {
        void Execute();
    }
}

using Minesweeper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string command);
    }
}

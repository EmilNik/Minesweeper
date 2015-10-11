namespace Minesweeper
{
    using System;

    using Minesweeper.Commands;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string command);
    }
}

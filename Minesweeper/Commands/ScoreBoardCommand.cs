using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    /// <summary>
    /// The exit command cares about printing the scoreBoard when the command is executed.
    /// </summary>
    class ScoreBoardCommand : ICommand
    {
        private ScoreBoard scoreBoard;
        private IPrinter printer;

        public ScoreBoardCommand(ScoreBoard scoreBoard, Printer printer)
        {
            this.scoreBoard = scoreBoard;
            this.printer = printer;
        }

        public void Execute()
        {
            this.printer.PrintScoreBoard(this.scoreBoard);
        }
    }
}

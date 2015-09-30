using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
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

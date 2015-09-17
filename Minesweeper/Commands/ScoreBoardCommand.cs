using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper.Commands
{
    class ScoreBoardCommand : ICommand
    {
        private ScoreBoard scoreBoard;

        public ScoreBoardCommand(ScoreBoard scoreBoard)
        {
            this.scoreBoard = scoreBoard;
        }
            

        public void Execute(string command)
        {
            scoreBoard.PrintScoreBoard();
        }
    }
}

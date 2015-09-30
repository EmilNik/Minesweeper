using Minesweeper.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private ScoreBoard scoreBoard;
        private Printer printer;

        private ICommand scoreBoardCommand;
        private ICommand exitCommand;
        private ICommand restartCommand;

        public CommandFactoryWithLazyLoading(ScoreBoard scoreBoard, Printer printer)
        {
            this.scoreBoard = scoreBoard;
            this.printer = printer;
        }

        public ICommand CreateCommand(string commandAsString)
        {
            ICommand command;

            try
            {
                if (commandAsString == "top")
                {
                    if (this.scoreBoardCommand == null)
                    {
                        this.scoreBoardCommand = new ScoreBoardCommand(scoreBoard, printer);
                    }

                    command = this.scoreBoardCommand;
                }
                else if (commandAsString == "exit")
                {
                    if (this.exitCommand == null)
                    {
                        this.exitCommand = new ExitCommand();
                    }

                    command = this.exitCommand;
                }
                else if (commandAsString == "restart")
                {
                    if (this.restartCommand == null)
                    {
                        this.restartCommand = new RestartCommand();
                    }

                    command = this.restartCommand;
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid command!");
                return null;
            }

            return command;
        }
    }
}

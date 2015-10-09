namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Minesweeper.Commands;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IPrinter printer;
        private Field field;
        private IValidator validator;

        private ICommand scoreBoardCommand;
        private ICommand exitCommand;
        private ICommand restartCommand;
        private ICommand flagCommand;

        public CommandFactoryWithLazyLoading(IPrinter printer, Field field, IValidator validator)
        {
            this.validator = validator;
            this.printer = printer;
            this.field = field;
        }
        
        /// <summary>
        /// Creates and returns a scoreBoardCommand, exitCommand or restartCommand depending on the user input. Each command has unique behaviour.
        /// </summary>
        /// <param name="commandAsString">User input.</param>
        /// <returns>A command that has unique behaviour.</returns>
        public ICommand CreateCommand(string commandAsString)
        {
            ICommand command;

            try
            {
                if (commandAsString == "top")
                {
                    if (this.scoreBoardCommand == null)
                    {
                        this.scoreBoardCommand = new ScoreBoardCommand(this.printer);
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
                        this.restartCommand = new RestartCommand(this.field);
                    }

                    command = this.restartCommand;
                }
                else if(commandAsString == "flag")
                {
                    if (this.flagCommand == null)
                    {
                        this.flagCommand = new FlagCommand(this.field, validator, printer);
                    }

                    command = this.flagCommand;
                }
                else
                {
                    throw new ArgumentException("Invalid command!");
                }
            }
            catch (ArgumentException)
            {
                printer.PrintMessageWithNewLine("Invalid command!");
                return null;
            }

            return command;
        }
    }
}

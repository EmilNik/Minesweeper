namespace Minesweeper
{
    using System;
    using Commands;

    public class CommandFactoryWithLazyLoading : ICommandFactory
    {
        private IPrinter printer;
        private IField field;
        private IValidator validator;

        private ICommand scoreBoardCommand;
        private ICommand exitCommand;
        private ICommand restartCommand;
        private ICommand flagCommand;

        public CommandFactoryWithLazyLoading(IPrinter printer, IField field, IValidator validator)
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
                else if (commandAsString == "flag")
                {
                    if (this.flagCommand == null)
                    {
                        this.flagCommand = new FlagCommand(this.field, this.validator, this.printer);
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
                this.printer.PrintMessageWithNewLine("Invalid command!");
                return null;
            }

            return command;
        }
    }
}

namespace Minesweeper.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The restart command cares about restarting the game and starting a new game when the command is executed.
    /// </summary>
    public class RestartCommand : ICommand
    {
        private readonly IField field;

        public RestartCommand(IField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("game");
            }

            this.field = field;
        }
        public void Execute()
        {
            this.field.Initialize();
        }
    }
}

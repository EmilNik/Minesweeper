namespace MinesweeperEngineTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Minesweeper;

    [TestClass]
    public class TestsEndGameMetdod
    {
        [TestMethod]
        public void TestEndGameMetdod()
        {
            MinesweeperEngine testGame = new MinesweeperEngine();
            //var winMessage = Messages.Success;
            //var failMessage = Messages.BoomMessage;
            testGame.EndGame(true, true);
        }

        /*
        private void EndGame(bool isBoomed, bool playerWon)
        {
            string message;

            if (playerWon)
            {
                message = Messages.Success;
            }
            else if (isBoomed)
            {
                message = Messages.BoomMessage;
            }
            else
            {
                return;
            }
            printer.PrintField(field.MineField, isBoomed);
            printer.PrintMessage(message, field.RevealedCells);
            string currentPlayerName = Console.ReadLine();
            scoreBoard.AddPlayer(currentPlayerName, field.RevealedCells);
        }*/
    }
}

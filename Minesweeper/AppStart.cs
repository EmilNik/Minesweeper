namespace Minesweeper
{
    using System;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            MinesweeperEngine game = new MinesweeperEngine();
            game.PlayMines();
        }
    }
}

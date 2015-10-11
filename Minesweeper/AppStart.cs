namespace Minesweeper
{
    using System;

    public class AppStart
    {
        public static void Main(string[] args)
        {
            IMinesweeperEngine game = new MinesweeperEngine();
            game.PlayMines();
        }
    }
}

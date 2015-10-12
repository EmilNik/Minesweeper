namespace Minesweeper
{
    using System;

    public class AppStart
    {
        ////TODO Remove this useless middleman
        public static void Main(string[] args)
        {
            IMinesweeperEngine game = new MinesweeperEngine();
            game.PlayMines();
        }
    }
}

namespace Minesweeper
{
    /// <summary>
    /// Main method.
    /// </summary>
    public class AppStart
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            // TODO Remove useless Middleman
            IMinesweeperEngine game = new MinesweeperEngine();
            game.PlayMines();
        }
    }
}

namespace Minesweeper
{
    using System;

    ////Prototype pattern
    public class Cell : CellPrototype
    {
        public Cell()
        {
            this.Value = string.Empty;
            this.IsBomb = false;
            this.IsFlagged = false;
        }

        public bool IsBomb { get; set; }

        public bool IsFlagged { get; set; }

        public string Value { get; set; }
 
        public override Cell Clone()
        {
            return this.MemberwiseClone() as Cell;
        }
    }
}

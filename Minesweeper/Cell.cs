using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    //Prototype pattern
    public class Cell : CellPrototype
    {
        public bool isBomb { get; set; }

        public bool isFlagged { get; set; }

        public string Value { get; set; }

        public Cell()
        {
            this.Value = string.Empty;
            this.isBomb = false;
            this.isFlagged = false;
        }
        public override Cell Clone()
        {
            return this.MemberwiseClone() as Cell;
        }
    }
}

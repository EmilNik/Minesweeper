using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public interface IValidator
    {
        void CheckIfIntIsNullOrUndefined(string argument, int number);

        void CheckIfValidInt(string argument, int number);

        void CheckIfStringIsNullOrUndefines(string argument, string text);

        void CheckIfValidString(string argument, string text);

        void CheckIfStringLengthIsInRange(string argument, string text, int minNumber, int maxNumber);
    }
}

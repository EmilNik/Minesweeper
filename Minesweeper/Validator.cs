using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Validator : IValidator
    {
        public void CheckIfIntIsNullOrUndefined(string argument, int number)
        {
            throw new NotImplementedException();
        }

        public void CheckIfValidInt(string argument, int number)
        {
            throw new NotImplementedException();
        }

        public void CheckIfStringIsNullOrUndefines(string argument, string text)
        {
            throw new NotImplementedException();
        }

        public void CheckIfValidString(string argument, string text)
        {
            throw new NotImplementedException();
        }

        public void CheckIfStringLengthIsInRange(string argument, string text, int minNumber, int maxNumber)
        {
            if (text.Length < minNumber || text.Length > maxNumber)
            {
                throw new ArgumentOutOfRangeException($"{argument} must be between {minNumber} and {maxNumber} symbols long");
            }
        }
    }
}

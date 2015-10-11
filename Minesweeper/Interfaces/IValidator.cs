namespace Minesweeper
{
    using System;

    public interface IValidator
    {
        bool IsMoveEntered(string line);

        void CheckIfIntIsNullOrUndefined(string argument, int number);

        void CheckIfValidInt(string argument, int number);

        void CheckIfStringIsNullOrUndefines(string argument, string text);

        void CheckIfValidString(string argument, string text);

        void CheckIfStringLengthIsInRange(string argument, string text, int minNumber, int maxNumber);
    }
}

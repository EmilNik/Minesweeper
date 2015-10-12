namespace Minesweeper
{
    using System;

    /// <summary>
    /// A validator class that has different methods to validate user input;
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// Checks if user input is a valid move and returns a boolean that is true if the move is valid and false if the move is not valid.
        /// </summary>
        /// <param name="line">User input as a string</param>
        /// <returns>Boolean that is true if the move is valid and false if the move is not valid</returns>
        public bool IsMoveEntered(string line)
        {
            bool validMove = false;
            try
            {
                ////TODO Validate wrong movements with the appropriate exception messages
                string[] inputParams = line.Split();
                int row = int.Parse(inputParams[0]);
                int col = int.Parse(inputParams[1]);
                validMove = true;
            }
            catch (FormatException)
            {
            }

            return validMove;
        }

        public void CheckIfIntIsNullOrUndefined(string argument, int number)
        {
            throw new NotImplementedException();
        }

        public void CheckIfValidInt(string argument, int number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a given int is in a given range. Throws an exception if the given int is .
        /// </summary>
        /// <param name="argument">The object name as a string that is being checked</param>
        /// <param name="text">A number that is being checked</param>
        /// <param name="minNumber">Min number</param>
        /// <param name="maxNumber">Max number</param>
        public void CheckIfIntIsInRange(string argument, int number, int minNumber, int maxNumber)
        {
            if (number < minNumber || number > maxNumber)
            {
                throw new ArgumentOutOfRangeException("{argument} must be between {minNumber} and {maxNumber}.");
            }
        }

        public void CheckIfStringIsNullOrUndefines(string argument, string text)
        {
            throw new NotImplementedException();
        }

        public void CheckIfValidString(string argument, string text)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a given string length is in a given range. Throws an exception if the string length is outside the given range.
        /// </summary>
        /// <param name="argument">The object name as a string that is being checked</param>
        /// <param name="text">A string that is being checked</param>
        /// <param name="minNumber">Min length of the string</param>
        /// <param name="maxNumber">Max length of the string</param>
        public void CheckIfStringLengthIsInRange(string argument, string text, int minNumber, int maxNumber)
        {
            if (text.Length < minNumber || text.Length > maxNumber)
            {
                throw new ArgumentOutOfRangeException($"{argument} must be between {minNumber} and {maxNumber} symbols long");
            }
        }
    }
}

1.  Redesigned the project structure: Team “…”
	-	Renamed the solution from 'WindowsMinchki' to 'Minesweeper'
	-   Renamed the project to `Minesweeper`.
	-	Extracted class 'ScoreBoard' in a separate file 'ScoreBoard.cs'.
		-	Reformatted the sorce code using best C# practices:
			-	Removed all unneeded empty lines;
			-	Added an empty line after a closing curly bracket **}**;
			- 	Added an empty line where this helps reading the code;
			-	Removed meaningless comments;
			-	Moved Usings inside he namespace;
			-	Added the access modifier to the class Scoreboard;
			-	Renamed variable FirstFive to firstFive (variable's names must strat with a lower-case letter);
			
		-	Created an interface IScoreBoard and made the class ScoreBoard inherit it.
			-	Interface IScoreBoard implements the method AddPlayer();
			
		-	Refactoring the method PrintScoreBoard() in class ScoreBoard:
			-	Before refactoring:
			
				bool firstFive = false;
				int currentCounter = 1;
	
				Console.WriteLine();
	
				if (this.scoreBoard.Values.Count == 0)
				{
					Console.WriteLine("Scoreboard empty!");
				}
				else
				{
					Console.WriteLine("Scoreboard:");
	
					foreach (int key in this.scoreBoard.Keys.OrderByDescending(obj => obj))
					{
						foreach (string person in this.scoreBoard[key])
						{
							// TODO
							if (currentCounter < 6)
							{
								Console.WriteLine("{0}. {1} --> {2} cells", currentCounter, person, key);
								currentCounter++;
							}
							else
							{
								firstFive = true;
								break;
							}
						}
	
						if (firstFive)
						{
							break;
						}
					}
					
			-	After refactoring:
			
					var numberOfPrintedNames = 5;

					var keys = this.scoreBoard.Keys.OrderByDescending(obj => 							obj).ToArray();
	
					if (keys.Length < numberOfPrintedNames)
					{
					numberOfPrintedNames = keys.Length;
					}
	
					for (int i = 0; i < numberOfPrintedNames; i++)
					{
					var key = keys[i];
					var person = this.scoreBoard[key];
	
					Console.WriteLine("{0}. {1} --> {2} cells", (i + 1), person, 									key);
	
					}
				
		-	Created IPrinter interface and class Printer that inherits it:
			-	moved method PrintScoreBoard from class Scoreboard to Printer
			
		-	Created ICommandFactory interface with the method CreateCommand(string commandAsString);
		
		-	Created class CommandFactoryWithLazyLoading that inherits the ICommandFactory interface;
		
		-	Created ICommand interface with he method Execite(string command)
		
		-	Created ScoreBoardCommand, ExitCommand and RestarCommand classes that inherit the ICommand interface;
			-	Implemented design pattern //SEE THiS PLEASE!!
			
		-	Refactoring the class Minichki.cs
			-	Removed the switch statement:
			
				switch (line)
					{
						case "top":
							{
								scoreBoard.PrintScoreBoard();
								goto enterRowCol;
							}
						case "exit":
							{
								Console.WriteLine("\nGood bye!\n");
								Environment.Exit(0);
								break;
							}
						case "restart":
							{
								Console.WriteLine();
								goto start;
							}
					}
					
			-	And replaced it with:
			
				ICommand command = commandFactory.CreateCommand(line);
				
2.  Moved method `PrintField(string[,] minesMatrix, bool boomed)` to class `Printer`.
		
3.  Moved method `PrintInitialMessage()` to class `Printer`.

4.  Get rid of `go to` by adding simple if staement into the beggining of the while loop in `Minichki`;

	while (true)
        {
            if (isBoomed || playerWon)
            {
                InitializeMinesField(out minichki, out randomMines, out row, out col, out minesCounter, out revealedCellsCounter, out isBoomed, out playerWon);

             FillWithRandomMines(minichki, randomMines);

            }
            ...
            ....
            ...
     		}
		
		
5.	Moved method `PrintScoreBoard()` from class `ScoreBoard` to `Printer`; 
		
6.	Changed the `AddPlayer` logic in the class `ScoreBoard`
	-	Now one name can have only one score. Each name is unique. If a name already exists in the ScoreBoard it will ovverride the scores it has.
7.  Introduced a class `Field`( and an interface to it `IField`)	 to hold all field properties and methods: (`Rows`, `Cols`,`NumberOfMines`,the field it self-`MineField`,`RevialedCells`,methods:`Initialize`,`IsMoveInBounds`,`RevealNumber`).
8.  Modified class `minichki` to work with the previous changes.
9.  Introduced a class `Messages` and moved all messages to it.Made a few changes in some clases to use the messages !
10.  Implemented `RestartCommand` and refactor `MinesweeperEngin` while loop: extracted metod `EndGame` to simplify logic!

 			private void EndGame(bool isBoomed, bool playerWon)
       		{
            string message;

            if (playerWon)
            {
                message = Messages.Success;
            }
            else if (isBoomed)
            {
                message = Messages.BoomMessage;
            }
            else
            {
                return;
            }
            printer.PrintField(field.MineField, isBoomed);
            printer.PrintMessage(message, field.RevealedCells);
            string currentPlayerName = Console.ReadLine();
            scoreBoard.AddPlayer(currentPlayerName, field.RevealedCells);
        	}
            
            
11.	Implemented singleton design pattern on `Printer`.
12.	Implemented new functionality: when ever new player is added the scoreBoard is saved in a file, through strategy pattern(the save/read can be done by diferent classes that implement `IDataManager`- different strategies).
    
    
     	public interface IDataManager
    	{
        Dictionary<string, int> Read();

        void Write(Dictionary<string, int> scoreBoard);
    	}
13.  Moved method `IsMoveEntered` from `Minesweeper.cs` to `Validator.cs`.
14.  Introduced class `Cell.cs` and abstract class `CellPrototype.cs` to implement Prototype pattern.
15.  Made changes to `Printer.cs` to work with previous changes(`Cell.cs`).
16.  Made changes to `Field.cs` to fill the field with objects`Cell()`.
17.  Implemented a new functionality. While playing the player now can flag a cell of his choice.Introduced a new command `flag` to do that.
18.  Chanched logic in `Printer.PrintField` to respond to flaged cells.
19.  ...s
     //
	
	
	
	
	
	-   Renamed the main class `Program` to `GameFifteen`.
	-   Extracted each class in a separate file with a good name: `GameFifteen.cs`, `Board.cs`, `Point.cs`.
	-   …
1.  Reformatted the source code:
	-   Removed all unneeded empty lines, e.g. in the method `PlayGame()`.
	-   Inserted empty lines between the methods.
	-   Split the lines containing several statements into several simple lines, e.g.:
	
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   …
2.  Renamed variables:
	-   In class `Fifteen`: `number` to `numberOfMoves`.
	-   In `Main(string\[\] args)`: `g` to `gameFifteen`.
	
3.  Introduced constants:
	-   `GAME\_BOARD\_SIZE = 4`
	-   `SCORE\_BOARD\_SIZE = 5`. 
4.  Extracted the method `GenerateRandomGame()` from the method `Main()`.

5.  Introduced class `ScoreBoard` and moved all related functionality in it.

6.  Moved method `GenerateRandomNumber(int start, int end)` to separate class `RandomUtils`.
     
7. All usings moved within the namespace of the project

8. Class MinichkiTest renamed to AppStart

9. Class Minichki renamed to MinesweeperEngine

10. Design Patterns
	1. Creational
		* Simple Factory pattern implemented by class CommandFactoryWithLazyLoading - creates a specific command for game end - exit, restart, or top
		* Prototype pattern implemented by class Cell
		* Creational pattern in CommandFactory
	2. Structural
		* Facade pattern implemented by class MinesweeperEngine introducing PlayMines() method
	3. Behavior
		* Strategy pattern in class CommandFactoryWithLazyLoading - client can determine what kind of printer and validator to use

11. TODOs (some thoughts on the game) 
   * Not sure but in DoPlayerWon() method, in Minichki class, **counter** variable and **for loop** are unnecessary -
     **counter variable** will always be equal to **this.RevealedCells variable**???
   * IsCellClicked() method is a little ambigous(hard to understand) with so many negations. See if negation can be skipped! 
   * GetDefaultField() to become private method, used only in the Initiliaze method of the Field class
   * Double implementation of input data once in **IsMoveEntered()** and in the **if statement** after that!
   * Change PrintField() method way of printing field to remove excessive if-else statements of checking validity. Use some Design Pattern
   * Think of way to implement at least three of each group of patterns - Creational, Structural, Behavior Patterns
   * Possible introduction of class Player:
     - playerName
     - score
   * Think of a way to get rid of repeating code for **a player** and **a playerWon**. Reconstruction of the code logic flow might be needed.

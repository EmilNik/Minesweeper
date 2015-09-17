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
			-	Added the access modifier to the class Scoreboard
			-	Renamed variable FirstFive to firstFive (variable's names must strat with a lower-case letter)
	//
	-   Renamed the main class `Program` to `GameFifteen`.
	-   Extracted each class in a separate file with a good name: `GameFifteen.cs`, `Board.cs`, `Point.cs`.
	-   …
2.  Reformatted the source code:
	-   Removed all unneeded empty lines, e.g. in the method `PlayGame()`.
	-   Inserted empty lines between the methods.
	-   Split the lines containing several statements into several simple lines, e.g.:
	
	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language.
	-   Put **{** and **}** after all conditionals and loops (when missing).
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**.
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.
	-   …
3.  Renamed variables:
	-   In class `Fifteen`: `number` to `numberOfMoves`.
	-   In `Main(string\[\] args)`: `g` to `gameFifteen`.
	
4.  Introduced constants:
	-   `GAME\_BOARD\_SIZE = 4`
	-   `SCORE\_BOARD\_SIZE = 5`. 
5.  Extracted the method `GenerateRandomGame()` from the method `Main()`.

6.  Introduced class `ScoreBoard` and moved all related functionality in it.

7.  Moved method `GenerateRandomNumber(int start, int end)` to separate class `RandomUtils`.

8.  …
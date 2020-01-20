<b><h2>Refactoring using Design Patterns</h2></b>

This repo contains the code for my workshop  Refactoring using Design Patterns

DPKata1 and DPKata2 contain an exercises for strategy design pattern

DPKataCORS contains an exercise for chain of responsability design pattern

Packages for NUnit are already installed

<b><h3>DPKata1</h3></b>

<b><h3>Steps</h3></b>

1. Have a look in BeforeDP folder
2. Run Tests from BeforeDP
3. Extract empty classes instead of methods from Program.cs
4. Add a strategy context
5. Extract data needed for strategy context
6. Set Strategy, use classes instead of the methods
7. Adapt tests
8. Add implementation from the methods to the corresponding classes
9. Re-run adapted tests

For steps 3-8, the refactoring is in AfterDP folder

<b><h3>DPKataSort</h3></b>

Sorting Strategies

<b><h2>DPCORS</h2></b>

Design a chain of responsibility for loggers
It should be a separated logger for console, file and e-mail
Warning & Error are logged in console
Email logger and Console logger handle functional errors and functional messages

Console Logger logs everything
E-mail logger functional errors
File logger warning and error


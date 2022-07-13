string square1 = "1";
string square2 = "2";
string square3 = "3";
string square4 = "4";
string square5 = "5";
string square6 = "6";
string square7 = "7";
string square8 = "8";
string square9 = "9";
string squareChoice;
bool gameOver = false;

void displayBoard ()
{
    Console.WriteLine($"{square1}|{square2}|{square3}");
    Console.WriteLine("-+-+-");
    Console.WriteLine($"{square4}|{square5}|{square6}");
    Console.WriteLine("-+-+-");
    Console.WriteLine($"{square7}|{square8}|{square9}");

    return;
}
void xTurn()
{
    Console.WriteLine("It is X's turn, please select a square (1-9): ");
    squareChoice = Console.ReadLine();
    squareLogic("X", squareChoice);
}

void oTurn()
{
    Console.WriteLine("It is O's turn, please select a square (1-9): ");
    squareChoice = Console.ReadLine();
    squareLogic("O", squareChoice);
}

void squareLogic(string playerSymbol, string squareChoice)
{
    if (squareChoice == "1")
    {
        square1 = playerSymbol;
    }
    if (squareChoice == "2")
    {
        square2 = playerSymbol;
    }
    if (squareChoice == "3")
    {
        square3 = playerSymbol;
    }
    if (squareChoice == "4")
    {
        square4 = playerSymbol;
    }
    if (squareChoice == "5")
    {
        square5 = playerSymbol;
    }
    if (squareChoice == "6")
    {
        square6 = playerSymbol;
    }
    if (squareChoice == "7")
    {
        square7 = playerSymbol;
    }
    if (squareChoice == "8")
    {
        square8 = playerSymbol;
    }
    if (squareChoice == "9")
    {
        square9 = playerSymbol;
    }
}

void isGameOver()
{
    if ((square1 == square2 && square2 == square3) || 
    (square4 == square5 && square5 == square6) ||
    (square7 == square8 && square8 == square9) ||
    (square1 == square4 && square4 == square7) ||
    (square2 == square5 && square5 == square8) ||
    (square3 == square6 && square6 == square9) ||
    (square1 == square5 && square5 == square9) ||
    (square3 == square5 && square5 == square7))
    {
        gameOver = true;
    }
}
void main()
{
    displayBoard();
    do
    {
        xTurn();
        displayBoard();
        isGameOver();
        if (gameOver == false)
        {
            oTurn();
            displayBoard();
        }
    } while (gameOver == false);
    Console.WriteLine("Congratulations! thanks for playing");
}

main();
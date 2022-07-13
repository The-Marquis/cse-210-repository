using System;

public class Player{
    public string guess = "";
    
    public Player(){
        
    }
   

    public void guessNewLetter(){
        Console.Write("\nGuess a letter [a-z]: ");
        guess = Console.ReadLine();
    }
}
using System;
public class Player{
    public string guess;
    public int score = 300;

    public Player(){

    }

    public void highOrLow(){
        Console.Write("Higher or lower? [h/l] ");
        guess = Console.ReadLine();
        
    }

    public void showPoints(){
        Console.WriteLine($"Your score is {score}");
    }

    
}
using System;
public class Card{
    
    public int value;
    public Card(){
        Random rnd = new Random();
        this.value = rnd.Next(1,13);

    }

    public void showCard(){
        Console.WriteLine($"The card is {value}");

    }

}


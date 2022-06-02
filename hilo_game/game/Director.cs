using System;
public class Director{

    bool isPlaying = true; 
    Player player1 = new Player();
    
    public Director(){
    }

    public void startGame(){
        while (isPlaying){
            Card card1 = new Card();
            card1.showCard();
            player1.highOrLow();
            Card card2 = new Card();
            card2.showCard();
            awardPoints(card1.value, card2.value, player1.guess);
            player1.showPoints();
            isGameOver();
        }
    } 
    public void awardPoints(int card1_value, int card2_value, string guess){
        string cardComparison = "";
        if (card1_value < card2_value){
            cardComparison = "h"; 
        }
        else if (card1_value > card2_value){
            cardComparison = "l";
        }

        if (cardComparison == guess){
            player1.score += 100;
        }
        else{
            player1.score -= 75;
        }

        
    }

    public void isGameOver(){
        if (player1.score <= 0){
            isPlaying = false;
        } 
        else{
            Console.Write("Play again? [y/n] ");
            string playerChoice = Console.ReadLine();
            if (playerChoice == "n"){
                isPlaying = false;
            }
        }
    }
}
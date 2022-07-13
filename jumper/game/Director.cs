using System;

namespace jumper.game{
    public class Director{
        public Player player = new Player();
        public Board  board = new Board();
        
        bool isPlaying = true;

        public Director(){

        }

        public void startGame(){
            board.selectWord();
            board.printBoard();
            do
            {
                getInputs();
                //Console.WriteLine($"you guessed {player.guess}");
                doUpdates();
                doOutputs();
                
            } while (isPlaying == true);

        }
        
        public void getInputs(){
            player.guessNewLetter();
        }

        
        public void doOutputs(){
            board.printBoard();
        }

        
        public void doUpdates(){
            board.updateBoard(player);
            isPlaying = board.isGameOver();
        }
    }
}
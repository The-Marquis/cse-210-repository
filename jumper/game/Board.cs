using System;

namespace jumper.game{
    public class Board{

        WordsList wordsList = new WordsList();


        List<string> boardList = new List<string>();

        List<string> wordList = new List<string>();
        List<string> correctGuesses = new List<string>();
        

        List<string> incorrectGuesses = new List<string>();
        public Board(){
            boardList.Add(" ___ ");
            boardList.Add("/   \\"); 
            boardList.Add(" ___ ");
            boardList.Add(" \\  /");
            boardList.Add("  \\/ ");
            for (int i = 0; i < 6; i++){
                correctGuesses.Add("_ ");
            }

        }

        public void selectWord(){
            string word = wordsList.chooseWord();
            string[] token = word.Split(",");
            foreach (string letter in token){
                wordList.Add(letter);
            }
        }
        public void printBoard(){
            foreach (string line in boardList){
                Console.WriteLine(line);
            }

            if (incorrectGuesses.Count != 5){
                Console.WriteLine("  O  ");
            }
            else {
                Console.WriteLine("\n  X  ");
            }

            Console.WriteLine(" /|\\ ");
            Console.WriteLine(" / \\ ");

            foreach (string letter in correctGuesses){
                Console.Write(letter);
            }
            Console.WriteLine(" ");
            ///foreach (string letter in wordList){
            ///    Console.WriteLine(letter);
            ///}
            Console.WriteLine(" ");
            Console.WriteLine("Incorrect guesses:\n");
            foreach (string letter in incorrectGuesses){
                Console.Write(letter + " ");
            }

        }

        public void updateBoard(Player player){
            int count = 0;
            bool guessedCorrectly = false;
            foreach (string letter in wordList){
                if (letter == player.guess){
                    correctGuesses[count] = letter;
                    guessedCorrectly = true;
                }
                count += 1;

            }

            if (guessedCorrectly == false){
                incorrectGuesses.Add(player.guess);
                boardList.RemoveAt(0);

                
            }
        }

        public bool isGameOver(){
            int count = 0;
            foreach (string letter in correctGuesses){
                
                if (letter == "_ "){
                    count += 1;
                }
            }
            if (count <=0 || incorrectGuesses.Count == 5){
                
                if (count <= 0){
                    Console.WriteLine("You win!");
                }
                else{
                    Console.WriteLine("You Lose!");
                }
                Console.WriteLine($"The word was: ");
                foreach (string letter in wordList){
                    Console.Write(letter);
                }
                return false;
            }
            else{
                return true;
            }
        }
    }
}
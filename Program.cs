using System.ComponentModel.Design;
using System.Diagnostics.Tracing;

namespace TheHangManGame
{
    internal class Program
    {
        static void Main(string[] args)

        {
            string[] wordList = { "Beautiful", "Clever", "Energetic", "graceful", "Happy", "intelligent", "Mysterious", "Radiant", "Spacious", "tranquil" };
            const int MIN_VALUE = 0;
            int maxValue = wordList.Length;

            Random randomWord = new Random();
            int wordIndex = randomWord.Next(MIN_VALUE, maxValue);//get random number between 0 and wordList.Length
            string wordToGuess = wordList[wordIndex].ToLower();//get the word with Index(position of the word inside of the wordList) and then covert it all to lower case
            const int EXTRA_TRIES = 3;
            int amountOfTries = wordToGuess.Length + EXTRA_TRIES;
            
            char guessLetter;
            List<char> temporaryGuessWord = new List<char>();//Keep tracking the corrent letter guessed by the user.

            //fill temporaryGuessWord with all the characters that have not been guessed.
            foreach (char letter in wordToGuess)
            {
                temporaryGuessWord.Add('_');
            }

            Console.WriteLine("Welcome to the hangman game!\nGuess the word.");
            Console.WriteLine($"Waste your chances, and you lose!\nYou have {amountOfTries} tries.");


            //Print the corrent characters that user is guessing - which is 0
            foreach (char letter in temporaryGuessWord)
            {
                Console.Write($"{letter} ");  // Print space except for the last iteration
            }
            Console.WriteLine();

            bool guessedWord = false; // Add a flag to track if the word is guessed

            for (int i = 0; i < amountOfTries; i++)//good for loop for repeating the guessing procedure
            {
                Console.WriteLine();
                Console.WriteLine("Enter a letter:");
                guessLetter = Console.ReadKey().KeyChar; // instead of reading strings, read character
                guessLetter = char.ToLower(guessLetter);
                //2 - implement checking if the guessing letter is in the secret word
                if (wordToGuess.Contains(guessLetter))
                {
                    Console.WriteLine();
                    Console.WriteLine("Good guessing");

                    for (int letterPosition = 0; letterPosition < wordToGuess.Length; letterPosition++)
                    {
                        if (wordToGuess[letterPosition] == guessLetter) //we found the position of the guessed letter 
                        {
                                temporaryGuessWord[letterPosition] = guessLetter; //we replaced "_" for the guessLetter...
                                continue;//... jump to the next index/position
                        }
                    }
                    foreach (char letter in temporaryGuessWord)
                    {
                        Console.Write(letter);
                    }
                }
                else 
                {
                    Console.WriteLine("\nWrong guess. \nTry again.");
                }
                    if (i >= amountOfTries - 1)
                {
                    Console.WriteLine("\nYou have reach to your max of attemps. ");
                    Console.WriteLine($"The word was: {wordToGuess}");
                }
                if (!temporaryGuessWord.Contains('_'))
                {
                    guessedWord = true;
                    Console.WriteLine("\nCongratulations! You guessed the word!!");
                    break; // The user guessed the entire word, no need to continue
                }
            } 
        }
    }
}
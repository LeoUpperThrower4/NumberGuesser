using System;

namespace NumberGuesser
{
    class Game
    {
        // Create a random number
        public static int numberToGuess = new Random().Next(101);
        public static int counter = 0;

        static void Main(string[] args)
        {
            //Asks for user name
            var usersName = AskName();
            // Say hi
            Console.WriteLine($"Welcome to the number guesser game, {usersName}");

            // Create a variable to store the guess
            var wasRightGuess = false;

            // Loop ultil right guess
            while (!wasRightGuess)
            {
                // Ask for the number
                Console.Write("Guess a number: ");
                // Asks for the guess then check if it's the right one
                wasRightGuess = CheckGuessedNumber(AskNumber());
            }
        }
        /// <summary>
        /// Asks the user for an integer, the guess. 
        /// </summary>
        /// <returns>Integer. The guessed number</returns>
        static int AskNumber()
        {
            // Create a var to know wheter the parse was successfull or not
            var succeded = int.TryParse(Console.ReadLine(), out var guessedNumber);
            // Loop while the contestant doesn't type an integer
            while (!succeded)
            {
                Console.WriteLine("Type an integer");
                succeded = int.TryParse(Console.ReadLine(), out guessedNumber);
            }

            // Logging the selected integer and returning it
            Console.WriteLine($"You guessed: {guessedNumber}");
            return guessedNumber;
        }
        /// <summary>
        /// Checks if the guessed number is the right one
        /// </summary>
        /// <returns>True if was the right guess, false if not</returns>
        static bool CheckGuessedNumber(int number)
        {
            // Checks wheter the guessed number was right or not
            if (number == numberToGuess)
            {
                // Congrats and return true
                Console.WriteLine("You are right!");
                counter++;
                Console.WriteLine($"You took {counter} tries");
                return true;
            }
            else
            {
                // Say is wrong and return false
                Console.WriteLine("You are wrong!");
                counter++;
                return false;
            }
        }
        /// <summary>
        /// Asks the user for it's name.
        /// </summary>
        /// <returns>String. User's name</returns>
        static string AskName()
        {
            // Asks the user name
            Console.Write("Hey there, what's your name? ");
            var usersName = Console.ReadLine();
            return usersName;
        }
    }
}

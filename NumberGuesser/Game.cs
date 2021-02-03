using System;

namespace NumberGuesser
{
    class Game
    {
        // Create a random number
        public static int numberToGuess = new Random().Next(101);
        public static int counter = 0;
        public static int difficulty = 0; // 0 - Easy; 1 - Hard

        static void Main(string[] args)
        {
            //Asks for user name
            var usersName = AskName();

            // Say hi
            Console.WriteLine($"Welcome to the number guesser game, {usersName}. You will have to guess a number between 0 and 100");

            //Asks the user for the difficulty
            difficulty = AskDifficulty();

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
            Console.Write("Press anything to exit");
            Console.ReadLine();
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
                // Add to the counter, congrats the user and return true
                counter++;
                Console.WriteLine($"You are right!. You took {counter} tries");
                return true;
            }
            else
            {
                //creates a var to store the output message
                var result = "You're wrong! ";
                //check the difficult level and give an according answer
                if (difficulty == 1)
                {
                    result += "Try again";
                }
                else
                {
                    result += (number > numberToGuess ? "it's lower" : "it's higher");
                }
                //Checks if the number is higher or lower and store a result string in a var saying it
                Console.WriteLine(result);
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
        /// <summary>
        /// Asks the user for the difficulty. 0 - Easy; 1 - Hard;
        /// </summary>
        /// <returns>Int. Difficulty level</returns>
        static int AskDifficulty()
        {
            // Asks for difficulty
            Console.Write("What's your desired difficulty? 0 - Easy; 1 - Hard ");
            // Try to parse the answer
            var succeded = int.TryParse(Console.ReadLine(), out var difficultuLevel);
            // Loop while don't get a valid level
            while (!succeded)
            {
                Console.WriteLine("Not a valid answer.");
                Console.WriteLine("What's your desired difficulty? 0 - Easy; 1 - Hard");
                //Try to parse the new text
                succeded = int.TryParse(Console.ReadLine(), out difficultuLevel);
            }
            // return the answer
            return difficultuLevel;
        }
    }
}

using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace NumbersGame
{
    // Olov Olsson Sundqvist .NET23
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcomes user to program
            Console.WriteLine("Välkommen!");
            // Start program in a loop to be able to restart program when it ends.
            while (true)
            {
                // Create a random number generator.
                Random random = new Random();
                // Creates int number that gets it value from user input later on.
                int number;
                // Creates string that gets value depending of the difficulty user chooses.
                string difficulty = "";
                // Create an int for users attempts that starts the count at 0.
                int attempt = 0;
                // Explaines to user what program does.
                Console.WriteLine("Låt oss spela ett spel. Jag tänker på ett nummer och du gissar vilket.");
                // While loop where user chooses difficulty of program.
                while (true)
                {
                    Console.WriteLine("\nVänligen välj svårighetsgrad genom att trycka på 1, 2 eller 3 för vald svårighetsgrad");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("1. Lätt - Ett tal mellan 1-10 och 5 gissningar");
                    Console.WriteLine("2. Medel - Ett tal mellan 1-20 och 5 gissningar");
                    Console.WriteLine("3. Svår - Ett tal mellan 1-50 och 4 gissningar");
                    Console.WriteLine("---------------------------------------------------\n");
                    // ConsoleKeyInfo + ReadKey so user wont have to press Enter after choosing 1, 2 or 3.
                    ConsoleKeyInfo difficultyInput = Console.ReadKey();
                    // If user press number 1 on numbers row or on the keypad, choose this option.
                    if (difficultyInput.Key == ConsoleKey.D1 || difficultyInput.Key == ConsoleKey.NumPad1)
                    {
                        // Makes a random number between 1-10
                        number = random.Next(1, 10);
                        difficulty = " 1-10."; 
                        break;
                    }
                    // If user press number 2 on numbers row or on the keypad, choose this option.
                    else if (difficultyInput.Key == ConsoleKey.D2 || difficultyInput.Key == ConsoleKey.NumPad2)
                    {
                        // Makes a random number between 1-20
                        number = random.Next(1, 20);
                        difficulty = " 1-20.";
                        break;
                    }
                    // If user press number 3 on numbers row or on the keypad, choose this option.
                    else if (difficultyInput.Key == ConsoleKey.D3 || difficultyInput.Key == ConsoleKey.NumPad3)
                    {
                        // Makes a random number between 1-50
                        number = random.Next(1, 50);
                        difficulty = " 1-50.";
                        // Adds the attempt count by 1 so you only gets 4 guesses.
                        attempt++;
                        break;
                    }
                    // If user press any other button, clear console, give error message and try again.
                    else
                            {
                        Console.Clear();
                        Console.WriteLine(">>>>Du har gjort ett felaktigt val. Försök igen.<<<<");
                    }
                }
                // Clears the console for design reasons.
                Console.Clear();
                // Asks the user to choose a number, but the range is depending on what choice they made before.
                Console.WriteLine("Då sätter vi igång. Vänligen gissa på ett nummer mellan " + difficulty);

                //Starting a while loop that breaks when user wins and answer is changed to false or when the five attempts are made without a right answer.
                while (true && attempt < 5)
                {
                    // Takes guess input from user and convert it to an int.
                    int guess = int.Parse(Console.ReadLine());
                    // See if user input is correct or not. If correct within five tries, exit program.
                    if (guess == number)
                    {
                        Console.WriteLine("\nWohoo! Grattis, du gissade rätt! Det var " + number + " jag tänkte på!");
                        break;
                    }
                    // If guess is to high, tell user its to high and remove one guess. If it is the last one tell the user its game over and exit program.
                    else if (guess > number)
                    {
                        WrongAnswersHigh();
                        attempt++;
                        string message = (attempt < 5) ? "Gissa igen" : $"\nSlut på gissningar! Jag tänkte på {number}!\n\nGAME OVER!";
                        Console.WriteLine(message);
                    }
                    // If guess is to low, tell user its to low and remove one guess. If it is the last one tell the user its game over and exit program.
                    else if (guess < number)
                    {
                        WrongAnswersLow();
                        attempt++;
                        string message = (attempt < 5) ? "Gissa igen" : $"\nSlut på gissningar! Jag tänkte på {number}!\n\nGAME OVER!";
                        Console.WriteLine(message);

                    }
                }
                // Ask user if it wants to play again.
                Console.WriteLine("\nTryck på 'Enter' för att spela igen, annars tryck på valfri tangent för att avsluta!");
                // Use readKey so user wont have to input anything and press 'enter' after its choice.
                ConsoleKeyInfo inputLetter = Console.ReadKey();
                // If user press 'Enter' the program (loop) will clear the console and restart.
                if (inputLetter.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                }
                // If user choose anything but 'Enter' the program will close.
                else
                {
                    Console.Clear();
                    Console.WriteLine("HEJ DÅ!");
                    Console.ReadKey();
                    break;
                }
            }
        }
        // Method that generates a random message to user if the guess is to low.
        public static void WrongAnswersLow()
        {
            Random random = new Random();
            int number = random.Next(1, 4);
            if (number == 1)
                Console.WriteLine("Tyvärr, du gissade för lågt.");
            else if (number == 2)
                Console.WriteLine("Ajdå, det var tyvärr för lågt.");
            else
                Console.WriteLine("Jag tänker på ett högre tal.");
        }
        // Method that generates a random message to user if the guess is to high.
        public static void WrongAnswersHigh()
        {
            Random random = new Random();
            int number = random.Next(1, 4);
            if (number == 1)
                Console.WriteLine("Tyvärr, du gissade för högt.");
            else if (number == 2)
                Console.WriteLine("Oj, det var tyvärr för högt.");
            else
                Console.WriteLine("Jag tänker på ett lägre tal.");
        }
    }
}
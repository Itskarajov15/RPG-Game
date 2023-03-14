using RPG.Characters;
using System.Runtime.CompilerServices;

namespace RPG
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();
            Console.Clear();
        }

        public static CharacterTypes CharacterSelectMenu()
        {
            Console.WriteLine("Options: ");

            var index = 1;

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"{index++}) {(CharacterTypes)i}");
            }

            int typeNumber = 0;
            Console.Write("Choose character type: ");

            try
            {
                typeNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid type. Your character will be Warrior.");
                typeNumber = 1;
            }

            return (CharacterTypes)typeNumber;
        }

        public static void OptionMenu(Character character)
        {
            Console.WriteLine("Would you like to buff up your stats before starting?");
            Console.Write("Response Y\\N: ");

            var response = Console.ReadLine();

            if (response.ToUpper() == "Y")
            {
                AddStats(character);
            }
        }

        private static void AddStats(Character character)
        {
            var pointsLeft = 3;

            while (pointsLeft > 0)
            {
                Console.WriteLine($"Points left: {pointsLeft}");

                (pointsLeft, var strengthPoints) = AddPoints(pointsLeft, nameof(character.Strength));

                character.Strength += strengthPoints;

                if (pointsLeft <= 0)
                {
                    Console.WriteLine("You have used all of your points.");
                    return;
                }

                Console.WriteLine($"Points left: {pointsLeft}");

                (pointsLeft, var agilityPoints) = AddPoints(pointsLeft, nameof(character.Agility));

                character.Agility += agilityPoints;

                if (pointsLeft <= 0)
                {
                    Console.WriteLine("You have used all of your points.");
                    return;
                }

                Console.WriteLine($"Points left: {pointsLeft}");

                (pointsLeft, var intelligencePoints) = AddPoints(pointsLeft, nameof(character.Intelligence));

                character.Intelligence += intelligencePoints;
            }
        }

        private static (int, int) AddPoints(int pointsLeft, string statName)
        {
            int points;

            while (true)
            {
                Console.Write($"{statName}: ");
                var inputPoints = Console.ReadLine();
                var isValid = int.TryParse(inputPoints, out points);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    continue;
                }

                if (pointsLeft < points)
                {
                    Console.WriteLine($"You do not have enough points. Points left: {pointsLeft}");
                    continue;
                }

                pointsLeft -= points;

                break;
            }

            return (pointsLeft, points);
        }
    }
}
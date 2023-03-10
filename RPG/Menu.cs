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

        public static string CharacterSelectMenu()
        {
            Console.WriteLine("Options: ");

            var index = 1;

            foreach (var type in (CharacterTypes[])Enum.GetValues(typeof(CharacterTypes)))
            {
                Console.WriteLine($"{index++}) {type}");
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

            return ((CharacterTypes)typeNumber).ToString();
        }

        public static void OptionMenu(Character character)
        {
            Console.WriteLine("Would you like to buff up your stats before starting?");
            Console.Write("Response Y\\N: ");

            var response = Console.ReadLine();

            if (response.ToUpper() == "Y")
            {
                BuffStats(character);
            }
        }

        private static void BuffStats(Character character)
        {
            var pointsLeft = 3;
            var strength = false;
            var agility = false;
            var intelligence = false;

            while (pointsLeft > 0)
            {
                if (!strength)
                {
                    Console.WriteLine("Strength");
                }

                if (!agility)
                {
                    Console.WriteLine("Agility");
                }

                if (!intelligence) 
                {
                    Console.WriteLine("Intelligence");
                }

                Console.Write("Select stat: ");
                var response = Console.ReadLine().ToUpper();

                var points = 0;

                try
                {
                    points = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid points.");
                    continue;
                }

                if (points > pointsLeft)
                {
                    Console.WriteLine("You do not have enough points");
                    continue;
                }

                if (response == "STRENGTH" && !strength)
                {
                    character.Strength += points;
                    strength = true;
                    pointsLeft -= points;
                }
                else if (response == "AGILITY" && !agility)
                {
                    character.Agility += points;
                    agility = true;
                    pointsLeft -= points;
                }
                else if (response == "INTELLIGENCE" && !intelligence)
                {
                    character.Intelligence += points;
                    intelligence = true;
                    pointsLeft -= points;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
        }
    }
}
using RPG.Characters;

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
                Console.WriteLine(ex.Message);
                return CharacterSelectMenu();
            }

            Console.Clear();
            return ((CharacterTypes)typeNumber).ToString();
        }

        //public void OptionMenu()
        //{
        //    Console.WriteLine("Would you like to buff up your stats before starting?");
        //    Console.Write("Y\\N: ");
        //    var response = Console.ReadLine();

        //    if (response == "Y")
        //    {
        //        var remainingPoints = 3;

        //        while (remainingPoints > 0)
        //        {
        //            Console.WriteLine("Strenght");
        //            Console.WriteLine("Agility");
        //            Console.WriteLine("Intelligence");
        //            Console.Write("Choose stats: ");
        //            var stat = Console.ReadLine();

        //            Console.Write("Enter points: ");
        //            var points = int.Parse(Console.ReadLine());

        //            if (points > remainingPoints)
        //            {
        //                Console.WriteLine("Invalid points");
        //                continue;
        //            }

        //            if (stat == "Strength")
        //            {
        //                character.Strength += points;
        //                Console.WriteLine($"Current Strength: {character.Strength}");
        //            }
        //            else if (stat == "Agility")
        //            {
        //                character.Agility += points;
        //                Console.WriteLine($"Current Agility: {character.Agility}");
        //            }
        //            else if (stat == "Intelligence")
        //            {
        //                character.Intelligence += points;
        //                Console.WriteLine($"Current Intelligence: {character.Intelligence}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid selected option. The stats of your character will not be buffed.");
        //                return;
        //            }

        //            remainingPoints -= points;
        //        }
        //    }
        //    else if (response == "N")
        //    {
        //        Console.WriteLine("Okay! The stats of your character will not be buffed.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid selected option. The stats of your character will not be buffed.");
        //    }

        //    Console.Clear();
        //}
    }
}
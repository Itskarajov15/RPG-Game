namespace RPG.Characters
{
    public static class CharacterFactory
    {
        public static Character CreateCharacter(string characterType)
        {
            if (characterType == "Warrior")
            {
                return new Warrior();
            }
            else if (characterType == "Archer")
            {
                return new Archer();
            }
            else if (characterType == "Mage")
            {
                return new Mage();
            }
            else if (characterType == "Monster")
            {
                var random = new Random();

                return new Monster(random.Next(1, 4), random.Next(1, 4), random.Next(1, 4), random.Next(0, 10), random.Next(0, 10));
            }
            else
            {
                return null;
            }
        }
    }
}
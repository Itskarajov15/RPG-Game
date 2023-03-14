namespace RPG.Characters
{
    public static class CharacterFactory
    {
        public static Character CreateCharacter(CharacterTypes characterType)
        {
            if (characterType == CharacterTypes.Warrior)
            {
                return new Warrior();
            }
            else if (characterType == CharacterTypes.Archer)
            {
                return new Archer();
            }
            else if (characterType == CharacterTypes.Mage)
            {
                return new Mage();
            }
            else
            {
                var random = new Random();

                return new Monster(random.Next(1, 4), random.Next(1, 4), random.Next(1, 4), random.Next(0, 10), random.Next(0, 10));
            }
        }
    }
}
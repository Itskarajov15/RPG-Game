namespace RPG.Characters
{
    public abstract class Character
    {
        public Character(
            int strength,
            int intelligence,
            int agility,
            int range,
            int row,
            int col)
        {
            this.Strength = strength;
            this.Intelligence = intelligence;
            this.Agility = agility;
            this.Range = range;
            this.Row = row;
            this.Col = col;

            Setup();
        }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }

        public int Range { get; set; }

        public char Symbol { get; protected set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public void Setup()
        {
            Health = Strength * 5;
            Mana = Intelligence * 3;
            Damage = Agility * 2;
        }
    }
}
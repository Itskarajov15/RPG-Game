namespace RPG.Data.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public char Symbol { get; set; }

        public string Type { get; set; } = null!;

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Range { get; set; }
    }
}
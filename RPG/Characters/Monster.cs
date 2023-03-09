namespace RPG.Characters
{
    public class Monster : Character
    {
        public Monster(
            int strength,
            int intelligence,
            int agility,
            int row,
            int col) 
            : base(strength, intelligence, agility, 1, row, col)
        {
            this.Symbol = 'M';
        }
    }
}
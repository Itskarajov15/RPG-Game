using RPG.Characters;

namespace RPG
{
    public class Game
    {
        private char[,] field;
        private List<Character> monsters;

        public Game(Character character)
        {
            this.Character = character;
            this.field = new char[10, 10];
            this.monsters = new();
        }

        public Character Character { get; set; }

        public void Start()
        {
            PopulateField();
            InGame();
        }

        private void InGame()
        {
            while (this.Character.Health > 0)
            {
                SpawnMonster();

                Console.WriteLine($"Health: {this.Character.Health}  Mana: {this.Character.Mana}");
                PrintField();

                Console.WriteLine(@"Attack");
                Console.WriteLine("Move");
                Console.Write("Choose action: ");

                var action = Console.ReadLine();

                switch (action.ToUpper())
                {
                    case "ATTACK":
                        AttackController();
                        break;
                    case "MOVE":
                        MoveController();
                        break;
                    default:
                        Console.WriteLine("Invalid action");
                        break;
                }

                if (this.Character.Health <= 0)
                {
                    break;
                }

                MoveMonsters();
            }

            Console.WriteLine("You have been killed. :(");
        }

        private void AttackController()
        {
            var monstersInRange = FindTargets();

            if (monstersInRange.Count > 0)
            {
                Console.WriteLine("Select a target: ");

                for (int i = 0; i < monstersInRange.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) target with remaining blood {monstersInRange[i].Health}");
                }

                try
                {
                    var target = int.Parse(Console.ReadLine());

                    if (target < 1 || target > monstersInRange.Count + 1)
                    {
                        Console.WriteLine("Invalid target. You will not be able to attack this round");
                        return;
                    }

                    var monster = monstersInRange[target - 1];

                    Attack(this.Character, monster);
                    if (monstersInRange[target - 1].Health <= 0)
                    {
                        this.monsters.Remove(monstersInRange[target - 1]);
                        this.field[monster.Row, monster.Col] = '▒';
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid target. You will not be able to attack this round");
                    return;
                }
            }
            else
            {
                Console.WriteLine("There are no targets in range.");
            }
        }

        private void Attack(Character attacker, Character target)
        {
            target.Health -= attacker.Damage;
        }

        private void MoveController()
        {
            var command = Console.ReadLine();

            switch (command.ToUpper())
            {
                case "W":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row - 1, this.Character.Col);
                    break;
                case "S":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row + 1, this.Character.Col);
                    break;
                case "D":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row, this.Character.Col + 1);
                    break;
                case "A":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row, this.Character.Col - 1);
                    break;
                case "E":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row - 1, this.Character.Col + 1);
                    break;
                case "X":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row + 1, this.Character.Col + 1);
                    break;
                case "Q":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row - 1, this.Character.Col - 1);
                    break;
                case "Z":
                    (this.Character.Row, this.Character.Col) = MoveCharacter(this.Character.Row, this.Character.Col, this.Character.Row + 1, this.Character.Col - 1);
                    break;
                default:
                    Console.WriteLine($"The command {command} is invalid. Please enter a valid command.");
                    break;
            }
        }

        private void SpawnMonster()
        {
            var monster = CharacterFactory.CreateCharacter(CharacterTypes.Monster);

            if (this.field[monster.Row, monster.Col] != '▒')
            {
                var rand = new Random();

                while (this.field[monster.Row, monster.Col] != '▒')
                {
                    monster.Row = rand.Next(0, 10);
                    monster.Col = rand.Next(0, 10);
                }
            }

            this.monsters.Add(monster);
            this.field[monster.Row, monster.Col] = monster.Symbol;
        }

        private void PrintField()
        {
            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    Console.Write(this.field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private void MoveMonsters()
        {
            foreach (var monster in this.monsters)
            {
                var row = monster.Row;
                var col = monster.Col;

                var nextRow = Math.Sign(this.Character.Row - row);
                var nextCol = Math.Sign(this.Character.Col - col);

                if (IsValid(row + nextRow, col + nextCol) && this.field[row + nextRow, col + nextCol] == '▒')
                {
                    this.field[row, col] = '▒';

                    monster.Row += nextRow;
                    monster.Col += nextCol;

                    this.field[monster.Row, monster.Col] = 'M';
                }
                else
                {
                    int distance = FindDistance(monster.Row, monster.Col, this.Character.Row, this.Character.Col);

                    if (distance <= monster.Range)
                    {
                        Attack(monster, this.Character);
                    }
                }
            }
        }

        private void PopulateField()
        {
            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    this.field[row, col] = '▒';
                }
            }

            this.field[this.Character.Row, this.Character.Col] = this.Character.Symbol;
        }

        private (int currRow, int currCol) MoveCharacter(int oldRow, int oldCol, int row, int col)
        {
            if (!IsValid(row, col))
            {
                Console.WriteLine("You cannot exit the field!");
                return (oldRow, oldCol);
            }

            if (this.field[row, col] != '▒')
            {
                Console.WriteLine("Invalid step.");
                return (oldRow, oldCol);
            }

            this.field[oldRow, oldCol] = '▒';
            this.field[row, col] = this.Character.Symbol;

            return (row, col);
        }

        private bool IsValid(int row, int col)
            => row >= 0 && row < this.field.GetLength(0) && col >= 0 && col < this.field.GetLength(1);

        private List<Character> FindTargets()
        {
            var monstersInRange = new List<Character>();

            foreach (var monster in this.monsters)
            {
                int distance = FindDistance(this.Character.Row, this.Character.Col, monster.Row, monster.Col);

                if (distance <= this.Character.Range)
                {
                    monstersInRange.Add(monster);
                }
            }

            return monstersInRange;
        }

        private int FindDistance(int attackerRow, int attackerCol, int targetRow, int targetCol)
            => Math.Max(Math.Abs(attackerRow - targetRow), Math.Abs(attackerCol - targetCol));
    }
}
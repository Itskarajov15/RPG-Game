using RPG;
using RPG.Characters;
using RPG.Data;
using RPG.Data.Models;

Menu.MainMenu();

var dbContext = new RPGDbContext();

var characterType = Menu.CharacterSelectMenu();
var character = CharacterFactory.CreateCharacter(characterType);

Menu.OptionMenu(character);

var game = new Game(character);

var hero = new Hero()
{
    Health = character.Health,
    Agility = character.Agility,
    CreatedOn = DateTime.Now,
    Damage = character.Damage,
    Intelligence = character.Intelligence,
    Mana = character.Mana,
    Range = character.Range,
    Strength = character.Strength,
    Symbol = character.Symbol,
    Type = character.GetType().Name
};

await dbContext.AddAsync(hero);
await dbContext.SaveChangesAsync();

game.Start();
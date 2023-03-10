using RPG;

Menu.MainMenu();

var characterType = Menu.CharacterSelectMenu();
var character = CharacterFactory.CreateCharacter(characterType);

Menu.OptionMenu(character);

var game = new Game(character);
game.Start();
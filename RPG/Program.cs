using RPG;

Menu.MainMenu();

var characterType = Menu.CharacterSelectMenu();
var character = CharacterFactory.CreateCharacter(characterType);

var game = new Game(character);
game.Start();
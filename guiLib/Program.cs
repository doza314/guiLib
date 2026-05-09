using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

var game = new StateMachine("TESTING", new Vector2u(1280, 720), Color.Blue, "start");

var startMenu = new Menu("start");
startMenu.addButton(new Button(new Vector2f(100, 100), new Vector2f(150, 50), "button"));

game.AddMenu(startMenu);
game.setExit("button");
game.Run();


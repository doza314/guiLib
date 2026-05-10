using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

var game = new StateMachine("TESTING", new Vector2u(960, 540), Color.Blue, "start");

var startMenu = new Menu("start");
startMenu.addButton(new Button(new Vector2f(100, 100), new Vector2f(150, 50), "button"));

var nextMenu = new Menu("button");
nextMenu.addButton(new Button(new Vector2f(150, 300), new  Vector2f(150, 50), "button1"));
nextMenu.setBgColor(Color.Green);

game.AddMenu(startMenu);
game.AddMenu(nextMenu);

game.setExit("button1");
game.Run();


using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

StateMachine game = new StateMachine("TESTING", new Vector2u(1280, 720), Color.Blue, "start");

game.setExit("start");
Menu startMenu = new Menu("start");

startMenu.addButton(new Button(new Vector2f(100, 100), new Vector2f(150, 50), "button"));

game.AddMenu(startMenu);

game.Run();


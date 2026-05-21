using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

var game = new StateMachine("TESTING", new Vector2u(960, 540), Color.Blue, "start");

var startMenu = new Menu("start");
var butt1 = new Button(new Vector2f(100, 100), "nextMenu");
butt1.textureFileOverride("button");
startMenu.addButton(butt1);

var nextMenu = new Menu("nextMenu");
var butt2 = new Button(new Vector2f(150, 300), "exit");
var butt3 = new Button(new Vector2f(400, 300),  "start");

butt2.textureFileOverride("button");
butt3.textureFileOverride("button");

nextMenu.addButton(butt2);
nextMenu.addButton(butt3);

nextMenu.setBgColor(Color.Green);

game.addMenu(startMenu);
game.addMenu(nextMenu);

game.setExit("exit");
game.Run();


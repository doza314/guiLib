using SFML.Graphics;
using SFML.System;
using SFML.Window;
using guiLib;

var startMenu = new Menu("start");
var nextMenu = new Menu("nextMenu");

var game = new StateMachine(startMenu, "game", new Vector2u(960, 540), Color.Blue);



var butt1 = new Button(() => game.navigate(nextMenu), new Vector2f(100, 100), "button"); 
startMenu.addButton(butt1);

var butt2 = new Button(() => game.navigate(startMenu),new Vector2f(150, 300), "button");
var butt3 = new Button(() => game.close(), new Vector2f(400, 300), "button");

nextMenu.addButton(butt2);
nextMenu.addButton(butt3);

nextMenu.setBgColor(Color.Green);

game.run();


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Escape_from_Basement.Game.Casting;
using Escape_from_Basement.Game.Directing;
using Escape_from_Basement.Game.Services;

namespace Escape_from_Basement{
    class Program
    {
        private static int FRAME_RATE = 20;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Escape From Basement";
        private static Color WHITE = new Color(255, 255, 255);
        private static Color GOLD = new Color(255, 215, 0);
        private static int DEFAULT_ARTIFACTS = 20;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args){

            Entities keys = new Entities();


            // make player
            Player player = new Player();
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X / 2,MAX_Y / 2));
            player.SetText("YOU");


            // make door and locks 
            Door mainDoor = new Door(MAX_X / 2, MAX_Y / 5);
            mainDoor.SetFontSize(FONT_SIZE);
            mainDoor.SetColor(WHITE);
            mainDoor.SetPosition(new Point(MAX_X / 2,MAX_Y / 5));
            mainDoor.SetText("DOOR");

            // make keys
            Key key1 = new Key();
            key1.SetFontSize(FONT_SIZE);
            key1.SetColor(GOLD);
            key1.SetPosition(new Point(MAX_X / 2,MAX_Y - (MAX_Y / 5)));
            key1.SetText("KEY");

            Key key2 = new Key();
            key2.SetFontSize(FONT_SIZE);
            key2.SetColor(GOLD);
            key2.SetPosition(new Point(MAX_X - (MAX_Y/ 5),MAX_Y / 2));
            key2.SetText("KEY");
            
            Key key3 = new Key();
            key3.SetFontSize(FONT_SIZE);
            key3.SetColor(GOLD);
            key3.SetPosition(new Point((MAX_X / 5),MAX_Y - (MAX_Y / 5)));
            key3.SetText("KEY");


            keys.AddActor("Key", key1);
            keys.AddActor("Key", key2);
            keys.AddActor("Key", key3);

            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(keys, player, mainDoor);
        }
    }
}
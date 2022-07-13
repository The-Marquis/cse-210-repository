using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cycle.Game.Casting;
using Cycle.Game.Directing;
using Cycle.Game.Services;

namespace Cycle{
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
        private static Color GREEN = new Color(0, 255, 0);
        private static Color RED = new Color(255, 0, 0);
        private static int DEFAULT_ARTIFACTS = 20;

        
        static void Main(string[] args){
            //  create banners

            Banner banner1 = new Banner();
            banner1.SetPosition(new Point(0,0));
            banner1.SetText("Player 1: ");

            Banner banner2 = new Banner();
            banner2.SetPosition(new Point(MAX_X - 90,0));
            banner2.SetText("Player 2:  ");
            
            // create players
            Player player1 = new Player();
            player1.SetColor(RED);
            player1.SetText("@");
            player1.SetPosition(new Point(MAX_X/5, MAX_Y/5));
            Entities tail1 = new Entities();

            for (int i=0; i<5; i++){
                Tail tailSegment = new Tail();
                tailSegment.SetText("#");
                tailSegment.SetColor(RED);
                tailSegment.SetPosition(new Point(player1.GetPosition().GetX(), player1.GetPosition().GetY() + (15*i)));
                tail1.AddActor("Tail Segment", tailSegment);
            }


            Player player2 = new Player();
            player2.SetColor(GREEN);
            player2.SetText("@");
            player2.SetPosition(new Point(MAX_X - (MAX_X/5), MAX_Y/5));
            Entities tail2 = new Entities();

            for (int i=0; i<6; i++){

                Tail tailSegment = new Tail();
                tailSegment.SetText("#");
                tailSegment.SetColor(GREEN);
                tailSegment.SetPosition(new Point(player2.GetPosition().GetX(), player2.GetPosition().GetY() + (15*i)));
                tail2.AddActor("Tail Segment", tailSegment);
            }

            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(player1, player2, tail1, tail2, banner1, banner2);
        }
    }
}

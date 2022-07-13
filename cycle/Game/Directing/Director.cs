using System;
using Cycle.Game.Casting;
using Cycle.Game.Services;

namespace Cycle.Game.Directing{
    public class Director{

        private KeyboardService keyboardService = null;
        private VideoService videoService = null;

        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        public void StartGame(Player player1, Player player2, Entities tail1, 
        Entities tail2, Banner banner1, Banner banner2){

            videoService.OpenWindow();
            while (videoService.IsWindowOpen()){

                GetInputs(player1, player2, tail1, tail2);
                DoUpdates(player1, player2, tail1, tail2, banner1, banner2);
                DoOutputs(player1, player2, tail1, tail2, banner1, banner2);
            }
            videoService.CloseWindow();

        }

        // Get Inputs
        public void GetInputs(Player player1, Player player2, Entities tail1, Entities tail2){
            List<Actor> tail1List = tail1.GetAllActors();
            List<Actor> tail2List = tail2.GetAllActors();

            
            Point velocity1 = keyboardService.GetDirection("player1");
            if (velocity1.GetX() == 0 && velocity1.GetY() == 0){
                Point newVelocity1 = new Point(
                    player1.GetPosition().GetX() - tail1List.Last().GetPosition().GetX(),
                    player1.GetPosition().GetY() - tail1List.Last().GetPosition().GetY());
                player1.SetVelocity(newVelocity1);
                
            }
            else{
                player1.SetVelocity(velocity1);
            }
            
            Point velocity2 = keyboardService.GetDirection("player2");
            if (velocity2.GetX() == 0 && velocity2.GetY() == 0){
                Point newVelocity2 = new Point(
                    player2.GetPosition().GetX() -tail2List.Last().GetPosition().GetX(),
                    player2.GetPosition().GetY() -tail2List.Last().GetPosition().GetY());
                player2.SetVelocity(newVelocity2);
                
            }
            else{
                player2.SetVelocity(velocity2);
            }
            

        }

        // Do Updates
        // check if a player has run into a tail
        // if so, give points and reset game.
        // if not, update position and add tail segment
        public void DoUpdates(Player player1, Player player2, Entities tail1, 
        Entities tail2, Banner banner1, Banner banner2){
            List<Actor> tail1List = tail1.GetAllActors();
            List<Actor> tail2List = tail2.GetAllActors();
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            
            foreach (Actor Segment in tail2List){
                if (player1.GetPosition().Equals(Segment.GetPosition())){
                    player2.SetPoints(1);
                    ResetGame(player1, player2, tail1, tail2);
                    return;
                }
            }

            foreach (Actor Segment in tail1List){
                if (player2.GetPosition().Equals(Segment.GetPosition())){
                    player1.SetPoints(1);
                    ResetGame(player1, player2, tail1, tail2);
                    return;
                }
            }

            //add tails
            Tail tail1Segment = new Tail();

            tail1Segment.SetText("#");
            tail1Segment.SetPosition(new Point(player1.GetPosition().GetX(), player1.GetPosition().GetY()));
            tail1Segment.SetColor(new Color(255, 0, 0));
            tail1.AddActor("Tail Segment", tail1Segment);

            Tail tail2Segment = new Tail();

            tail2Segment.SetText("#");
            tail2Segment.SetPosition(new Point(player2.GetPosition().GetX(), player2.GetPosition().GetY()));
            tail2Segment.SetColor(new Color(0, 255, 0));
            tail2.AddActor("Tail Segment", tail2Segment);

            // update banners
            banner1.SetText($"Player 1: {player1.GetPoints()}");
            banner2.SetText($"Player 2: {player2.GetPoints()}");
            

            player1.MoveNext(maxX, maxY);
            player2.MoveNext(maxX, maxY);
        }

        // Do Outputs
        public void DoOutputs(Player player1, Player player2, Entities tail1, 
        Entities tail2, Banner banner1, Banner banner2){
            List<Actor> tail1List = tail1.GetAllActors();
            List<Actor> tail2List = tail2.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActor(banner1);
            videoService.DrawActor(banner2);
            videoService.DrawActor(player1);
            videoService.DrawActors(tail1List);
            videoService.DrawActor(player2);
            videoService.DrawActors(tail2List);
            videoService.FlushBuffer();
        }

        // Reset Game
        public void ResetGame(Player player1, Player player2, Entities tail1, Entities tail2){
            
            int MAX_X = videoService.GetWidth();
            int MAX_Y = videoService.GetHeight();
            List<Actor> tail1List = tail1.GetAllActors();
            List<Actor> tail2List = tail2.GetAllActors();

            // reset player 1
            player1.SetPosition(new Point(MAX_X/5, MAX_Y/5));
            foreach (Actor segment in tail1List){
                tail1.RemoveActor("Tail Segment", segment);
            }

            for (int i=0; i<5; i++){
                Tail tailSegment = new Tail();
                tailSegment.SetText("#");
                tailSegment.SetColor(new Color(255, 0, 0));
                tailSegment.SetPosition(new Point(player1.GetPosition().GetX(), player1.GetPosition().GetY() + (15*i)));
                tail1.AddActor("Tail Segment", tailSegment);
            }
            
            // reset player 2
            player2.SetPosition(new Point(MAX_X- (MAX_X/5), MAX_Y/5));
            foreach (Actor segment in tail2List){
                tail2.RemoveActor("Tail Segment", segment);
            }

            for (int i=1; i<6; i++){

                Tail tailSegment = new Tail();
                tailSegment.SetText("#");
                tailSegment.SetColor(new Color(0, 255, 0));
                tailSegment.SetPosition(new Point(player2.GetPosition().GetX(), player2.GetPosition().GetY() + (15*i)));
                tail2.AddActor("Tail Segment", tailSegment);
            }
        }
    }
}
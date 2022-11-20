using System;
using Escape_from_Basement.Game.Casting;
using Escape_from_Basement.Game.Services;

namespace Escape_from_Basement.Game.Directing{
    // director:responsibilities:
    // run game
    // update player location
    // retrieve keys from player
    public class Director{

        private KeyboardService keyboardService = null;
        private VideoService videoService = null;

        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }




        public void StartGame(Entities entities, Player player, Door mainDoor)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(entities, player, mainDoor);
                DoUpdates(entities, player, mainDoor);
                DoOutputs(entities, player, mainDoor);
            }
            videoService.CloseWindow();
        }

        //get inputs:
        //get player velocity

        public void GetInputs(Entities keys, Player player, Door mainDoor){
            
            Point velocity = keyboardService.GetDirection();
            player.SetVelocity(velocity);
        }

        // Do updates
        // update player position
        // check if player found key
        // check if player depositing found key

        

        public void DoUpdates(Entities keys, Player player, Door mainDoor){

                List<Actor> keysList = keys.GetAllActors();
                int maxX = videoService.GetWidth();
                int maxY = videoService.GetHeight();
                foreach (Actor key in keysList)
                    if (player.GetPosition().Equals(key.GetPosition())){
                        player.setKeys(1);
                        keys.RemoveActor("Key", key);
                    }
                
                Entities locks = mainDoor.getLocks();
                List<Actor> locksList = locks.GetActors("Lock"); 
                foreach (Actor doorLock in locksList){
                    if (player.GetPosition().Equals(doorLock.GetPosition()) && player.getKeys() > 0){
                        player.setKeys(-1);
                        locks.RemoveActor("Lock", doorLock);

                    }
                }
                if (locksList.Count() <= 0){
                    mainDoor.SetText("OPEN");
                }
                player.MoveNext(maxX, maxY);



        }

        // Do Outputs
        // 

        public void DoOutputs(Entities keys, Player player, Door mainDoor){
            
            List<Actor> keysList = keys.GetAllActors();
            List<Actor> locksList = mainDoor.getLocks().GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(keysList);
            videoService.DrawActor(player);
            videoService.DrawActor(mainDoor);
            videoService.DrawActors(locksList);
            videoService.FlushBuffer();
        }


    }
}
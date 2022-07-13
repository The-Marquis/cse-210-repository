using System.Collections.Generic;

namespace Cycle.Game.Casting{
    
    public class Player : Actor{
        private int points = 0;


        public void SetPoints(int points){
            this.points += points;
        }

        public int GetPoints(){
            return points;
        }
        
    }
}
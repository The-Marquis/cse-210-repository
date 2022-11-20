using System;

namespace Escape_from_Basement.Game.Casting{

    public class Player : Actor{

        private string text = "YOU";
        private int keys = 0;

        public void setKeys(int keys){
            this.keys += keys; 
        }
        
        public int getKeys(){
            return keys;
        }

    }
}
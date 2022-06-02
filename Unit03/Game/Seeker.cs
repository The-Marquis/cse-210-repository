using System;


namespace Unit03.Game
{
    // TODO: Implement the Seeker class as follows...

    // 1) Add the class declaration. Use the following class comment.
    public class Seeker{

        private int location = 0;
        /// <summary>
        /// <para>The person looking for the Hider.</para>
        /// <para>
        /// The responsibility of a Seeker is to keep track of its location.
        /// </para>
        /// </summary>
    

    // 2) Create the class constructor. Use the following method comment.
        public Seeker(){
            location = 0;

        }    
        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
       

    // 3) Create the GetLocation() method. Use the following method comment.
        public int GetLocation(){
            return location;
        }
        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location as an int.</returns>
        

    // 4) Create the MoveLocation(int location) method. Use the following method comment.
        public void MoveLocation(int location){
            this.location = location;
        }
        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="location">The given location.</param>
    }
    
}
using System;
using Escape_from_Basement.Game.Services;

namespace Escape_from_Basement.Game.Casting{

    public class Door: Actor{
        private string text = "Door";

        private Lock lock1 = new Lock();
        private Lock lock2 = new Lock();
        private Lock lock3 = new Lock();
        Entities locks = new Entities();

        public Door(int x, int y){
            lock1.SetText("LOCK");
            lock2.SetText("LOCK");
            lock3.SetText("LOCK");

            lock1.SetPosition(new Point(x - 60,y + 15));
            lock2.SetPosition(new Point(x, y + 15));
            lock3.SetPosition(new Point(x + 60, y +15));

            locks.AddActor("Lock", lock1);
            locks.AddActor("Lock", lock2);
            locks.AddActor("Lock", lock3);
            
        }


        public Entities getLocks(){
            return locks;
        }

        
        
    }

}
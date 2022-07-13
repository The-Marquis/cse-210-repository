using System;

namespace jumper.game{
    public class WordsList {
        Random rnd = new Random();
        List<string> words = new List<string>();
        
        
        public WordsList(){
            
            words.Add("a,b,r,o,a,d");
            words.Add("a,c,r,o,s,s");
            words.Add("a,c,t,i,v,e");
            words.Add("a,d,v,i,s,e");
            words.Add("a,f,r,a,i,d");
            words.Add("a,l,m,o,s,t");
            words.Add("a,n,i,m,a,l");
            words.Add("a,n,y,o,n,e");
            words.Add("a,p,p,e,a,r");
            words.Add("a,r,t,i,s,t");
            words.Add("a,s,s,i,s,t");
            words.Add("a,t,t,e,n,d");
            words.Add("a,v,e,n,u,e");
            words.Add("b,a,t,t,l,e");
            words.Add("b,e,c,o,m,e");
            words.Add("b,e,h,i,n,d");
            words.Add("b,e,r,l,i,n");
            words.Add("b,i,s,h,o,p");
            words.Add("b,o,t,t,o,m");
            words.Add("b,r,e,a,t,h");
            words.Add("b,r,o,k,e,n");
            words.Add("b,u,r,e,a,u");
            words.Add("c,a,n,c,e,r");
            words.Add("c,a,r,e,e,r");
            words.Add("c,a,u,g,h,t");
            words.Add("c,h,a,n,c,e");
            words.Add("c,h,o,i,c,e");
            words.Add("c,h,u,r,c,h");
            words.Add("c,l,o,s,e,d");
            words.Add("c,o,l,u,m,n");
            words.Add("c,o,m,m,o,n");
        }

        public string chooseWord(){
            int wordIndex = rnd.Next(0,30);
            return words[wordIndex];

        }

    }
}
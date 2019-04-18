using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClass
{//Constructor
   public class Multiplication
    {
        public int num;

        public Multiplication(int n)
        {
            num = n;
        }
        //Method
        public void setNum(int newN)
        {
            
            newN=newN* 10 ;
            num = newN;
        }
    }
}

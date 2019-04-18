namespace ConsoleAppClass
{
    using System;

    internal class Program
    {
        internal static void Main(string[] args)
        {

            int e = 0;
            //Window size
            Console.WindowHeight = 10;
            Console.WindowWidth = 20;
            //Call Class
            Person per = new Person(" ");
            //Enter Name
            Console.WriteLine("Enter name");
            per.setNa(Console.ReadLine());
            Console.WriteLine(per.name);
            //Call another Class
            Multiplication mul = new Multiplication(  e);

            Console.WriteLine("Enter num");
            e = Convert.ToInt32(Console.ReadLine());
            mul.setNum(e);
           Console.WriteLine(mul.num);
                
    
          //Console out
            Console.WriteLine("Hello");
            //Exit

            Console.WriteLine("Type any key to exit ");
            Console.ReadKey();
        }
    }
}

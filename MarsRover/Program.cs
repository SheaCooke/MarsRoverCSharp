using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Rover myRover = new Rover(20);
            //Console.WriteLine(myRover.ToString());

            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER") };

            string i = "";

            foreach (var j in commands)
            {
                i += j.NewMode;
            }

            Console.WriteLine(i);



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDate.ConsoleApp
{
    class Program
    {
       // private static DatabaseState _DatabaseState;

        static void Main(string[] args)
        {
            Console.WriteLine("'g' to Get Date; 'gc' to Garbage Collect;  'x' to Exit");
            var command = "";

            while (command != "x")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "g":
                        GetDate();
                        break;
                    case "gc":
                        GC.Collect();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetDate()
        {
            using (var databaseState = new DatabaseState())
            {
                Console.WriteLine(databaseState.GetDate());
            }
        }
    }
}

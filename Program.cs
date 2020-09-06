using System;

namespace PascalsTriangle
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine($"\n{new PascalTriangle(GetUserInput())}");
            }
            catch (NotSupportedException exc)
            {
                Console.Clear();
                Console.WriteLine($"\nCongrats, you found an Easter Egg!\n\n{exc.Message}");
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n{exc.GetType()}: {exc.Message}");
            }
        }

        static int GetUserInput()
        {
            Console.Write("Howdy!\n\nInput the number of rows of the Pascal's Triangle\n> Your choice: ");
            return int.Parse(Console.ReadLine());
        }
    }
}

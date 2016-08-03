using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ConsoleHelper.SetConsoleFont();

            var board = new Board();

            do
            {
                Console.Clear();
                Console.WriteLine(board);
                Console.Write("Input your move ({0}) :", Char.ConvertFromUtf32(0x51));
                var move = Console.ReadLine();

                try
                {
                    board.DoMove(move);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}

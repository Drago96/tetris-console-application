using System;
using Tetris.Services.Contracts;

namespace Tetris.Services.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void PrintEmptyLine()
        {
            Console.WriteLine();
        }

        public void Print(string message)
        {
            Console.Write(message);
        }

        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintOnPosition(int row, int col, string message)
        {
            Console.SetCursorPosition(row, col);
            Console.WriteLine(message);
        }
    }
}

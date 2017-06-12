using System;
using Tetris.Services.Contracts;

namespace Tetris.Services.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}

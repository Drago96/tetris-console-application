namespace Tetris.Services.IO
{
    using System;
    using Tetris.Services.Contracts;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
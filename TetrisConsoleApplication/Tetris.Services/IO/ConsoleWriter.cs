using System;
using Tetris.Services.Contracts;

namespace Tetris.Services.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}

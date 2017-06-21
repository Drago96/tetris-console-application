namespace Tetris.Services.IO
{
    using System;

    public static class ConsoleWriter 
    {
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void Write(string message)
        {
            Console.Write(message);
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

       public static void WriteOnPosition(int row, int col, string message)
       {
           Console.SetCursorPosition(row, col);
           Console.Write(message);
       }

       public static void WriteLineOnPosition(int row, int col, string message)
       {
           Console.SetCursorPosition(row, col);
           Console.WriteLine(message);
       }
    }
}
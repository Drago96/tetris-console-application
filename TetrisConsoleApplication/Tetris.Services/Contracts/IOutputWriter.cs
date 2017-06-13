namespace Tetris.Services.Contracts
{
    public interface IOutputWriter
    {
        void PrintEmptyLine();

        void Print(string message);

        void PrintLine(string message);

        void PrintOnPosition(int row, int col, string message);

        void PrintLineOnPosition(int row, int col, string message);
    }
}

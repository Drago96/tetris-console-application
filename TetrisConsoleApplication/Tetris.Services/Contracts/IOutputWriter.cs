namespace Tetris.Services.Contracts
{
    public interface IOutputWriter
    {
        void Print(string message);

        void PrintLine(string message);
    }
}

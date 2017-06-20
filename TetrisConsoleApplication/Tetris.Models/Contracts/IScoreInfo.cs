namespace Tetris.Models.Contracts
{
    interface IScoreInfo
    {
        int Level { get; set; }

        long Score { get; set; }

        int LinesCleared { get; set; }
    }
}
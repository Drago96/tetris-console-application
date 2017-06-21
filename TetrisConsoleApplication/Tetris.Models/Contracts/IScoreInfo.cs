namespace Tetris.Models.Contracts
{
    interface IScoreInfo
    {
        int Level { get; set; }

        long Score { get; set; }

        int LinesCleared { get; set; }

        int ScorePerLine { get; set; }

        int LinesPerLevel { get; set; }
    }
}
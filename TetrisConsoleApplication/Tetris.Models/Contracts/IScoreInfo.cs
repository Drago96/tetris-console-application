namespace Tetris.Models.Contracts
{
    public interface IScoreInfo
    {
        int Level { get; set; }

        long Score { get; set; }

        int LinesCleared { get; set; }

        int ScorePerLine { get; set; }

        int LinesPerLevel { get; set; }
    }
}
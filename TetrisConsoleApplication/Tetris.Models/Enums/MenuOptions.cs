namespace Tetris.Models.Enums
{
    using System.ComponentModel;

    public enum MenuOptions
    {
        [Description("New anonymous game")]
        NewGameAnonymous,
        [Description("New game as a registered user")]
        NewGameRegisterd,
        [Description("Highscores")]
        Highscores,
        [Description("Credits")]
        Credits,
       [Description("Exit game")]
        Quit
    }

}

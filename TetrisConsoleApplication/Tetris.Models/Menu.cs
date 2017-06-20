namespace Tetris.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tetris.Models.Enums;

    public class Menu
    {
        public Menu()
        {
            this.CurrentCursorPosition = 1;
            this.MenuOptions = new HashSet<MenuOption>(Enum.GetValues(typeof(MenuOption)).Cast<MenuOption>());
        }

        public int CurrentCursorPosition { get; set; }

        public ICollection<MenuOption> MenuOptions { get; set; }
    }
}
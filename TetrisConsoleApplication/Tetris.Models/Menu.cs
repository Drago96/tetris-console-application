using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.Enums;

namespace Tetris.Models
{
    public class Menu
    {
        public Menu()
        {
            this.CurrentCursorPosition = 1;
            this.MenuOptions = Enum.GetValues(typeof(MenuOption));

        }

        public int CurrentCursorPosition { get; set; }

        public Array MenuOptions { get; set; }
    }
}

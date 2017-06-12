namespace Tetris.Services
{
    using System;
    using System.ComponentModel;
    using System.Net.Mime;
    using System.Reflection;
    using Models.Enums;

    public class MenuService
    {
        public void InitializeMenu()
        {
            ShowMenuOptions();
        }

        public void ShowMenuOptions()
        {
            foreach (var menuOption in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine($"{(int)menuOption}. {GetMenuItemDescription(menuOption)}");
            }
            ChooseAction();
        }

        public static string GetMenuItemDescription(object enumValue)
        {
            var fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute) attrs[0]).Description;
                }
            }
            return enumValue.ToString();
        }

        public void ChooseAction()
        {
            Console.WriteLine("Please choose an action...");
            var input = (MenuOptions) Enum.Parse(typeof(MenuOptions), Console.ReadLine());
            
            switch (input)
            {
                case MenuOptions.NewGameAnonymous:
                    break;

                case MenuOptions.NewGameRegisterd:
                    break;

                case MenuOptions.Credits:
                    break;

                case MenuOptions.Highscores:
                    break;

                case MenuOptions.Quit:
                    Environment.Exit(0);
                    break;

                default:
                    ChooseAction();
                    break;
            }
        }
    }
}

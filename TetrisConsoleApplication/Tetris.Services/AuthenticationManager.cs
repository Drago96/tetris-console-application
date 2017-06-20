namespace Tetris.Services
{
    using System;
    using Tetris.Models.Entities;

    public static class AuthenticationManager
    {
        private static User _currentUser;

    
        public static bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_currentUser?.Name);
        }

        public static void Logout()
        {

            _currentUser = null;
        }

    
        public static void Login(User user)
        {
            _currentUser = user;
        }

        public static User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
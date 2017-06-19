namespace Tetris.Services
{
    using System;
    using Tetris.Models.Entities;

    public static class AuthenticationManager
    {
        private static User _currentUser;

    
        public static bool IsAuthenticated()
        {
            return _currentUser != null;
        }

        public static void Logout()
        {
            if (!IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            _currentUser = null;
        }

    
        public static void Login(User user)
        {
            //if (IsAuthenticated())
            //{
            //    throw new InvalidOperationException("You should logout first!");
            //}

            if (user == null)
            {
                throw new InvalidOperationException("User to log in is invalid!");
            }

            _currentUser = user;
        }

        public static User GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
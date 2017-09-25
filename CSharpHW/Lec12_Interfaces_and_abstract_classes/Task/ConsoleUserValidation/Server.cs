using System;
using static System.Console;
using System.Collections.Generic;

namespace ConsoleUserValidation
{
    class Server
    {
        private readonly List<User> _users;
        private readonly Validator  _validator;

        public Server(List<User> users, Validator validator)
        {
            _users = users;
            _validator = validator;
        }

        public void LogIn(IUser user)
        {
            if (_validator.ValidateUser(user))
            {
                var userIdx = GetUserIdxIfExist(user);

                if (userIdx >= 0)
                {
                    if (user.Password == _users[userIdx].Password)
                    {
                        WriteLine("You have successfully logged in");
                        WriteLine($"Last entry: {_users[userIdx].LastEntry}");
                    }
                    else
                    {
                        WriteLine("Wrong password, try again");
                        return;
                    }
                }
                else
                {
                    _users.Add((User)user);
                    userIdx = _users.Count - 1;

                    WriteLine("You have successfully sign in");
                    WriteLine(_users[userIdx].GetFullInfo());
                }

                _users[userIdx].LastEntry = DateTime.Now.ToString();
            }
            else
            {
                WriteLine("Incorrect data input, try again");
            }
        }

        private int GetUserIdxIfExist(IUser incommingUser)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (incommingUser.Name == _users[i].Name && incommingUser.Email == _users[i].Email)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wrappers.Models;

namespace Wrappers.Builders
{
    public class UserBuilder
    {
        private string userName = "";
        private string userPassword = "";

        public UserBuilder WithName(string name = "")
        {
            userName = name;
            return this;
        }

        public UserBuilder WithPassword(string password = "")
        {
            userPassword = password;
            return this;
        }

        public User Build()
        {
            return new User(userName, userPassword);
        }
    }
}

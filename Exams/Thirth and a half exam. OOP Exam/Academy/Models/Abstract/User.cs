using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils;

namespace Academy.Models
{
    public abstract class User : IUser
    {
        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;

            }
            set
            {
                Validator.StringValidator(value,
                    GlobalConstants.MinUsernameLength,
                    GlobalConstants.MaxUsernameLength,
                    GlobalMessages.UserNameLength());
                this.username = value;
            }
        }

        public virtual string PersonType()
        {
            return "User";
        }

        public override string ToString()
        {
            return string.Format("* {0}:\n - Username: {1}", PersonType() ,this.username);
        }

    }
}

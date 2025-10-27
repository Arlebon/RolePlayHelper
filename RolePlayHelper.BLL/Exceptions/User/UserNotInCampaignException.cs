using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.User
{
    public class UserNotInCampaignException : NotFoundException
    {
        public UserNotInCampaignException() : base("User not found in this campaign")
        {

        }

        public UserNotInCampaignException(string message) : base(message)
        {

        }
    }
}

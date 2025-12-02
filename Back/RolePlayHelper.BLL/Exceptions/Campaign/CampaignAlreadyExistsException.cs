using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Campaign
{
    public class CampaignAlreadyExistsException : AlreadyExistsException
    {
        public CampaignAlreadyExistsException() : base("Campaign already exists")
        {

        }

        public CampaignAlreadyExistsException(string message) : base(message)
        {

        }
    }
}

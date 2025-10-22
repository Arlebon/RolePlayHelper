using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Exceptions.Campaign
{
    public class CampaignNotFoundException : NotFoundException
    {
        public CampaignNotFoundException() : base("Campaign not found")
        {

        }

        public CampaignNotFoundException(string message) : base(message)
        {

        }
    }
}

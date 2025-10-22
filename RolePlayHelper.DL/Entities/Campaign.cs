using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DL.Entities
{
    public class Campaign
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int GMId { get; set; }

        public User GM { get; set; } = null!;

        public int MaxCharNb { get; set; }

        public List<Character> Charcacters { get; set; } = new List<Character>();
    }
}

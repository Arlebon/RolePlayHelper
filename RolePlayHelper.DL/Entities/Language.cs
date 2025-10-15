using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.DL.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Race> Races { get; set; } = new(); 
    }
}

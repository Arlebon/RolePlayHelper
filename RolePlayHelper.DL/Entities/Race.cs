using System.Diagnostics;

namespace RolePlayHelper.DL.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

      
        public List<RaceTrait> Traits { get; set; } = new();
        public List<Language> Languages { get; set; } = new();


        public int StatModifierId { get; set; }
        public StatModifier StatModifier { get; set; } = null!;
    }
}

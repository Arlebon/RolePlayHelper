using System.Diagnostics;

namespace RolePlayHelper.DL.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        //public int RaceTraitId { get; set; }
        //public List<RaceTrait> Traits { get; set; } = [];


        //public int LanguageId { get; set; }
        //public IEnumerable<Language> Languages { get; set; } = [];


        public int StatModifierId { get; set; }
        public StatModifier StatModifier { get; set; } = null!;
    }
}

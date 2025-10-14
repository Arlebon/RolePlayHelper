using System.Diagnostics;

namespace RolePlayHelper.DL.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<RaceTrait> traits { get; set; } = [];

        public IEnumerable<Language> languages { get; set; } = [];


    }
}

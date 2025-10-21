using System.ComponentModel.DataAnnotations.Schema;

namespace RolePlayHelper.DL.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        public List<int> ClassIds { get; set; } = new();
        public List<CharClass> Classes { get; set; } = new();

        public List<int> SubClassIds { get; set; } = new();
        [NotMapped]
        public List<CharClass> SubClasses { get; set; } = new();


        public Race Race { get; set; } = null!;

        #region stats
        public int STR { get; set; }

        public int DEX { get; set; }

        public int CHA { get; set; }

        public int INT { get; set; }

        public int CON { get; set; }
        public int WIS { get; set; }

        #endregion


        public int MVT { get; set; }

        public int MaxHP { get; set; }

        public int ArmorClass { get; set; }

        public int HitModifier { get; set; }

        public int Initiative { get; set; }

        public int SpellAttack { get; set; }

        public int SpellSave { get; set; }

        public int RaceId { get; set; }

    }
}

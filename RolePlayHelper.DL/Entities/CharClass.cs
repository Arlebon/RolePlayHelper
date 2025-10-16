namespace RolePlayHelper.DL.Entities
{
    public class CharClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        // A Character (Sub)Class can have a parentClass
        public int? ParentCharacterId { get; set; }
        public CharClass? ParentClass { get; set; }

        // A ParentClass can have severall Subclasses
        public List<CharClass>? SubClasses { get; set; } = new();

    }
}

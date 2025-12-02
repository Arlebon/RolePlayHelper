namespace RolePlayHelper.DL.Entities
{
    public class CharClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // On CharClass can be assigned to many characters
        public List<Character> Characters { get; set; } = new();


        // A (Sub)Class can have a parentClass
        public int? ParentClassId { get; set; }
        public CharClass? ParentClass { get; set; }

        // A ParentClass can have severall Subclasses
        public List<CharClass>? SubClasses { get; set; } = new();

    }
}

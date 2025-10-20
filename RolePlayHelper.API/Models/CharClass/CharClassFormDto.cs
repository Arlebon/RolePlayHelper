namespace RolePlayHelper.API.Models.CharClass
{
    public class CharClassFormDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        // A (Sub)Class can have a parentClass
        public int? ParentClassId { get; set; }

    }
}

namespace RolePlayHelper.API.Models.CharClass
{
    public class CharClassListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        public int? ParentClassId { get; set; }
        public CharClassListDto? ParentClass { get; set; }


        public List<CharClassListDto>? SubClasses { get; set; } = new();
    }
}

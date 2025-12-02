namespace RolePlayHelper.DL.Entities
{
    public class Campaign
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int GMId { get; set; }

        public User GM { get; set; } = null!;

        public int MaxCharNb { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
    }
}

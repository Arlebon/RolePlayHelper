using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Models.Character
{
    public class CharacterDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPublic { get; set; } = true;
        public List<int> ClassIds { get; set; } = new();
        public List<string> Classes { get; set; } = new();

        public string Race { get; set; } = null!;

        public string? CurrentCampaign { get; set; }


        public int STR { get; set; }

        public int DEX { get; set; }

        public int CHA { get; set; }

        public int INT { get; set; }

        public int CON { get; set; }
        public int WIS { get; set; }
    }
}

using RolePlayHelper.API.Models.CharClass;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class CharClassMapper
    {
        public static CharClassListDto ToCharClassListDto(this CharClass charClass)
        {
            return new CharClassListDto()
            {
                Id = charClass.Id,
                Description = charClass.Description,
                Name = charClass.Name,
                ParentClassId = charClass.ParentClassId,


                ParentClass = charClass.ParentClass != null
                    ? new CharClassListDto
                    {
                        Id = charClass.ParentClass.Id,
                        Name = charClass.ParentClass.Name
                    }
                    : null,
                SubClasses = charClass.SubClasses?
                    .Select(scl => scl.ToSubClassListDto())
                    .ToList() ?? new List<SubClassListDto>(), // Si ma liste est null je crée un liste vide
                SubClassNames = charClass.SubClasses?.Select(cc => cc.Name).ToList()?? new()
            };
        }

        public static CharClassListAddCharDto ToCharClassListAddCharDto(this CharClass charClass)
        {
            return new CharClassListAddCharDto()
            {
                Id = charClass.Id,
                Name = charClass.Name,
            };
        }

        public static CharClass ToCharClass(this CharClassFormDto form)
        {
            return new CharClass()
            {
                Name = form.Name,
                Description = form.Description,
                ParentClassId = form.ParentClassId,
            };
        }

        public static SubClassListDto ToSubClassListDto(this CharClass charClass)
        {
            return new SubClassListDto()
            {
                Id = charClass.Id,
                Name = charClass.Name,
                Description = charClass.Description
            };
        }
    }
}

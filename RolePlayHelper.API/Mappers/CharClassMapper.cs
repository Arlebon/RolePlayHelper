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
                    .Select(scl => scl.ToCharClassListDto())
                    .ToList() ?? new List<CharClassListDto>() // Si ma liste est null je crée un liste vide
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
    }
}

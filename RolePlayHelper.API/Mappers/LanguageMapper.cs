using RolePlayHelper.API.Models.Language;
using RolePlayHelper.DL.Entities;

namespace RolePlayHelper.API.Mappers
{
    public static class LanguageMapper
    {
        public static Language ToLanguage(this LanguageFormDto form)
        {
            return new Language()
            {
                Name = form.Name,
            };
        }
    }
}

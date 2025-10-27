using Microsoft.EntityFrameworkCore;
using RolePlayHelper.BLL.Tools;
using RolePlayHelper.DL.Entities;
using System.Linq.Expressions;

namespace RolePlayHelper.DAL.Seeders
{
    public static class SeederHelper
    {
        public static T GetOrGenerateDefault<T>(
            Func<T?> getter,
            
            // Expression <> permet de traduire en requête SQL au lieu de travailler en mémoire.
            // Le predicate sera mon filtre pour chercher la valeur defaut dans la db.
            Expression<Func<T, bool>> predicate,

            // factory pour créer une valeur défaut si pas trouvé dans db.
            Func<T> factory,

            DbContext context) where T : class
        {
            var entity = set.FirstOrDefault(predicate);
            if (entity == null)
            {
                entity = factory();
                if (entity is Character character)
                {
                    CharacterTool.ApplyStatModifier(character, character.Race.StatModifier);
                }
                context.Add(entity);
                context.SaveChanges();
            }

            return entity;
        }
    }
}

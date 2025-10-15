using RolePlayHelper.DAL.Repositories;
using RolePlayHelper.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePlayHelper.BLL.Services
{
    public class StatModifierService
    {
        private readonly StatModifierRepository _statModifierRepository;

        public StatModifierService(StatModifierRepository statModifierRepository)
        {
            _statModifierRepository = statModifierRepository;
        }

        public void Add(StatModifier statModifier)
        {
            _statModifierRepository.Add(statModifier);
        }

        public StatModifier GetOne(int id)
        {
            StatModifier? statModifier = _statModifierRepository.GetOne(id);

            if (statModifier == null)
            {
                throw new Exception("Stat modifier doesn't exists");
            }

            return statModifier;
        }
    }
}

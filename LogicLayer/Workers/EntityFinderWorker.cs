using Models.Interfaces;
using ModelsLayer.Contexts;
using ModelsLayer.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Workers
{
    class EntityFinderWorker : IFinder
    {
        private EntityContext _context;

        public EntityFinderWorker(EntityContext entityContext) {
            _context = entityContext;

        }
        public List<Phone> FindByLastName(string findText)
        {
            return _context.phones.Include("person").Where(p => p.person.lastName.ToLower().Contains(findText.ToLower())).ToList();
        }

        public List<Phone> FindByName(string findText)
        {
            return _context.phones.Include("person").Where(p => p.person.name.ToLower().Contains(findText.ToLower())).ToList();
        }

        public List<Phone> FindByPhone(string findText)
        {
            return _context.phones.Include("person").Where(p => p.phone.ToLower().Contains(findText.ToLower())).ToList();
        }

        public List<Phone> FindBySurname(string findText)
        {
            return _context.phones.Include("person").Where(p => p.person.surname.ToLower().Contains(findText.ToLower())).ToList();
        }
    }
}

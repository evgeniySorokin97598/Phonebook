using Models.Interfaces;
using ModelsLayer.Contexts;
using ModelsLayer.DataBaseModels;
using ModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Workers
{
    public class EntityWorker : IDataBase
    {
        private EntityContext _context;
        public IFinder _finder { get; set; }
        public EntityWorker()
        {
            _context = new EntityContext();
            _finder = new EntityFinderWorker(_context);
        }

       

        public void AddPerson(Person person)
        {
            
            _context.people.Add(person);
            _context.phones.Add(person.phone);
            _context.SaveChanges();
        }

        public void AddPhone(Phone phone)
        {
            _context.phones.Add(phone);
            _context.people.Add(phone.person);
            _context.SaveChanges();
        }

        public void ChangePerson(Person person)
        {
            var findPerson = _context.people.Find(person.Id);
            findPerson = person;
            _context.SaveChanges();
        }

        public void ChangePhone(Phone phone)
        {
            var findPhone = _context.phones.Find(phone.Id);
            findPhone = phone;
            _context.SaveChanges();
        }

        public void DeletePhone(Phone phone)
        {
            _context.phones.Remove(phone);
            _context.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            return _context.people.Include("phone").ToList();
        }

        public List<Phone> GetPhones()
        {
            return _context.phones.Include("person").ToList();
        }
    }
}

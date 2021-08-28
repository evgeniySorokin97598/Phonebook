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
        private EntityContext context;

        public EntityWorker()
        {
            context = new EntityContext();

        }

        public void AddPerson(Person person)
        {
            
            context.people.Add(person);
            context.phones.Add(person.phone);
            context.SaveChanges();
        }

        public void AddPhone(Phone phone)
        {
            context.phones.Add(phone);
            context.people.Add(phone.person);
            context.SaveChanges();
        }

        public void ChangePerson(Person person)
        {
            var findPerson = context.people.Find(person.Id);
            findPerson = person;
            context.SaveChanges();
        }

        public void ChangePhone(Phone phone)
        {
            var findPhone = context.phones.Where(p => p.phone == phone.phone).FirstOrDefault();
            findPhone = phone;
            context.SaveChanges();
        }

        public void DeletePhone(Phone phone)
        {
            context.phones.Remove(phone);
            context.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            return context.people.Include("phone").ToList();
        }

        public List<Phone> GetPhones()
        {
            
            return context.phones.Include("person").ToList();
        }
    }
}

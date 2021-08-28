using ModelsLayer.DataBaseModels;
using ModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Workers
{
    public class Test : IDataBase
    {
       
        public void AddPhone(Phone phone)
        {

        }

        public void ChangePhone(Phone phone)
        {

        }

        public void DeletePhone(long id)
        {
            //var findphone = phones.Where(p => p.phoneId == id).FirstOrDefault();
            //phones.Remove(findphone);
        }

        public List<Phone> GetPhones()
        {

            List<Phone> phones = new List<Phone>();

            Person person = new Person()
            {
                name = "имя",
                surname = "фамилия",
                lastName = "отчество",
                adres = "адрес",
                
            };

            Person person1 = new Person()
            {
                name = "имя1",
                surname = "фамилия1",
                lastName = "отчество1",
                adres = "адрес1",
               
            };

            Person person2 = new Person()
            {
                name = "имя2",
                surname = "фамилия2",
                lastName = "отчество2",
                adres = "адрес2",
                
            };

            Phone phone = new Phone()
            {
                phone = "+79508999052",
                person = person

            };

            Phone phone1 = new Phone()
            {
                phone = "+79508999052",
                person = person1

            };
            Phone phone2 = new Phone()
            {
                phone = "+79508999052",
                person = person2

            };

            phones.Add(phone);
            phones.Add(phone1);
            phones.Add(phone2);
            return phones;


        }
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            Person person = GetNewPerson();
            Phone phone = GetPhone();

            person.phone = phone;
            phone.person = person;
            people.Add(person);





            return people;
        }

        public Person GetNewPerson()
        {

            return new Person()
            {
                name = "имя",
                surname = "фамилия",
                lastName = "отчество",
                adres = "адрес",
            };
        }

        public Phone GetPhone()
        {
            return new Phone()
            {
                phone = "+79508999054"
            };


        }

        public void AddPerson(Person person)
        {

        }

        public void ChangePerson(Person person)
        {

        }

        
    }
}

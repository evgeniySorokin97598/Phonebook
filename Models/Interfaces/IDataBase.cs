using ModelsLayer.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Interfaces
{
    public interface IDataBase
    {
        void AddPhone(Phone phone);
        void AddPerson(Person person);
        void ChangePhone(Phone phone);
        void ChangePerson(Person person);
        void DeletePhone(long id);
        List<Phone> GetPhones();
        List<Person> GetPeople();


    }
}

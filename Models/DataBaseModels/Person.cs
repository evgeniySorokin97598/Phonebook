using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataBaseModels
{
    //[Table("Persons")]
    public class Person
    {
        
       
        public long Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastName { get; set; }
        public string adres { get; set; }
        public Phone phone { get; set; }

        public bool CheckNull() {
            if (string.IsNullOrEmpty(name.Trim()) || 
                string.IsNullOrEmpty(surname.Trim()) || 
                string.IsNullOrEmpty(lastName.Trim()) || 
                string.IsNullOrEmpty(adres.Trim())) return false;
            else return true;
        }

    }
}

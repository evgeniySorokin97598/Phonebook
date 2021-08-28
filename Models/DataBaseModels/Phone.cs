using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DataBaseModels
{
    //[Table("Phones")]
    public class Phone
    {
        [Key]
        [ForeignKey("person")]
        public long Id { get; set; }
        public Person person { get; set; } 
        public string phone { get; set; }

        public bool CheckNull() {
            if (string.IsNullOrEmpty(phone)) return false;
            else return true;
        
        
        }
    } 
}

using ModelsLayer.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IFinder
    {
        List<Phone> FindByName(string findText);
        List<Phone> FindBySurname(string findText);
        List<Phone> FindByLastName(string findText);
        List<Phone> FindByPhone(string findText);
    }
}

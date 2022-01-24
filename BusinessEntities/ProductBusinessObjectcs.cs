using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public interface IProductBusinessObject
    {
        bool CreateProduct(Product entity);


        Municipality GetMunicipalityById(int Id);
        Municipality GetMunicipalityByName(string name);
        IQueryable<Municipality> GetAllMunicipality();
    }
}

using Project4.Entities;
using Project4.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.Business
{
    public interface IPersonelDal: IEntityRepository<Personel>
    {
        List<Personel> GetAll();
    }
}
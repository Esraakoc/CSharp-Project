using Project4.Entities;
using Project4.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4.DataAccess
{
    public class EfPersonelDal : IPersonelDal
    {
        public void Add(Personel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Personel entity)
        {
            throw new NotImplementedException();
        }

        public List<Personel> GetAll()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Personels.ToList();
            }
        }

        public Personel GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public void Update(Personel entity)
        {
            throw new NotImplementedException();
        }
    }
}

using CommonData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData.DataBaseProvider
{
    public interface IRepository<T> where T : DTOBase
    {
        IQueryable<T> Read();

        IQueryable<T> Read(int id);

        T Create(T objectToSave);

        T Update(T objectToUpdate);

        bool Delete();

        bool Delete(int id);
    }
}

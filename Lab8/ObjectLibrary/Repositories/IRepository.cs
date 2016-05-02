using ObjectLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Repositories
{
    public interface IRepository<T> where T : DBObjectBase
    {
        IList<T> Read();

        T Read(int id);

        T Create(T objectToSave);

        T Update(T objectToUpdate);

        bool Delete();

        bool Delete(int id);
    }
}

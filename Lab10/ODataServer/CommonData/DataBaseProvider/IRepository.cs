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

        Task<int> Create(T objectToSave);

        Task<int> Update(T objectToUpdate);

        Task<bool> Delete();

        Task<bool> Delete(int id);
    }
}

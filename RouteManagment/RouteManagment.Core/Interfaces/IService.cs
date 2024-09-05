using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll() ;

        Task<T> GetById(int id) ;   

        Task<T> Add(T entity) ;
        Task<T> Update(T entity) ;
        Task<T> Delete(int id) ;

    }
}

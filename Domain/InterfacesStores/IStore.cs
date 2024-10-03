using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Security;

namespace Domain.InterfacesStores
{

    public interface IStore<E,M> where E : class  where M : class
    {
        IEnumerable<M> FindAll { get; }
        M Update(M obj);
        M Create(M obj);
        M Delete(M obj);
        void Delete(int id);
        M Update(M updated, int key);
        M Find(int key);
        IEnumerable<M> CreateAll(IEnumerable<M> tList);
        IEnumerable<M> DeleteAll(IEnumerable<M> tList);
       
    }

}


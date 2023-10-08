using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public interface Interfacerepo<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T item);
        bool Update(T item);
        IEnumerable<T> Search(string name);
        bool Remove(int id);
    }
}

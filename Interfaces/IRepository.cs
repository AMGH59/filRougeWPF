using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Interfaces
{
    public interface IRepository<T>
    {
        bool Save(T element);
        bool Update(T element);
        T FinById(int id);
        IEnumerable<T> Search(Func<T, bool> predicate);
    }
}

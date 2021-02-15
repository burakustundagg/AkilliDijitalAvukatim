using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract {
    public interface IRepository<T> {
        List<T> GetList();
        T Get(int id);
        string Add(T entity);
        string Update(T entity, string oldName);
        string Delete(int id);
    }
}

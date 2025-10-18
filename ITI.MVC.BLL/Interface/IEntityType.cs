using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.BLL.Interface
{
    public interface IEntityType<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T model);
        void Update(T model);
        void Delete(T model);
        int Save();
    }
}

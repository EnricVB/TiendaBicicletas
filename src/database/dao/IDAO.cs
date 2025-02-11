using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.database.dao {
    internal interface IDAO<T> {
        public void Insert(T value);
        public T? Get(int id);
        public List<T> List();
        public void Delete(int id);
        public void Update(int id, T value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp
{
    public class GenericRepository<T> : IRepository<T>
    {

        public List<T> Entities { get; set; }
        public GenericRepository()
        {
            Entities = new List<T>();
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities;
        }

        public T GetById(int id)
        {
            foreach (T entity in Entities)
            {
                var idProperty=entity.GetType().GetProperty("ID");
                if(idProperty != null && (int) idProperty.GetValue(entity)==id)
                {
                    return entity;
                }
            }

            return default;
        }

        public void Update(T newEntity)
        {
            int index = -1;
            for(int i=0;i<Entities.Count; i++)
            {
                var entity = Entities[i];
                var id=entity.GetType().GetProperty("ID");
                if (id != null && (int)id.GetValue(entity) == (int)id.GetValue(newEntity))
                {
                    index = i;
                    break;
                }
                if (index != -1) {
                    Entities[i] = newEntity;
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityToolBox
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _set;
        }

        public virtual T? GetOne(int id)
        {
            return _set.Find(id);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Add(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _set.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _context.SaveChanges();
        }
    }
}

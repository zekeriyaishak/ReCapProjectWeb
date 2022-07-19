using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TRentCarContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TRentCarContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TRentCarContext rentCarContext = new TRentCarContext())
            {
                var addedEntity = rentCarContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                rentCarContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TRentCarContext rentCarContext = new TRentCarContext())
            {
                var deletedEntity = rentCarContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                rentCarContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TRentCarContext rentCarContext = new TRentCarContext())
            {
                return filter == null ? rentCarContext.Set<TEntity>().ToList() : rentCarContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TRentCarContext rentCarContext = new TRentCarContext())
            {
                var uptadedEntity = rentCarContext.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                rentCarContext.SaveChanges();
            }
        }
        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    using (TRentCarContext rentCarContext = new TRentCarContext())
        //    {
        //        return rentCarContext.Set<TEntity>().SingleOrDefault(filter);
        //    }
        //}
    }
}

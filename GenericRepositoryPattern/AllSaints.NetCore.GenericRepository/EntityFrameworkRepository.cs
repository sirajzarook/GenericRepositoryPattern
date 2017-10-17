using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSaints.NetCore.GenericRepository
{
	public class EntityFrameworkRepository<TEntity, TKey> where TEntity : class
	{
		private readonly DbContext _dbContext;
		public EntityFrameworkRepository(DbContext dbContext)
		{
			if (dbContext == null) throw new ArgumentNullException("dbContext");
			_dbContext = dbContext;
		}
		protected DbContext DbContext
		{
			get { return _dbContext; }
		}
		public void Create(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			DbContext.Set<TEntity>().Add(entity);

		}
		public TEntity GetById(TKey id)
		{
			return _dbContext.Set<TEntity>().Find(id);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsQueryable();
		}

		public void Delete(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			DbContext.Set<TEntity>().Attach(entity);
			DbContext.Set<TEntity>().Remove(entity);
		}
		public void Update(TEntity entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			DbContext.Set<TEntity>().Attach(entity);
			DbContext.Entry(entity).State = EntityState.Modified;

		}
	}
}

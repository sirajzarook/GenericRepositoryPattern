using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSaints.NetCore.GenericRepository.Abstracts
{
	public interface IGenericRepository<TEntity, in TKey> where TEntity : class
	{
		TEntity GetById(TKey id);
		IQueryable<TEntity> GetAll();
		bool Create(TEntity entity);
		bool Update(TEntity entity);
		bool Delete(TEntity entity);
		bool Save();
	}
}

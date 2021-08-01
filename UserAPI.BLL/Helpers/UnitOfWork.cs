using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace UserAPI.BLL.Helpers
{
	public class UnitOfWork : IUnitOfWork
	{
		private DbContext _context;

		public UnitOfWork(DbContext context)
		{
			_context = context;
		}

		public ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
		{
			return new DbTransaction(_context.Database.BeginTransaction());
		}

		public void Add<T>(T entity)
			where T : class, IDbEntity
		{
			var set = _context.Set<T>();
			set.Add(entity);
		}

		public void Attach<T>(T entity)
			where T : class, IDbEntity
		{
			var set = _context.Set<T>();
			set.Attach(entity);
		}

		void IUnitOfWork.Remove<T>(T entity)
		{
			var set = _context.Set<T>();
			set.Remove(entity);
		}

		public void Update<T>(T entity)
			where T : class, IDbEntity
		{
			var set = _context.Set<T>();
			set.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public IQueryable<T> Query<T>()
			where T : class, IDbEntity
		{
			return _context.Set<T>();
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context = null;
		}
	}
}
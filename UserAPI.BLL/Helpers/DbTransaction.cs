using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.BLL.Helpers
{
	public class DbTransaction : ITransaction
	{
		private readonly IDbContextTransaction _transaction;

		public DbTransaction(IDbContextTransaction transaction)
		{
			_transaction = transaction;
		}

		public void Commit()
		{
			_transaction.Commit();
		}

		public void Rollback()
		{
			_transaction.Rollback();
		}

		public void Dispose()
		{
			_transaction.Dispose();
		}
	}
}
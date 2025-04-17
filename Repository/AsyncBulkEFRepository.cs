using EFCore.BulkExtensions;

using Microsoft.EntityFrameworkCore;

using Mtd.Core.Repositories;
using Mtd.Infrastructure.EFCore.Repositories;

namespace Mtd.Infrastructure.EFCore.Bulk.Repository;
public abstract class AsyncBulkEFRepository<T>(DbContext context) : AsyncEFRepository<T>(context), IAsyncBulkWriteable<T, IReadOnlyCollection<T>> where T : class
{
	public virtual Task BulkDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
	public virtual Task BulkInsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
	public virtual Task BulkInsertOrUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertOrUpdateAsync(entities, cancellationToken: cancellationToken);
	public virtual Task BulkInsertOrUpdateOrDeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertOrUpdateOrDeleteAsync(entities, cancellationToken: cancellationToken);
	public virtual Task BulkSaveChangesAsync(CancellationToken cancellationToken) =>
		_dbContext.BulkSaveChangesAsync(cancellationToken: cancellationToken);
	public virtual Task BulkUpdateAsync(IEnumerable<T> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
	public virtual Task TruncateAsync(CancellationToken cancellationToken) =>
		_dbContext.TruncateAsync<T>(cancellationToken: cancellationToken);
}

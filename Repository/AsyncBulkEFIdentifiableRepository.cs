
using EFCore.BulkExtensions;

using Microsoft.EntityFrameworkCore;

using Mtd.Core.Entities;
using Mtd.Core.Repositories;
using Mtd.Infrastructure.EFCore.Repositories;

namespace Mtd.Infrastructure.EFCore.Bulk.Repository;

public abstract class AsyncBulkEFIdentifiableRepository<T_Identity, T_Entity>(DbContext dbContext)
	: AsyncEFIdentifiableRepository<T_Identity, T_Entity>(dbContext), IAsyncBulkWriteable<T_Entity, IReadOnlyCollection<T_Entity>>
	where T_Identity : notnull, IComparable<T_Identity>
	where T_Entity : class, IIdentity<T_Identity>
{
	public Task BulkDeleteAsync(IEnumerable<T_Entity> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkDeleteAsync(entities, cancellationToken: cancellationToken);
	public Task BulkInsertAsync(IEnumerable<T_Entity> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertAsync(entities, cancellationToken: cancellationToken);
	public Task BulkInsertOrUpdateAsync(IEnumerable<T_Entity> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertOrUpdateAsync(entities, cancellationToken: cancellationToken);
	public Task BulkInsertOrUpdateOrDeleteAsync(IEnumerable<T_Entity> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkInsertOrUpdateOrDeleteAsync(entities, cancellationToken: cancellationToken);
	public Task BulkSaveChangesAsync(CancellationToken cancellationToken) =>
		_dbContext.BulkSaveChangesAsync(cancellationToken: cancellationToken);
	public Task BulkUpdateAsync(IEnumerable<T_Entity> entities, CancellationToken cancellationToken) =>
		_dbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
	public Task TruncateAsync(CancellationToken cancellationToken) =>
		_dbContext.TruncateAsync<T_Entity>(cancellationToken: cancellationToken);
}

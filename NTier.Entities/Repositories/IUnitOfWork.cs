public interface IUnitOfWork       
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); // entity Fr'de karşılığı var
}
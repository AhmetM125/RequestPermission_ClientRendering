namespace RequestPermission.Api.DataLayer.Generic
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}

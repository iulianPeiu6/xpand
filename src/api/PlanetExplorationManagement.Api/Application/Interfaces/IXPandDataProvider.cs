namespace Application.Interfaces
{
    public interface IXPandDataProvider
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    }
}
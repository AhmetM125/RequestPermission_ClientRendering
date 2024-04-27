using Microsoft.EntityFrameworkCore;
using RequestPermission.Api.Infrastracture;
using System.Linq.Expressions;

namespace RequestPermission.Api.DataLayer.Generic
{
    public class GenericRepository<T> : RequestPermissionContext, IUnitOfWork, IGenericRepository<T> where T : class
    {
        private readonly RequestPermissionContext _requestPermissionContext;
        public GenericRepository(DbContextOptions<RequestPermissionContext> options, RequestPermissionContext permissionContext)
            : base(options)
        {
            _requestPermissionContext = permissionContext;
        }

        public void Add(T entity)
        {
            _requestPermissionContext.Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _requestPermissionContext.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _requestPermissionContext.Remove(entity);
        }
        public void DeleteAll()
        {
            _requestPermissionContext.RemoveRange(_requestPermissionContext.Set<T>());
        }

        public void DeleteById(Guid id)
        {
            var obj = _requestPermissionContext.Find<T>(id);
            _requestPermissionContext.Remove(obj);
        }

        public void DeleteById(int id)
        {
            var obj = _requestPermissionContext.Find<T>(id);
            _requestPermissionContext.Remove(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _requestPermissionContext.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _requestPermissionContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _requestPermissionContext.Set<T>().FirstOrDefaultAsync();
        }
        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault(filter);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _requestPermissionContext.Set<T>().FirstOrDefaultAsync(filter);
        }
        public T GetFirstOrDefault()
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _requestPermissionContext.Set<T>().FirstOrDefault(filter);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter)
        {
            return _requestPermissionContext.Set<T>().Where(filter);
        }
        public IQueryable<T> GetQueryable()
        {
            return _requestPermissionContext.Set<T>();
        }
        public IEnumerable<T> GetWithRawSql(string query, params object[] parameters)

        {
            return _requestPermissionContext.Set<T>().FromSqlRaw(query, parameters).ToList();
        }
        public IEnumerable<T> GetWithRawSql(string query)
        {
            return _requestPermissionContext.Set<T>().FromSqlRaw(query).AsEnumerable();
        }
        public void MultipleAdd(IEnumerable<T> entities)
        {
            _requestPermissionContext.AddRange(entities);
        }

        public async Task MultipleAddAsync(IEnumerable<T> entities)
        {
            await _requestPermissionContext.AddRangeAsync(entities);
        }

        public void MultipleDelete(IEnumerable<T> entities)
        {
            _requestPermissionContext.RemoveRange(entities);
        }
        public void MultipleUpdate(IEnumerable<T> entities)
        {
            _requestPermissionContext.UpdateRange(entities);
        }

        public void Save()
        {
            _requestPermissionContext.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            var currentTime = DateTime.UtcNow;
            var currentUserId = Guid.Empty; // i need session user id here (later)
            var currentUser = "ahmet.yurdal";

            var changes = _requestPermissionContext.ChangeTracker.Entries();
            foreach (var entity in changes)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property("InsertDate").CurrentValue = currentTime;
                    entity.Property("InsertUser").CurrentValue = currentUser;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Property("UpdateDate").CurrentValue = currentTime;
                    entity.Property("UpdateUser").CurrentValue = currentUser;
                }
            }
            await _requestPermissionContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _requestPermissionContext.Update(entity);
        }
    }
}

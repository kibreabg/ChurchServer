using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using ChurchServer.SharedKernel;
using ChurchServer.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ChurchDbContext _dbContext;

        public UserRepository(ChurchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(string id) where T : IdentityUser
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public Task<T> GetByIdAsync<T>(string id) where T : IdentityUser
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }
        public Task<T> GetBySpecAsync<T>(ISpecification<T> spec) where T : IdentityUser
        {
            var specificationResult = ApplySpecification(spec);
            return specificationResult.FirstOrDefaultAsync();
        }

        public Task<List<T>> ListAsync<T>() where T : IdentityUser
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : IdentityUser
        {
            var specificationResult = ApplySpecification(spec);
            return specificationResult.ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : IdentityUser
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task UpdateAsync<T>(T entity) where T : IdentityUser
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : IdentityUser
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : IdentityUser
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}

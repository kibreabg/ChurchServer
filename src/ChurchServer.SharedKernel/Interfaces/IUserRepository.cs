using Ardalis.Specification;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.SharedKernel.Interfaces
{
    public interface IUserRepository
    {
        Task<T> GetByIdAsync<T>(string id) where T : IdentityUser;
        Task<T> GetBySpecAsync<T>(ISpecification<T> spec) where T : IdentityUser;
        Task<List<T>> ListAsync<T>() where T : IdentityUser;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : IdentityUser;
        Task<T> AddAsync<T>(T entity) where T : IdentityUser;
        Task UpdateAsync<T>(T entity) where T : IdentityUser;
        Task DeleteAsync<T>(T entity) where T : IdentityUser;
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
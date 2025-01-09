using FullStackChallengeAPI.Data.DTO;
using FullStackChallengeAPI.Entity;

namespace FullStackChallengeAPI.Data.Interfaces;

public interface IUserRepository<T>
{
    // Register a new user
    Task<T> RegisterAsync(T entity);

    // Login a user and return a JWT token or null if authentication fails
    Task<User?> LoginAsync(LoginRequestDTO login);
}
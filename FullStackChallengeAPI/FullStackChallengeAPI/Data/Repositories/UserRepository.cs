using FullStackChallengeAPI.Data.DTO;
using FullStackChallengeAPI.Data.Interfaces;
using FullStackChallengeAPI.Data.Utilities;
using FullStackChallengeAPI.Entity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace FullStackChallengeAPI.Data.Repositories;

public class UserRepository : IUserRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // Register a new user
    public async Task<User> RegisterAsync(User user)
    {
        // Check if email already exists
        var existingUser = await _context.users
                                         .FirstOrDefaultAsync(u => u.email == user.email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Email is already taken.");
        }

        user.id = new Guid();
        
        // Hash the password
        user.password = HashPassword(user.password);

        // Add the user to the database
        _context.users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    // Update user information
    public async Task<Guid> UpdateAsync(User user)
    {
        _context.users.Update(user);
        await _context.SaveChangesAsync();

        return user.id;
    }

    // Login user and return a JWT token if successful
    public async Task<string?> LoginAsync(LoginRequestDTO login)
    {
        var user = await _context.users
                                  .FirstOrDefaultAsync(u => u.email == login.Email);
        if (user == null || !VerifyPassword(login.Password, user.password))
        {
            return null; // Invalid credentials
        }

        // Return JWT token (you'd generate the token here)
        var token = GenerateJwtToken(user);

        return token;
    }

    // Helper method to hash password (you can use bcrypt or Argon2 instead)
    private string HashPassword(string password)
    {
        // Generate a salt using a secure random number generator
        var salt = new byte[16];
        using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Use PBKDF2 to hash the password with the salt
        var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        // Store the salt and hashed password (you can store the salt separately if needed)
        return hashedPassword;
    }

    // Helper method to verify password
    private bool VerifyPassword(string inputPassword, string storedHashedPassword)
    {
        // In this case, we only compare the password hashes (no salt for simplicity).
        // In production, you should use a more advanced hashing mechanism like bcrypt or Argon2.
        return storedHashedPassword == HashPassword(inputPassword);
    }

    // Generate JWT token (this is just an example, you'd need to implement JWT creation)
    private string GenerateJwtToken(User user)
    {
        // Implement JWT token generation here (using libraries like System.IdentityModel.Tokens.Jwt)
        return "generated-jwt-token"; // Placeholder
    }
}
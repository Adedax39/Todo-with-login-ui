using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public class PasswordHasher
{
    private const int SaltSize = 16;
    private const int Iterations = 10000;

    public  string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Hash the password
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: Iterations,
            numBytesRequested: 32
        );

        // Combine the salt and hash
        byte[] hashBytes = new byte[SaltSize + 32];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, 32);

        return Convert.ToBase64String(hashBytes);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extract the salt from the hashed password
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Compute the hash of the provided password with the extracted salt
        byte[] hashToVerify = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: Iterations,
            numBytesRequested: 32
        );

        // Compare the computed hash with the stored hash
        for (int i = 0; i < 32; i++)
        {
            if (hashBytes[i + SaltSize] != hashToVerify[i])
            {
                return false;
            }
        }
        return true;
    }
}
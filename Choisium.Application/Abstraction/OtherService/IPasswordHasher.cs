namespace Choisium.Application.Abstraction.OtherService
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// Genera un hash seguro de una contraseña en texto plano.
        /// </summary>
        string HashPassword(string password);

        /// <summary>
        /// Verifica si una contraseña coincide con su hash.
        /// </summary>
        bool VerifyPassword(string password, string hashedPassword);
    }
}
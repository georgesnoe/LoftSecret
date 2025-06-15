using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LoftSecret.Database;

public class Database
{
    /* Constants to easily manages sql errors */
    // Email is duplicated
    public const int SQL_EMAIL_DUPLICATE = 345647982;
    public const string SQL_EMAIL_DUPLICATE_STR = "Adresse email déjà existante";

    // Email not exists
    public const int SQL_EMAIL_NOT_EXISTS = 345647983;
    public const string SQL_EMAIL_NOT_EXISTS_STR = "Adresse email non existante";

    // Password Error
    public const int SQL_PASSWORD_ERROR = 345647984;
    public const string SQL_PASSWORD_ERROR_STR = "Mot de passe incorrect";


    /* MySql Database configuration */

    /* Database server or provider */
    private const string __dbServer = "localhost";

    /* Database port
       Note: By default, mysql uses 3306 so
       left this untouched
    */
    private const string __dbPort = "3306";

    /* Database name (eg. myawesomedb) */
    private const string __dbName = "loft_secret";

    /* Database user (eg. yourname) */
    private const string __dbUser = "root";

    /* Database password */
    private const string __dbPasswd = "";

    /* Resulting string */
    public const string __connectionString = $"Server={__dbServer};Port={__dbPort};Database={__dbName};Uid={__dbUser};Pwd={__dbPasswd}";

    // Salt to hash passwords
    private const string __salt = "CGYzqeN4plZekNC88Umm1Q==";

    // Hash iteration count
    private const int __hashIterationCount = 10;

    // Static methods to hash passwords
    public static string HashPassword(string password)
    {
        return Convert.ToBase64String(
            KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(__salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: __hashIterationCount,
                numBytesRequested: 256 / 8
            )
        );
    }
}

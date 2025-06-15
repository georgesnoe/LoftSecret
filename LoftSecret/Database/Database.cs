namespace LoftSecret.Database;

public class Database
{
    /* Constants to easily manages sql errors */
    public const int SQL_EMAIL_DUPLICATE = 345647982;
    public const string SQL_EMAIL_DUPLICATE_STR = "Adresse email déjà existante";

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
}

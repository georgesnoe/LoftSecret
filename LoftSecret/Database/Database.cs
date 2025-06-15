namespace LoftSecret.Database;

public class Database
{
    /* Constants to easily manages sql errors */
    public static readonly int SQL_EMAIL_DUPLICATE = 345647982;

    /* MySql Database configuration */

    /* Database server or provider */
    private static readonly string __dbServer = "localhost";

    /* Database port
       Note: By default, mysql uses 3306 so
       left this untouched
    */
    private static readonly string __dbPort = "3306";

    /* Database name (eg. myawesomedb) */
    private static readonly string __dbName = "loft_secret";

    /* Database user (eg. yourname) */
    private static readonly string __dbUser = "root";

    /* Database password */
    private static readonly string __dbPasswd = "";

    /* Resulting string */
    public static readonly string __connectionString = $"Server={__dbServer};Port={__dbPort};Database={__dbName};Uid={__dbUser};Pwd={__dbPasswd}";
}

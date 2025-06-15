using MySql.Data.MySqlClient;
using System.Data;
using LoftSecret.Models;

namespace LoftSecret.Database;

public class UtilisateursDb
{
    /* Add an user into the database with its informations */
    public static async Task<Int32> AddUtilisateur(Utilisateurs utilisateur)
    {
        using (var connection = new MySqlConnection(Database.__connectionString))
        {
            await connection.OpenAsync();
            string query = "INSERT INTO utilisateurs (nom, prenoms, telephone, email, mot_de_passe, role_id) VALUES (@nom, @prenoms, @telephone, @email, @mot_de_passe, @role_id)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nom", utilisateur.Nom);
                command.Parameters.AddWithValue("@prenoms", utilisateur.Prenoms);
                command.Parameters.AddWithValue("@telephone", utilisateur.Telephone);
                command.Parameters.AddWithValue("@email", utilisateur.Email);
                command.Parameters.AddWithValue("@mot_de_passe", utilisateur.MotDePasse);
                command.Parameters.AddWithValue("@role_id", utilisateur.RoleId);

                Int32 returnValue;
                try
                {
                    returnValue = await command.ExecuteNonQueryAsync();
                }
                catch (MySqlException e)
                {
                    /* Email Duplicate here */
                    Console.WriteLine(e.Message);
                    returnValue = Database.SQL_EMAIL_DUPLICATE;
                }
                return returnValue;
            }
        }
    }

    public static async Task<Utilisateurs?> FindUtilisateurByEmail(string email)
    {
        using (var connection = new MySqlConnection(Database.__connectionString))
        {
            await connection.OpenAsync();
            string query = "SELECT * FROM utilisateurs WHERE email = @email";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", email);
                try
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Utilisateurs
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Prenoms = reader.GetString("prenoms"),
                                Telephone = reader.GetString("telephone"),
                                Email = reader.GetString("email"),
                                DateInscription = reader.GetDateTime("date_inscription"),
                                MotDePasse = reader.GetString("mot_de_passe"),
                                RoleId = reader.GetInt32("role_id")
                            };
                        }
                    }
                }
                catch (MySqlException e)
                {
                    /* Email Duplicate here */
                    Console.WriteLine(e.Message);
                }
            }
        }
        return null;
    }
}

using MySql.Data.MySqlClient;

using LoftSecret.Models;

namespace LoftSecret.Database;

public class UtilisateursDb
{
    /* Add an user into the database with its informations */
    public static async Task AddUtilisateur(Utilisateurs utilisateur)
    {
        using (var connection = new MySqlConnection(InitDatabase.__connectionString))
        {
            await connection.OpenAsync();
            string query = "INSERT INTO utilisateurs (nom, prenoms, telephone, email, mot_de_passe, date_inscription, role_id) VALUES (@nom, @prenoms, @telephone, @email, @mot_de_passe, @date_inscription, @role_id)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nom", utilisateur.Nom);
                command.Parameters.AddWithValue("@prenoms", utilisateur.Prenoms);
                command.Parameters.AddWithValue("@telephone", utilisateur.Telephone);
                command.Parameters.AddWithValue("@email", utilisateur.Email);
                command.Parameters.AddWithValue("@mot_de_passe", utilisateur.MotDePasse);
                command.Parameters.AddWithValue("@date_inscription", utilisateur.DateInscription);
                command.Parameters.AddWithValue("@role_id", utilisateur.RoleId);
            }
        }
    }
}

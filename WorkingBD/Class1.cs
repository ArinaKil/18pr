using MySql.Data.MySqlClient;

namespace WorkingBD
{
    public class WorkingBD
    {
        public static MySqlDataReader Query(string sql, MySqlConnection connection)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            return cmd.ExecuteReader();
        }
    }
}

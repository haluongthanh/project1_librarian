using MySql.Data.MySqlClient;


public class DBHelper
{
    public static MySqlConnection? _connection;
    public static MySqlConnection GetConnection()
    {
        if (_connection == null)
        {
            _connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;userid=root;password=Thanh36@;port=3306;database=libranrian;"
            };
        }
        return _connection;
    }

    public static MySqlDataReader ExecQuery(string query)
    {
        MySqlCommand command = new MySqlCommand(query, _connection);
        return command.ExecuteReader();
    }

    public static MySqlConnection OpenConnection()
    {
        if (_connection == null)
        {
            GetConnection();
        }

        if (_connection.State == System.Data.ConnectionState.Closed)
            _connection.Open();

        return _connection;
    }

    public static void CloseConnection()
    {
        if (_connection != null) _connection.Close();
    }
}


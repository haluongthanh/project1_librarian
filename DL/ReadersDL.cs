using code.Entities;
using MySql.Data.MySqlClient;

namespace code.DL
{
    public class ReadersDL
    {
        public bool AddReaders(Readers readers)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_CreateReaders", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Readers_names", readers.Name);

            cmd.Parameters.AddWithValue("@Addresss", readers.Address);

            cmd.Parameters.AddWithValue("@Phones", readers.Phone);

            cmd.Parameters.AddWithValue("@Emails", readers.Email);

            cmd.Parameters.AddWithValue("@Passwords", readers.Password);

            cmd.Parameters.AddWithValue("@Statuss", readers.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool UpdateReaders(Readers readers)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_UpdateReaders", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", readers.Id);

            cmd.Parameters.AddWithValue("@Readers_names", readers.Name);

            cmd.Parameters.AddWithValue("@Addresss", readers.Address);

            cmd.Parameters.AddWithValue("@Phones", readers.Phone);

            cmd.Parameters.AddWithValue("@Emails", readers.Email);

            cmd.Parameters.AddWithValue("@Passwords", readers.Password);

            cmd.Parameters.AddWithValue("@Statuss", readers.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool DeleteReaders(Readers readers)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_DeleteReaders", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", readers.Id);

            cmd.Parameters.AddWithValue("@Statuss", readers.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool ChangePassword(Readers readers)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_ChangePasswordReaders", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emails", readers.Email);

            cmd.Parameters.AddWithValue("@Passwords", readers.Password);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
    }
}
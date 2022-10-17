using code.Entities;
using MySql.Data.MySqlClient;

namespace code.DL
{
    public class BookDL
    {
        public bool AddBook(Book book)
        {
            // Mo ket noi den DB
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_CreateBooks", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Isbn", book.Isbn);

            cmd.Parameters.AddWithValue("@Book_names", book.Book_names);

            cmd.Parameters.AddWithValue("@Authors", book.Author);

            cmd.Parameters.AddWithValue("@Publisher_names", book.Publisher_names);

            cmd.Parameters.AddWithValue("@Publishing_years", book.Publishing_year);

            cmd.Parameters.AddWithValue("@Amounts", book.Amount);

            cmd.Parameters.AddWithValue("@Statuss", book.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool UpdateBook(Book book)
        {
            // Mo ket noi den DB
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_UpdateBooks", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Isbn", book.Isbn);

            cmd.Parameters.AddWithValue("@Book_names", book.Book_names);

            cmd.Parameters.AddWithValue("@Authors", book.Author);

            cmd.Parameters.AddWithValue("@Publisher_names", book.Publisher_names);

            cmd.Parameters.AddWithValue("@Publishing_years", book.Publishing_year);

            cmd.Parameters.AddWithValue("@Amounts", book.Amount);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool DeleteBook(Book book)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_DeleteBook", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", book.Isbn);

            cmd.Parameters.AddWithValue("@Statuss", book.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
    }
}
using code.Entities;
using MySql.Data.MySqlClient;

namespace code.DL
{
    public class EmployeeDL
    {
        public bool AddEmployee(Employee employee)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_CreateEmployees", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Employee_names", employee.Name);

            cmd.Parameters.AddWithValue("@Addresss", employee.Address);

            cmd.Parameters.AddWithValue("@Phones", employee.Phone);

            cmd.Parameters.AddWithValue("@Emails", employee.Email);

            cmd.Parameters.AddWithValue("@Passwords", employee.Password);

            cmd.Parameters.AddWithValue("@Positions", employee.Position);

            cmd.Parameters.AddWithValue("@Statuss", employee.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool UpdateEmployee(Employee employee)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_UpdateEmployees", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", employee.Id);

            cmd.Parameters.AddWithValue("@Employee_names", employee.Name);

            cmd.Parameters.AddWithValue("@Addresss", employee.Address);

            cmd.Parameters.AddWithValue("@Phones", employee.Phone);

            cmd.Parameters.AddWithValue("@Emails", employee.Email);

            cmd.Parameters.AddWithValue("@Passwords", employee.Password);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }

        public bool DeleteEmployee(Employee employee)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_DeleteEmployees", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", employee.Id);

            cmd.Parameters.AddWithValue("@Statuss", employee.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool decentralization(Employee employee)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_Decentralization", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", employee.Id);

            cmd.Parameters.AddWithValue("@Positions", employee.Position);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool ChangePassword(Employee employee)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_ChangePasswordEmployee", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emails", employee.Email);

            cmd.Parameters.AddWithValue("@Passwords", employee.Password);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
    }

}
using code.Entities;
using MySql.Data.MySqlClient;

namespace code.DL
{
    public class LoanSlipDetailsDL
    {
        public bool AddLoanSlipDetalis(LoanSlipDetails loanSlipDetails)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_CreateLoanSlipDetails", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_isbn", loanSlipDetails.id_Isbn);

            cmd.Parameters.AddWithValue("@Amounts", loanSlipDetails.amount);

            cmd.Parameters.AddWithValue("@Statuss", loanSlipDetails.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool UpdateLoanSlipDetalis(LoanSlipDetails loanSlipDetails)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_UpdateLoanSlipDetails", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", loanSlipDetails.id);

            cmd.Parameters.AddWithValue("@Id_isbn", loanSlipDetails.id_Isbn);

            cmd.Parameters.AddWithValue("@Amounts", loanSlipDetails.amount);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool DeleteLoanSlipDetalis(LoanSlipDetails loanSlipDetails)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_DeleteLoanSlipDetails", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", loanSlipDetails.id);

            cmd.Parameters.AddWithValue("@Statuss", loanSlipDetails.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
    }
}
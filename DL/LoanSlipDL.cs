using code.Entities;
using MySql.Data.MySqlClient;

namespace code.DL
{
    public class LoanSlipDL
    {
        public bool AddLoanSlip(LoanSlip loanSlip)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_CreateLoanSlip", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Readerss", loanSlip.Id_Readers);

            cmd.Parameters.AddWithValue("@Id_Employees", loanSlip.Id_Employee);

            cmd.Parameters.AddWithValue("@Id_loan_Slip_Detailss", loanSlip.Id_loan_Slip_Details);

            cmd.Parameters.AddWithValue("@Borrowed_dates", loanSlip.Borrowed_date);

            cmd.Parameters.AddWithValue("@Pay_days", loanSlip.Pay_day);

            cmd.Parameters.AddWithValue("@Statuss", loanSlip.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool UpdateLoanSlip(LoanSlip loanSlip)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_UpdateLoanSlip", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", loanSlip.id);

            cmd.Parameters.AddWithValue("@Id_Readerss", loanSlip.Id_Readers);

            cmd.Parameters.AddWithValue("@Id_Employees", loanSlip.Id_Employee);

            cmd.Parameters.AddWithValue("@Id_loan_Slip_Detailss", loanSlip.Id_loan_Slip_Details);

            cmd.Parameters.AddWithValue("@Borrowed_dates", loanSlip.Borrowed_date);

            cmd.Parameters.AddWithValue("@Pay_days", loanSlip.Pay_day);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
        public bool DeleteLoanSlip(LoanSlip loanSlip)
        {
            DBHelper.OpenConnection();

            MySqlCommand cmd = new MySqlCommand("sp_DeleteLoanSlip", DBHelper.OpenConnection());

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Ids", loanSlip.id);

            cmd.Parameters.AddWithValue("@Statuss", loanSlip.status);

            cmd.Parameters.Add(new MySqlParameter("@empId", MySqlDbType.Int32));
            cmd.Parameters["@empId"].Direction = System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@empId"].Value != DBNull.Value;
        }
    }
}
using System;
using code.BL;
using code.DL;
using code.Entities;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace code.BL
{
    public class LoanSlipDetailsService
    {
        private readonly LoanSlipDetailsDL _DL;

        public LoanSlipDetailsService()
        {
            _DL = new LoanSlipDetailsDL();
        }
        public void AddLoanSlipDetailsDL()
        {
            Console.Clear();
            try
            {
                LoanSlipDetails loanSlipDetails = new LoanSlipDetails();



                int isFirst = 0;

                string isbn;

                isFirst = 0;
                do
                {
                    Console.Write("Id ISBN: ");

                    isbn = Console.ReadLine() ?? "";
                    if (CheckISBN(isbn))
                    {
                        loanSlipDetails.id_Isbn = isbn;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("id does not exist");
                    }

                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("amount: ");

                    int amount = int.Parse(Console.ReadLine() ?? "");
                    if (CheckAmount(amount, isbn))
                    {
                        loanSlipDetails.amount = amount;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("amount is not enough");
                    }

                } while (isFirst != 1);

                int status = 1;
                loanSlipDetails.status = status;

                _DL.AddLoanSlipDetalis(loanSlipDetails);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void UpdateLoanSlipDetailsDL()
        {
            Console.Clear();
            try
            {
                LoanSlipDetails loanSlipDetails = new LoanSlipDetails();



                int isFirst = 0;


                do
                {
                    Console.Write("Id: ");

                    int id = int.Parse(Console.ReadLine() ?? "");
                    int status = 1;

                    if (CheckId(id, status))
                    {
                        loanSlipDetails.id = id;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("id does not exist");
                    }

                } while (isFirst != 1);

                string isbn;
                do
                {
                    Console.Write("Id ISBN: ");

                    isbn = Console.ReadLine() ?? "";
                    if (CheckISBN(isbn))
                    {
                        loanSlipDetails.id_Isbn = isbn;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("id does not exist");
                    }

                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("amount: ");

                    int amount = int.Parse(Console.ReadLine() ?? "");
                    if (CheckAmount(amount, isbn))
                    {
                        loanSlipDetails.amount = amount;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("amount is not enough");
                    }

                } while (isFirst != 1);


                _DL.UpdateLoanSlipDetalis(loanSlipDetails);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void DeleteLoanSlipDetalis()
        {
            Console.Clear();
            LoanSlipDetails loanSlipDetails = new LoanSlipDetails();

            int isFirst = 0;

            do
            {
                Console.Write("Id Delete: ");

                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 1;

                if (CheckId(Id, status))
                {
                    loanSlipDetails.id = Id;
                    isFirst = 1;

                    status = 0;
                    loanSlipDetails.status = status;
                }
                else
                {
                    Console.WriteLine("id does not exist");
                }

            } while (isFirst != 1);

            _DL.DeleteLoanSlipDetalis(loanSlipDetails);
        }
        public void status()
        {
            Console.Clear();
            LoanSlipDetails loanSlipDetails = new LoanSlipDetails();

            int isFirst = 0;

            do
            {
                Console.Write("Id : ");

                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 1;

                if (CheckId(Id, status))
                {
                    if (CheckAmountDetails(Id, status))
                    {
                        loanSlipDetails.id = Id;
                        isFirst = 1;

                        status = 2;
                        loanSlipDetails.status = status;
                    }

                }
                else
                {
                    Console.WriteLine("id does not exist");
                }

            } while (isFirst != 1);

            _DL.DeleteLoanSlipDetalis(loanSlipDetails);
        }
        public void Restore()
        {
            Console.Clear();
            LoanSlipDetails loanSlipDetails = new LoanSlipDetails();


            int isFirst = 0;

            do
            {
                Console.Write("Id Restore: ");

                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 0;

                if (CheckId(Id, status))
                {
                    loanSlipDetails.id = Id;
                    isFirst = 1;
                    status = 1;
                    loanSlipDetails.status = status;
                }

            } while (isFirst != 1);

            _DL.DeleteLoanSlipDetalis(loanSlipDetails);
        }
        public void DisplayLoanSlipDetails(int i)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Status={i}";

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_ISBN"],13} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
        }
        public void SearchLoanSlipDetails(string name)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Id={name}";

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_ISBN"],13} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
        }
        bool CheckISBN(string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books where ISBN='{isbn}' and Status=1";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["ISBN"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }

        }
        bool CheckAmount(int amount, string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books where ISBN='{isbn}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Amount"]}";

                    int row1 = int.Parse(row);

                    if (row1 >= amount)
                    {
                        amount = row1 - amount;
                        DBHelper.CloseConnection();

                        UpdateAmountBook(amount, isbn);
                        return true;
                    }
                }
                return false;
            }

        }
        bool CheckAmountDetails(int id, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM loan_slip_details where Id='{id}' and Status='{status}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Amount"]}";

                    string row1 = $"{reader["Id_ISBN"]}";

                    int amount = int.Parse(row);

                    if (row != null)
                    {
                        DBHelper.CloseConnection();

                        CheckAmount1(amount, row1);
                        return true;
                    }
                }
                return false;
            }
        }
        bool CheckAmount1(int amount, string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books where ISBN='{isbn}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Amount"]}";

                    int row1 = int.Parse(row);

                    if (row1 >= amount)
                    {
                        amount = row1 + amount;

                        DBHelper.CloseConnection();

                        UpdateAmountBook(amount, isbn);
                        return true;
                    }
                }
                return false;
            }

        }
        bool UpdateAmountBook(int amount, string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"update ignore books set Amount={amount} where ISBN='{isbn}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["ISBN"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }

        }
        bool CheckId(int id, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM loan_slip_details where Id='{id}' and Status='{status}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Id"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
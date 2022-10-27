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

                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("Create");
                Console.WriteLine("══════════════════════════════════════");

                int isFirst = 0;

                string isbn;

                isFirst = 0;

                int status = 1;
                do
                {
                    if (checkDisplaybook(status))
                    {
                        DisplayBook(status);

                        do
                        {
                            Console.Write("ISBN: ");
                            isbn = Console.ReadLine() ?? "";
                            string name = "ISBN";
                            if (CheckISBN(isbn))
                            {
                                Sreach(name, isbn);
                                loanSlipDetails.id_Isbn = isbn;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("ISBN does not exist");
                            }

                        } while (isFirst != 1);

                        isFirst = 0;
                        do
                        {
                            Console.Write("Amount: ");

                            int amount = int.Parse(Console.ReadLine() ?? "");
                            if (CheckAmount(amount, isbn))
                            {
                                loanSlipDetails.amount = amount;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("Amount is not enough");
                            }

                        } while (isFirst != 1);


                        loanSlipDetails.status = status;

                        isFirst = 0;
                        do
                        {

                            Console.Write("Do you want to crete (Y/N): ");
                            string l = Console.ReadLine() ?? "";
                            if (l == "y" || l == "Y")
                            {
                                Console.WriteLine("You have successfully create");
                                _DL.AddLoanSlipDetalis(loanSlipDetails);
                                isFirst = 1;
                            }
                            else if (l == "n" || l == "N")
                            {
                                Console.WriteLine("You do not agree to create");
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("You entered wrong");
                            }

                        } while (isFirst != 1);
                    }
                    else
                    {
                        Console.WriteLine("not exist book");
                        isFirst = 1;
                    }
                } while (isFirst != 1);


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

                int status = 1;

                int status2 = 2;

                string isbn;

                do
                {
                    if (checkDisplaydetails(status, status2))
                    {

                        DisplayLoanSlipDetails(status, status2);
                        do
                        {
                            Console.Write("Update Id: ");

                            int id = int.Parse(Console.ReadLine() ?? "");

                            if (CheckId(id, status, status2))
                            {
                                string check = Convert.ToString(id);
                                SearchLoanSlipDetails(check);
                                loanSlipDetails.id = id;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("id does not exist");
                            }

                            isFirst = 0;
                            do
                            {
                                if (checkDisplaybook(status))
                                {
                                    DisplayBook(status);

                                    isFirst = 0;
                                    do
                                    {
                                        Console.Write("Update ISBN: ");
                                        isbn = Console.ReadLine() ?? "";
                                        string name = "Id";
                                        if (CheckISBN(isbn))
                                        {
                                            Sreach(name, isbn);
                                            loanSlipDetails.id_Isbn = isbn;
                                            isFirst = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ISBN does not exist");
                                        }

                                    } while (isFirst != 1);

                                    isFirst = 0;
                                    do
                                    {
                                        Console.Write("Update Amount: ");

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

                                    isFirst = 0;
                                    do
                                    {

                                        Console.Write("Do you want to update (Y/N): ");
                                        string l = Console.ReadLine() ?? "";
                                        if (l == "y" || l == "Y")
                                        {
                                            Console.WriteLine("You have successfully update");
                                            _DL.UpdateLoanSlipDetalis(loanSlipDetails);
                                            isFirst = 1;
                                        }
                                        else if (l == "n" || l == "N")
                                        {
                                            Console.WriteLine("You do not agree to update");
                                            isFirst = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("You entered wrong");
                                        }

                                    } while (isFirst != 1);
                                }
                                else
                                {
                                    Console.WriteLine("not exist book");
                                    isFirst = 1;
                                }
                            } while (isFirst != 1);

                        } while (isFirst != 1);
                    }
                    else
                    {
                        Console.WriteLine("not exist details");
                        isFirst = 1;
                    }
                } while (isFirst != 1);
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

            int status = 1;

            int status2 = 2;

            do
            {
                if (checkDisplaydetails(status, status2))
                {
                    DisplayLoanSlipDetails(status, status2);

                    do
                    {

                        Console.Write("Id Delete: ");
                        int Id = int.Parse(Console.ReadLine() ?? "");

                        if (CheckId(Id, status, status2))
                        {
                            string check = Convert.ToString(Id);
                            SearchLoanSlipDetails(check);
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

                    isFirst = 0;
                    do
                    {
                        Console.Write("Do you want to delete (Y/N): ");
                        string l = Console.ReadLine() ?? "";
                        if (l == "y" || l == "Y")
                        {
                            Console.WriteLine("You have successfully delete");
                            _DL.DeleteLoanSlipDetalis(loanSlipDetails);
                            isFirst = 1;
                        }
                        else if (l == "n" || l == "N")
                        {
                            Console.WriteLine("You do not agree to delete");
                            isFirst = 1;
                        }
                        else
                        {
                            Console.WriteLine("You entered wrong");
                        }

                    } while (isFirst != 1);
                }
                else
                {
                    Console.WriteLine("not exist");
                    isFirst = 1;
                }
            } while (isFirst != 1);



        }

        public void Restore()
        {
            Console.Clear();

            LoanSlipDetails loanSlipDetails = new LoanSlipDetails();

            int isFirst = 0;

            int status = 0;

            int status2 = 0;
            do
            {
                if (checkDisplaydetails(status, status2))
                {
                    DisplayLoanSlipDetails(status, status2);

                    do
                    {

                        Console.Write("Id Restore: ");
                        int Id = int.Parse(Console.ReadLine() ?? "");

                        if (CheckId(Id, status, status2))
                        {
                            string check = Convert.ToString(Id);
                            SearchLoanSlipDetails(check);
                            loanSlipDetails.id = Id;
                            isFirst = 1;

                            status = 1;
                            loanSlipDetails.status = status;
                        }

                    } while (isFirst != 1);

                    isFirst = 0;
                    do
                    {

                        Console.Write("Do you want to restore (Y/N): ");
                        string l = Console.ReadLine() ?? "";
                        if (l == "y" || l == "Y")
                        {
                            Console.WriteLine("You have successfully restore status");
                            _DL.DeleteLoanSlipDetalis(loanSlipDetails);
                            isFirst = 1;
                        }
                        else if (l == "n" || l == "N")
                        {
                            Console.WriteLine("You do not agree to restore status");
                            isFirst = 1;
                        }
                        else
                        {
                            Console.WriteLine("You entered wrong");
                        }

                    } while (isFirst != 1);
                }
                else
                {
                    Console.WriteLine("not exist");
                    isFirst = 1;
                }
            } while (isFirst != 1);

        }
        public void DisplayBook(int i)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where Status={i} ";

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "ID", "Book name", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],15} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void Sreach(string Search, string name)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where {Search}='{name}'";

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "ID", "Book name", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],15} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void DisplayLoanSlipDetails(int i, int status)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Status={i} or Status='{status}'";

            Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void DisplayLoanSlipDetailshistory()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details_history";

            Console.WriteLine(string.Format("| {0,15} | {0,5} | {1,15} | {2,10} | {3,12} |", "Data history id", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["data_history_id"],15} | {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void SearchLoanSlipDetails(string name)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Id={name}";

            Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void SreachDetails(string name)
        {
            int isFirst = 0;
            do
            {
                if (checksearch(name))
                {
                    Console.Clear();
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine("Library Management System ");
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

                    DBHelper.OpenConnection();

                    var query = $"SELECT * FROM Loan_slip_details Where Id={name} Status=1 or Status=2";

                    Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

                    using (MySqlDataReader reader = DBHelper.ExecQuery(query))
                    {
                        while (reader.Read())
                        {
                            string row = $"| {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

                            System.Console.WriteLine(row);
                        }
                    }
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("not exist details");
                    isFirst = 1;
                }
            } while (isFirst != 1);
        }
        bool checksearch(string name)
        {
            Console.Clear();

            DBHelper.OpenConnection();

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Id={name} Status=1 or Status=2";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false; ;
            }
        }
        bool CheckISBN(string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books where ISBN='{isbn}' and Status= 1";

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
        bool CheckId(int id, int status, int status2)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM loan_slip_details where Id='{id}' and Status='{status}' or Status='{status2}'";

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
        bool checkDisplaybook(int i)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where Status={i}";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],10} | {reader["Status"],10} |";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }

        }
        bool checkDisplaydetails(int i, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Status={i} or Status='{status}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],15} | {reader["Amount"],10} | {reader["Status"],12} |";

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
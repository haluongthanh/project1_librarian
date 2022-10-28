using System;
using code.BL;
using code.DL;
using code.Entities;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace code.BL
{
    public class LoanSlipService
    {
        private readonly LoanSlipDL _DL;

        public LoanSlipService()
        {
            _DL = new LoanSlipDL();
        }
        public void AddLoanSLip(string Mail)
        {
            try
            {
                Console.Clear();

                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("Create");
                Console.WriteLine("══════════════════════════════════════");

                LoanSlip loanSlip = new LoanSlip();

                string name;

                int status = 1;

                int status2 = 1;

                int isFirst = 0;

                do
                {
                    if (checkDisplayReaders(status))
                    {

                        DisplayReaders(status);

                        do
                        {

                            Console.Write("Id Readers: ");
                            name = "Readers";
                            int Id_Readers = int.Parse(Console.ReadLine() ?? "");
                            if (CheckId(name, Id_Readers, status))
                            {
                                name = "Id";
                                string check = Convert.ToString(Id_Readers);
                                SreachReaders(name, check);
                                loanSlip.Id_Readers = Id_Readers;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("id does not exist ");
                            }

                            int Id_Employee = CheckReadeers(Mail);
                            Console.WriteLine("Id Employee: " + Id_Employee);
                            loanSlip.Id_Employee = Id_Employee;

                            isFirst = 0;
                            if (checkDisplaydetails(status, status2))
                            {
                                DisplayLoanSlipDetails(status, status2);

                                do
                                {
                                    Console.Write("Id Loan Slip Details: ");
                                    name = "loan_slip_details";
                                    int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
                                    if (CheckId(name, Id_loan_slip_details, status))
                                    {
                                        string check = Convert.ToString(Id_loan_slip_details);
                                        SearchLoanSlipDetails(check);
                                        loanSlip.Id_loan_Slip_Details = Id_loan_slip_details;
                                        isFirst = 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("id does not exist ");
                                    }

                                } while (isFirst != 1);

                                isFirst = 0;
                                do
                                {
                                    Console.Write("Borrowed date: ");
                                    string date = Console.ReadLine() ?? "";
                                    if (checkdate(date))
                                    {
                                        loanSlip.Borrowed_date = DateTime.Parse(date);
                                        isFirst = 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("borrowed date Wrong format ");
                                    }


                                } while (isFirst != 1);

                                isFirst = 0;
                                do
                                {
                                    Console.Write("Pay day: ");
                                    string Pay_day = Console.ReadLine() ?? "";
                                    if (checkdate(Pay_day))
                                    {
                                        loanSlip.Pay_day = DateTime.Parse(Pay_day);
                                        isFirst = 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("pay day Wrong format ");
                                    }


                                } while (isFirst != 1);

                                status = 1;
                                loanSlip.status = status;

                                isFirst = 0;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("ID Readers:" + loanSlip.Id_Readers);
                                    Console.WriteLine("ID Employee: " + loanSlip.Id_Employee);
                                    Console.WriteLine("ID Loan Slip Details" + loanSlip.Id_loan_Slip_Details);
                                    Console.WriteLine("Borrowed date" + loanSlip.Borrowed_date);
                                    Console.WriteLine("Pay Day: " + loanSlip.Pay_day);
                                    Console.Write("Do you want to create (Y/N): ");
                                    string l = Console.ReadLine() ?? "";
                                    if (l == "y" || l == "Y")
                                    {
                                        status = 2;

                                        Console.WriteLine("You have successfully create");
                                        _DL.AddLoanSlip(loanSlip);
                                        UpdateStatus(loanSlip.Id_loan_Slip_Details, status);
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
                                Console.WriteLine("not exist database details");
                                isFirst = 1;
                            }

                        } while (isFirst != 1);

                    }
                    else
                    {
                        Console.WriteLine("not exist database readers");
                        isFirst = 1;
                    }
                } while (isFirst != 1);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void UpdateLoanSLip(string Mail)
        {
            try
            {
                Console.Clear();

                LoanSlip loanSlip = new LoanSlip();

                string name;

                int status = 1;

                int status2 = 2;

                int isFirst = 0;


                do
                {
                    if (checkDisplayLoánlip(status, status2))
                    {
                        DisplayLoanSlip(status, status2);

                        do
                        {
                            Console.Write("Id update: ");
                            name = "Loan_slip";
                            int Id = int.Parse(Console.ReadLine() ?? "");

                            if (CheckIdLoannSlip(name, Id, status, status2))
                            {
                                string check = Convert.ToString(Id);
                                Sreach(check, status, status2);
                                loanSlip.id = Id;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("id does not exist ");
                            }

                        } while (isFirst != 1);

                        if (checkDisplayReaders(status))
                        {
                            DisplayReaders(status);
                            do
                            {
                                DisplayReaders(status);
                                isFirst = 0;
                                do
                                {
                                    Console.Write("Update Id Readers: ");
                                    name = "Readers";
                                    int Id_Readers = int.Parse(Console.ReadLine() ?? "");
                                    if (CheckId(name, Id_Readers, status))
                                    {
                                        name = "Id";
                                        string check = Convert.ToString(Id_Readers);
                                        SreachReaders(name, check);
                                        loanSlip.Id_Readers = Id_Readers;
                                        isFirst = 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("id does not exist ");
                                    }

                                } while (isFirst != 1);


                                int Id_Employee = CheckReadeers(Mail);
                                Console.WriteLine("Id Employee: " + Id_Employee);
                                loanSlip.Id_Employee = Id_Employee;
                                if (checkDisplaydetails(status, status2))
                                {
                                    DisplayLoanSlipDetails(status, status2);
                                    isFirst = 0;
                                    do
                                    {
                                        Console.Write("Id Loan Slip Details: ");
                                        name = "loan_slip_details";
                                        int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
                                        if (CheckId(name, Id_loan_slip_details, status))
                                        {
                                            string check = Convert.ToString(Id_loan_slip_details);
                                            SearchLoanSlipDetails(check);
                                            loanSlip.Id_loan_Slip_Details = Id_loan_slip_details;
                                            isFirst = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("id does not exist ");
                                        }

                                    } while (isFirst != 1);

                                    isFirst = 0;
                                    do
                                    {
                                        Console.Write("Borrowed date: ");
                                        string date = Console.ReadLine() ?? "";
                                        if (checkdate(date))
                                        {
                                            loanSlip.Borrowed_date = DateTime.Parse(date);
                                            isFirst = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("borrowed date Wrong format ");
                                        }


                                    } while (isFirst != 1);

                                    isFirst = 0;
                                    do
                                    {
                                        Console.Write("Pay day: ");
                                        string Pay_day = Console.ReadLine() ?? "";
                                        if (checkdate(Pay_day))
                                        {
                                            loanSlip.Pay_day = DateTime.Parse(Pay_day);
                                            isFirst = 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("pay day Wrong format ");
                                        }


                                    } while (isFirst != 1);

                                    status = 1;
                                    loanSlip.status = status;

                                    isFirst = 0;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("ID Readers:" + loanSlip.Id_Readers);
                                        Console.WriteLine("ID Employee: " + loanSlip.Id_Employee);
                                        Console.WriteLine("ID Loan Slip Details" + loanSlip.Id_loan_Slip_Details);
                                        Console.WriteLine("Borrowed date" + loanSlip.Borrowed_date);
                                        Console.WriteLine("Pay Day: " + loanSlip.Pay_day);
                                        Console.Write("Do you want to create (Y/N): ");
                                        string l = Console.ReadLine() ?? "";
                                        if (l == "y" || l == "Y")
                                        {
                                            status = 2;

                                            Console.WriteLine("You have successfully create");
                                            _DL.AddLoanSlip(loanSlip);
                                            UpdateStatus(loanSlip.Id_loan_Slip_Details, status);
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
                                    Console.WriteLine("not exist database details");
                                }

                            } while (isFirst != 1);

                        }
                        else
                        {
                            Console.WriteLine("not exist database readers");
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("not exist database loan slip");
                        isFirst = 1;
                    }

                } while (isFirst != 1);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void Status()
        {
            try
            {
                Console.Clear();

                LoanSlip loanSlip = new LoanSlip();

                string name;

                int isFirst = 0;

                int status = 1;

                int status2 = 1;


                do
                {
                    if (checkDisplayLoánlip(status, status))
                    {
                        DisplayLoanSlip(status, status);

                        int Id;
                        do
                        {

                            Console.Write("Id update status: ");

                            name = "Loan_slip";
                            Id = int.Parse(Console.ReadLine() ?? "");


                            if (CheckIdLoannSlip(name, Id, status, status2))
                            {
                                string check = Convert.ToString(Id);
                                Sreach(check, status, status2);

                                loanSlip.id = Id;
                                isFirst = 1;

                                status = 2;
                                loanSlip.status = status;
                            }
                            else
                            {
                                Console.WriteLine("Id does not exist");
                            }

                        } while (isFirst != 1);

                        isFirst = 0;
                        do
                        {

                            Console.Write("Do you want to update status (Y/N): ");
                            string l = Console.ReadLine() ?? "";
                            if (l == "y" || l == "Y")
                            {
                                int a = CheckIddetails(Id, status);
                                int b = CheckAmountdetails(a, status);
                                string c = CheckISBNdetails(a);
                                int d = CheckAmonutBook(c);
                                d = b + d;
                                UpdateAmountBook(d, c);
                                _DL.DeleteLoanSlip(loanSlip);
                                Console.WriteLine("You have successfully update status ");
                                isFirst = 1;
                            }
                            else if (l == "n" || l == "N")
                            {
                                Console.WriteLine("You do not agree to update status");
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
                        Console.WriteLine("not exist database loan slip");
                        isFirst = 1;
                    }
                } while (isFirst != 1);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void DeleteLoanSlip()
        {
            Console.Clear();

            LoanSlip loanSlip = new LoanSlip();

            string name;

            int isFirst = 0;

            int status = 1;

            int status2 = 2;

            DisplayLoanSlip(status, status2);

            do
            {

                Console.Write("Id Delete: ");

                name = "Loan_slip";
                int Id = int.Parse(Console.ReadLine() ?? "");


                if (CheckIdLoannSlip(name, Id, status, status2))
                {
                    string check = Convert.ToString(Id);
                    Sreach(check, status, status2);
                    loanSlip.id = Id;
                    isFirst = 1;

                    status = 0;
                    loanSlip.status = status;
                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to delete (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully delete ");
                    _DL.DeleteLoanSlip(loanSlip);
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
        public void Restore()
        {
            Console.Clear();

            LoanSlip loanSlip = new LoanSlip();

            string name;

            int isFirst = 0;

            int status = 0;

            int status2 = 0;

            DisplayLoanSlip(status, status2);

            do
            {

                Console.Write("Id Restore: ");
                name = "Loan_slip";

                int Id = int.Parse(Console.ReadLine() ?? "");


                if (CheckIdLoannSlip(name, Id, status, status2))
                {
                    string check = Convert.ToString(Id);
                    Sreach(check, status, status2);
                    loanSlip.id = Id;
                    isFirst = 1;

                    status = 1;
                    loanSlip.status = status;
                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to restore (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully restore ");
                    _DL.DeleteLoanSlip(loanSlip);
                    isFirst = 1;
                }
                else if (l == "n" || l == "N")
                {
                    Console.WriteLine("You do not agree to restore");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("You entered wrong");
                }

            } while (isFirst != 1);
        }
        public void DisplayReaders(int i)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Readers Where Status='{i}'";

            Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,13} | {3,15} | {4,27} | {5,10} | {6,10} |", "ID", "Readers Name", "Address", "Phone", "Email", "Password", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Readers_name"],15} | {reader["Address"],13} | {reader["phone"],15} | {reader["Email"],27} | {reader["Password"],10} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void SreachReaders(string Search, string name)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Readers Where {Search}='{name}'";

            Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,13} | {3,15} | {4,27} | {5,10} | {6,10} |", "ID", "Readers Name", "Address", "Phone", "Email", "Password", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Readers_name"],15} | {reader["Address"],13} | {reader["phone"],15} | {reader["Email"],27} | {reader["Password"],10} | {reader["Status"],10} |";

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

            Console.WriteLine(string.Format("| {0,10} | {1,13} | {2,10} | {3,20} | {4,20} | {5,10} | {6,10} |", "ID", "Book name", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],10} | {reader["Title"],13} | {reader["Author"],10} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],10} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void DisplayLoanSlipDetails(int i, int status)
        {
            // Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_details Where Status={i} or Status={status}";

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],13} | {reader["Amount"],10} | {reader["Status"],12} |";

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

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} |", "ID", "ID ISBN ", "Amount", "Status"));

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Isbn"],13} | {reader["Amount"],10} | {reader["Status"],12} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void DisplayLoanSlip(int i, int status)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Status={i} or Status={status}";

            Console.WriteLine(string.Format("| {0,5} | {1,10} | {2,15} | {3,20} | {4,25} | {5,25} | {6,15} |", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void DisplayLoanSliphistory()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip_history";

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,10} | {3,15} | {4,20} | {5,25} | {6,25} | {7,15} |", "Data history id", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["data_history_id"],15} | {reader["Id"],15} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void Sreach(string name, int status, int status1)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Id='{name}' and Status={status} or Status={status1}";

            Console.WriteLine(string.Format("| {0,5} | {1,10} | {2,15} | {3,20} | {4,25} | {5,25} | {6,15} |", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
        }
        public void Sreachloanslip(string name)
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

                    var query = $"SELECT * FROM Loan_slip Where Id='{name}'";

                    Console.WriteLine(string.Format("| {0,5} | {1,10} | {2,15} | {3,20} | {4,25} | {5,25} | {6,15} |", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
                    using (MySqlDataReader reader = DBHelper.ExecQuery(query))
                    {
                        while (reader.Read())
                        {
                            string row = $"| {reader["Id"],5} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                            System.Console.WriteLine(row);
                        }
                    }
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("not exist employee");
                    isFirst = 1;
                }
            } while (isFirst != 1);
        }
        bool checksearch(string name)
        {
            Console.Clear();

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Id='{name}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false; ;
            }
        }
        bool CheckId(string name, int id, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Id='{id}' and Status='{status}'";

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
        bool CheckIdLoannSlip(string name, int id, int status, int status2)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Id='{id}' and Status='{status}' or Status='{status2}'";

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
        int CheckReadeers(string Email)
        {

            DBHelper.OpenConnection();

            int choice = 0;

            var query = $"SELECT * FROM Employees where Email='{Email}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Id"]}";

                    if (row != null)
                    {
                        choice = int.Parse(row);
                    }
                }

            }
            return choice;
        }
        int CheckIddetails(int id, int status)
        {
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM loan_slip where Id='{id}' and Status='{status}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Id_loan_slip_details"]}";

                    if (row != null)
                    {
                        id = int.Parse(row);

                    }
                }
            }
            return id;
        }
        int CheckAmountdetails(int id, int status)
        {
            DBHelper.OpenConnection();

            int amount = 0;

            var query = $"SELECT * FROM loan_slip_details where Id='{id}' and Status='{status}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Amount"]}";

                    if (row != null)
                    {
                        amount = int.Parse(row);

                    }
                }
            }
            return amount;
        }
        string CheckISBNdetails(int id)
        {
            DBHelper.OpenConnection();

            string name = "";

            var query = $"SELECT * FROM loan_slip_details where Id='{id}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Isbn"]}";

                    if (row != null)
                    {
                        name = row;
                    }
                }
                return name;

            }
        }
        int CheckAmonutBook(string isbn)
        {
            DBHelper.OpenConnection();

            int amount = 0;

            var query = $"SELECT * FROM Books where ISBN='{isbn}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {

                    string row = $"{reader["Amount"]}";

                    if (row != null)
                    {
                        amount = int.Parse(row);
                    }
                }
            }
            return amount;


        }
        public void UpdateAmountBook(int amount, string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"update ignore books set Amount={amount} where ISBN='{isbn}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { }
        }
        bool UpdateStatus(int id, int status)
        {

            DBHelper.OpenConnection();

            var query = $"update ignore loan_slip_details set Status={status} where Id='{id}'";

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
        bool checkdate(string date)
        {
            //(19|20)
            string motif = "[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
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

        bool checkDisplayLoánlip(int i, int status)
        {
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Status={i} or Status={status}";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],10} | {reader["Id_Employee"],15} | {reader["Id_loan_slip_details"],20} | {reader["Borrowed_date"],25} | {reader["Pay_day"],25} | {reader["Status"],15}|";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        bool checkDisplayReaders(int i)
        {
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Readers Where Status='{i}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Readers_name"],15} | {reader["Address"],13} | {reader["phone"],15} | {reader["Email"],27} | {reader["Password"],10} | {reader["Status"],10} |";

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

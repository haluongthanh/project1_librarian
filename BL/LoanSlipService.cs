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
                LoanSlip loanSlip = new LoanSlip();

                string name;

                int status = 1;

                int isFirst = 0;

                do
                {
                    Console.Write("Id Readers: ");
                    name = "Readers";
                    int Id_Readers = int.Parse(Console.ReadLine() ?? "");
                    if (CheckId(name, Id_Readers, status))
                    {
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

                isFirst = 0;
                do
                {
                    Console.Write("Id Loan Slip Details: ");
                    name = "loan_slip_details";
                    int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
                    if (CheckId(name, Id_loan_slip_details, status))
                    {
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

                _DL.AddLoanSlip(loanSlip);

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

                int isFirst = 0;

                do
                {
                    Console.Write("Id update: ");
                    name = "Loan_slip";
                    int Id = int.Parse(Console.ReadLine() ?? "");

                    if (CheckId(name, Id, status))
                    {
                        loanSlip.id = Id;
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
                    Console.Write("Id Readers: ");
                    name = "Readers";
                    int Id_Readers = int.Parse(Console.ReadLine() ?? "");
                    if (CheckId(name, Id_Readers, status))
                    {
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

                isFirst = 0;
                do
                {
                    Console.Write("Id Loan Slip Details: ");
                    name = "loan_slip_details";
                    int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
                    if (CheckId(name, Id_loan_slip_details, status))
                    {
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
                    string date = Console.ReadLine() ?? "";
                    if (checkdate(date))
                    {
                        loanSlip.Pay_day = DateTime.Parse(date);
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("pay day Wrong format ");
                    }


                } while (isFirst != 1);


                _DL.UpdateLoanSlip(loanSlip);

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

                do
                {
                    Console.Write("Id : ");

                    name = "Loan_slip";
                    int Id = int.Parse(Console.ReadLine() ?? "");
                    int status = 1;

                    if (CheckId(name, Id, status))
                    {
                        name = "Loan_slip_details";
                        status = 2;
                        if (CheckId(name, Id, status))
                        {
                            loanSlip.id = Id;
                            isFirst = 1;

                            status = 2;
                            loanSlip.status = status;
                        }
                        else
                        {
                            Console.WriteLine("id does not exist or loan slip details have not been updated to the paid in full status ");
                        }


                    }

                } while (isFirst != 1);

                _DL.DeleteLoanSlip(loanSlip);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void MenuUpdate()
        {
            try
            {
                Console.Clear();
                LoanSlip loanSlip = new LoanSlip();

                int isFirst = 0;

                int status = 1;

                int id;

                string name;

                string name1;

                do
                {
                    Console.Write("Id update: ");
                    id = int.Parse(Console.ReadLine() ?? "");
                    status = 1;
                    name1 = "Loan_Slip";

                    if (CheckId(name1, id, status))
                    {
                        string i = Convert.ToString(id);
                        Sreach(i);
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("id does not exist");
                    }

                } while (isFirst != 1);

                int choice;
                do
                {
                    Console.WriteLine("1.ID Readers");
                    Console.WriteLine("2.ID Loan Slip Details");
                    Console.WriteLine("3.Borrowed date");
                    Console.WriteLine("4.Pay Day");
                    choice = int.Parse(Console.ReadLine() ?? "");
                    switch (choice)
                    {
                        case 1:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Id Readers: ");
                                name = "Readers";
                                int Id_Readers = int.Parse(Console.ReadLine() ?? "");
                                if (CheckId(name, Id_Readers, status))
                                {
                                    name1 = "Id_Readers";
                                    string i = Convert.ToString(Id_Readers);
                                    updatedata(name1, i, id);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("id does not exist ");
                                }

                            } while (isFirst != 1);
                            break;
                        case 2:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Id Loan Slip Details: ");
                                name = "loan_slip_details";
                                int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
                                if (CheckId(name, Id_loan_slip_details, status))
                                {
                                    name1 = "Id_loan_slip_details";
                                    string i = Convert.ToString(Id_loan_slip_details);
                                    updatedata(name1, i, id);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("id does not exist ");
                                }

                            } while (isFirst != 1);
                            break;
                        case 3:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Borrowed date: ");
                                string date = Console.ReadLine() ?? "";
                                if (checkdate(date))
                                {
                                    name1 = "Borrowed_date";
                                    updatedata(name1, date, id);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("borrowed date wrong format");
                                }


                            } while (isFirst != 1);
                            break;
                        case 4:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Pay day: ");
                                string date = Console.ReadLine() ?? "";
                                if (checkdate(date))
                                {
                                    name1 = "Pay_day";
                                    updatedata(name1, date, id);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("pay day wrong format");
                                }

                            } while (isFirst != 1);
                            break;
                        default:
                            MenuUpdate();
                            break;
                    }
                } while (choice != 0);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void updatedata(string name, string name1, int id)
        {
            DBHelper.OpenConnection();

            var query = $"update ignore loan_slip set {name}='{name1}' where Id = {id}; ";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
        }
        public void DeleteLoanSlip()
        {
            Console.Clear();
            LoanSlip loanSlip = new LoanSlip();
            string name;

            int isFirst = 0;

            do
            {
                Console.Write("Id Delte: ");

                name = "Loan_slip";
                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 1;

                if (CheckId(name, Id, status))
                {
                    loanSlip.id = Id;
                    isFirst = 1;

                    status = 0;
                    loanSlip.status = status;
                }

            } while (isFirst != 1);

            _DL.DeleteLoanSlip(loanSlip);
        }
        public void Restore()
        {
            Console.Clear();
            LoanSlip loanSlip = new LoanSlip();
            string name;

            int isFirst = 0;

            do
            {
                Console.Write("Id Restore: ");
                name = "Loan_slip";

                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 0;

                if (CheckId(name, Id, status))
                {
                    loanSlip.id = Id;
                    isFirst = 1;

                    status = 1;
                    loanSlip.status = status;
                }

            } while (isFirst != 1);

            _DL.DeleteLoanSlip(loanSlip);
        }
        public void DisplayLoanSlip(int i)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Status={i}";

            Console.WriteLine(string.Format("| {0,5} | {1,5} | {2,5} | {3,5} | {4,15} | {5,15} | {6,10} |", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],5} | {reader["Id_Employee"],5} | {reader["Id_loan_slip_details"]} | {reader["Borrowed_date"],15} | {reader["Pay_day"],15} | {reader["Status"],10}|";

                    System.Console.WriteLine(row);
                }
            }
        }
        public void Sreach(string name)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Loan_slip Where Id='{name}'";

            Console.WriteLine(string.Format("| {0,5} | {1,5} | {2,5} | {3,5} | {4,15} | {5,15} | {6,10} |", "ID", "Id Readers", "Id Employee", "Id loan slip details", "Borrowed date", "Pay day", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Id_Readers"],5} | {reader["Id_Employee"],5} | {reader["Id_loan_slip_details"]} | {reader["Borrowed_date"],15} | {reader["Pay_day"],15} | {reader["Status"],10}|";

                    System.Console.WriteLine(row);
                }
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
        int CheckReadeers(string Email)
        {

            DBHelper.OpenConnection();

            int choice = 0;

            var query = $"SELECT * FROM Employee where Email='{Email}' and Status=1";

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

        bool checkdate(string date)
        {
            //(19|20)
            string motif = "[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
        }
    }
}
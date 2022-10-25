using System;
using code.BL;
using code.DL;
using code.Entities;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace code.BL
{
    public class EmployeeService
    {
        private readonly EmployeeDL _repo;

        public EmployeeService()
        {
            _repo = new EmployeeDL();
        }
        public void AddEmployee()
        {
            try
            {
                Console.Clear();

                Employee employee = new Employee();

                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("Create");
                Console.WriteLine("══════════════════════════════════════");


                int isFirst = 0;
                do
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine() ?? "";
                    if (IsNameNbr(name))
                    {
                        employee.Name = name;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Name wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("Address: ");
                    string Address = Console.ReadLine() ?? "";
                    employee.Address = Address;
                    isFirst = 1;

                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Readers";
                    string names = "Employees";

                    Console.Write("Phone Number: ");
                    string Phone = Console.ReadLine() ?? "";
                    if (IsPhoneNbr(Phone))
                    {
                        if (checkPhone(Phone, name))
                        {
                            Console.WriteLine("phone number already exist");
                        }
                        else if (checkPhone(Phone, names))
                        {
                            Console.WriteLine("phone number already exist");
                        }
                        else
                        {
                            employee.Phone = Phone;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("phone number wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Readers";
                    string names = "Employees";

                    Console.Write("Email: ");
                    string Email = Console.ReadLine() ?? "";
                    if (IsValidEmail(Email))
                    {
                        if (checkEmail(Email, name))
                        {
                            Console.Write("Email already exist");
                        }
                        else if (checkEmail(Email, names))
                        {
                            Console.Write("Email already exist");
                        }
                        else
                        {
                            employee.Email = Email;
                            isFirst = 1;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Email wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("Password: ");
                    var pass = string.Empty;
                    ConsoleKey key;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;

                        if (key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            Console.Write("\b \b");
                            pass = pass[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            pass += keyInfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);

                    string Password = pass;
                    if (IsPassWordNbr(Password))
                    {
                        employee.Password = Password;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Password wrong format");
                    }
                } while (isFirst != 1);



                int status = 1;

                employee.Position = status;
                employee.status = status;

                isFirst = 0;
                do
                {

                    Console.Write("Do you want to create (Y/N): ");
                    string l = Console.ReadLine() ?? "";
                    if (l == "y" || l == "Y")
                    {
                        Console.WriteLine("You have successfully create");
                        _repo.AddEmployee(employee);
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
            catch (System.Exception)
            {

                throw;
            }
        }
        public void UpdateEmployee()
        {
            try
            {
                Console.Clear();

                Employee employee = new Employee();

                int isFirst = 0;

                int id;

                int status = 1;

                DisplayEmployee(status);

                do
                {
                    Console.Write("ID Update: ");
                    id = int.Parse(Console.ReadLine() ?? "");
                    string name = "Id";

                    if (CheckId(id, status))
                    {
                        string i = Convert.ToString(id);
                        Sreach(name, i);
                        employee.Id = id;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Id khong ton tai");
                    }

                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("Update Name: ");
                    string name = Console.ReadLine() ?? "";
                    if (IsNameNbr(name))
                    {
                        employee.Name = name;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Name wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("Update Address: ");
                    string Address = Console.ReadLine() ?? "";
                    employee.Address = Address;
                    isFirst = 1;
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Employees";
                    string names = "Readers";

                    Console.Write("Update Phone: ");
                    string Phone = Console.ReadLine() ?? "";
                    if (IsPhoneNbr(Phone))
                    {
                        if (checkPhoneUpdate(id, Phone, name))
                        {
                            employee.Phone = Phone;
                            isFirst = 1;
                        }
                        else if (checkPhoneUpdate(id, Phone, names))
                        {
                            employee.Phone = Phone;
                            isFirst = 1;
                        }
                        else if (checkPhone(Phone, name))
                        {
                            Console.WriteLine("phone da ton tai");
                        }
                        else if (checkPhone(Phone, name))
                        {
                            Console.WriteLine("phone da ton tai");
                        }
                        else
                        {
                            employee.Phone = Phone;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("phone sai dinh dang");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Employees";
                    string names = "Readers";

                    Console.Write("Update Email: ");
                    string Email = Console.ReadLine() ?? "";
                    if (IsValidEmail(Email))
                    {
                        if (checkEmailUpdate(id, Email, name))
                        {
                            employee.Email = Email;
                            isFirst = 1;
                        }
                        else if (checkEmailUpdate(id, Email, names))
                        {
                            employee.Email = Email;
                            isFirst = 1;
                        }
                        else if (checkEmail(Email, name))
                        {
                            Console.Write("Email đã tồn tại");
                        }
                        else if (checkEmail(Email, name))
                        {
                            Console.Write("Email đã tồn tại");
                        }
                        else
                        {
                            employee.Email = Email;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.Write("email sai dinh dang");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    Console.Write("Update Password: ");
                    var pass = string.Empty;
                    ConsoleKey key;
                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;

                        if (key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            Console.Write("\b \b");
                            pass = pass[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            pass += keyInfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);

                    string Password = pass;
                    if (IsPassWordNbr(Password))
                    {
                        employee.Password = Password;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Password wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {

                    Console.Write("Do you want to Update (Y/N): ");
                    string l = Console.ReadLine() ?? "";
                    if (l == "y" || l == "Y")
                    {
                        Console.WriteLine("You have successfully update");
                        _repo.UpdateEmployee(employee);
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
            catch (System.Exception)
            {

                throw;
            }
        }

        public void DeleteEmployee()
        {
            Console.Clear();

            Employee employee = new Employee();

            int isFirst = 0;

            int status = 1;

            DisplayEmployee(status);

            do
            {

                Console.Write("ID Delete: ");
                int Id = int.Parse(Console.ReadLine() ?? "");
                string name = "Id";
                if (CheckId(Id, status))
                {
                    string i = Convert.ToString(Id);
                    Sreach(name, i);
                    employee.Id = Id;
                    isFirst = 1;

                    status = 0;
                    employee.status = status;
                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to Delete (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully Delete");
                    _repo.DeleteEmployee(employee);
                    isFirst = 1;
                }
                else if (l == "n" || l == "N")
                {
                    Console.WriteLine("You do not agree to Delete");
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

            Employee employee = new Employee();

            int isFirst = 0;

            int status = 0;

            DisplayEmployee(status);

            do
            {

                Console.Write("ID Restore: ");
                int Id = int.Parse(Console.ReadLine() ?? "");
                string name = "Id";

                if (CheckId(Id, status))
                {
                    string i = Convert.ToString(Id);
                    Sreach(name, i);
                    employee.Id = Id;
                    isFirst = 1;

                    status = 1;
                    employee.status = status;
                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to Restore (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully Restore");
                    _repo.DeleteEmployee(employee);
                    isFirst = 1;
                }
                else if (l == "n" || l == "N")
                {
                    Console.WriteLine("You do not agree to Restore");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("You entered wrong");
                }

            } while (isFirst != 1);

        }
        public void ChangePassword(string Mail)
        {
            Console.Clear();

            Employee employee = new Employee();

            int isFirst = 0;

            do
            {
                Console.Write("Input old password: ");

                var pass = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        Console.Write("\b \b");
                        pass = pass[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pass += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                string Password = pass;

                if (CheckPassword(Mail, Password))
                {
                    Console.Write("Input your new password: ");

                    pass = string.Empty;

                    do
                    {
                        var keyInfo = Console.ReadKey(intercept: true);
                        key = keyInfo.Key;

                        if (key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            Console.Write("\b \b");
                            pass = pass[0..^1];
                        }
                        else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            pass += keyInfo.KeyChar;
                        }
                    } while (key != ConsoleKey.Enter);

                    Password = pass;

                    if (IsPassWordNbr(Password))
                    {
                        Console.Write("Confirm your new password: ");

                        pass = string.Empty;

                        do
                        {
                            var keyInfo = Console.ReadKey(intercept: true);
                            key = keyInfo.Key;

                            if (key == ConsoleKey.Backspace && pass.Length > 0)
                            {
                                Console.Write("\b \b");
                                pass = pass[0..^1];
                            }
                            else if (!char.IsControl(keyInfo.KeyChar))
                            {
                                Console.Write("*");
                                pass += keyInfo.KeyChar;
                            }
                        } while (key != ConsoleKey.Enter);

                        string Password1 = pass;

                        if (Password == Password1)
                        {
                            employee.Email = Mail;
                            employee.Password = Password1;
                            isFirst = 1;
                        }
                        else
                        {
                            Console.WriteLine("confirm your new password is incorrect");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Password wrong format");
                    }
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to Change Password (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully Change Password");
                    _repo.ChangePassword(employee);
                    isFirst = 1;
                }
                else if (l == "n" || l == "N")
                {
                    Console.WriteLine("You do not agree to Change Password");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("You entered wrong");
                }

            } while (isFirst != 1);

        }
        public void decentralization()
        {
            Console.Clear();

            Employee employee = new Employee();

            int isFirst = 0;

            int status = 1;

            DisplayEmployee(status);

            do
            {

                Console.Write("ID decentralization: ");
                int Id = int.Parse(Console.ReadLine() ?? "");
                string name = "Id";

                if (CheckId(Id, status))
                {
                    string a = Convert.ToString(Id);
                    Sreach(name, a);

                    Console.WriteLine("1.Admin\n2.Staff");
                    Console.Write("Your choice:");
                    int choice = int.Parse(Console.ReadLine() ?? "");

                    switch (choice)
                    {
                        case 1:
                            employee.Id = Id;
                            isFirst = 1;
                            int i = 0;
                            employee.Position = i;
                            break;
                        case 2:
                            employee.Id = Id;
                            isFirst = 1;
                            int q = 1;
                            employee.Position = q;
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Id does not exist");
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("Do you want to decentralization (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully decentralization");
                    _repo.decentralization(employee);
                    isFirst = 1;
                }
                else if (l == "n" || l == "N")
                {
                    Console.WriteLine("You do not agree to decentralization");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("You entered wrong");
                }

            } while (isFirst != 1);

        }
        public void DisplayEmployee(int i)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Employees Where Status={i}";
            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} | {4,22} | {5,12} | {6,10} |", "ID", "Employee name ", "Address", "Phone", "Email", "Password", "Status"));


            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Employee_name"],14} | {reader["Address"],10} | {reader["phone"],12} | {reader["Email"],22} | {reader["Password"],12} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
        }
        public void Sreach(string Search, string name)
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Employees Where {Search}={name} Status=1";

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} | {4,22} | {5,12} | {6,10} |", "ID", "Employee name ", "Address", "Phone", "Email", "Password", "Status"));


            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Employee_name"],14} | {reader["Address"],10} | {reader["phone"],12} | {reader["Email"],22} | {reader["Password"],12} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
        }
        bool IsNameNbr(string name)
        {
            string motif = "^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$";

            if (name != null) return Regex.IsMatch(name, motif);
            else return false;

        }
        bool IsPassWordNbr(string password)
        {
            string motif = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

            if (password != null) return Regex.IsMatch(password, motif);
            else return false;

        }
        bool IsValidEmail(string email)
        {
            string motif = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            if (email != null) return Regex.IsMatch(email, motif);
            else return false;
        }
        bool IsPhoneNbr(string number)
        {
            string motif = "(84|0[3|5|7|8|9])+([0-9]{8})";

            if (number != null) return Regex.IsMatch(number, motif);
            else return false;
        }
        bool checkEmail(string Mail, string name)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Email='{Mail}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Email"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        bool checkEmailUpdate(int id, string Mail, string name)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Id ={id} and Email='{Mail}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Email"]}";

                    if (row == Mail)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        bool checkPhone(string Phone, string name)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Phone='{Phone}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Phone"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        bool checkPhoneUpdate(int id, string Phone, string name)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM {name} where Id ={id} and Phone='{Phone}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Phone"]}";

                    if (row == Phone)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        bool CheckPassword(string Mail, string password)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Employees where Email='{Mail}' and Password='{password}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Email"]}{reader["Password"]}";

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

            var query = $"SELECT * FROM Employees where Id='{id}' and  Status={status}";

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
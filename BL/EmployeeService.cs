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

                Employee employee = new Employee();

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
                    string names = "Employee";

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
                    string names = "Employee";

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
                    string Password = Console.ReadLine() ?? "";
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

                _repo.AddEmployee(employee);
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
                Employee employee = new Employee();

                int isFirst = 0;
                int id;

                do
                {
                    Console.Write("ID Update: ");
                    id = int.Parse(Console.ReadLine() ?? "");
                    int status = 1;
                    if (CheckId(id, status))
                    {
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
                    string name = "Employee";
                    string names = "Readers";

                    Console.Write("Phone: ");
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
                    string name = "Employee";
                    string names = "Readers";

                    Console.Write("Email: ");
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
                    Console.Write("Password: ");
                    string Password = Console.ReadLine() ?? "";
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

                _repo.UpdateEmployee(employee);
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
                Employee employee = new Employee();

                int isFirst = 0;

                int id;

                string name1, Search;

                do
                {
                    Console.Write("Id update: ");
                    id = int.Parse(Console.ReadLine() ?? "");
                    int status = 1;

                    if (CheckId(id, status))
                    {
                        isFirst = 1;
                        Search = "Id";
                        name1 = Convert.ToString(id);
                        Sreach(Search, name1);
                    }
                    else
                    {
                        Console.WriteLine("id does not exist");
                    }

                } while (isFirst != 1);
                int choice;

                do
                {
                    Console.WriteLine("1.Name");
                    Console.WriteLine("2.Address");
                    Console.WriteLine("3.Phone");
                    Console.WriteLine("4.Email");
                    Console.WriteLine("5.Password");
                    Console.WriteLine("0.Ẽit");
                    Console.WriteLine("Your choice:");
                    choice = int.Parse(Console.ReadLine() ?? "");
                    switch (choice)
                    {
                        case 1:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Name: ");
                                string name = Console.ReadLine() ?? "";
                                if (IsNameNbr(name))
                                {
                                    name1 = "Employee_name";
                                    updatedata(name1, name, id);
                                    isFirst = 1;

                                }
                                else
                                {
                                    Console.WriteLine("Name wrong format");
                                }
                            } while (isFirst != 1);
                            break;
                        case 2:
                            isFirst = 0;
                            do
                            {
                                Console.Write("Address: ");
                                string Address = Console.ReadLine() ?? "";
                                isFirst = 1;
                                name1 = "Address";
                                updatedata(name1, Address, id);

                            } while (isFirst != 1);
                            break;
                        case 3:
                            isFirst = 0;
                            do
                            {
                                string name = "Employee";
                                string names = "Readers";
                                name1 = "Phone";

                                Console.Write("Phone: ");
                                string Phone = Console.ReadLine() ?? "";
                                if (IsPhoneNbr(Phone))
                                {
                                    if (checkPhoneUpdate(id, Phone, name))
                                    {
                                        updatedata(name1, Phone, id);
                                        isFirst = 1;
                                    }
                                    else if (checkPhoneUpdate(id, Phone, names))
                                    {
                                        updatedata(name1, Phone, id);
                                        isFirst = 1;
                                    }
                                    else if (checkPhone(Phone, name))
                                    {
                                        Console.WriteLine("phone already exist");
                                    }
                                    else if (checkPhone(Phone, name))
                                    {
                                        Console.WriteLine("phone already exist");
                                    }
                                    else
                                    {
                                        updatedata(name1, Phone, id);
                                        isFirst = 1;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("phone wrong format");
                                }
                            } while (isFirst != 1);
                            break;
                        case 4:
                            isFirst = 0;
                            do
                            {
                                string name = "Employee";
                                string names = "Readers";
                                name1 = "Email";

                                Console.Write("Email: ");
                                string Email = Console.ReadLine() ?? "";
                                if (IsValidEmail(Email))
                                {
                                    if (checkEmailUpdate(id, Email, name))
                                    {
                                        updatedata(name1, Email, id);
                                        isFirst = 1;
                                    }
                                    else if (checkEmailUpdate(id, Email, names))
                                    {
                                        updatedata(name1, Email, id);
                                        isFirst = 1;
                                    }
                                    else if (checkEmail(Email, name))
                                    {
                                        Console.Write("Email already exist");
                                    }
                                    else if (checkEmail(Email, name))
                                    {
                                        Console.Write("Email already existi");
                                    }
                                    else
                                    {
                                        updatedata(name1, Email, id);
                                        isFirst = 1;
                                    }
                                }
                                else
                                {
                                    Console.Write("email wrong format");
                                }
                            } while (isFirst != 1);
                            break;
                        case 5:
                            isFirst = 0;
                            do
                            {
                                name1 = "Password";
                                Console.Write("Password: ");
                                string Password = Console.ReadLine() ?? "";
                                if (IsPassWordNbr(Password))
                                {
                                    updatedata(name1, Password, id);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Password wrong format");
                                }
                            } while (isFirst != 1);
                            break;
                        default:
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

            var query = $"update ignore Employee set {name}='{name1}' where Id = {id}; ";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
        }
        public void DeleteEmployee()
        {
            Employee employee = new Employee();

            int isFirst = 0;

            do
            {
                Console.Write("ID Delete: ");
                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 1;
                if (CheckId(Id, status))
                {
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

            _repo.DeleteEmployee(employee);
        }
        public void Restore()
        {
            Employee employee = new Employee();

            int isFirst = 0;

            do
            {
                Console.Write("ID Restore: ");

                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 0;

                if (CheckId(Id, status))
                {
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

            _repo.DeleteEmployee(employee);
        }
        public void ChangePassword(string Mail)
        {
            Employee employee = new Employee();

            int isFirst = 0;

            do
            {
                Console.Write("Input old password: ");

                string Password = Console.ReadLine() ?? "";

                if (CheckPassword(Mail, Password))
                {
                    Console.Write("Input your new password: ");

                    Password = Console.ReadLine() ?? "";

                    if (IsPassWordNbr(Password))
                    {
                        Console.Write("Confirm your new password: ");

                        string Password1 = Console.ReadLine() ?? "";

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

            _repo.ChangePassword(employee);
        }
        public void decentralization()
        {
            Employee employee = new Employee();

            int isFirst = 0;

            do
            {
                Console.Write("ID decentralization: ");
                int Id = int.Parse(Console.ReadLine() ?? "");
                int status = 1;
                if (CheckId(Id, status))
                {
                    Console.WriteLine("1.Admin\n2.Staff");
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


            _repo.decentralization(employee);
        }
        public void DisplayEmployee(int i)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Librarian");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Employee Where Status={i}";
            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} | {4,22} | {5,12} | {6,10} |", "ID", "Employee name ", "Address", "Phone", "Email", "Password", "Status"));


            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Employee_name"],13} | {reader["Address"],10} | {reader["phone"],12} | {reader["Email"],22} | {reader["Password"],12} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
        }
        public void Sreach(string Search, string name)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("LiBrarian");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Employee Where {Search}={name}";

            Console.WriteLine(string.Format("| {0,5} | {1,13} | {2,10} | {3,12} | {4,22} | {5,12} | {6,10} |", "ID", "Employee name ", "Address", "Phone", "Email", "Password", "Status"));


            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["Id"],5} | {reader["Employee_name"],13} | {reader["Address"],10} | {reader["phone"],12} | {reader["Email"],22} | {reader["Password"],12} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
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

            var query = $"SELECT * FROM Readers where Email='{Mail}' and Password='{password}'";

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

            var query = $"SELECT * FROM Employee where Id='{id}' and  Status={status}";

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
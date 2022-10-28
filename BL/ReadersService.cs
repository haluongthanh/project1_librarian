using System;
using code.BL;
using code.DL;
using code.Entities;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace code.BL
{
    public class ReadersService
    {
        private readonly ReadersDL _DL;

        public ReadersService()
        {
            _DL = new ReadersDL();
        }
        public void AddReaders()
        {
            try
            {
                Console.Clear();

                Readers readers = new Readers();

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
                        readers.Name = name;
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
                    readers.Address = Address;
                    isFirst = 1;
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Employees";
                    string names = "Readers";

                    Console.Write("Phone: ");
                    string Phone = Console.ReadLine() ?? "";

                    if (IsPhoneNbr(Phone))
                    {
                        if (checkPhone(Phone, name))
                        {
                            Console.WriteLine("phone already exist");
                        }
                        else if (checkPhone(Phone, names))
                        {
                            Console.WriteLine("phone already exist");
                        }
                        else
                        {
                            readers.Phone = Phone;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("phone wrong format");
                    }
                } while (isFirst != 1);

                isFirst = 0;
                do
                {
                    string name = "Employees";
                    string names = "Readers";

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
                            readers.Email = Email;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.Write("email wrong format");
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
                        readers.Password = Password;
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("\nPassword wrong format");
                    }
                } while (isFirst != 1);

                int status = 1;
                readers.status = status;

                isFirst = 0;
                do
                {
                    Console.Write("\nDo you want to create (Y/N): ");
                    string l = Console.ReadLine() ?? "";
                    if (l == "y" || l == "Y")
                    {
                        Console.WriteLine("You have successfully create");
                        _DL.AddReaders(readers);
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
        public void UpdateReaders()
        {
            try
            {
                Console.Clear();

                Readers readers = new Readers();

                int isFirst = 0;

                int id;

                int status = 1;

                do
                {
                    if (checkDisplayReaders(status))
                    {
                        DisplayReaders(status);

                        do
                        {
                            Console.Write("Id update: ");
                            id = int.Parse(Console.ReadLine() ?? "");
                            string name = "Id";

                            if (CheckId(id, status))
                            {
                                string check = Convert.ToString(id);

                                SreachReaders(name, check);

                                readers.Id = id;
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
                            Console.Write("Update Name: ");
                            string name = Console.ReadLine() ?? "";
                            if (IsNameNbr(name))
                            {
                                readers.Name = name;
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
                            readers.Address = Address;
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
                                    readers.Phone = Phone;
                                    isFirst = 1;
                                }
                                else if (checkPhoneUpdate(id, Phone, names))
                                {
                                    readers.Phone = Phone;
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
                                    readers.Phone = Phone;
                                    isFirst = 1;
                                }
                            }
                            else
                            {
                                Console.WriteLine("phone wrong format");
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
                                    readers.Email = Email;
                                    isFirst = 1;
                                }
                                else if (checkEmailUpdate(id, Email, names))
                                {
                                    readers.Email = Email;
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
                                    readers.Email = Email;
                                    isFirst = 1;
                                }
                            }
                            else
                            {
                                Console.Write("email wrong format");
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
                                readers.Password = Password;
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("\nPassword wrong format");
                            }
                        } while (isFirst != 1);

                        isFirst = 0;
                        do
                        {

                            Console.Write("\nDo you want to Update (Y/N): ");
                            string l = Console.ReadLine() ?? "";
                            if (l == "y" || l == "Y")
                            {
                                Console.WriteLine("You have successfully update");
                                _DL.UpdateReaders(readers);
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
        public void DisplayReadershistory()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Readers_history";

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,13} | {4,15} | {5,27} | {6,10} | {7,10} |", "Data history id", "ID", "Readers Name", "Address", "Phone", "Email", "Password", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["data_history_id"],15} | {reader["Id"],15} | {reader["Readers_name"],15} | {reader["Address"],13} | {reader["phone"],15} | {reader["Email"],27} | {reader["Password"],10} | {reader["Status"],10} |";

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
            int isFirst = 0;
            do
            {
                if (checksearch(Search, name))
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
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("not exist employee");
                    isFirst = 1;
                }
            } while (isFirst != 1);
        }
        bool checksearch(string Search, string name)
        {
            Console.Clear();

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Readers Where {Search}='{name}'";

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
                return false; ;
            }
        }
        public void DeleteReaders()
        {
            Console.Clear();

            Readers readers = new Readers();

            int isFirst = 0;

            int status = 1;
            do
            {
                if (checkDisplayReaders(status))
                {
                    DisplayReaders(status);

                    do
                    {

                        Console.Write("ID Delete: ");
                        int Id = int.Parse(Console.ReadLine() ?? "");
                        string name = "Id";

                        if (CheckId(Id, status))
                        {
                            string check = Convert.ToString(Id);

                            SreachReaders(name, check);

                            readers.Id = Id;
                            isFirst = 1;

                            status = 0;
                            readers.status = status;
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
                            _DL.DeleteReaders(readers);
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
                    Console.WriteLine("not exist database readers");
                    isFirst = 1;
                }
            } while (isFirst != 1);


        }
        public void Restore()
        {
            Console.Clear();

            Readers readers = new Readers();

            int isFirst = 0;

            int status = 0;

            do
            {
                if (checkDisplayReaders(status))
                {
                    DisplayReaders(status);

                    do
                    {

                        Console.Write("ID Restore: ");

                        int Id = int.Parse(Console.ReadLine() ?? "");
                        string name = "Id";

                        if (CheckId(Id, status))
                        {
                            string check = Convert.ToString(Id);

                            SreachReaders(name, check);
                            readers.Id = Id;
                            isFirst = 1;

                            status = 1;
                            readers.status = status;
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
                            Console.WriteLine("You have successfully Restore ");
                            _DL.DeleteReaders(readers);
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
                else
                {
                    Console.WriteLine("not exist database readers");
                    isFirst = 1;
                }
            } while (isFirst != 1);


        }
        public void ChangePassword(string Mail)
        {
            Console.Clear();

            Readers readers = new Readers();

            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("Change Password");
            Console.WriteLine("══════════════════════════════════════");

            int isFirst = 0;

            do
            {
                Console.Write("\nInput old password: ");
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
                    Console.Write("\nInput your new password: ");

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
                        Console.Write("\nConfirm your new password: ");


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
                            readers.Email = Mail;
                            readers.Password = Password1;
                            isFirst = 1;
                        }
                        else
                        {
                            Console.WriteLine("\nconfirm your new password is incorrect");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nPassword wrong format");
                    }
                }

            } while (isFirst != 1);

            isFirst = 0;
            do
            {

                Console.Write("\nDo you want to Change Password (Y/N): ");
                string l = Console.ReadLine() ?? "";
                if (l == "y" || l == "Y")
                {
                    Console.WriteLine("You have successfully Change Password");
                    _DL.ChangePassword(readers);
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

            var query = $"SELECT * FROM Readers where Id='{id}' and Status='{status}'";

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

using System;
using code.BL;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;

ReadersService readersService = new ReadersService();
BookService bookService = new BookService();
EmployeeService employeeService = new EmployeeService();
LoanSlipService loanSlipService = new LoanSlipService();
LoanSlipDetailsService loanSlipDetailsService = new LoanSlipDetailsService();

begin();

void begin()
{

    Console.Clear();

    int selectedChoice = 0;

    do
    {
        string[] _menu = { "Exit", "Login", "Register", };
        string _name = "Library Management System ";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 2)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    login();
                    break;
                case 2:
                    readersService.AddReaders();
                    break;
                default:
                    begin();
                    break;
            }
        }
    } while (selectedChoice != 0);
}

void login()
{
    Console.Clear();

    int isFirst = 0;
    do
    {
        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine("Login");
        Console.WriteLine("══════════════════════════════════════");
        Console.Write("Enter Mail: ");
        string Mail = Console.ReadLine() ?? "";
        Console.Write("Enter your password: ");
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

        string password = pass;

        if (checklogin(Mail, password))
        {
            MenuReaders(Mail);
            isFirst = 1;
        }
        else if (checkloginEmployyee(Mail, password))
        {
            if (checkPosition(Mail, password))
            {
                MenuAdmin(Mail);
                isFirst = 1;
            }
            else
            {
                MenuEmployee(Mail);
                isFirst = 1;
            }

        }
        else
        {
            Console.WriteLine("\nInvalid Mail or password");
        }

    } while (isFirst != 1);
}
void MenuAdmin(string Mail)
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Book Manager", "Readers Manager", "Employee Mannager", "Decentralization", "Change Password", "History" };

        string _name = "Library Management System ";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 6)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    BookMenu();
                    break;
                case 2:
                    ReadersMenu();
                    break;
                case 3:
                    EmployeeMenu();
                    break;
                case 4:
                    employeeService.decentralization();
                    break;
                case 5:
                    employeeService.ChangePassword(Mail);
                    break;
                case 6:
                    history();
                    break;
                default:
                    MenuAdmin(Mail);
                    break;
            }
        }
    } while (selectedChoice != 0);
}
void MenuEmployee(string Mail)
{

    Console.Clear();

    int selectedChoice = 0;

    do
    {
        string[] _menu = { "Exit", "Display Book", "loan slip manager", "loan slip details manager", "Update Status", "Change Password" };
        string _name = "Library Management System ";

        ShowMenu(_menu, _name);

        int i;

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 5)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    bookService.DisplayBook(i);
                    break;
                case 2:
                    loanSlipMenu(Mail);
                    break;
                case 3:
                    loanSlipDetailsMenu();
                    break;
                case 4:
                    loanSlipService.Status();
                    break;
                case 5:
                    employeeService.ChangePassword(Mail);
                    break;
                default:
                    break;
            }
        }
    } while (selectedChoice != 0);

}
void MenuReaders(string Mail)
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display Book", "Search", "Change Password" };
        string _name = "Library Management System ";

        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Library Management System ";

        int i;

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 3)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    bookService.DisplayBook(i);
                    break;

                case 2:
                    selectedChoice = 0;
                    do
                    {
                        ShowMenu(_menus, _names);

                        string search, name;

                        Console.Write("Your choice: ");

                        choice = Console.ReadLine();

                        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 3)
                        {

                        }
                        else
                        {
                            switch (selectedChoice)
                            {
                                case 1:

                                    search = "ISBN";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                case 2:

                                    search = "Title";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                case 3:

                                    search = "Author";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 3:
                    readersService.ChangePassword(Mail);
                    break;
                default:
                    MenuReaders(Mail);
                    break;
            }
        }
    } while (selectedChoice != 0);
}
void BookMenu()
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display Book", "Add Book", "Update", "Delete", "Search", "Restore" };
        string _name = "Library Management System ";
        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Library Management System ";

        int i;

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 6)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    bookService.DisplayBook(i);
                    break;
                case 2:
                    bookService.AddBook();
                    break;
                case 3:

                    bookService.UpdateBook();
                    break;
                case 4:
                    bookService.DeleteBook();
                    break;
                case 5:
                    selectedChoice = 0;
                    do
                    {
                        ShowMenu(_menus, _names);

                        string search, name;

                        Console.Write("Your choice: ");

                        choice = Console.ReadLine();

                        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 3)
                        {

                        }
                        else
                        {
                            switch (selectedChoice)
                            {
                                case 1:

                                    search = "ISBN";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                case 2:

                                    search = "Title";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                case 3:

                                    search = "Author";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreachbook(search, name);
                                    break;
                                default:
                                    BookMenu();
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 6:
                    bookService.Restore();
                    break;
                default:
                    BookMenu();
                    break;
            }
        }
    } while (selectedChoice != 0);
}
void loanSlipDetailsMenu()
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display loan slip details", "Add loan slip details", "Update", "Delete", "Search", "Restore" };
        string _name = "Library Management System ";
        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Library Management System " ?? "";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        int i, i2;

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 8)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    i2 = 2;
                    loanSlipDetailsService.DisplayLoanSlipDetails(i, i2);
                    break;
                case 2:
                    loanSlipDetailsService.AddLoanSlipDetailsDL();
                    break;
                case 3:
                    loanSlipDetailsService.UpdateLoanSlipDetailsDL();
                    break;
                case 4:
                    loanSlipDetailsService.DeleteLoanSlipDetalis();
                    break;
                case 5:

                    Console.WriteLine("Input the id you want to search:");
                    string name = Console.ReadLine() ?? "";
                    loanSlipDetailsService.SreachDetails(name);
                    break;
                case 6:
                    loanSlipDetailsService.Restore();
                    break;
                default:
                    loanSlipDetailsMenu();
                    break;
            }
        }
    } while (selectedChoice != 0);
}
void EmployeeMenu()
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display Employee", "Add Employee", "Update", "Delete", "Search", "Restore" };
        string _name = "Library Management System ";
        string[] _menus = { "Exit", "Search by id", "Search by name" };
        string _names = "Library Management System ";

        ShowMenu(_menu, _name);

        int i;
        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 7)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    employeeService.DisplayEmployee(i);
                    break;
                case 2:
                    employeeService.AddEmployee();
                    break;
                case 3:
                    employeeService.UpdateEmployee();
                    break;
                case 4:
                    employeeService.DeleteEmployee();
                    break;
                case 5:
                    Console.Clear();
                    selectedChoice = 0;
                    do
                    {
                        ShowMenu(_menus, _names);
                        string search, name;


                        Console.Write("Your choice: ");

                        choice = Console.ReadLine();

                        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 2)
                        {

                        }
                        else
                        {
                            switch (selectedChoice)
                            {
                                case 1:

                                    search = "Id";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    employeeService.SreachEmployee(search, name);
                                    break;
                                case 2:

                                    search = "Employee_name";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    employeeService.SreachEmployee(search, name);
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 6:
                    employeeService.Restore();
                    break;
                default:
                    EmployeeMenu();
                    break;
            }
        }
    } while (selectedChoice != 0);
}

void ReadersMenu()
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display Readers", "Add Readers", "Update", "Delete", "Search", "Restore" };
        string _name = "Library Management System ";
        string[] _menus = { "Exit", "Search by id", "Search by name" };
        string _names = "Library Management System ";

        ShowMenu(_menu, _name);

        int i;

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 7)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    readersService.DisplayReaders(i);
                    break;
                case 2:
                    readersService.AddReaders();
                    break;
                case 3:
                    readersService.UpdateReaders();
                    break;
                case 4:
                    readersService.DeleteReaders();
                    break;
                case 5:
                    Console.Clear();
                    selectedChoice = 0;
                    do
                    {
                        ShowMenu(_menus, _names);

                        string search;

                        string name;

                        Console.Write("Your choice: ");

                        choice = Console.ReadLine();

                        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 2)
                        {

                        }
                        else
                        {
                            switch (selectedChoice)
                            {
                                case 1:

                                    search = "Id";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    readersService.Sreach(search, name);
                                    break;
                                case 2:

                                    search = "Readers_name";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    readersService.Sreach(search, name);
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);

                    break;
                case 6:
                    readersService.Restore();
                    break;
                default:
                    ReadersMenu();
                    break;
            }
        }
    } while (selectedChoice != 0);
}

void loanSlipMenu(string Mail)
{
    Console.Clear();
    Console.WriteLine(Mail);
    int selectedChoice = 0;
    do
    {

        string[] _menu = { "Exit", "Display loan Slip", "Create Loan Slip", "Update", "Delete", "Search", "Restore", };
        string _name = "Library Management System ";
        string[] _menus = { "Exit", "Search by id" };
        string _names = "Library Management System " ?? "";

        ShowMenu(_menu, _name);

        int i, i2;

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 8)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    i2 = 2;
                    loanSlipService.DisplayLoanSlip(i, i2);
                    break;
                case 2:
                    loanSlipService.AddLoanSLip(Mail);
                    break;
                case 3:
                    loanSlipService.UpdateLoanSLip(Mail);
                    break;
                case 4:
                    loanSlipService.DeleteLoanSlip();
                    break;
                case 5:
                    Console.Write("Enter the data you want to search: ");
                    string name = Console.ReadLine() ?? "";
                    loanSlipService.Sreachloanslip(name);
                    break;
                case 6:
                    loanSlipService.Restore();
                    break;
                default:
                    loanSlipMenu(Mail);
                    break;
            }
        }
    } while (selectedChoice != 0);
}

void history()
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Display Book history", "Display Readers history", "Display Employee history", "Display loan Slip history", "Display loan slip deatils history" };
        string _name = "Library Management System ";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 6)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:

                    bookService.DisplayBookhistory();
                    break;
                case 2:
                    readersService.DisplayReadershistory();
                    break;
                case 3:
                    employeeService.DisplayEmployeehistory();
                    break;
                case 4:
                    loanSlipService.DisplayLoanSliphistory();
                    break;
                case 5:
                    loanSlipDetailsService.DisplayLoanSlipDetailshistory();
                    break;
                default:
                    history();
                    break;
            }
        }
    } while (selectedChoice != 0);
}
bool checklogin(string Mail, string password)
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

bool checkloginEmployyee(string Mail, string password)
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

bool checkPosition(string Mail, string password)
{

    DBHelper.OpenConnection();

    var query = $"SELECT * FROM Employees where Email='{Mail}' and Password='{password}' and Position=0";

    using (MySqlDataReader reader = DBHelper.ExecQuery(query))
    {
        while (reader.Read())
        {
            string row = $"{reader["Position"]}";

            if (row != null)
            {
                return true;
            }
        }
        return false;
    }
}

void ShowMenu(string[] menu, string name)
{

    Console.WriteLine("══════════════════════════════════════");
    Console.WriteLine(name);
    Console.WriteLine("══════════════════════════════════════");
    int count = menu.Length;
    for (int i = 1; i < count; i++)
    {
        Console.WriteLine("{0}. {1}", i, menu[i]);
    }
    Console.WriteLine("0. {0}", menu[0]);
}
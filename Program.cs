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
        string _name = "Librarian";

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
        Console.Write("Enter Mail: ");
        string Mail = Console.ReadLine() ?? "";
        if (IsValidEmail(Mail))
        {
            Console.Write("Enter Passwork: ");
            string password = Console.ReadLine() ?? "";
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
                Console.WriteLine(" Invalid Mail or password");
            }
        }
        else
        {
            Console.WriteLine("Mail sai dinh dang");
        }
    } while (isFirst != 1);
}
void MenuAdmin(string Mail)
{
    Console.Clear();
    int selectedChoice = 0;
    do
    {
        string[] _menu = { "Exit", "Book Manager", "Readers Manager", "Employee Mannager", "Decentralization", "Change Password" };

        string _name = "Librarian";

        ShowMenu(_menu, _name);

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
        string[] _menu = { "Exit", "loan slip manager", "loan slip details manager", "Change Password" };
        string _name = "Librarian";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 4)
        {

        }
        else
        {
            switch (selectedChoice)
            {

                case 1:
                    loanSlipMenu(Mail);
                    break;
                case 2:
                    loanSlipDetailsMenu();
                    break;
                case 3:
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
        string _name = "Librarian";

        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Search";

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
                            Console.WriteLine("Bạn cần nhập giá trị từ 1 -> 3.");
                        }
                        else
                        {
                            switch (selectedChoice)
                            {
                                case 1:
                                    search = "ISBN";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreach(search, name);
                                    break;
                                case 2:
                                    search = "Book_name";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreach(search, name);
                                    break;
                                case 3:
                                    search = "Author";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreach(search, name);
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
        string[] _menu = { "Exit", "Display Book", "Display Book Delete", "Add Book", "Update", "Delete", "Search", "restore" };
        string _name = "Librarian";
        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Search";

        int i;

        ShowMenu(_menu, _name);

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
                    bookService.DisplayBook(i);
                    break;
                case 2:
                    i = 0;
                    bookService.DisplayBook(i);
                    break;
                case 3:
                    bookService.AddBook();
                    break;
                case 4:
                    selectedChoice = 0;
                    do
                    {
                        Console.WriteLine("1.Update all");
                        Console.WriteLine("2.update each part");
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
                                    bookService.UpdateBook();
                                    break;
                                case 2:
                                    bookService.MenuUpdate();
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 5:
                    bookService.DeleteBook();
                    break;
                case 6:

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
                                    bookService.Sreach(search, name);
                                    break;
                                case 2:
                                    search = "Book_name";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreach(search, name);
                                    break;
                                case 3:
                                    search = "Author";
                                    Console.Write("Enter the data you want to search: ");
                                    name = Console.ReadLine() ?? "";
                                    bookService.Sreach(search, name);
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 7:
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
        string[] _menu = { "Exit", "Display loan slip details", "Display loan slip details Delete", "Add loan slip details", "Update", "Delete", "Search", "Restore", "Update Status" };
        string _name = "Librarian";
        string[] _menus = { "Exit", "Search by isbn", "Search by name", "Search by author" };
        string _names = "Search" ?? "";

        ShowMenu(_menu, _name);

        Console.Write("Your choice: ");

        var choice = Console.ReadLine();

        int i;

        if (!int.TryParse(choice, out selectedChoice) || selectedChoice < 1 || selectedChoice > 8)
        {

        }
        else
        {
            switch (selectedChoice)
            {
                case 1:
                    i = 1;
                    loanSlipDetailsService.DisplayLoanSlipDetails(i);
                    break;
                case 2:
                    i = 0;
                    loanSlipDetailsService.DisplayLoanSlipDetails(i);
                    break;
                case 3:
                    loanSlipDetailsService.AddLoanSlipDetailsDL();
                    break;
                case 4:
                    loanSlipDetailsService.UpdateLoanSlipDetailsDL();
                    break;
                case 5:
                    loanSlipDetailsService.DeleteLoanSlipDetalis();
                    break;
                case 6:
                    Console.WriteLine("Input the id you want to search:");
                    string name = Console.ReadLine() ?? "";
                    loanSlipDetailsService.SearchLoanSlipDetails(name);
                    break;
                case 7:
                    loanSlipDetailsService.Restore();
                    break;
                case 8:
                    loanSlipDetailsService.status();
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
        string[] _menu = { "Exit", "Display Employee", "Display Employee Delete", "Add Employee", "Update", "Delete", "Search", "Restore" };
        string _name = "Librarian";
        string[] _menus = { "Exit", "Search by id", "Search by name" };
        string _names = "Search";

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
                    i = 0;
                    employeeService.DisplayEmployee(i);
                    break;
                case 3:
                    employeeService.AddEmployee();
                    break;
                case 4:
                    selectedChoice = 0;
                    do
                    {
                        Console.WriteLine("1.Update all");
                        Console.WriteLine("2.update each part");
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
                                    employeeService.UpdateEmployee();
                                    break;
                                case 2:
                                    employeeService.MenuUpdate();
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 5:
                    employeeService.DeleteEmployee();
                    break;
                case 6:
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

                                    employeeService.Sreach(search, name);
                                    break;
                                case 2:
                                    search = "Employee_name";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    employeeService.Sreach(search, name);
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 7:
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
        string[] _menu = { "Exit", "Display Readers", "Display Readers Removed", "Add Readers", "Update", "Delete", "Search", "Restore" };
        string _name = "Librarian";
        string[] _menus = { "Exit", "Search by id", "Search by name" };
        string _names = "Search";

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
                    i = 0;
                    readersService.DisplayReaders(i);
                    break;
                case 3:
                    readersService.AddReaders();
                    break;
                case 4:
                    selectedChoice = 0;
                    do
                    {
                        Console.WriteLine("1.Update all");
                        Console.WriteLine("2.update each part");
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
                                    readersService.UpdateReaders();
                                    break;
                                case 2:
                                    readersService.MenuUpdate();
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 5:
                    readersService.DeleteReaders();
                    break;
                case 6:
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

                                    readersService.SreachReaders(search, name);
                                    break;
                                case 2:
                                    search = "Readers_name";

                                    Console.Write("Enter the data you want to search: ");

                                    name = Console.ReadLine() ?? "";

                                    readersService.SreachReaders(search, name);
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);

                    break;
                case 7:
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
    int selectedChoice = 0;
    do
    {

        string[] _menu = { "Exit", "Display loan Slip", "Display Loan Slip Delete", "Create Loan Slip", "Update", "Delete", "Search", "Restore", "Update Status" };
        string _name = "Librarian";
        string[] _menus = { "Exit", "Search by id" };
        string _names = "Search" ?? "";

        ShowMenu(_menu, _name);

        int i;

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
                    loanSlipService.DisplayLoanSlip(i);
                    break;
                case 2:
                    i = 0;
                    loanSlipService.DisplayLoanSlip(i);
                    break;
                case 3:
                    loanSlipService.AddLoanSLip(Mail);
                    break;
                case 4:
                    selectedChoice = 0;
                    do
                    {
                        Console.WriteLine("1.Update all");
                        Console.WriteLine("2.update each part");
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
                                    loanSlipService.UpdateLoanSLip(Mail);
                                    break;
                                case 2:
                                    loanSlipService.MenuUpdate();
                                    break;
                                default:
                                    break;
                            }
                        }
                    } while (selectedChoice != 0);
                    break;
                case 5:
                    loanSlipService.DeleteLoanSlip();
                    break;
                case 6:
                    Console.Write("Enter the data you want to search: ");
                    string name = Console.ReadLine() ?? "";

                    loanSlipService.Sreach(name);
                    break;
                case 7:
                    loanSlipService.Restore();
                    break;
                case 8:
                    loanSlipService.Status();
                    break;
                default:
                    loanSlipMenu(Mail);
                    break;
            }
        }
    } while (selectedChoice != 0);
}

bool IsValidEmail(string email)
{
    string motif = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

    if (email != null) return Regex.IsMatch(email, motif);
    else return false;
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

    var query = $"SELECT * FROM Employee where Email='{Mail}' and Password='{password}'";

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

    var query = $"SELECT * FROM Employee where Email='{Mail}' and Password='{password}' and Position=0";

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
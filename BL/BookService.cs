using System;
using code.BL;
using code.DL;
using code.Entities;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace code.BL
{
    public class BookService
    {
        private readonly BookDL _repo;

        public BookService()
        {
            _repo = new BookDL();
        }
        public void AddBook()
        {
            try
            {
                Console.Clear();

                Book book = new Book();

                int isFirst = 0;

                int status;
                Console.WriteLine("══════════════════════════════════════");
                Console.WriteLine("Create");
                Console.WriteLine("══════════════════════════════════════");

                do
                {
                    Console.Write("ISBN: ");
                    string Isbn = Console.ReadLine() ?? "";
                    status = 1;

                    if (isValidISBNs(Isbn))
                    {
                        if (CheckIsbn(Isbn, status))
                        {
                            Console.WriteLine("ISBN already exist");
                        }
                        else
                        {
                            book.Isbn = Isbn;
                            isFirst = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ISBN wrong format");
                    }

                } while (isFirst != 1);

                do
                {
                    Console.Write("Title: ");
                    string Book_names = Console.ReadLine() ?? "";
                    book.Book_names = Book_names;
                    status = 1;
                    if (CheckTitle(Book_names))
                    {
                        Console.WriteLine("Title already exist");
                    }
                    else
                    {
                        book.Book_names = Book_names;
                        isFirst = 1;
                    }
                } while (isFirst != 1);


                Console.Write("Author: ");
                string Author = Console.ReadLine() ?? "";
                book.Author = Author;

                Console.Write("Publisher Name: ");
                string Publisher_names = Console.ReadLine() ?? "";
                book.Publisher_names = Publisher_names;

                isFirst = 0;
                do
                {

                    Console.Write("Publisher Year: ");
                    string date = Console.ReadLine() ?? "";
                    if (checkdate(date))
                    {
                        book.Publishing_year = DateTime.Parse(date);
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("Publisher Year wrong format");
                    }

                } while (isFirst != 1);

                Console.Write("Amount: ");
                int Amount = int.Parse(Console.ReadLine() ?? "");
                book.Amount = Amount;

                status = 1;
                book.status = status;

                isFirst = 0;
                do
                {

                    Console.Write("Do you want to create (Y/N): ");
                    string l = Console.ReadLine() ?? "";
                    if (l == "y" || l == "Y")
                    {
                        _repo.AddBook(book);
                        Console.WriteLine("You have successfully create");
                        isFirst = 1;
                    }
                    else if (l == "n" || l == "N")
                    {
                        Console.WriteLine("You do not agree to create");
                        isFirst = 1;
                    }
                    else
                    {
                        Console.WriteLine("You enter wrong");
                    }

                } while (isFirst != 1);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void UpdateBook()
        {
            try
            {
                Console.Clear();

                Book book = new Book();

                int isFirst = 0;

                int status = 1;

                do
                {
                    if (checkDisplay(status))
                    {
                        DisplayBook(status);

                        do
                        {
                            Console.Write("ISBN Update: ");
                            string Isbn = Console.ReadLine() ?? "";
                            string name = "ISBN";

                            if (CheckIsbn(Isbn, status))
                            {
                                Sreach(name, Isbn);
                                book.Isbn = Isbn;
                                isFirst = 1;

                            }
                            else
                            {
                                Console.WriteLine("ISBN does not exist");
                            }


                        } while (isFirst != 1);

                        do
                        {
                            Console.Write("Update Title: ");
                            string Book_names = Console.ReadLine() ?? "";
                            book.Book_names = Book_names;
                            status = 1;
                            if (CheckTitle2(Book_names, book.Isbn))
                            {
                                book.Book_names = Book_names;
                                isFirst = 1;
                            }
                            else if (CheckTitle(Book_names))
                            {
                                Console.WriteLine("Title already exist");
                            }
                            else
                            {
                                book.Book_names = Book_names;
                                isFirst = 1;
                            }
                        } while (isFirst != 1);


                        Console.Write("Update Author: ");
                        string Author = Console.ReadLine() ?? "";
                        book.Author = Author;

                        Console.Write("Update Publisher Name: ");
                        string Publisher_names = Console.ReadLine() ?? "";
                        book.Publisher_names = Publisher_names;

                        isFirst = 0;
                        do
                        {

                            Console.Write("Update Publisher Year: ");
                            string date = Console.ReadLine() ?? "";
                            if (checkdate(date))
                            {
                                book.Publishing_year = DateTime.Parse(date);
                                isFirst = 1;
                            }
                            else
                            {
                                Console.WriteLine("Publisher Year wrong format");
                            }

                        } while (isFirst != 1);


                        Console.Write("Update Amount: ");
                        int Amount = int.Parse(Console.ReadLine() ?? "");
                        book.Amount = Amount;

                        isFirst = 0;
                        do
                        {

                            Console.Write("Do you want to Update (Y/N): ");
                            string l = Console.ReadLine() ?? "";
                            if (l == "y" || l == "Y")
                            {
                                Console.WriteLine("You have successfully update");
                                _repo.UpdateBook(book);
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
                        Console.WriteLine("not exist database");
                        isFirst = 1;
                    }

                } while (isFirst != 1);


            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void DeleteBook()
        {
            Console.Clear();

            Book book = new Book();

            int isFirst = 0;

            int status = 1;
            do
            {
                if (checkDisplay(status))
                {
                    DisplayBook(status);

                    do
                    {
                        string name = "ISBN";
                        Console.Write("ISBN Delete: ");
                        string isbn = Console.ReadLine() ?? "";

                        if (CheckIsbn(isbn, status))
                        {
                            Sreach(name, isbn);
                            book.Isbn = isbn;
                            isFirst = 1;

                            status = 0;
                            book.status = status;
                        }
                        else
                        {
                            Console.WriteLine("ISBN does not exist");
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
                            _repo.DeleteBook(book);
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
                    Console.WriteLine("not exist database");
                    isFirst = 1;
                }
            } while (isFirst != 1);

        }
        public void Restore()
        {
            Console.Clear();

            Book book = new Book();

            int isFirst = 0;

            int status = 0;
            do
            {
                if (checkDisplay(status))
                {
                    DisplayBook(status);
                    do
                    {


                        Console.Write("ISBN Restore: ");
                        string isbn = Console.ReadLine() ?? "";
                        string name = "ISBN";

                        if (CheckIsbn(isbn, status))
                        {
                            Sreach(name, isbn);
                            book.Isbn = isbn;
                            isFirst = 1;

                            status = 1;
                            book.status = status;
                        }
                        else
                        {
                            Console.WriteLine("ISBN does not exist");
                        }

                    } while (isFirst != 1);

                    isFirst = 0;
                    do
                    {

                        Console.Write("Do you want to restore (Y/N): ");
                        string l = Console.ReadLine() ?? "";
                        if (l == "y" || l == "Y")
                        {
                            Console.WriteLine("You have successfully restore");
                            _repo.DeleteBook(book);
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
                else
                {
                    Console.WriteLine("not exist database");
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

            var query = $"SELECT * FROM books Where Status={i}";

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "ID", "Title", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
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
        public void DisplayBookhistory()
        {
            Console.Clear();

            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books_history";

            Console.WriteLine(string.Format("| {0,15} | {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "Data History Id", "ID", "Title", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["data_history_id"],15} | {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],15} | {reader["Status"],10} |";

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

            Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "ID", "Title", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
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
        public void Sreachbook(string search, string name)
        {
            int isFirst = 0;
            do
            {
                if (checksearch(search, name))
                {
                    Console.Clear();
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.WriteLine("Library Management System ");
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

                    DBHelper.OpenConnection();

                    var query = $"SELECT * FROM books Where {search}='{name}'";

                    Console.WriteLine(string.Format("| {0,15} | {1,15} | {2,15} | {3,20} | {4,25} | {5,15} | {6,10} |", "ID", "Title", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
                    using (MySqlDataReader reader = DBHelper.ExecQuery(query))
                    {
                        while (reader.Read())
                        {
                            string row = $"| {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],15} | {reader["Status"],10} |";

                            System.Console.WriteLine(row);
                        }
                    }
                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    isFirst = 1;
                }
                else
                {
                    Console.WriteLine("not exist books");
                    isFirst = 1;
                }
            } while (isFirst != 1);

        }
        bool checksearch(string search, string name)
        {
            Console.Clear();

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where {search}='{name}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],15} | {reader["Title"],15} | {reader["Author"],15} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],15} | {reader["Status"],10} |";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }

        }
        bool CheckIsbn(string Isbn, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Books where ISBN='{Isbn}' and Status={status}";

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
        bool CheckTitle(string name)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Books where Title='{name}'";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Title"]}";

                    if (row != null)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        bool CheckTitle2(string name, string isbn)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Books where Title='{name}' and ISBN={isbn}";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"{reader["Title"]}";

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

            string motif = "[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
        }
        bool isValidISBNs(string date)
        {

            string motif = "(978|979)[0-9X]{10}$";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
        }
        bool checkDisplay(int i)
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

    }
}

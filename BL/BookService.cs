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


                Console.Write("Book Name: ");
                string Book_names = Console.ReadLine() ?? "";
                book.Book_names = Book_names;

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

                _repo.AddBook(book);
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

                do
                {
                    Console.Write("ISBN update: ");
                    string Isbn = Console.ReadLine() ?? "";
                    int status = 1;
                    if (CheckIsbn(Isbn, status))
                    {
                        book.Isbn = Isbn;
                        isFirst = 1;

                    }
                    else
                    {
                        Console.WriteLine("Isbn does not exist");
                    }


                } while (isFirst != 1);

                Console.Write("Book Name: ");
                string Book_names = Console.ReadLine() ?? "";
                book.Book_names = Book_names;

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

                _repo.UpdateBook(book);
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

                Book book = new Book();

                int isFirst = 0;

                string Isbn;

                string name1;


                do
                {
                    Console.Write("ISBN update: ");
                    Isbn = Console.ReadLine() ?? "";
                    int status = 1;
                    if (CheckIsbn(Isbn, status))
                    {
                        name1 = "ISBN";
                        book.Isbn = Isbn;
                        isFirst = 1;
                        Sreach(name1, Isbn);
                    }
                    else
                    {
                        Console.WriteLine("Isbn does not exist");
                    }


                } while (isFirst != 1);
                int choice;
                do
                {
                    Console.WriteLine("1.Book Name");
                    Console.WriteLine("2.Author");
                    Console.WriteLine("3.Publisher Name");
                    Console.WriteLine("4.publisher Year");
                    Console.WriteLine("5.Amount");
                    Console.WriteLine("0.Exit");
                    Console.WriteLine("Your choice: ");
                    choice = int.Parse(Console.ReadLine() ?? "");
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Book Name: ");
                            string Book_names = Console.ReadLine() ?? "";
                            name1 = "Book_name";
                            updatedata(name1, Book_names, Isbn);
                            break;
                        case 2:

                            Console.Write("Author: ");
                            string Author = Console.ReadLine() ?? "";
                            name1 = "Author";
                            updatedata(name1, Author, Isbn);
                            break;
                        case 3:
                            Console.Write("Publisher Name: ");
                            string Publisher_names = Console.ReadLine() ?? "";
                            name1 = "Publisher_name";
                            updatedata(name1, Publisher_names, Isbn);
                            break;
                        case 4:
                            isFirst = 0;
                            do
                            {

                                Console.Write("Publisher Year: ");
                                string date = Console.ReadLine() ?? "";
                                if (checkdate(date))
                                {
                                    name1 = "Publisher_year";
                                    updatedata(name1, date, Isbn);
                                    isFirst = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Publisher Year wrong format");
                                }

                            } while (isFirst != 1);
                            break;
                        case 5:
                            Console.Write("Amount: ");
                            int Amount = int.Parse(Console.ReadLine() ?? "");
                            string i = Convert.ToString(Amount);
                            name1 = "Amount";
                            updatedata(name1, i, Isbn);
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
        public void updatedata(string name, string name1, string id)
        {
            DBHelper.OpenConnection();

            var query = $"update ignore Readers set {name}='{name1}' where Id = {id}; ";

            using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
        }
        public void DeleteBook()
        {
            Console.Clear();

            Book book = new Book();

            int isFirst = 0;

            do
            {
                Console.Write("ISBN Delete: ");
                string isbn = Console.ReadLine() ?? "";
                int status = 1;
                if (CheckIsbn(isbn, status))
                {
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

            _repo.DeleteBook(book);
        }
        public void Restore()
        {
            Console.Clear();

            Book book = new Book();

            int isFirst = 0;

            do
            {
                Console.Write("ISBN Delete: ");
                string isbn = Console.ReadLine() ?? "";
                int status = 0;

                if (CheckIsbn(isbn, status))
                {
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

            _repo.DeleteBook(book);
        }
        public void DisplayBook(int i)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where Status={i}";

            Console.WriteLine(string.Format("| {0,10} | {1,13} | {2,10} | {3,20} | {4,25} | {5,10} | {6,10} |", "ID", "Book name", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],10} | {reader["Book_name"],13} | {reader["Author"],10} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],10} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
        }
        public void Sreach(string Search, string name)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Library Management System ");
            Console.WriteLine("==========================================================================");

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM books Where {Search}='{name}'";

            Console.WriteLine(string.Format("| {0,10} | {1,13} | {2,10} | {3,20} | {4,20} | {5,10} | {6,10} |", "ID", "Book name", "Author", "Publisher name", "Publishing year", "Amount", "Status"));
            using (MySqlDataReader reader = DBHelper.ExecQuery(query))
            {
                while (reader.Read())
                {
                    string row = $"| {reader["ISBN"],10} | {reader["Book_name"],13} | {reader["Author"],10} | {reader["Publisher_name"],20} | {reader["Publishing_year"],25} | {reader["Amount"],10} | {reader["Status"],10} |";

                    System.Console.WriteLine(row);
                }
            }
        }
        bool CheckIsbn(string Isbn, int status)
        {

            DBHelper.OpenConnection();

            var query = $"SELECT * FROM Books where ISBN='{Isbn}' and {status}";

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

            string motif = "[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
        }
        bool isValidISBNs(string date)
        {

            string motif = "[0-9X]{10}$";

            if (date != null) return Regex.IsMatch(date, motif);
            else return false;
        }
    }
}

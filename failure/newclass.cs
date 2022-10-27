// public void MenuUpdate()
// {
//     try
//     {
//         Console.Clear();

//         Book book = new Book();


//         int isFirst = 0;

//         string Isbn;

//         string name1;


//         do
//         {
//             Console.Write("ISBN update: ");
//             Isbn = Console.ReadLine() ?? "";
//             int status = 1;
//             if (CheckIsbn(Isbn, status))
//             {
//                 name1 = "ISBN";
//                 book.Isbn = Isbn;
//                 isFirst = 1;
//                 Sreach(name1, Isbn);
//             }
//             else
//             {
//                 Console.WriteLine("Isbn does not exist");
//             }


//         } while (isFirst != 1);
//         int choice;
//         do
//         {
//             Console.WriteLine("1.Book Name");
//             Console.WriteLine("2.Author");
//             Console.WriteLine("3.Publisher Name");
//             Console.WriteLine("4.publisher Year");
//             Console.WriteLine("5.Amount");
//             Console.WriteLine("0.Exit");
//             Console.WriteLine("Your choice: ");
//             choice = int.Parse(Console.ReadLine() ?? "");
//             switch (choice)
//             {
//                 case 1:
//                     Console.Write("Book Name: ");
//                     string Book_names = Console.ReadLine() ?? "";
//                     name1 = "Book_name";
//                     updatedata(name1, Book_names, Isbn);
//                     break;
//                 case 2:

//                     Console.Write("Author: ");
//                     string Author = Console.ReadLine() ?? "";
//                     name1 = "Author";
//                     updatedata(name1, Author, Isbn);
//                     break;
//                 case 3:
//                     Console.Write("Publisher Name: ");
//                     string Publisher_names = Console.ReadLine() ?? "";
//                     name1 = "Publisher_name";
//                     updatedata(name1, Publisher_names, Isbn);
//                     break;
//                 case 4:
//                     isFirst = 0;
//                     do
//                     {

//                         Console.Write("Publisher Year: ");
//                         string date = Console.ReadLine() ?? "";
//                         if (checkdate(date))
//                         {
//                             name1 = "Publisher_year";
//                             updatedata(name1, date, Isbn);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("Publisher Year wrong format");
//                         }

//                     } while (isFirst != 1);
//                     break;
//                 case 5:
//                     Console.Write("Amount: ");
//                     int Amount = int.Parse(Console.ReadLine() ?? "");
//                     string i = Convert.ToString(Amount);
//                     name1 = "Amount";
//                     updatedata(name1, i, Isbn);
//                     break;
//                 default:
//                     MenuUpdate();
//                     break;
//             }
//         } while (choice != 0);
//     }
//     catch (System.Exception)
//     {

//         throw;
//     }
// }
// public void updatedata(string name, string name1, string id)
// {
//     DBHelper.OpenConnection();

//     var query = $"update ignore Readers set {name}='{name1}' where Id = {id}; ";

//     using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
// }


// public void MenuUpdate()
// {
//     try
//     {
//         Console.Clear();

//         Employee employee = new Employee();

//         int isFirst = 0;

//         int id;

//         string name1, Search;

//         do
//         {
//             Console.Write("Id update: ");
//             id = int.Parse(Console.ReadLine() ?? "");
//             int status = 1;

//             if (CheckId(id, status))
//             {
//                 isFirst = 1;
//                 Search = "Id";
//                 name1 = Convert.ToString(id);
//                 Sreach(Search, name1);
//             }
//             else
//             {
//                 Console.WriteLine("id does not exist");
//             }

//         } while (isFirst != 1);
//         int choice;

//         do
//         {
//             Console.WriteLine("1.Name");
//             Console.WriteLine("2.Address");
//             Console.WriteLine("3.Phone");
//             Console.WriteLine("4.Email");
//             Console.WriteLine("5.Password");
//             Console.WriteLine("0.Ẽit");
//             Console.WriteLine("Your choice:");
//             choice = int.Parse(Console.ReadLine() ?? "");
//             switch (choice)
//             {
//                 case 1:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Name: ");
//                         string name = Console.ReadLine() ?? "";
//                         if (IsNameNbr(name))
//                         {
//                             name1 = "Employee_name";
//                             updatedata(name1, name, id);
//                             isFirst = 1;

//                         }
//                         else
//                         {
//                             Console.WriteLine("Name wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 2:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Address: ");
//                         string Address = Console.ReadLine() ?? "";
//                         isFirst = 1;
//                         name1 = "Address";
//                         updatedata(name1, Address, id);

//                     } while (isFirst != 1);
//                     break;
//                 case 3:
//                     isFirst = 0;
//                     do
//                     {
//                         string name = "Employee";
//                         string names = "Readers";
//                         name1 = "Phone";

//                         Console.Write("Phone: ");
//                         string Phone = Console.ReadLine() ?? "";
//                         if (IsPhoneNbr(Phone))
//                         {
//                             if (checkPhoneUpdate(id, Phone, name))
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkPhoneUpdate(id, Phone, names))
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkPhone(Phone, name))
//                             {
//                                 Console.WriteLine("phone already exist");
//                             }
//                             else if (checkPhone(Phone, name))
//                             {
//                                 Console.WriteLine("phone already exist");
//                             }
//                             else
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("phone wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 4:
//                     isFirst = 0;
//                     do
//                     {
//                         string name = "Employee";
//                         string names = "Readers";
//                         name1 = "Email";

//                         Console.Write("Email: ");
//                         string Email = Console.ReadLine() ?? "";
//                         if (IsValidEmail(Email))
//                         {
//                             if (checkEmailUpdate(id, Email, name))
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkEmailUpdate(id, Email, names))
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkEmail(Email, name))
//                             {
//                                 Console.Write("Email already exist");
//                             }
//                             else if (checkEmail(Email, name))
//                             {
//                                 Console.Write("Email already existi");
//                             }
//                             else
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                         }
//                         else
//                         {
//                             Console.Write("email wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 5:
//                     isFirst = 0;
//                     do
//                     {
//                         name1 = "Password";
//                         Console.Write("Password: ");
//                         string Password = Console.ReadLine() ?? "";
//                         if (IsPassWordNbr(Password))
//                         {
//                             updatedata(name1, Password, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("Password wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 default:
//                     MenuUpdate();
//                     break;
//             }
//         } while (choice != 0);

//     }
//     catch (System.Exception)
//     {

//         throw;
//     }
// }
// public void updatedata(string name, string name1, int id)
// {
//     DBHelper.OpenConnection();

//     var query = $"update ignore Employee set {name}='{name1}' where Id = {id}; ";

//     using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
// }

// public void MenuUpdate()
// {
//     try
//     {
//         Console.Clear();
//         LoanSlip loanSlip = new LoanSlip();

//         int isFirst = 0;

//         int status = 1;

//         int id;

//         string name;

//         string name1;

//         do
//         {
//             Console.Write("Id update: ");
//             id = int.Parse(Console.ReadLine() ?? "");
//             status = 1;
//             name1 = "Loan_Slip";

//             if (CheckId(name1, id, status))
//             {
//                 string i = Convert.ToString(id);
//                 Sreach(i);
//                 isFirst = 1;
//             }
//             else
//             {
//                 Console.WriteLine("id does not exist");
//             }

//         } while (isFirst != 1);

//         int choice;
//         do
//         {
//             Console.WriteLine("1.ID Readers");
//             Console.WriteLine("2.ID Loan Slip Details");
//             Console.WriteLine("3.Borrowed date");
//             Console.WriteLine("4.Pay Day");
//             choice = int.Parse(Console.ReadLine() ?? "");
//             switch (choice)
//             {
//                 case 1:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Id Readers: ");
//                         name = "Readers";
//                         int Id_Readers = int.Parse(Console.ReadLine() ?? "");
//                         if (CheckId(name, Id_Readers, status))
//                         {
//                             name1 = "Id_Readers";
//                             string i = Convert.ToString(Id_Readers);
//                             updatedata(name1, i, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("id does not exist ");
//                         }

//                     } while (isFirst != 1);
//                     break;
//                 case 2:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Id Loan Slip Details: ");
//                         name = "loan_slip_details";
//                         int Id_loan_slip_details = int.Parse(Console.ReadLine() ?? "");
//                         if (CheckId(name, Id_loan_slip_details, status))
//                         {
//                             name1 = "Id_loan_slip_details";
//                             string i = Convert.ToString(Id_loan_slip_details);
//                             updatedata(name1, i, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("id does not exist ");
//                         }

//                     } while (isFirst != 1);
//                     break;
//                 case 3:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Borrowed date: ");
//                         string date = Console.ReadLine() ?? "";
//                         if (checkdate(date))
//                         {
//                             name1 = "Borrowed_date";
//                             updatedata(name1, date, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("borrowed date wrong format");
//                         }


//                     } while (isFirst != 1);
//                     break;
//                 case 4:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Pay day: ");
//                         string date = Console.ReadLine() ?? "";
//                         if (checkdate(date))
//                         {
//                             name1 = "Pay_day";
//                             updatedata(name1, date, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("pay day wrong format");
//                         }

//                     } while (isFirst != 1);
//                     break;
//                 default:
//                     MenuUpdate();
//                     break;
//             }
//         } while (choice != 0);

//     }
//     catch (System.Exception)
//     {

//         throw;
//     }
// }
// public void updatedata(string name, string name1, int id)
// {
//     DBHelper.OpenConnection();

//     var query = $"update ignore loan_slip set {name}='{name1}' where Id = {id}; ";

//     using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
// }

// public void MenuUpdate()
// {
//     try
//     {
//         Console.Clear();

//         Readers readers = new Readers();

//         int isFirst = 0;

//         int id;

//         string name1;

//         do
//         {
//             int status = 1;
//             DisplayReaders(status);

//             Console.Write("Id update: ");
//             id = int.Parse(Console.ReadLine() ?? "");


//             if (CheckId(id, status))
//             {
//                 readers.Id = id;
//                 name1 = "Id";
//                 string i = Convert.ToString(id);
//                 isFirst = 1;
//                 SreachReaders(name1, i);
//             }
//             else
//             {
//                 Console.WriteLine("id does not exist");
//             }

//         } while (isFirst != 1);

//         int choice;
//         do
//         {
//             Console.WriteLine("1.Name");
//             Console.WriteLine("2.Address");
//             Console.WriteLine("3.Phone");
//             Console.WriteLine("4.Email");
//             Console.WriteLine("5.Password");
//             Console.WriteLine("0.Ẽit");
//             Console.WriteLine("Your choice:");
//             choice = int.Parse(Console.ReadLine() ?? "");
//             switch (choice)
//             {
//                 case 1:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Name: ");
//                         string name = Console.ReadLine() ?? "";
//                         if (IsNameNbr(name))
//                         {
//                             name1 = "Readers_name";
//                             updatedata(name1, name, id);

//                             isFirst = 1;

//                         }
//                         else
//                         {
//                             Console.WriteLine("Name wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 2:
//                     isFirst = 0;
//                     do
//                     {
//                         Console.Write("Address: ");
//                         string Address = Console.ReadLine() ?? "";
//                         name1 = "Address";
//                         isFirst = 1;
//                         updatedata(name1, Address, id);

//                     } while (isFirst != 1);
//                     break;
//                 case 3:
//                     isFirst = 0;
//                     do
//                     {
//                         string name = "Employee";
//                         string names = "Readers";
//                         name1 = "Phone";

//                         Console.Write("Phone: ");
//                         string Phone = Console.ReadLine() ?? "";
//                         if (IsPhoneNbr(Phone))
//                         {
//                             if (checkPhoneUpdate(id, Phone, name))
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkPhoneUpdate(id, Phone, names))
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkPhone(Phone, name))
//                             {
//                                 Console.WriteLine("phone already exist");
//                             }
//                             else if (checkPhone(Phone, name))
//                             {
//                                 Console.WriteLine("phone already exist");
//                             }
//                             else
//                             {
//                                 updatedata(name1, Phone, id);
//                                 isFirst = 1;
//                             }
//                         }
//                         else
//                         {
//                             Console.WriteLine("phone wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 4:
//                     isFirst = 0;
//                     do
//                     {
//                         string name = "Employee";
//                         string names = "Readers";
//                         name1 = "Email";

//                         Console.Write("Email: ");
//                         string Email = Console.ReadLine() ?? "";
//                         if (IsValidEmail(Email))
//                         {
//                             if (checkEmailUpdate(id, Email, name))
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkEmailUpdate(id, Email, names))
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                             else if (checkEmail(Email, name))
//                             {
//                                 Console.Write("Email already exist");
//                             }
//                             else if (checkEmail(Email, name))
//                             {
//                                 Console.Write("Email already existi");
//                             }
//                             else
//                             {
//                                 updatedata(name1, Email, id);
//                                 isFirst = 1;
//                             }
//                         }
//                         else
//                         {
//                             Console.Write("email wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 case 5:
//                     isFirst = 0;
//                     do
//                     {
//                         name1 = "Password";
//                         Console.Write("Password: ");
//                         string Password = Console.ReadLine() ?? "";
//                         if (IsPassWordNbr(Password))
//                         {
//                             updatedata(name1, Password, id);
//                             isFirst = 1;
//                         }
//                         else
//                         {
//                             Console.WriteLine("Password wrong format");
//                         }
//                     } while (isFirst != 1);
//                     break;
//                 default:
//                     MenuUpdate();
//                     break;
//             }
//         } while (choice != 0);
//     }
//     catch (System.Exception)
//     {

//         throw;
//     }
// }
// public void updatedata(string name, string name1, int id)
// {
//     DBHelper.OpenConnection();

//     var query = $"update ignore Readers set {name}='{name1}' where Id = {id}; ";

//     using (MySqlDataReader reader = DBHelper.ExecQuery(query)) { };
// }



// do
// {


//     Console.Write("Id : ");

//     name = "Loan_slip";
//     int Id = int.Parse(Console.ReadLine() ?? "");

//     if (CheckId(name, Id, status))
//     {
//         name = "Loan_slip_details";
//         status = 0;
//         string check = Convert.ToString(Id);
//         Sreach(check);
//         // if (CheckId(name, Id, status))
//         // {
//         //     loanSlip.id = Id;
//         //     isFirst = 1;

//         //     status = 2;
//         //     loanSlip.status = status;
//         // }
//         // else
//         // {
//         //     Console.WriteLine("id does not exist or loan slip details have not been updated to the paid in full status ");
//         // }

//         loanSlip.status = status;
//         // CheckIddetails(Id, status);
//         isFirst = 1;

//     }

// } while (isFirst != 1);
namespace code.Entities
{
    public class LoanSlip
    {
        public int id { get; set; }
        public int Id_Readers { get; set; }
        public int Id_Employee { get; set; }
        public int Id_loan_Slip_Details { get; set; }
        public DateTime Borrowed_date { get; set; }
        public DateTime Pay_day { get; set; }
        public int status { get; set; }
    }
}
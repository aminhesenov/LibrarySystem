using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
namespace LibraryApp.Models
{
    public class AddBooks : Controller
    {
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\C#\\Books.accdb";
        public  string Add(string bookName, string author, string isbn, string shelfNo)
        {
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                conn.Open();
                string query = "INSERT INTO Books (BookName, Author, ISBN, ShelfNo) VALUES (?,?,?,?)";
                OleDbCommand cmd=new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("",bookName);
                cmd.Parameters.AddWithValue("",author);
                cmd.Parameters.AddWithValue("", isbn);
                cmd.Parameters.AddWithValue("", shelfNo);
                cmd.ExecuteNonQuery();
                return "Book add";
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

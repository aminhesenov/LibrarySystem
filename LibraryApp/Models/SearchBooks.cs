using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.Text;
namespace LibraryApp.Models
{
    public class SearchBooks : Controller
    {
        string cs = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\\C#\\Books.accdb";
        public string Search(string bookName)
        {
            StringBuilder result=new StringBuilder();
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                conn.Open();
                string query = "SELECT *FROM Books WHERE [BookName] LIKE ?";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@p1", "%" +bookName + "%");
                OleDbDataReader reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.AppendLine(reader["BookName"] + " | " + reader["Author"] + " | " + reader["ISBN"] + " | " + reader["ShelfNo"]);
                }
            }
            return result.ToString();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

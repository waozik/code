using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
namespace DynamicAndExcle
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<Account>
            {
                new Account {Id=13245,Balance = 54.212 },
                new Account {Id= 2344,Balance =1234.233 }
            };
            var excelApp = new Excel.Application();

            excelApp.Visible = true;
            excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "ID Number";
            workSheet.Cells[1, "B"] = "Current Balance";
            var row = 1;
            foreach (var acct in accounts)
            {
                row++;
                workSheet.Cells[row, "A"] = acct.Id;
                workSheet.Cells[row, "B"] = acct.Balance;
            }
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
          
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
    }
}

using System;
using System.Linq;

namespace linqEtcCs
{
    class Program
    {
        static void Main(string[] args)
        {
            select_new_noname();

            linqSelect();
            
            Console.ReadKey();
        }

        static void linqSelect()
        {
            string[] animals = { "アメンボ", "イノシシ", "ウマ", "エリマキトカゲ", "オオカミ" };
            var q1 = animals.Where(c => c.Length > 3).Select(c => c + c);
            foreach( var item in q1)
            {
                Console.WriteLine(item);
            }
        }

        static int f1(int n)
        {
            return n*n*n;
        }

        static void select_new_noname()
        {
            // Ordersオブジェクトの配列
            Order[] oders = new Order[]
            {
                new Order(1000, 1, DateTime.Now, "Norway"),
                new Order(1001, 3, DateTime.Now, "Germany"),
                new Order(1002, 7, DateTime.Now, "Norway"),
                new Order(1003, 7, DateTime.Now, "Poland"),
            };


            var query1 = from n in oders where n.ShipCountry == "Norway" select new { OrderID = n.OrderID, EmployeeID = n.EmployeeID };

            foreach(var item in query1)
            {
                Console.WriteLine(item.EmployeeID);
            }

            //var query2 = oders.Where(c => c.ShipCountry == "Norway").Select(x => new { x.OrderID, x.EmployeeID });
            var query2 = oders.Where(c => c.ShipCountry == "Norway").Select(n => n.EmployeeID*100 );
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
            var query3 = oders.Where(c => c.ShipCountry == "Norway").Select(c=> f1(c.EmployeeID));
            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
            var query31 = oders.Where(c => c.ShipCountry == "Norway").Select(c => { return c.EmployeeID + c.OrderID + 20000; });
            foreach (var item in query31)
            {
                Console.WriteLine(item);
            }

        }
    }

    public class Order
    {
        public int OrderID;
        public int EmployeeID;
        public DateTime OrderDate;
        public string ShipCountry;

        public Order(int id, int emp, DateTime date, string ship)
        {
            this.OrderID = id;
            this.EmployeeID = emp;
            this.OrderDate = date;
            this.ShipCountry = ship;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqToSql
{
    class Program
    {
        static void Main(string[] args)
        {


            //select
            using (DBSalesContextDataContext db = new DBSalesContextDataContext())
            {
                //query syntax
                var lst = from p in db.Products where p.Pro_ID > 3 orderby p.Pro_ID select p;
                
                //nonquery syntax (method synatx)
                //var lst =  db.Products.Where(a => a.Pro_ID > 3).OrderByDescending(a => a.Pro_ID).ToList();

                Console.WriteLine(db.GetCommand(lst).CommandText);
                foreach (var item in lst)
                {
                    Console.WriteLine($"name {item.Pro_Name} price {item.Sale_Price}");
                }
            }



            //insert 
            using (DBSalesContextDataContext db = new DBSalesContextDataContext())
            {
                Product p = new Product();
                p.Pro_ID = 51;
                p.Pro_Name = "tamer";
                p.Sale_Price = 400;

                db.Products.InsertOnSubmit(p);
                db.SubmitChanges();

            }



            //update
            using (DBSalesContextDataContext db = new DBSalesContextDataContext())
            {
                Product p = db.Products.SingleOrDefault(a => a.Pro_ID == 50);
                p.Pro_Name = "mahmoud";
                p.Sale_Price = 500;
                    
                
                db.SubmitChanges();

            }



            //delete 
            using (DBSalesContextDataContext db = new DBSalesContextDataContext())
            {
                Product p = db.Products.SingleOrDefault(a => a.Pro_ID == 50);

                db.Products.DeleteOnSubmit(p);
                db.SubmitChanges();
            }


            //stored procedure select 
            using (DBSalesContextDataContext db = new DBSalesContextDataContext())
            {
                var lst = db.AllCustomers();

                foreach (var item in lst)
                {
                    Console.WriteLine($"name {item.اسم_العميل} price {item.رقم_التليفون}");
                }
            }

            Console.ReadLine();
        }
    }
}

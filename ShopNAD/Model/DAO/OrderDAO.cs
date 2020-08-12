using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAO
{
    public class OrderDAO
    {
        DbContextShopNAD db = null;

        public OrderDAO() {
            db = new DbContextShopNAD();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

            
    }
}

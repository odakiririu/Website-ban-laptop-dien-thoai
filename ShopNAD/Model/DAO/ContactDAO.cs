using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ContactDAO
    {
        DbContextShopNAD db = null;
       
        public  ContactDAO ()
        {
            db = new DbContextShopNAD();
        }

        public Contact GetInfo()
        {
            return db.Contacts.SingleOrDefault(x => x.Status == true);
        }

        public long InsertFeedBack(Feedback fb)
        {
               db.Feedbacks.Add(fb);
                db.SaveChanges();
                return fb.ID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;

namespace HearbalKart.Business.Classes
{
    public class AccountValidation
    {
        public Customers validateUser(string Email, string Password)
        {
            TList<Customers> objcust = new TList<Customers>();
            Email.Trim();
            Password.Trim();
            //string whereclaus = CustomersColumn.EmailId + " LIKE '" + SearchPanel1.Username + "%'  and Usertype=7";
            //string whereclaus = CustomersColumn.EmailId + " LIKE '" + username + "%' and "+CustomersColumn.Password+ "='" + Password + "' and " +CustomersColumn.IsActive +"=1";
            string whereclaus = CustomersColumn.EmailId + " ='" + Email + "' and " + CustomersColumn.Password + "='" + Password + "' and " + CustomersColumn.IsActive + "=1";
            int Total = 0;
            string orderby = string.Empty;
            objcust = DataRepository.CustomersProvider.GetPaged(whereclaus, orderby, 0, int.MaxValue, out Total);
            //DataRepository.CustomersProvider.DeepLoad(objcust, true);
            if ((objcust != null) && (objcust.Count > 0))
            {
                return objcust.First();
            }
            return null;
        }
    }
}

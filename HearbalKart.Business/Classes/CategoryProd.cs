using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using System.Configuration;

namespace HearbalKart.Business.Classes
{
    
    public class CategoryProd
    {
        TList<ProdTable> objprodtablelist = new TList<ProdTable>();


        public TList<ProdTable> GetproductsByCtgID(int ctgID)
        {
            string whereclaus = ProdTableColumn.CategoryId + " =" + ctgID + "and " + ProdTableColumn.IsActive + "=1";
            int Total = 0;
            string orderby = string.Empty;
            objprodtablelist = null;
            objprodtablelist = DataRepository.ProdTableProvider.GetPaged(whereclaus, orderby, 0, int.MaxValue, out Total);
            //DataRepository.CustomersProvider.DeepLoad(objcust, true);
            if ((objprodtablelist != null) && (objprodtablelist.Count > 8))
            {
                objprodtablelist.Take(1);
            }
            if ((objprodtablelist != null) && (objprodtablelist.Count > 0))
            {

                return objprodtablelist;
            }
            return null;
        }
    }
}

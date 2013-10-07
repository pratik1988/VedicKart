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
        TList<ProdCompany> Objprodcomplist = new TList<ProdCompany>();
        public IEnumerable<ProdCompany> GetCompanyByID(IEnumerable<int> ctgID)
        {


            Objprodcomplist = null;
            var objprodtable = DataRepository.ProdCompanyProvider.GetAll().Where(x => ctgID.Contains(Convert.ToInt32(x.Id)));
            if ((objprodtable != null))
            {
                return objprodtable;
            }
            return null;
        }
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
        public IEnumerable<ProdTable> GetproductsByCtgID(IEnumerable<int> ctgID)
        {
            

            objprodtablelist = null;
            var objprodtable = DataRepository.ProdTableProvider.GetAll().Where(x => ctgID.Contains(Convert.ToInt32(x.CategoryId)));
            if ((objprodtable != null))
            {
                return objprodtable;
            }
            return null;
        }
    }
}

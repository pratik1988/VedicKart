﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using System.Configuration;

namespace HearbalKart.Business.Classes
{
    
    public class Product
    {
        TList<ProdCategory> ObjprodcategoryList = new TList<ProdCategory>();
        ProdCategory Objprodcategory = new ProdCategory();
        TList<ProdCompany> Objprodcomplist = new TList<ProdCompany>();
        ProdCompany objprodcomp = new ProdCompany();
        TList<ProdMedicineFor> Objprodmedinelist = new TList<ProdMedicineFor>();
        ProdMedicineFor objprodmedicine = new ProdMedicineFor();
        TList<ProdSupplymentType> Objprodsupplylist = new TList<ProdSupplymentType>();
        ProdSupplymentType Objprodsupply = new ProdSupplymentType();
        TList<ProdType> ObjProdTypelist = new TList<ProdType>();
        ProdType ObjProdType = new ProdType();
        TList<ProdOffer> ObjProdOfferlist = new TList<ProdOffer>();
        ProdOffer ObjProdOffer = new ProdOffer();
        Items ObjProditms = new Items();
        ItemPurchase ObjProditmpurchase = new ItemPurchase();
        ItemSell ObjProditmsell = new ItemSell();
        ProdTable objprod = new ProdTable();
        TList<ProdTable> objprodlist = new TList<ProdTable>();



        #region insertProdCategory
        public string insertProdCategory(ProdCategory orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdCategoryProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdCategory
        public string UpdateProdCategory(ProdCategory orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdCategoryProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region insertProdCompany
        public string insertProdCompany(ProdCompany orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdCompanyProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdCompany
        public string UpdateProdCompany(ProdCompany orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdCompanyProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region insertProdMedicine
        public string insertProdmedicinefor(ProdMedicineFor orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdMedicineForProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdMedicine
        public string UpdateProdMedicine(ProdMedicineFor orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdMedicineForProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion


        #region insertProdSupplyment
        public string insertProdSupplymentType(ProdSupplymentType orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdSupplymentTypeProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdSupplyment
        public string UpdateProdSupplymentType(ProdSupplymentType orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdSupplymentTypeProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region insertProdType
        public string insertProdType(ProdType orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdTypeProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdType
        public string UpdateProdType(ProdType orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdTypeProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region insertProdOffer
        public string insertProdOffer(ProdOffer orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.ProdOfferProvider.Insert(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProdOffer
        public string UpdateProdOffer(ProdOffer orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.ProdOfferProvider.Update(orduser))
                {
                    // Show proper message
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region insertProd
        public string insertProd(Items obitem,ItemPurchase objitmpurchase,ItemSell ObjitmSell,ProdTable objtable)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                if ((DataRepository.ItemsProvider.Insert(transaction, obitem)))
                {
                    // Show proper message
                    objitmpurchase.ItemId = obitem.Id;
                    ObjitmSell.ItemId = obitem.Id;
                    if ((DataRepository.ItemPurchaseProvider.Insert(transaction, objitmpurchase)) && ((DataRepository.ItemSellProvider.Insert(transaction, ObjitmSell))))
                    {
                        objtable.ItemId = obitem.Id;
                        objtable.SellId = ObjitmSell.Id;
                        objtable.PurchaseId = objitmpurchase.Id;
                        if (DataRepository.ProdTableProvider.Insert(transaction, objtable))
                        {

                        }
                        else
                        {
                            transaction.Rollback();
                            return "Information could not be saved.";
                        }
                    }
                    else
                    {
                            transaction.Rollback();
                        return "Information could not be saved.";
                    }
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Insert successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        #region UpdateProd
        public string UpdateProd(Items obitem, ItemPurchase objitmpurchase, ItemSell ObjitmSell, ProdTable objtable)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                if ((DataRepository.ItemsProvider.Update(transaction, obitem)))
                {
                    // Show proper message
                    //objitmpurchase.ItemId = obitem.Id;
                    //ObjitmSell.ItemId = obitem.Id;
                    if ((DataRepository.ItemPurchaseProvider.Update(transaction, objitmpurchase)) && ((DataRepository.ItemSellProvider.Update(transaction, ObjitmSell))))
                    {
                        //objtable.ItemId = obitem.Id;
                        //objtable.SellId = ObjitmSell.Id;
                        //objtable.PurchaseId = objitmpurchase.Id;
                        if (DataRepository.ProdTableProvider.Update(transaction, objtable))
                        {

                        }
                        else
                        {
                            transaction.Rollback();
                            return "Information could not be saved.";
                        }
                    }
                    else
                    {
                        transaction.Rollback();
                        return "Information could not be saved.";
                    }
                }
                else
                {
                    return "Information could not be saved.";
                }
                transaction.Commit();
                return "Information Update successfully.";
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return "Information could not be saved.Please contact Administrator.";
            }
        }
        #endregion

        public TList<ProdCategory> GetAllProdCategories()
        {
            ObjprodcategoryList = null;
            ObjprodcategoryList = DataRepository.ProdCategoryProvider.GetAll();
            return ObjprodcategoryList;
        }

        public ProdCategory GetProdcategoryByID(int id)
        {
            Objprodcategory = null;
            Objprodcategory = DataRepository.ProdCategoryProvider.GetById(id);
            return Objprodcategory;
        }

        public TList<ProdCompany> GetAllProdCompanies()
        {
            Objprodcomplist = null;
            Objprodcomplist = DataRepository.ProdCompanyProvider.GetAll();
            return Objprodcomplist;
        }

        public ProdCompany GetProdcompByID(int id)
        {
            objprodcomp = null;
            objprodcomp = DataRepository.ProdCompanyProvider.GetById(id);
            return objprodcomp;
        }

        public TList<ProdMedicineFor> GetAllProdmedicines()
        {
            Objprodmedinelist = null;
            Objprodmedinelist = DataRepository.ProdMedicineForProvider.GetAll();
            return Objprodmedinelist;
        }

        public ProdMedicineFor GetProdmedicineByID(int id)
        {
            objprodmedicine = null;
            objprodmedicine = DataRepository.ProdMedicineForProvider.GetById(id);
            return objprodmedicine;
        }

        public TList<ProdSupplymentType> GetAllProdSupplyment()
        {
            Objprodsupplylist = null;
            Objprodsupplylist = DataRepository.ProdSupplymentTypeProvider.GetAll();
            return Objprodsupplylist;
        }

        public ProdSupplymentType GetProdsupplymentByID(int id)
        {
            Objprodsupply = null;
            Objprodsupply = DataRepository.ProdSupplymentTypeProvider.GetById(id);
            return Objprodsupply;
        }

        public TList<ProdType> GetAllProdType()
        {
            ObjProdTypelist = null;
            ObjProdTypelist = DataRepository.ProdTypeProvider.GetAll();
            return ObjProdTypelist;
        }

        public TList<ProdTable> GetAllProd()
        {
            objprodlist = null;
            objprodlist = DataRepository.ProdTableProvider.GetAll();
            return objprodlist;
        }

        public ProdTable GetProdByID(int id)
        {
            objprod = null;
            objprod = DataRepository.ProdTableProvider.GetById(id);
            return objprod;
        }
        public ProdType GetProdTypeByID(int id)
        {
            ObjProdType = null;
            ObjProdType = DataRepository.ProdTypeProvider.GetById(id);
            return ObjProdType;
        }

        public TList<ProdOffer> GetAllProdOffer()
        {
            ObjProdOfferlist = null;
            ObjProdOfferlist = DataRepository.ProdOfferProvider.GetAll();
            return ObjProdOfferlist;
        }

        public ProdOffer GetProdOfferByID(int id)
        {
            ObjProdOffer = null;
            ObjProdOffer = DataRepository.ProdOfferProvider.GetById(id);
            return ObjProdOffer;
        }

        public Items GetItemsByID(int id)
        {
            ObjProditms = null;
            ObjProditms = DataRepository.ItemsProvider.GetById(id);
            return ObjProditms;
        }

        public ItemPurchase GetItempurchaseByID(int id)
        {
            ObjProditmpurchase = null;
            ObjProditmpurchase = DataRepository.ItemPurchaseProvider.GetById(id);
            return ObjProditmpurchase;
        }

        public ItemSell GetItemsellByID(int id)
        {
            ObjProditmsell = null;
            ObjProditmsell = DataRepository.ItemSellProvider.GetById(id);
            return ObjProditmsell;
        }
    }

}

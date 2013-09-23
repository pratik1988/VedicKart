using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using System.Configuration;
namespace HearbalKart.Business.Classes
{
   public class CustomerClass
    {
       TList<Customers> objcustlist = new TList<Customers>();
       Customers objcust = new Customers();
       TList<UserType> objUsertyplist = new TList<UserType>();
       UserType objusertype = new UserType();
       TList<Gender> objgenderlist = new TList<Gender>();
       Gender objgender = new Gender();
       TList<Countries> objcountrylist = new TList<Countries>();
       Countries objcountry = new Countries();
       TList<Cities> objCitieslist = new TList<Cities>();
       Cities objCities = new Cities();
       TList<States> objStateslist = new TList<States>();
       States objStates = new States();


       #region insertCustomers
       public string insertCustomers(Customers orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();

               orduser.IsActive = true;
               if (DataRepository.CustomersProvider.Insert(orduser))
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

       #region UpdateCustomers
       public string UpdateCustomers(Customers orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();
               if (DataRepository.CustomersProvider.Update(orduser))
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

       #region insertUserType
       public string insertUserType(UserType orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();

               orduser.IsActive = true;
               if (DataRepository.UserTypeProvider.Insert(orduser))
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

       #region UpdateUserType
       public string UpdateUserType(UserType orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();
               if (DataRepository.UserTypeProvider.Update(orduser))
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

       #region insertGender
       public string insertGender(Gender orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();

               orduser.IsActive = true;
               if (DataRepository.GenderProvider.Insert(orduser))
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

       #region UpdateGender
       public string UpdateGender(Gender orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();
               if (DataRepository.GenderProvider.Update(orduser))
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

       #region insertCountries
       public string insertCountries(Countries orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();

               orduser.IsActive = true;
               if (DataRepository.CountriesProvider.Insert(orduser))
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

       #region UpdateCountries
       public string UpdateCountries(Countries orduser)
       {
           TransactionManager transaction = null;
           try
           {
               transaction = DataRepository.Provider.CreateTransaction();
               transaction.BeginTransaction();
               if (DataRepository.CountriesProvider.Update(orduser))
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


       public TList<States> GetAllStates()
       {
           objStateslist = null;
           objStateslist = DataRepository.StatesProvider.GetAll();
           return objStateslist;
       }

       public States GetStatesByID(int id)
       {
           objStates = null;
           objStates = DataRepository.StatesProvider.GetById(id);
           return objStates;
       }

       public TList<Cities> GetAllCities()
       {
           objCitieslist = null;
           objCitieslist = DataRepository.CitiesProvider.GetAll();
           return objCitieslist;
       }

       public Cities GetCitiesByID(int id)
       {
           objCities = null;
           objCities = DataRepository.CitiesProvider.GetById(id);
           return objCities;
       }
       public TList<Countries> GetAllCountries()
       {
           objcountrylist = null;
           objcountrylist = DataRepository.CountriesProvider.GetAll();
           return objcountrylist;
       }

       public Countries GetCountriesByID(int id)
       {
           objcountry = null;
           objcountry = DataRepository.CountriesProvider.GetById(id);
           return objcountry;
       }


       public TList<Customers> GetAllCustomers()
       {
           objcustlist = null;
           objcustlist = DataRepository.CustomersProvider.GetAll();
           return objcustlist;
       }

       public Customers GetCustomersByID(int id)
       {
           objcust = null;
           objcust = DataRepository.CustomersProvider.GetById(id);
           return objcust;
       }

       public TList<UserType> GetAllUserType()
       {
           objUsertyplist = null;
           objUsertyplist = DataRepository.UserTypeProvider.GetAll();
           return objUsertyplist;
       }

       public UserType GetUserTypeByID(int id)
       {
           objusertype = null;
           objusertype = DataRepository.UserTypeProvider.GetById(id);
           return objusertype;
       }

       public TList<Gender> GetAllGender()
       {
           objgenderlist = null;
           objgenderlist = DataRepository.GenderProvider.GetAll();
           return objgenderlist;
       }

       public Gender GetGenderByID(int id)
       {
           objgender = null;
           objgender = DataRepository.GenderProvider.GetById(id);
           return objgender;
       }
    }
}

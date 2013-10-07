using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using System.Configuration;

namespace HearbalKart.Business.Classes
{
    public class Order
    {
        TList<OrderStatus> OBJordrStatusList = new TList<OrderStatus>();
        TList<Orders> Objorders = new TList<Orders>();
        OrderStatus objorderStatus = new OrderStatus();
        
        #region insertOrderStatus
        public string insertOrderStatus(OrderStatus orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();

                orduser.IsActive = true;
                if (DataRepository.OrderStatusProvider.Insert(orduser))
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

        #region UpdateOrderStatus
        public string UpdateOrderStatus(OrderStatus orduser)
        {
            TransactionManager transaction = null;
            try
            {
                transaction = DataRepository.Provider.CreateTransaction();
                transaction.BeginTransaction();
                if (DataRepository.OrderStatusProvider.Update(orduser))
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

        #region Method With Parameters
        public OrderStatus GetStatusByID(int ID)
        {
            objorderStatus = null;
            objorderStatus = DataRepository.OrderStatusProvider.GetById(ID);
            return objorderStatus;
        }
        #endregion

        #region Method WithOut Parameters
        public TList<OrderStatus> GetallOrderStatus()
        {
            OBJordrStatusList = null;
            OBJordrStatusList = DataRepository.OrderStatusProvider.GetAll();
            return OBJordrStatusList;
        }

        public TList<Orders> GetAllOrders()
        {
            Objorders = null;
            Objorders = DataRepository.OrdersProvider.GetAll();
            return Objorders;
        }
        #endregion
        
    }
}

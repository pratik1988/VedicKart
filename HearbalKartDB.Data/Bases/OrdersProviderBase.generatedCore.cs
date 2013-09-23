#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using HearbalKartDB.Entities;
using HearbalKartDB.Data;

#endregion

namespace HearbalKartDB.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OrdersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrdersProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Orders, HearbalKartDB.Entities.OrdersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.OrdersKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		FK_Orders_CustomerBilling Description: 
		/// </summary>
		/// <param name="_billingId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByBillingId(System.Int32? _billingId)
		{
			int count = -1;
			return GetByBillingId(_billingId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		FK_Orders_CustomerBilling Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public TList<Orders> GetByBillingId(TransactionManager transactionManager, System.Int32? _billingId)
		{
			int count = -1;
			return GetByBillingId(transactionManager, _billingId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		FK_Orders_CustomerBilling Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByBillingId(TransactionManager transactionManager, System.Int32? _billingId, int start, int pageLength)
		{
			int count = -1;
			return GetByBillingId(transactionManager, _billingId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		fkOrdersCustomerBilling Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByBillingId(System.Int32? _billingId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillingId(null, _billingId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		fkOrdersCustomerBilling Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billingId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByBillingId(System.Int32? _billingId, int start, int pageLength,out int count)
		{
			return GetByBillingId(null, _billingId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CustomerBilling key.
		///		FK_Orders_CustomerBilling Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billingId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public abstract TList<Orders> GetByBillingId(TransactionManager transactionManager, System.Int32? _billingId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		FK_Orders_Customers Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByCustomerId(System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		FK_Orders_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		FK_Orders_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		fkOrdersCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByCustomerId(System.Int32? _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		fkOrdersCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByCustomerId(System.Int32? _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Customers key.
		///		FK_Orders_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public abstract TList<Orders> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		FK_Orders_OrderStatus Description: 
		/// </summary>
		/// <param name="_orderStatusId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByOrderStatusId(System.Int32? _orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(_orderStatusId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		FK_Orders_OrderStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderStatusId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public TList<Orders> GetByOrderStatusId(TransactionManager transactionManager, System.Int32? _orderStatusId)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, _orderStatusId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		FK_Orders_OrderStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByOrderStatusId(TransactionManager transactionManager, System.Int32? _orderStatusId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderStatusId(transactionManager, _orderStatusId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		fkOrdersOrderStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderStatusId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByOrderStatusId(System.Int32? _orderStatusId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderStatusId(null, _orderStatusId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		fkOrdersOrderStatus Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderStatusId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public TList<Orders> GetByOrderStatusId(System.Int32? _orderStatusId, int start, int pageLength,out int count)
		{
			return GetByOrderStatusId(null, _orderStatusId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_OrderStatus key.
		///		FK_Orders_OrderStatus Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderStatusId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Orders objects.</returns>
		public abstract TList<Orders> GetByOrderStatusId(TransactionManager transactionManager, System.Int32? _orderStatusId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override HearbalKartDB.Entities.Orders Get(TransactionManager transactionManager, HearbalKartDB.Entities.OrdersKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Orders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public HearbalKartDB.Entities.Orders GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public HearbalKartDB.Entities.Orders GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public HearbalKartDB.Entities.Orders GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public HearbalKartDB.Entities.Orders GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public HearbalKartDB.Entities.Orders GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Orders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Orders"/> class.</returns>
		public abstract HearbalKartDB.Entities.Orders GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Orders&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Orders&gt;"/></returns>
		public static TList<Orders> Fill(IDataReader reader, TList<Orders> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				HearbalKartDB.Entities.Orders c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Orders")
					.Append("|").Append((System.Int32)reader[((int)OrdersColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Orders>(
					key.ToString(), // EntityTrackingKey
					"Orders",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Orders();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Id = (System.Int32)reader[((int)OrdersColumn.Id - 1)];
					c.CustomerId = (reader.IsDBNull(((int)OrdersColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.CustomerId - 1)];
					c.OrderStatusId = (reader.IsDBNull(((int)OrdersColumn.OrderStatusId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.OrderStatusId - 1)];
					c.BillingId = (reader.IsDBNull(((int)OrdersColumn.BillingId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.BillingId - 1)];
					c.TotalAmount = (reader.IsDBNull(((int)OrdersColumn.TotalAmount - 1)))?null:(System.Int64?)reader[((int)OrdersColumn.TotalAmount - 1)];
					c.SurveyId = (reader.IsDBNull(((int)OrdersColumn.SurveyId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.SurveyId - 1)];
					c.IsActive = (reader.IsDBNull(((int)OrdersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsActive - 1)];
					c.IsDeliver = (reader.IsDBNull(((int)OrdersColumn.IsDeliver - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsDeliver - 1)];
					c.IsSurveyDone = (reader.IsDBNull(((int)OrdersColumn.IsSurveyDone - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsSurveyDone - 1)];
					c.BookingDate = (reader.IsDBNull(((int)OrdersColumn.BookingDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.BookingDate - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)OrdersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)OrdersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)OrdersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Orders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Orders"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Orders entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OrdersColumn.Id - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)OrdersColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.CustomerId - 1)];
			entity.OrderStatusId = (reader.IsDBNull(((int)OrdersColumn.OrderStatusId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.OrderStatusId - 1)];
			entity.BillingId = (reader.IsDBNull(((int)OrdersColumn.BillingId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.BillingId - 1)];
			entity.TotalAmount = (reader.IsDBNull(((int)OrdersColumn.TotalAmount - 1)))?null:(System.Int64?)reader[((int)OrdersColumn.TotalAmount - 1)];
			entity.SurveyId = (reader.IsDBNull(((int)OrdersColumn.SurveyId - 1)))?null:(System.Int32?)reader[((int)OrdersColumn.SurveyId - 1)];
			entity.IsActive = (reader.IsDBNull(((int)OrdersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsActive - 1)];
			entity.IsDeliver = (reader.IsDBNull(((int)OrdersColumn.IsDeliver - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsDeliver - 1)];
			entity.IsSurveyDone = (reader.IsDBNull(((int)OrdersColumn.IsSurveyDone - 1)))?null:(System.Boolean?)reader[((int)OrdersColumn.IsSurveyDone - 1)];
			entity.BookingDate = (reader.IsDBNull(((int)OrdersColumn.BookingDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.BookingDate - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)OrdersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)OrdersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)OrdersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrdersColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Orders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Orders"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Orders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.OrderStatusId = Convert.IsDBNull(dataRow["OrderStatusID"]) ? null : (System.Int32?)dataRow["OrderStatusID"];
			entity.BillingId = Convert.IsDBNull(dataRow["BillingID"]) ? null : (System.Int32?)dataRow["BillingID"];
			entity.TotalAmount = Convert.IsDBNull(dataRow["TotalAmount"]) ? null : (System.Int64?)dataRow["TotalAmount"];
			entity.SurveyId = Convert.IsDBNull(dataRow["SurveyID"]) ? null : (System.Int32?)dataRow["SurveyID"];
			entity.IsActive = Convert.IsDBNull(dataRow["ISActive"]) ? null : (System.Boolean?)dataRow["ISActive"];
			entity.IsDeliver = Convert.IsDBNull(dataRow["ISDeliver"]) ? null : (System.Boolean?)dataRow["ISDeliver"];
			entity.IsSurveyDone = Convert.IsDBNull(dataRow["IsSurveyDone"]) ? null : (System.Boolean?)dataRow["IsSurveyDone"];
			entity.BookingDate = Convert.IsDBNull(dataRow["BookingDate"]) ? null : (System.DateTime?)dataRow["BookingDate"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.ModifiedDate = Convert.IsDBNull(dataRow["ModifiedDate"]) ? null : (System.DateTime?)dataRow["ModifiedDate"];
			entity.DeletedDate = Convert.IsDBNull(dataRow["DeletedDate"]) ? null : (System.DateTime?)dataRow["DeletedDate"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Orders"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Orders Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Orders entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region BillingIdSource	
			if (CanDeepLoad(entity, "CustomerBilling|BillingIdSource", deepLoadType, innerList) 
				&& entity.BillingIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.BillingId ?? (int)0);
				CustomerBilling tmpEntity = EntityManager.LocateEntity<CustomerBilling>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomerBilling), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillingIdSource = tmpEntity;
				else
					entity.BillingIdSource = DataRepository.CustomerBillingProvider.GetById(transactionManager, (entity.BillingId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillingIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillingIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerBillingProvider.DeepLoad(transactionManager, entity.BillingIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillingIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customers|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CustomerId ?? (int)0);
				Customers tmpEntity = EntityManager.LocateEntity<Customers>(EntityLocator.ConstructKeyFromPkItems(typeof(Customers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomersProvider.GetById(transactionManager, (entity.CustomerId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomersProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource

			#region OrderStatusIdSource	
			if (CanDeepLoad(entity, "OrderStatus|OrderStatusIdSource", deepLoadType, innerList) 
				&& entity.OrderStatusIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OrderStatusId ?? (int)0);
				OrderStatus tmpEntity = EntityManager.LocateEntity<OrderStatus>(EntityLocator.ConstructKeyFromPkItems(typeof(OrderStatus), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderStatusIdSource = tmpEntity;
				else
					entity.OrderStatusIdSource = DataRepository.OrderStatusProvider.GetById(transactionManager, (entity.OrderStatusId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderStatusIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderStatusIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OrderStatusProvider.DeepLoad(transactionManager, entity.OrderStatusIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderStatusIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomerBillingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerBilling>|CustomerBillingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerBillingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerBillingCollection = DataRepository.CustomerBillingProvider.GetByOrderId(transactionManager, entity.Id);

				if (deep && entity.CustomerBillingCollection.Count > 0)
				{
					deepHandles.Add("CustomerBillingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerBilling>) DataRepository.CustomerBillingProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerBillingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region OrderDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderDetails>|OrderDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrderDetailsCollection = DataRepository.OrderDetailsProvider.GetByOrderId(transactionManager, entity.Id);

				if (deep && entity.OrderDetailsCollection.Count > 0)
				{
					deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<OrderDetails>) DataRepository.OrderDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderDetailsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DistributorsOrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DistributorsOrders>|DistributorsOrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistributorsOrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DistributorsOrdersCollection = DataRepository.DistributorsOrdersProvider.GetByOrderId(transactionManager, entity.Id);

				if (deep && entity.DistributorsOrdersCollection.Count > 0)
				{
					deepHandles.Add("DistributorsOrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DistributorsOrders>) DataRepository.DistributorsOrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.DistributorsOrdersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Orders object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Orders instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Orders Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Orders entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region BillingIdSource
			if (CanDeepSave(entity, "CustomerBilling|BillingIdSource", deepSaveType, innerList) 
				&& entity.BillingIdSource != null)
			{
				DataRepository.CustomerBillingProvider.Save(transactionManager, entity.BillingIdSource);
				entity.BillingId = entity.BillingIdSource.Id;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customers|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.Id;
			}
			#endregion 
			
			#region OrderStatusIdSource
			if (CanDeepSave(entity, "OrderStatus|OrderStatusIdSource", deepSaveType, innerList) 
				&& entity.OrderStatusIdSource != null)
			{
				DataRepository.OrderStatusProvider.Save(transactionManager, entity.OrderStatusIdSource);
				entity.OrderStatusId = entity.OrderStatusIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<CustomerBilling>
				if (CanDeepSave(entity.CustomerBillingCollection, "List<CustomerBilling>|CustomerBillingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerBilling child in entity.CustomerBillingCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.Id;
						}
						else
						{
							child.OrderId = entity.Id;
						}

					}

					if (entity.CustomerBillingCollection.Count > 0 || entity.CustomerBillingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerBillingProvider.Save(transactionManager, entity.CustomerBillingCollection);
						
						deepHandles.Add("CustomerBillingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerBilling >) DataRepository.CustomerBillingProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerBillingCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<OrderDetails>
				if (CanDeepSave(entity.OrderDetailsCollection, "List<OrderDetails>|OrderDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderDetails child in entity.OrderDetailsCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.Id;
						}
						else
						{
							child.OrderId = entity.Id;
						}

					}

					if (entity.OrderDetailsCollection.Count > 0 || entity.OrderDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OrderDetailsProvider.Save(transactionManager, entity.OrderDetailsCollection);
						
						deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< OrderDetails >) DataRepository.OrderDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.OrderDetailsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<DistributorsOrders>
				if (CanDeepSave(entity.DistributorsOrdersCollection, "List<DistributorsOrders>|DistributorsOrdersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DistributorsOrders child in entity.DistributorsOrdersCollection)
					{
						if(child.OrderIdSource != null)
						{
							child.OrderId = child.OrderIdSource.Id;
						}
						else
						{
							child.OrderId = entity.Id;
						}

					}

					if (entity.DistributorsOrdersCollection.Count > 0 || entity.DistributorsOrdersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DistributorsOrdersProvider.Save(transactionManager, entity.DistributorsOrdersCollection);
						
						deepHandles.Add("DistributorsOrdersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DistributorsOrders >) DataRepository.DistributorsOrdersProvider.DeepSave,
							new object[] { transactionManager, entity.DistributorsOrdersCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region OrdersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Orders</c>
	///</summary>
	public enum OrdersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CustomerBilling</c> at BillingIdSource
		///</summary>
		[ChildEntityType(typeof(CustomerBilling))]
		CustomerBilling,
		
		///<summary>
		/// Composite Property for <c>Customers</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customers))]
		Customers,
		
		///<summary>
		/// Composite Property for <c>OrderStatus</c> at OrderStatusIdSource
		///</summary>
		[ChildEntityType(typeof(OrderStatus))]
		OrderStatus,
		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for CustomerBillingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerBilling>))]
		CustomerBillingCollection,
		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for OrderDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderDetails>))]
		OrderDetailsCollection,
		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for DistributorsOrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<DistributorsOrders>))]
		DistributorsOrdersCollection,
	}
	
	#endregion OrdersChildEntityTypes
	
	#region OrdersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilterBuilder : SqlFilterBuilder<OrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		public OrdersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersFilterBuilder
	
	#region OrdersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersParameterBuilder : ParameterizedSqlFilterBuilder<OrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		public OrdersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersParameterBuilder
	
	#region OrdersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrdersSortBuilder : SqlSortBuilder<OrdersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersSqlSortBuilder class.
		/// </summary>
		public OrdersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrdersSortBuilder
	
} // end namespace

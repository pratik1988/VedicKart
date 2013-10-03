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
	/// This class is the base class for any <see cref="OrderDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderDetailsProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.OrderDetails, HearbalKartDB.Entities.OrderDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.OrderDetailsKey key)
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
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		FK_OrderDetails_Customers Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByCustomerId(System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		FK_OrderDetails_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		/// <remarks></remarks>
		public TList<OrderDetails> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		FK_OrderDetails_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		fkOrderDetailsCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByCustomerId(System.Int32? _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		fkOrderDetailsCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByCustomerId(System.Int32? _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Customers key.
		///		FK_OrderDetails_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public abstract TList<OrderDetails> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		FK_OrderDetails_Items Description: 
		/// </summary>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByItemId(System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(_itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		FK_OrderDetails_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		/// <remarks></remarks>
		public TList<OrderDetails> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		FK_OrderDetails_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		fkOrderDetailsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByItemId(System.Int32? _itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, _itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		fkOrderDetailsItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByItemId(System.Int32? _itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, _itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Items key.
		///		FK_OrderDetails_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public abstract TList<OrderDetails> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		FK_OrderDetails_Orders Description: 
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(_orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		FK_OrderDetails_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		/// <remarks></remarks>
		public TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		FK_OrderDetails_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		fkOrderDetailsOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32? _orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, _orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		fkOrderDetailsOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public TList<OrderDetails> GetByOrderId(System.Int32? _orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_OrderDetails_Orders key.
		///		FK_OrderDetails_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.OrderDetails objects.</returns>
		public abstract TList<OrderDetails> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.OrderDetails Get(TransactionManager transactionManager, HearbalKartDB.Entities.OrderDetailsKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OrderDetails index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public HearbalKartDB.Entities.OrderDetails GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderDetails index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public HearbalKartDB.Entities.OrderDetails GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public HearbalKartDB.Entities.OrderDetails GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public HearbalKartDB.Entities.OrderDetails GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderDetails index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public HearbalKartDB.Entities.OrderDetails GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderDetails"/> class.</returns>
		public abstract HearbalKartDB.Entities.OrderDetails GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;OrderDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;OrderDetails&gt;"/></returns>
		public static TList<OrderDetails> Fill(IDataReader reader, TList<OrderDetails> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.OrderDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OrderDetails")
					.Append("|").Append((System.Int32)reader[((int)OrderDetailsColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<OrderDetails>(
					key.ToString(), // EntityTrackingKey
					"OrderDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.OrderDetails();
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
					c.Id = (System.Int32)reader[((int)OrderDetailsColumn.Id - 1)];
					c.OrderId = (reader.IsDBNull(((int)OrderDetailsColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.OrderId - 1)];
					c.CustomerId = (reader.IsDBNull(((int)OrderDetailsColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.CustomerId - 1)];
					c.ItemId = (reader.IsDBNull(((int)OrderDetailsColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.ItemId - 1)];
					c.Amount = (reader.IsDBNull(((int)OrderDetailsColumn.Amount - 1)))?null:(System.Int64?)reader[((int)OrderDetailsColumn.Amount - 1)];
					c.IsActive = (reader.IsDBNull(((int)OrderDetailsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrderDetailsColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)OrderDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)OrderDetailsColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)OrderDetailsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.OrderDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.OrderDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OrderDetailsColumn.Id - 1)];
			entity.OrderId = (reader.IsDBNull(((int)OrderDetailsColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.OrderId - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)OrderDetailsColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.CustomerId - 1)];
			entity.ItemId = (reader.IsDBNull(((int)OrderDetailsColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)OrderDetailsColumn.ItemId - 1)];
			entity.Amount = (reader.IsDBNull(((int)OrderDetailsColumn.Amount - 1)))?null:(System.Int64?)reader[((int)OrderDetailsColumn.Amount - 1)];
			entity.IsActive = (reader.IsDBNull(((int)OrderDetailsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrderDetailsColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)OrderDetailsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)OrderDetailsColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)OrderDetailsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrderDetailsColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.OrderDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.OrderDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OrderId = Convert.IsDBNull(dataRow["OrderId"]) ? null : (System.Int32?)dataRow["OrderId"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.ItemId = Convert.IsDBNull(dataRow["ItemID"]) ? null : (System.Int32?)dataRow["ItemID"];
			entity.Amount = Convert.IsDBNull(dataRow["Amount"]) ? null : (System.Int64?)dataRow["Amount"];
			entity.IsActive = Convert.IsDBNull(dataRow["ISActive"]) ? null : (System.Boolean?)dataRow["ISActive"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.OrderDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.OrderDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Items|ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ItemId ?? (int)0);
				Items tmpEntity = EntityManager.LocateEntity<Items>(EntityLocator.ConstructKeyFromPkItems(typeof(Items), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemsProvider.GetById(transactionManager, (entity.ItemId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ItemIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ItemsProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ItemIdSource

			#region OrderIdSource	
			if (CanDeepLoad(entity, "Orders|OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OrderId ?? (int)0);
				Orders tmpEntity = EntityManager.LocateEntity<Orders>(EntityLocator.ConstructKeyFromPkItems(typeof(Orders), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.OrdersProvider.GetById(transactionManager, (entity.OrderId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.OrderDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.OrderDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.OrderDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.OrderDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customers|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.Id;
			}
			#endregion 
			
			#region ItemIdSource
			if (CanDeepSave(entity, "Items|ItemIdSource", deepSaveType, innerList) 
				&& entity.ItemIdSource != null)
			{
				DataRepository.ItemsProvider.Save(transactionManager, entity.ItemIdSource);
				entity.ItemId = entity.ItemIdSource.Id;
			}
			#endregion 
			
			#region OrderIdSource
			if (CanDeepSave(entity, "Orders|OrderIdSource", deepSaveType, innerList) 
				&& entity.OrderIdSource != null)
			{
				DataRepository.OrdersProvider.Save(transactionManager, entity.OrderIdSource);
				entity.OrderId = entity.OrderIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region OrderDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.OrderDetails</c>
	///</summary>
	public enum OrderDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Customers</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customers))]
		Customers,
		
		///<summary>
		/// Composite Property for <c>Items</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Items))]
		Items,
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
	}
	
	#endregion OrderDetailsChildEntityTypes
	
	#region OrderDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsFilterBuilder : SqlFilterBuilder<OrderDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		public OrderDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsFilterBuilder
	
	#region OrderDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsParameterBuilder : ParameterizedSqlFilterBuilder<OrderDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		public OrderDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsParameterBuilder
	
	#region OrderDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrderDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderDetailsSortBuilder : SqlSortBuilder<OrderDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsSqlSortBuilder class.
		/// </summary>
		public OrderDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderDetailsSortBuilder
	
} // end namespace

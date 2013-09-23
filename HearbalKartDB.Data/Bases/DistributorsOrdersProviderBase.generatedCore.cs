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
	/// This class is the base class for any <see cref="DistributorsOrdersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DistributorsOrdersProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.DistributorsOrders, HearbalKartDB.Entities.DistributorsOrdersKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.DistributorsOrdersKey key)
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
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		FK_DistributorsOrders_Distributars Description: 
		/// </summary>
		/// <param name="_distributorId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByDistributorId(System.Int32? _distributorId)
		{
			int count = -1;
			return GetByDistributorId(_distributorId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		FK_DistributorsOrders_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_distributorId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		/// <remarks></remarks>
		public TList<DistributorsOrders> GetByDistributorId(TransactionManager transactionManager, System.Int32? _distributorId)
		{
			int count = -1;
			return GetByDistributorId(transactionManager, _distributorId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		FK_DistributorsOrders_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_distributorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByDistributorId(TransactionManager transactionManager, System.Int32? _distributorId, int start, int pageLength)
		{
			int count = -1;
			return GetByDistributorId(transactionManager, _distributorId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		fkDistributorsOrdersDistributars Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_distributorId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByDistributorId(System.Int32? _distributorId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDistributorId(null, _distributorId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		fkDistributorsOrdersDistributars Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_distributorId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByDistributorId(System.Int32? _distributorId, int start, int pageLength,out int count)
		{
			return GetByDistributorId(null, _distributorId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Distributars key.
		///		FK_DistributorsOrders_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_distributorId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public abstract TList<DistributorsOrders> GetByDistributorId(TransactionManager transactionManager, System.Int32? _distributorId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		FK_DistributorsOrders_Orders Description: 
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByOrderId(System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(_orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		FK_DistributorsOrders_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		/// <remarks></remarks>
		public TList<DistributorsOrders> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		FK_DistributorsOrders_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		fkDistributorsOrdersOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByOrderId(System.Int32? _orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, _orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		fkDistributorsOrdersOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public TList<DistributorsOrders> GetByOrderId(System.Int32? _orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_DistributorsOrders_Orders key.
		///		FK_DistributorsOrders_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.DistributorsOrders objects.</returns>
		public abstract TList<DistributorsOrders> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.DistributorsOrders Get(TransactionManager transactionManager, HearbalKartDB.Entities.DistributorsOrdersKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DistributorsOrders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public HearbalKartDB.Entities.DistributorsOrders GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DistributorsOrders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public HearbalKartDB.Entities.DistributorsOrders GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DistributorsOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public HearbalKartDB.Entities.DistributorsOrders GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DistributorsOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public HearbalKartDB.Entities.DistributorsOrders GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DistributorsOrders index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public HearbalKartDB.Entities.DistributorsOrders GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DistributorsOrders index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> class.</returns>
		public abstract HearbalKartDB.Entities.DistributorsOrders GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DistributorsOrders&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DistributorsOrders&gt;"/></returns>
		public static TList<DistributorsOrders> Fill(IDataReader reader, TList<DistributorsOrders> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.DistributorsOrders c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DistributorsOrders")
					.Append("|").Append((System.Int32)reader[((int)DistributorsOrdersColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DistributorsOrders>(
					key.ToString(), // EntityTrackingKey
					"DistributorsOrders",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.DistributorsOrders();
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
					c.Id = (System.Int32)reader[((int)DistributorsOrdersColumn.Id - 1)];
					c.DistributorId = (reader.IsDBNull(((int)DistributorsOrdersColumn.DistributorId - 1)))?null:(System.Int32?)reader[((int)DistributorsOrdersColumn.DistributorId - 1)];
					c.OrderId = (reader.IsDBNull(((int)DistributorsOrdersColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)DistributorsOrdersColumn.OrderId - 1)];
					c.IsActive = (reader.IsDBNull(((int)DistributorsOrdersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DistributorsOrdersColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DistributorsOrders"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.DistributorsOrders entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)DistributorsOrdersColumn.Id - 1)];
			entity.DistributorId = (reader.IsDBNull(((int)DistributorsOrdersColumn.DistributorId - 1)))?null:(System.Int32?)reader[((int)DistributorsOrdersColumn.DistributorId - 1)];
			entity.OrderId = (reader.IsDBNull(((int)DistributorsOrdersColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)DistributorsOrdersColumn.OrderId - 1)];
			entity.IsActive = (reader.IsDBNull(((int)DistributorsOrdersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DistributorsOrdersColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)DistributorsOrdersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DistributorsOrdersColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.DistributorsOrders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DistributorsOrders"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.DistributorsOrders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.DistributorId = Convert.IsDBNull(dataRow["DistributorID"]) ? null : (System.Int32?)dataRow["DistributorID"];
			entity.OrderId = Convert.IsDBNull(dataRow["OrderID"]) ? null : (System.Int32?)dataRow["OrderID"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DistributorsOrders"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.DistributorsOrders Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.DistributorsOrders entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DistributorIdSource	
			if (CanDeepLoad(entity, "Distributars|DistributorIdSource", deepLoadType, innerList) 
				&& entity.DistributorIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DistributorId ?? (int)0);
				Distributars tmpEntity = EntityManager.LocateEntity<Distributars>(EntityLocator.ConstructKeyFromPkItems(typeof(Distributars), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DistributorIdSource = tmpEntity;
				else
					entity.DistributorIdSource = DataRepository.DistributarsProvider.GetById(transactionManager, (entity.DistributorId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistributorIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DistributorIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DistributarsProvider.DeepLoad(transactionManager, entity.DistributorIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DistributorIdSource

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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.DistributorsOrders object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.DistributorsOrders instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.DistributorsOrders Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.DistributorsOrders entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DistributorIdSource
			if (CanDeepSave(entity, "Distributars|DistributorIdSource", deepSaveType, innerList) 
				&& entity.DistributorIdSource != null)
			{
				DataRepository.DistributarsProvider.Save(transactionManager, entity.DistributorIdSource);
				entity.DistributorId = entity.DistributorIdSource.Id;
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
	
	#region DistributorsOrdersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.DistributorsOrders</c>
	///</summary>
	public enum DistributorsOrdersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Distributars</c> at DistributorIdSource
		///</summary>
		[ChildEntityType(typeof(Distributars))]
		Distributars,
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
	}
	
	#endregion DistributorsOrdersChildEntityTypes
	
	#region DistributorsOrdersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DistributorsOrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersFilterBuilder : SqlFilterBuilder<DistributorsOrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilterBuilder class.
		/// </summary>
		public DistributorsOrdersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributorsOrdersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributorsOrdersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributorsOrdersFilterBuilder
	
	#region DistributorsOrdersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DistributorsOrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersParameterBuilder : ParameterizedSqlFilterBuilder<DistributorsOrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersParameterBuilder class.
		/// </summary>
		public DistributorsOrdersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributorsOrdersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributorsOrdersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributorsOrdersParameterBuilder
	
	#region DistributorsOrdersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DistributorsOrdersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DistributorsOrdersSortBuilder : SqlSortBuilder<DistributorsOrdersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersSqlSortBuilder class.
		/// </summary>
		public DistributorsOrdersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DistributorsOrdersSortBuilder
	
} // end namespace

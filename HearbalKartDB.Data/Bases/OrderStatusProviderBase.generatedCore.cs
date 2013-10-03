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
	/// This class is the base class for any <see cref="OrderStatusProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrderStatusProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.OrderStatus, HearbalKartDB.Entities.OrderStatusKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.OrderStatusKey key)
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
		public override HearbalKartDB.Entities.OrderStatus Get(TransactionManager transactionManager, HearbalKartDB.Entities.OrderStatusKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OrderStatus index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public HearbalKartDB.Entities.OrderStatus GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderStatus index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public HearbalKartDB.Entities.OrderStatus GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public HearbalKartDB.Entities.OrderStatus GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public HearbalKartDB.Entities.OrderStatus GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderStatus index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public HearbalKartDB.Entities.OrderStatus GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OrderStatus index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.OrderStatus"/> class.</returns>
		public abstract HearbalKartDB.Entities.OrderStatus GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;OrderStatus&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;OrderStatus&gt;"/></returns>
		public static TList<OrderStatus> Fill(IDataReader reader, TList<OrderStatus> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.OrderStatus c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OrderStatus")
					.Append("|").Append((System.Int32)reader[((int)OrderStatusColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<OrderStatus>(
					key.ToString(), // EntityTrackingKey
					"OrderStatus",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.OrderStatus();
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
					c.Id = (System.Int32)reader[((int)OrderStatusColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)OrderStatusColumn.Name - 1)))?null:(System.String)reader[((int)OrderStatusColumn.Name - 1)];
					c.IsActive = (reader.IsDBNull(((int)OrderStatusColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrderStatusColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)OrderStatusColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)OrderStatusColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)OrderStatusColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.OrderStatus"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderStatus"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.OrderStatus entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)OrderStatusColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)OrderStatusColumn.Name - 1)))?null:(System.String)reader[((int)OrderStatusColumn.Name - 1)];
			entity.IsActive = (reader.IsDBNull(((int)OrderStatusColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)OrderStatusColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)OrderStatusColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)OrderStatusColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)OrderStatusColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)OrderStatusColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.OrderStatus"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderStatus"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.OrderStatus entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.OrderStatus"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.OrderStatus Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.OrderStatus entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>|OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByOrderStatusId(transactionManager, entity.Id);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Orders>) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.OrderStatus object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.OrderStatus instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.OrderStatus Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.OrderStatus entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<Orders>
				if (CanDeepSave(entity.OrdersCollection, "List<Orders>|OrdersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Orders child in entity.OrdersCollection)
					{
						if(child.OrderStatusIdSource != null)
						{
							child.OrderStatusId = child.OrderStatusIdSource.Id;
						}
						else
						{
							child.OrderStatusId = entity.Id;
						}

					}

					if (entity.OrdersCollection.Count > 0 || entity.OrdersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.OrdersProvider.Save(transactionManager, entity.OrdersCollection);
						
						deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Orders >) DataRepository.OrdersProvider.DeepSave,
							new object[] { transactionManager, entity.OrdersCollection, deepSaveType, childTypes, innerList }
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
	
	#region OrderStatusChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.OrderStatus</c>
	///</summary>
	public enum OrderStatusChildEntityTypes
	{
		///<summary>
		/// Collection of <c>OrderStatus</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,
	}
	
	#endregion OrderStatusChildEntityTypes
	
	#region OrderStatusFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OrderStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilterBuilder : SqlFilterBuilder<OrderStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		public OrderStatusFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusFilterBuilder
	
	#region OrderStatusParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OrderStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusParameterBuilder : ParameterizedSqlFilterBuilder<OrderStatusColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusParameterBuilder class.
		/// </summary>
		public OrderStatusParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusParameterBuilder
	
	#region OrderStatusSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OrderStatusColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OrderStatusSortBuilder : SqlSortBuilder<OrderStatusColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusSqlSortBuilder class.
		/// </summary>
		public OrderStatusSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OrderStatusSortBuilder
	
} // end namespace

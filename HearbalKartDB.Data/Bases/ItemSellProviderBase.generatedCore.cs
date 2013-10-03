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
	/// This class is the base class for any <see cref="ItemSellProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemSellProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.ItemSell, HearbalKartDB.Entities.ItemSellKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ItemSellKey key)
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
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		FK_ItemSell_Items Description: 
		/// </summary>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		public TList<ItemSell> GetByItemId(System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(_itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		FK_ItemSell_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		/// <remarks></remarks>
		public TList<ItemSell> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		FK_ItemSell_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		public TList<ItemSell> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		fkItemSellItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		public TList<ItemSell> GetByItemId(System.Int32? _itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, _itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		fkItemSellItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		public TList<ItemSell> GetByItemId(System.Int32? _itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, _itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ItemSell_Items key.
		///		FK_ItemSell_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ItemSell objects.</returns>
		public abstract TList<ItemSell> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.ItemSell Get(TransactionManager transactionManager, HearbalKartDB.Entities.ItemSellKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ItemSell index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public HearbalKartDB.Entities.ItemSell GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemSell index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public HearbalKartDB.Entities.ItemSell GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemSell index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public HearbalKartDB.Entities.ItemSell GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemSell index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public HearbalKartDB.Entities.ItemSell GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemSell index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public HearbalKartDB.Entities.ItemSell GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ItemSell index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ItemSell"/> class.</returns>
		public abstract HearbalKartDB.Entities.ItemSell GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ItemSell&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ItemSell&gt;"/></returns>
		public static TList<ItemSell> Fill(IDataReader reader, TList<ItemSell> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.ItemSell c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ItemSell")
					.Append("|").Append((System.Int32)reader[((int)ItemSellColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ItemSell>(
					key.ToString(), // EntityTrackingKey
					"ItemSell",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.ItemSell();
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
					c.Id = (System.Int32)reader[((int)ItemSellColumn.Id - 1)];
					c.ItemId = (reader.IsDBNull(((int)ItemSellColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)ItemSellColumn.ItemId - 1)];
					c.Cost = (reader.IsDBNull(((int)ItemSellColumn.Cost - 1)))?null:(System.String)reader[((int)ItemSellColumn.Cost - 1)];
					c.CostVary = (reader.IsDBNull(((int)ItemSellColumn.CostVary - 1)))?null:(System.Decimal?)reader[((int)ItemSellColumn.CostVary - 1)];
					c.Createdate = (reader.IsDBNull(((int)ItemSellColumn.Createdate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.Createdate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)ItemSellColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ItemSellColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ItemSell"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ItemSell"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.ItemSell entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ItemSellColumn.Id - 1)];
			entity.ItemId = (reader.IsDBNull(((int)ItemSellColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)ItemSellColumn.ItemId - 1)];
			entity.Cost = (reader.IsDBNull(((int)ItemSellColumn.Cost - 1)))?null:(System.String)reader[((int)ItemSellColumn.Cost - 1)];
			entity.CostVary = (reader.IsDBNull(((int)ItemSellColumn.CostVary - 1)))?null:(System.Decimal?)reader[((int)ItemSellColumn.CostVary - 1)];
			entity.Createdate = (reader.IsDBNull(((int)ItemSellColumn.Createdate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.Createdate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)ItemSellColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ItemSellColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ItemSellColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ItemSell"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ItemSell"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.ItemSell entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ItemId = Convert.IsDBNull(dataRow["ItemID"]) ? null : (System.Int32?)dataRow["ItemID"];
			entity.Cost = Convert.IsDBNull(dataRow["Cost"]) ? null : (System.String)dataRow["Cost"];
			entity.CostVary = Convert.IsDBNull(dataRow["CostVary"]) ? null : (System.Decimal?)dataRow["CostVary"];
			entity.Createdate = Convert.IsDBNull(dataRow["Createdate"]) ? null : (System.DateTime?)dataRow["Createdate"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ItemSell"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ItemSell Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.ItemSell entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

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
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region ProdTableCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProdTable>|ProdTableCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProdTableCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProdTableCollection = DataRepository.ProdTableProvider.GetBySellId(transactionManager, entity.Id);

				if (deep && entity.ProdTableCollection.Count > 0)
				{
					deepHandles.Add("ProdTableCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProdTable>) DataRepository.ProdTableProvider.DeepLoad,
						new object[] { transactionManager, entity.ProdTableCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.ItemSell object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.ItemSell instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ItemSell Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.ItemSell entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ItemIdSource
			if (CanDeepSave(entity, "Items|ItemIdSource", deepSaveType, innerList) 
				&& entity.ItemIdSource != null)
			{
				DataRepository.ItemsProvider.Save(transactionManager, entity.ItemIdSource);
				entity.ItemId = entity.ItemIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<ProdTable>
				if (CanDeepSave(entity.ProdTableCollection, "List<ProdTable>|ProdTableCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProdTable child in entity.ProdTableCollection)
					{
						if(child.SellIdSource != null)
						{
							child.SellId = child.SellIdSource.Id;
						}
						else
						{
							child.SellId = entity.Id;
						}

					}

					if (entity.ProdTableCollection.Count > 0 || entity.ProdTableCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProdTableProvider.Save(transactionManager, entity.ProdTableCollection);
						
						deepHandles.Add("ProdTableCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProdTable >) DataRepository.ProdTableProvider.DeepSave,
							new object[] { transactionManager, entity.ProdTableCollection, deepSaveType, childTypes, innerList }
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
	
	#region ItemSellChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.ItemSell</c>
	///</summary>
	public enum ItemSellChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Items</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Items))]
		Items,
		///<summary>
		/// Collection of <c>ItemSell</c> as OneToMany for ProdTableCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProdTable>))]
		ProdTableCollection,
	}
	
	#endregion ItemSellChildEntityTypes
	
	#region ItemSellFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ItemSellColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellFilterBuilder : SqlFilterBuilder<ItemSellColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellFilterBuilder class.
		/// </summary>
		public ItemSellFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemSellFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemSellFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemSellFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemSellFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemSellFilterBuilder
	
	#region ItemSellParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ItemSellColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellParameterBuilder : ParameterizedSqlFilterBuilder<ItemSellColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellParameterBuilder class.
		/// </summary>
		public ItemSellParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemSellParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemSellParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemSellParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemSellParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemSellParameterBuilder
	
	#region ItemSellSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ItemSellColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ItemSellSortBuilder : SqlSortBuilder<ItemSellColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellSqlSortBuilder class.
		/// </summary>
		public ItemSellSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ItemSellSortBuilder
	
} // end namespace

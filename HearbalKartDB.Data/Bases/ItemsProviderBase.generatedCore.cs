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
	/// This class is the base class for any <see cref="ItemsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ItemsProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Items, HearbalKartDB.Entities.ItemsKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ItemsKey key)
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
		public override HearbalKartDB.Entities.Items Get(TransactionManager transactionManager, HearbalKartDB.Entities.ItemsKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Items index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public HearbalKartDB.Entities.Items GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public HearbalKartDB.Entities.Items GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public HearbalKartDB.Entities.Items GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public HearbalKartDB.Entities.Items GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public HearbalKartDB.Entities.Items GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Items index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Items"/> class.</returns>
		public abstract HearbalKartDB.Entities.Items GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Items&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Items&gt;"/></returns>
		public static TList<Items> Fill(IDataReader reader, TList<Items> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.Items c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Items")
					.Append("|").Append((System.Int32)reader[((int)ItemsColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Items>(
					key.ToString(), // EntityTrackingKey
					"Items",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Items();
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
					c.Id = (System.Int32)reader[((int)ItemsColumn.Id - 1)];
					c.ItemName = (reader.IsDBNull(((int)ItemsColumn.ItemName - 1)))?null:(System.String)reader[((int)ItemsColumn.ItemName - 1)];
					c.IsActive = (reader.IsDBNull(((int)ItemsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ItemsColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)ItemsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.CreatedDate - 1)];
					c.Modifieddate = (reader.IsDBNull(((int)ItemsColumn.Modifieddate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.Modifieddate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ItemsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Items"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Items"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Items entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ItemsColumn.Id - 1)];
			entity.ItemName = (reader.IsDBNull(((int)ItemsColumn.ItemName - 1)))?null:(System.String)reader[((int)ItemsColumn.ItemName - 1)];
			entity.IsActive = (reader.IsDBNull(((int)ItemsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ItemsColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)ItemsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.CreatedDate - 1)];
			entity.Modifieddate = (reader.IsDBNull(((int)ItemsColumn.Modifieddate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.Modifieddate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ItemsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ItemsColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Items"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Items"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Items entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ItemName = Convert.IsDBNull(dataRow["ItemName"]) ? null : (System.String)dataRow["ItemName"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.Modifieddate = Convert.IsDBNull(dataRow["Modifieddate"]) ? null : (System.DateTime?)dataRow["Modifieddate"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Items"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Items Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Items entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region ItemPurchaseCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemPurchase>|ItemPurchaseCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemPurchaseCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ItemPurchaseCollection = DataRepository.ItemPurchaseProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.ItemPurchaseCollection.Count > 0)
				{
					deepHandles.Add("ItemPurchaseCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ItemPurchase>) DataRepository.ItemPurchaseProvider.DeepLoad,
						new object[] { transactionManager, entity.ItemPurchaseCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ProdTableCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProdTable>|ProdTableCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProdTableCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProdTableCollection = DataRepository.ProdTableProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.ProdTableCollection.Count > 0)
				{
					deepHandles.Add("ProdTableCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProdTable>) DataRepository.ProdTableProvider.DeepLoad,
						new object[] { transactionManager, entity.ProdTableCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region ItemSellCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ItemSell>|ItemSellCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemSellCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ItemSellCollection = DataRepository.ItemSellProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.ItemSellCollection.Count > 0)
				{
					deepHandles.Add("ItemSellCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ItemSell>) DataRepository.ItemSellProvider.DeepLoad,
						new object[] { transactionManager, entity.ItemSellCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.OrderDetailsCollection = DataRepository.OrderDetailsProvider.GetByItemId(transactionManager, entity.Id);

				if (deep && entity.OrderDetailsCollection.Count > 0)
				{
					deepHandles.Add("OrderDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<OrderDetails>) DataRepository.OrderDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.OrderDetailsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Items object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Items instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Items Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Items entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<ItemPurchase>
				if (CanDeepSave(entity.ItemPurchaseCollection, "List<ItemPurchase>|ItemPurchaseCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemPurchase child in entity.ItemPurchaseCollection)
					{
						if(child.ItemIdSource != null)
						{
							child.ItemId = child.ItemIdSource.Id;
						}
						else
						{
							child.ItemId = entity.Id;
						}

					}

					if (entity.ItemPurchaseCollection.Count > 0 || entity.ItemPurchaseCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ItemPurchaseProvider.Save(transactionManager, entity.ItemPurchaseCollection);
						
						deepHandles.Add("ItemPurchaseCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ItemPurchase >) DataRepository.ItemPurchaseProvider.DeepSave,
							new object[] { transactionManager, entity.ItemPurchaseCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<ProdTable>
				if (CanDeepSave(entity.ProdTableCollection, "List<ProdTable>|ProdTableCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProdTable child in entity.ProdTableCollection)
					{
						if(child.ItemIdSource != null)
						{
							child.ItemId = child.ItemIdSource.Id;
						}
						else
						{
							child.ItemId = entity.Id;
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
				
	
			#region List<ItemSell>
				if (CanDeepSave(entity.ItemSellCollection, "List<ItemSell>|ItemSellCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ItemSell child in entity.ItemSellCollection)
					{
						if(child.ItemIdSource != null)
						{
							child.ItemId = child.ItemIdSource.Id;
						}
						else
						{
							child.ItemId = entity.Id;
						}

					}

					if (entity.ItemSellCollection.Count > 0 || entity.ItemSellCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ItemSellProvider.Save(transactionManager, entity.ItemSellCollection);
						
						deepHandles.Add("ItemSellCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ItemSell >) DataRepository.ItemSellProvider.DeepSave,
							new object[] { transactionManager, entity.ItemSellCollection, deepSaveType, childTypes, innerList }
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
						if(child.ItemIdSource != null)
						{
							child.ItemId = child.ItemIdSource.Id;
						}
						else
						{
							child.ItemId = entity.Id;
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
	
	#region ItemsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Items</c>
	///</summary>
	public enum ItemsChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Items</c> as OneToMany for ItemPurchaseCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemPurchase>))]
		ItemPurchaseCollection,
		///<summary>
		/// Collection of <c>Items</c> as OneToMany for ProdTableCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProdTable>))]
		ProdTableCollection,
		///<summary>
		/// Collection of <c>Items</c> as OneToMany for ItemSellCollection
		///</summary>
		[ChildEntityType(typeof(TList<ItemSell>))]
		ItemSellCollection,
		///<summary>
		/// Collection of <c>Items</c> as OneToMany for OrderDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderDetails>))]
		OrderDetailsCollection,
	}
	
	#endregion ItemsChildEntityTypes
	
	#region ItemsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ItemsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsFilterBuilder : SqlFilterBuilder<ItemsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsFilterBuilder class.
		/// </summary>
		public ItemsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemsFilterBuilder
	
	#region ItemsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ItemsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsParameterBuilder : ParameterizedSqlFilterBuilder<ItemsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsParameterBuilder class.
		/// </summary>
		public ItemsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemsParameterBuilder
	
	#region ItemsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ItemsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ItemsSortBuilder : SqlSortBuilder<ItemsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsSqlSortBuilder class.
		/// </summary>
		public ItemsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ItemsSortBuilder
	
} // end namespace

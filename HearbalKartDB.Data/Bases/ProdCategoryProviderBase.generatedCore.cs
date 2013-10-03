﻿#region Using directives

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
	/// This class is the base class for any <see cref="ProdCategoryProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProdCategoryProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.ProdCategory, HearbalKartDB.Entities.ProdCategoryKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryKey key)
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
		public override HearbalKartDB.Entities.ProdCategory Get(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProdCategory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategory GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategory GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategory GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategory GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategory index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategory GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategory index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategory"/> class.</returns>
		public abstract HearbalKartDB.Entities.ProdCategory GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProdCategory&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProdCategory&gt;"/></returns>
		public static TList<ProdCategory> Fill(IDataReader reader, TList<ProdCategory> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.ProdCategory c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProdCategory")
					.Append("|").Append((System.Int32)reader[((int)ProdCategoryColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProdCategory>(
					key.ToString(), // EntityTrackingKey
					"ProdCategory",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.ProdCategory();
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
					c.Id = (System.Int32)reader[((int)ProdCategoryColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)ProdCategoryColumn.Name - 1)))?null:(System.String)reader[((int)ProdCategoryColumn.Name - 1)];
					c.IsActive = (reader.IsDBNull(((int)ProdCategoryColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdCategoryColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)ProdCategoryColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)ProdCategoryColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ProdCategoryColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdCategory"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategory"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.ProdCategory entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProdCategoryColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)ProdCategoryColumn.Name - 1)))?null:(System.String)reader[((int)ProdCategoryColumn.Name - 1)];
			entity.IsActive = (reader.IsDBNull(((int)ProdCategoryColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdCategoryColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)ProdCategoryColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)ProdCategoryColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ProdCategoryColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdCategory"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategory"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.ProdCategory entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategory"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdCategory Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategory entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region ProdCategoryMappingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ProdCategoryMapping>|ProdCategoryMappingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ProdCategoryMappingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ProdCategoryMappingCollection = DataRepository.ProdCategoryMappingProvider.GetByCategoryId(transactionManager, entity.Id);

				if (deep && entity.ProdCategoryMappingCollection.Count > 0)
				{
					deepHandles.Add("ProdCategoryMappingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ProdCategoryMapping>) DataRepository.ProdCategoryMappingProvider.DeepLoad,
						new object[] { transactionManager, entity.ProdCategoryMappingCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.ProdCategory object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.ProdCategory instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdCategory Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategory entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<ProdCategoryMapping>
				if (CanDeepSave(entity.ProdCategoryMappingCollection, "List<ProdCategoryMapping>|ProdCategoryMappingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ProdCategoryMapping child in entity.ProdCategoryMappingCollection)
					{
						if(child.CategoryIdSource != null)
						{
							child.CategoryId = child.CategoryIdSource.Id;
						}
						else
						{
							child.CategoryId = entity.Id;
						}

					}

					if (entity.ProdCategoryMappingCollection.Count > 0 || entity.ProdCategoryMappingCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ProdCategoryMappingProvider.Save(transactionManager, entity.ProdCategoryMappingCollection);
						
						deepHandles.Add("ProdCategoryMappingCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ProdCategoryMapping >) DataRepository.ProdCategoryMappingProvider.DeepSave,
							new object[] { transactionManager, entity.ProdCategoryMappingCollection, deepSaveType, childTypes, innerList }
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
	
	#region ProdCategoryChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.ProdCategory</c>
	///</summary>
	public enum ProdCategoryChildEntityTypes
	{
		///<summary>
		/// Collection of <c>ProdCategory</c> as OneToMany for ProdCategoryMappingCollection
		///</summary>
		[ChildEntityType(typeof(TList<ProdCategoryMapping>))]
		ProdCategoryMappingCollection,
	}
	
	#endregion ProdCategoryChildEntityTypes
	
	#region ProdCategoryFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProdCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryFilterBuilder : SqlFilterBuilder<ProdCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilterBuilder class.
		/// </summary>
		public ProdCategoryFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryFilterBuilder
	
	#region ProdCategoryParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProdCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryParameterBuilder : ParameterizedSqlFilterBuilder<ProdCategoryColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryParameterBuilder class.
		/// </summary>
		public ProdCategoryParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryParameterBuilder
	
	#region ProdCategorySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProdCategoryColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProdCategorySortBuilder : SqlSortBuilder<ProdCategoryColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategorySqlSortBuilder class.
		/// </summary>
		public ProdCategorySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProdCategorySortBuilder
	
} // end namespace

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
	/// This class is the base class for any <see cref="DeliveredDaysProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DeliveredDaysProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.DeliveredDays, HearbalKartDB.Entities.DeliveredDaysKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.DeliveredDaysKey key)
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
		public override HearbalKartDB.Entities.DeliveredDays Get(TransactionManager transactionManager, HearbalKartDB.Entities.DeliveredDaysKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DeliveredDays index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public HearbalKartDB.Entities.DeliveredDays GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DeliveredDays index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public HearbalKartDB.Entities.DeliveredDays GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DeliveredDays index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public HearbalKartDB.Entities.DeliveredDays GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DeliveredDays index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public HearbalKartDB.Entities.DeliveredDays GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DeliveredDays index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public HearbalKartDB.Entities.DeliveredDays GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DeliveredDays index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.DeliveredDays"/> class.</returns>
		public abstract HearbalKartDB.Entities.DeliveredDays GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DeliveredDays&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DeliveredDays&gt;"/></returns>
		public static TList<DeliveredDays> Fill(IDataReader reader, TList<DeliveredDays> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.DeliveredDays c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DeliveredDays")
					.Append("|").Append((System.Int32)reader[((int)DeliveredDaysColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DeliveredDays>(
					key.ToString(), // EntityTrackingKey
					"DeliveredDays",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.DeliveredDays();
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
					c.Id = (System.Int32)reader[((int)DeliveredDaysColumn.Id - 1)];
					c.DeliveryIn = (reader.IsDBNull(((int)DeliveredDaysColumn.DeliveryIn - 1)))?null:(System.String)reader[((int)DeliveredDaysColumn.DeliveryIn - 1)];
					c.IsActive = (reader.IsDBNull(((int)DeliveredDaysColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DeliveredDaysColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.DeliveredDays"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DeliveredDays"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.DeliveredDays entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)DeliveredDaysColumn.Id - 1)];
			entity.DeliveryIn = (reader.IsDBNull(((int)DeliveredDaysColumn.DeliveryIn - 1)))?null:(System.String)reader[((int)DeliveredDaysColumn.DeliveryIn - 1)];
			entity.IsActive = (reader.IsDBNull(((int)DeliveredDaysColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DeliveredDaysColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)DeliveredDaysColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DeliveredDaysColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.DeliveredDays"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DeliveredDays"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.DeliveredDays entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.DeliveryIn = Convert.IsDBNull(dataRow["DeliveryIN"]) ? null : (System.String)dataRow["DeliveryIN"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.DeliveredDays"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.DeliveredDays Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.DeliveredDays entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region DistributarsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Distributars>|DistributarsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistributarsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DistributarsCollection = DataRepository.DistributarsProvider.GetByDaliveredDaysId(transactionManager, entity.Id);

				if (deep && entity.DistributarsCollection.Count > 0)
				{
					deepHandles.Add("DistributarsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Distributars>) DataRepository.DistributarsProvider.DeepLoad,
						new object[] { transactionManager, entity.DistributarsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.DeliveredDays object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.DeliveredDays instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.DeliveredDays Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.DeliveredDays entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Distributars>
				if (CanDeepSave(entity.DistributarsCollection, "List<Distributars>|DistributarsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Distributars child in entity.DistributarsCollection)
					{
						if(child.DaliveredDaysIdSource != null)
						{
							child.DaliveredDaysId = child.DaliveredDaysIdSource.Id;
						}
						else
						{
							child.DaliveredDaysId = entity.Id;
						}

					}

					if (entity.DistributarsCollection.Count > 0 || entity.DistributarsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DistributarsProvider.Save(transactionManager, entity.DistributarsCollection);
						
						deepHandles.Add("DistributarsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Distributars >) DataRepository.DistributarsProvider.DeepSave,
							new object[] { transactionManager, entity.DistributarsCollection, deepSaveType, childTypes, innerList }
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
	
	#region DeliveredDaysChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.DeliveredDays</c>
	///</summary>
	public enum DeliveredDaysChildEntityTypes
	{
		///<summary>
		/// Collection of <c>DeliveredDays</c> as OneToMany for DistributarsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Distributars>))]
		DistributarsCollection,
	}
	
	#endregion DeliveredDaysChildEntityTypes
	
	#region DeliveredDaysFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DeliveredDaysColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysFilterBuilder : SqlFilterBuilder<DeliveredDaysColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilterBuilder class.
		/// </summary>
		public DeliveredDaysFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DeliveredDaysFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DeliveredDaysFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DeliveredDaysFilterBuilder
	
	#region DeliveredDaysParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DeliveredDaysColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysParameterBuilder : ParameterizedSqlFilterBuilder<DeliveredDaysColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysParameterBuilder class.
		/// </summary>
		public DeliveredDaysParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DeliveredDaysParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DeliveredDaysParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DeliveredDaysParameterBuilder
	
	#region DeliveredDaysSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DeliveredDaysColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DeliveredDaysSortBuilder : SqlSortBuilder<DeliveredDaysColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysSqlSortBuilder class.
		/// </summary>
		public DeliveredDaysSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DeliveredDaysSortBuilder
	
} // end namespace

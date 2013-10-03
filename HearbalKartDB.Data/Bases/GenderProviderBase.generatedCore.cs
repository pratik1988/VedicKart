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
	/// This class is the base class for any <see cref="GenderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class GenderProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Gender, HearbalKartDB.Entities.GenderKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.GenderKey key)
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
		public override HearbalKartDB.Entities.Gender Get(TransactionManager transactionManager, HearbalKartDB.Entities.GenderKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Gender index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public HearbalKartDB.Entities.Gender GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Gender index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public HearbalKartDB.Entities.Gender GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Gender index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public HearbalKartDB.Entities.Gender GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Gender index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public HearbalKartDB.Entities.Gender GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Gender index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public HearbalKartDB.Entities.Gender GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Gender index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Gender"/> class.</returns>
		public abstract HearbalKartDB.Entities.Gender GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Gender&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Gender&gt;"/></returns>
		public static TList<Gender> Fill(IDataReader reader, TList<Gender> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.Gender c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Gender")
					.Append("|").Append((System.Int32)reader[((int)GenderColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Gender>(
					key.ToString(), // EntityTrackingKey
					"Gender",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Gender();
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
					c.Id = (System.Int32)reader[((int)GenderColumn.Id - 1)];
					c.Gname = (reader.IsDBNull(((int)GenderColumn.Gname - 1)))?null:(System.String)reader[((int)GenderColumn.Gname - 1)];
					c.IsActive = (reader.IsDBNull(((int)GenderColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)GenderColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)GenderColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)GenderColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)GenderColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Gender"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Gender"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Gender entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)GenderColumn.Id - 1)];
			entity.Gname = (reader.IsDBNull(((int)GenderColumn.Gname - 1)))?null:(System.String)reader[((int)GenderColumn.Gname - 1)];
			entity.IsActive = (reader.IsDBNull(((int)GenderColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)GenderColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)GenderColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)GenderColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)GenderColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)GenderColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Gender"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Gender"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Gender entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Gname = Convert.IsDBNull(dataRow["GName"]) ? null : (System.String)dataRow["GName"];
			entity.IsActive = Convert.IsDBNull(dataRow["ISActive"]) ? null : (System.Boolean?)dataRow["ISActive"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDAte"]) ? null : (System.DateTime?)dataRow["CreatedDAte"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Gender"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Gender Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Gender entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetById methods when available
			
			#region CustomersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Customers>|CustomersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomersCollection = DataRepository.CustomersProvider.GetByGender(transactionManager, entity.Id);

				if (deep && entity.CustomersCollection.Count > 0)
				{
					deepHandles.Add("CustomersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Customers>) DataRepository.CustomersProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Gender object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Gender instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Gender Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Gender entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<Customers>
				if (CanDeepSave(entity.CustomersCollection, "List<Customers>|CustomersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Customers child in entity.CustomersCollection)
					{
						if(child.GenderSource != null)
						{
							child.Gender = child.GenderSource.Id;
						}
						else
						{
							child.Gender = entity.Id;
						}

					}

					if (entity.CustomersCollection.Count > 0 || entity.CustomersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomersProvider.Save(transactionManager, entity.CustomersCollection);
						
						deepHandles.Add("CustomersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Customers >) DataRepository.CustomersProvider.DeepSave,
							new object[] { transactionManager, entity.CustomersCollection, deepSaveType, childTypes, innerList }
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
	
	#region GenderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Gender</c>
	///</summary>
	public enum GenderChildEntityTypes
	{
		///<summary>
		/// Collection of <c>Gender</c> as OneToMany for CustomersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Customers>))]
		CustomersCollection,
	}
	
	#endregion GenderChildEntityTypes
	
	#region GenderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;GenderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderFilterBuilder : SqlFilterBuilder<GenderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderFilterBuilder class.
		/// </summary>
		public GenderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GenderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GenderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GenderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GenderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GenderFilterBuilder
	
	#region GenderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;GenderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderParameterBuilder : ParameterizedSqlFilterBuilder<GenderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderParameterBuilder class.
		/// </summary>
		public GenderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the GenderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GenderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GenderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GenderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GenderParameterBuilder
	
	#region GenderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;GenderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class GenderSortBuilder : SqlSortBuilder<GenderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderSqlSortBuilder class.
		/// </summary>
		public GenderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion GenderSortBuilder
	
} // end namespace

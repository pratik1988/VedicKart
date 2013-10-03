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
	/// This class is the base class for any <see cref="CitiesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CitiesProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Cities, HearbalKartDB.Entities.CitiesKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.CitiesKey key)
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
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		FK_Cities_States Description: 
		/// </summary>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		public TList<Cities> GetByStateId(System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(_stateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		FK_Cities_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		/// <remarks></remarks>
		public TList<Cities> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		FK_Cities_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		public TList<Cities> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		fkCitiesStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		public TList<Cities> GetByStateId(System.Int32? _stateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStateId(null, _stateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		fkCitiesStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		public TList<Cities> GetByStateId(System.Int32? _stateId, int start, int pageLength,out int count)
		{
			return GetByStateId(null, _stateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Cities_States key.
		///		FK_Cities_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Cities objects.</returns>
		public abstract TList<Cities> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.Cities Get(TransactionManager transactionManager, HearbalKartDB.Entities.CitiesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Cities index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public HearbalKartDB.Entities.Cities GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cities index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public HearbalKartDB.Entities.Cities GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cities index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public HearbalKartDB.Entities.Cities GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cities index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public HearbalKartDB.Entities.Cities GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cities index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public HearbalKartDB.Entities.Cities GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Cities index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Cities"/> class.</returns>
		public abstract HearbalKartDB.Entities.Cities GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Cities&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Cities&gt;"/></returns>
		public static TList<Cities> Fill(IDataReader reader, TList<Cities> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.Cities c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Cities")
					.Append("|").Append((System.Int32)reader[((int)CitiesColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Cities>(
					key.ToString(), // EntityTrackingKey
					"Cities",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Cities();
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
					c.Id = (System.Int32)reader[((int)CitiesColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)CitiesColumn.Name - 1)))?null:(System.String)reader[((int)CitiesColumn.Name - 1)];
					c.IsActive = (reader.IsDBNull(((int)CitiesColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CitiesColumn.IsActive - 1)];
					c.StateId = (reader.IsDBNull(((int)CitiesColumn.StateId - 1)))?null:(System.Int32?)reader[((int)CitiesColumn.StateId - 1)];
					c.Pin = (reader.IsDBNull(((int)CitiesColumn.Pin - 1)))?null:(System.Int64?)reader[((int)CitiesColumn.Pin - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CitiesColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)CitiesColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)CitiesColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Cities"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Cities"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Cities entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CitiesColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)CitiesColumn.Name - 1)))?null:(System.String)reader[((int)CitiesColumn.Name - 1)];
			entity.IsActive = (reader.IsDBNull(((int)CitiesColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CitiesColumn.IsActive - 1)];
			entity.StateId = (reader.IsDBNull(((int)CitiesColumn.StateId - 1)))?null:(System.Int32?)reader[((int)CitiesColumn.StateId - 1)];
			entity.Pin = (reader.IsDBNull(((int)CitiesColumn.Pin - 1)))?null:(System.Int64?)reader[((int)CitiesColumn.Pin - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CitiesColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)CitiesColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)CitiesColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CitiesColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Cities"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Cities"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Cities entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.StateId = Convert.IsDBNull(dataRow["StateID"]) ? null : (System.Int32?)dataRow["StateID"];
			entity.Pin = Convert.IsDBNull(dataRow["Pin"]) ? null : (System.Int64?)dataRow["Pin"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Cities"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Cities Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Cities entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region StateIdSource	
			if (CanDeepLoad(entity, "States|StateIdSource", deepLoadType, innerList) 
				&& entity.StateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.StateId ?? (int)0);
				States tmpEntity = EntityManager.LocateEntity<States>(EntityLocator.ConstructKeyFromPkItems(typeof(States), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.StateIdSource = tmpEntity;
				else
					entity.StateIdSource = DataRepository.StatesProvider.GetById(transactionManager, (entity.StateId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'StateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.StateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.StatesProvider.DeepLoad(transactionManager, entity.StateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion StateIdSource
			
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

				entity.CustomerBillingCollection = DataRepository.CustomerBillingProvider.GetByCityId(transactionManager, entity.Id);

				if (deep && entity.CustomerBillingCollection.Count > 0)
				{
					deepHandles.Add("CustomerBillingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerBilling>) DataRepository.CustomerBillingProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerBillingCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region DistributarsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Distributars>|DistributarsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistributarsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DistributarsCollection = DataRepository.DistributarsProvider.GetByCityId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Cities object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Cities instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Cities Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Cities entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region StateIdSource
			if (CanDeepSave(entity, "States|StateIdSource", deepSaveType, innerList) 
				&& entity.StateIdSource != null)
			{
				DataRepository.StatesProvider.Save(transactionManager, entity.StateIdSource);
				entity.StateId = entity.StateIdSource.Id;
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
						if(child.CityIdSource != null)
						{
							child.CityId = child.CityIdSource.Id;
						}
						else
						{
							child.CityId = entity.Id;
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
				
	
			#region List<Distributars>
				if (CanDeepSave(entity.DistributarsCollection, "List<Distributars>|DistributarsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Distributars child in entity.DistributarsCollection)
					{
						if(child.CityIdSource != null)
						{
							child.CityId = child.CityIdSource.Id;
						}
						else
						{
							child.CityId = entity.Id;
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
	
	#region CitiesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Cities</c>
	///</summary>
	public enum CitiesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>States</c> at StateIdSource
		///</summary>
		[ChildEntityType(typeof(States))]
		States,
		///<summary>
		/// Collection of <c>Cities</c> as OneToMany for CustomerBillingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerBilling>))]
		CustomerBillingCollection,
		///<summary>
		/// Collection of <c>Cities</c> as OneToMany for DistributarsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Distributars>))]
		DistributarsCollection,
	}
	
	#endregion CitiesChildEntityTypes
	
	#region CitiesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CitiesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesFilterBuilder : SqlFilterBuilder<CitiesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesFilterBuilder class.
		/// </summary>
		public CitiesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CitiesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CitiesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CitiesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CitiesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CitiesFilterBuilder
	
	#region CitiesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CitiesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesParameterBuilder : ParameterizedSqlFilterBuilder<CitiesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesParameterBuilder class.
		/// </summary>
		public CitiesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CitiesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CitiesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CitiesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CitiesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CitiesParameterBuilder
	
	#region CitiesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CitiesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CitiesSortBuilder : SqlSortBuilder<CitiesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesSqlSortBuilder class.
		/// </summary>
		public CitiesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CitiesSortBuilder
	
} // end namespace

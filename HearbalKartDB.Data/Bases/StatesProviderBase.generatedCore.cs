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
	/// This class is the base class for any <see cref="StatesProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class StatesProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.States, HearbalKartDB.Entities.StatesKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.StatesKey key)
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
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		FK_States_Countries Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		public TList<States> GetByCountryId(System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		FK_States_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		/// <remarks></remarks>
		public TList<States> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		FK_States_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		public TList<States> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		fkStatesCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		public TList<States> GetByCountryId(System.Int32? _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		fkStatesCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		public TList<States> GetByCountryId(System.Int32? _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_States_Countries key.
		///		FK_States_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.States objects.</returns>
		public abstract TList<States> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.States Get(TransactionManager transactionManager, HearbalKartDB.Entities.StatesKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_States index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public HearbalKartDB.Entities.States GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_States index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public HearbalKartDB.Entities.States GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_States index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public HearbalKartDB.Entities.States GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_States index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public HearbalKartDB.Entities.States GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_States index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public HearbalKartDB.Entities.States GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_States index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.States"/> class.</returns>
		public abstract HearbalKartDB.Entities.States GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;States&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;States&gt;"/></returns>
		public static TList<States> Fill(IDataReader reader, TList<States> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.States c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("States")
					.Append("|").Append((System.Int32)reader[((int)StatesColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<States>(
					key.ToString(), // EntityTrackingKey
					"States",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.States();
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
					c.Id = (System.Int32)reader[((int)StatesColumn.Id - 1)];
					c.CountryId = (reader.IsDBNull(((int)StatesColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)StatesColumn.CountryId - 1)];
					c.Name = (reader.IsDBNull(((int)StatesColumn.Name - 1)))?null:(System.String)reader[((int)StatesColumn.Name - 1)];
					c.Pin = (reader.IsDBNull(((int)StatesColumn.Pin - 1)))?null:(System.Int64?)reader[((int)StatesColumn.Pin - 1)];
					c.IsActive = (reader.IsDBNull(((int)StatesColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)StatesColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)StatesColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)StatesColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)StatesColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.DeletedDate - 1)];
					c.PinCode = (reader.IsDBNull(((int)StatesColumn.PinCode - 1)))?null:(System.String)reader[((int)StatesColumn.PinCode - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.States"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.States"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.States entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)StatesColumn.Id - 1)];
			entity.CountryId = (reader.IsDBNull(((int)StatesColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)StatesColumn.CountryId - 1)];
			entity.Name = (reader.IsDBNull(((int)StatesColumn.Name - 1)))?null:(System.String)reader[((int)StatesColumn.Name - 1)];
			entity.Pin = (reader.IsDBNull(((int)StatesColumn.Pin - 1)))?null:(System.Int64?)reader[((int)StatesColumn.Pin - 1)];
			entity.IsActive = (reader.IsDBNull(((int)StatesColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)StatesColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)StatesColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)StatesColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)StatesColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)StatesColumn.DeletedDate - 1)];
			entity.PinCode = (reader.IsDBNull(((int)StatesColumn.PinCode - 1)))?null:(System.String)reader[((int)StatesColumn.PinCode - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.States"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.States"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.States entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Pin = Convert.IsDBNull(dataRow["Pin"]) ? null : (System.Int64?)dataRow["Pin"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.ModifiedDate = Convert.IsDBNull(dataRow["ModifiedDate"]) ? null : (System.DateTime?)dataRow["ModifiedDate"];
			entity.DeletedDate = Convert.IsDBNull(dataRow["DeletedDate"]) ? null : (System.DateTime?)dataRow["DeletedDate"];
			entity.PinCode = Convert.IsDBNull(dataRow["PinCode"]) ? null : (System.String)dataRow["PinCode"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.States"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.States Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.States entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CountryIdSource	
			if (CanDeepLoad(entity, "Countries|CountryIdSource", deepLoadType, innerList) 
				&& entity.CountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CountryId ?? (int)0);
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CountryIdSource = tmpEntity;
				else
					entity.CountryIdSource = DataRepository.CountriesProvider.GetById(transactionManager, (entity.CountryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.CountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CountryIdSource
			
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

				entity.CustomerBillingCollection = DataRepository.CustomerBillingProvider.GetByStateId(transactionManager, entity.Id);

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

				entity.DistributarsCollection = DataRepository.DistributarsProvider.GetByStateId(transactionManager, entity.Id);

				if (deep && entity.DistributarsCollection.Count > 0)
				{
					deepHandles.Add("DistributarsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Distributars>) DataRepository.DistributarsProvider.DeepLoad,
						new object[] { transactionManager, entity.DistributarsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CitiesCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Cities>|CitiesCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CitiesCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CitiesCollection = DataRepository.CitiesProvider.GetByStateId(transactionManager, entity.Id);

				if (deep && entity.CitiesCollection.Count > 0)
				{
					deepHandles.Add("CitiesCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Cities>) DataRepository.CitiesProvider.DeepLoad,
						new object[] { transactionManager, entity.CitiesCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.States object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.States instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.States Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.States entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Countries|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.Id;
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
						if(child.StateIdSource != null)
						{
							child.StateId = child.StateIdSource.Id;
						}
						else
						{
							child.StateId = entity.Id;
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
						if(child.StateIdSource != null)
						{
							child.StateId = child.StateIdSource.Id;
						}
						else
						{
							child.StateId = entity.Id;
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
				
	
			#region List<Cities>
				if (CanDeepSave(entity.CitiesCollection, "List<Cities>|CitiesCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Cities child in entity.CitiesCollection)
					{
						if(child.StateIdSource != null)
						{
							child.StateId = child.StateIdSource.Id;
						}
						else
						{
							child.StateId = entity.Id;
						}

					}

					if (entity.CitiesCollection.Count > 0 || entity.CitiesCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CitiesProvider.Save(transactionManager, entity.CitiesCollection);
						
						deepHandles.Add("CitiesCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< Cities >) DataRepository.CitiesProvider.DeepSave,
							new object[] { transactionManager, entity.CitiesCollection, deepSaveType, childTypes, innerList }
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
	
	#region StatesChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.States</c>
	///</summary>
	public enum StatesChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
		///<summary>
		/// Collection of <c>States</c> as OneToMany for CustomerBillingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerBilling>))]
		CustomerBillingCollection,
		///<summary>
		/// Collection of <c>States</c> as OneToMany for DistributarsCollection
		///</summary>
		[ChildEntityType(typeof(TList<Distributars>))]
		DistributarsCollection,
		///<summary>
		/// Collection of <c>States</c> as OneToMany for CitiesCollection
		///</summary>
		[ChildEntityType(typeof(TList<Cities>))]
		CitiesCollection,
	}
	
	#endregion StatesChildEntityTypes
	
	#region StatesFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;StatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesFilterBuilder : SqlFilterBuilder<StatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesFilterBuilder class.
		/// </summary>
		public StatesFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StatesFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StatesFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StatesFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StatesFilterBuilder
	
	#region StatesParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;StatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesParameterBuilder : ParameterizedSqlFilterBuilder<StatesColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesParameterBuilder class.
		/// </summary>
		public StatesParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the StatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StatesParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StatesParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StatesParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StatesParameterBuilder
	
	#region StatesSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;StatesColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class StatesSortBuilder : SqlSortBuilder<StatesColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesSqlSortBuilder class.
		/// </summary>
		public StatesSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion StatesSortBuilder
	
} // end namespace

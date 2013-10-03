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
	/// This class is the base class for any <see cref="DistributarsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DistributarsProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Distributars, HearbalKartDB.Entities.DistributarsKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.DistributarsKey key)
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
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		FK_Distributars_Cities Description: 
		/// </summary>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCityId(System.Int32? _cityId)
		{
			int count = -1;
			return GetByCityId(_cityId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		FK_Distributars_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		/// <remarks></remarks>
		public TList<Distributars> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		FK_Distributars_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		fkDistributarsCities Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCityId(System.Int32? _cityId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCityId(null, _cityId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		fkDistributarsCities Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCityId(System.Int32? _cityId, int start, int pageLength,out int count)
		{
			return GetByCityId(null, _cityId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Cities key.
		///		FK_Distributars_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public abstract TList<Distributars> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		FK_Distributars_Countries Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCountryId(System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		FK_Distributars_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		/// <remarks></remarks>
		public TList<Distributars> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		FK_Distributars_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		fkDistributarsCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCountryId(System.Int32? _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		fkDistributarsCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByCountryId(System.Int32? _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Countries key.
		///		FK_Distributars_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public abstract TList<Distributars> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		FK_Distributars_Distributars Description: 
		/// </summary>
		/// <param name="_daliveredDaysId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByDaliveredDaysId(System.Int32? _daliveredDaysId)
		{
			int count = -1;
			return GetByDaliveredDaysId(_daliveredDaysId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		FK_Distributars_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_daliveredDaysId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		/// <remarks></remarks>
		public TList<Distributars> GetByDaliveredDaysId(TransactionManager transactionManager, System.Int32? _daliveredDaysId)
		{
			int count = -1;
			return GetByDaliveredDaysId(transactionManager, _daliveredDaysId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		FK_Distributars_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_daliveredDaysId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByDaliveredDaysId(TransactionManager transactionManager, System.Int32? _daliveredDaysId, int start, int pageLength)
		{
			int count = -1;
			return GetByDaliveredDaysId(transactionManager, _daliveredDaysId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		fkDistributarsDistributars Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_daliveredDaysId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByDaliveredDaysId(System.Int32? _daliveredDaysId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDaliveredDaysId(null, _daliveredDaysId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		fkDistributarsDistributars Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_daliveredDaysId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByDaliveredDaysId(System.Int32? _daliveredDaysId, int start, int pageLength,out int count)
		{
			return GetByDaliveredDaysId(null, _daliveredDaysId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_Distributars key.
		///		FK_Distributars_Distributars Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_daliveredDaysId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public abstract TList<Distributars> GetByDaliveredDaysId(TransactionManager transactionManager, System.Int32? _daliveredDaysId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		FK_Distributars_States Description: 
		/// </summary>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByStateId(System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(_stateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		FK_Distributars_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		/// <remarks></remarks>
		public TList<Distributars> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		FK_Distributars_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		fkDistributarsStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByStateId(System.Int32? _stateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStateId(null, _stateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		fkDistributarsStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public TList<Distributars> GetByStateId(System.Int32? _stateId, int start, int pageLength,out int count)
		{
			return GetByStateId(null, _stateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Distributars_States key.
		///		FK_Distributars_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Distributars objects.</returns>
		public abstract TList<Distributars> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.Distributars Get(TransactionManager transactionManager, HearbalKartDB.Entities.DistributarsKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Distributars index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public HearbalKartDB.Entities.Distributars GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Distributars index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public HearbalKartDB.Entities.Distributars GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Distributars index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public HearbalKartDB.Entities.Distributars GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Distributars index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public HearbalKartDB.Entities.Distributars GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Distributars index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public HearbalKartDB.Entities.Distributars GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Distributars index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Distributars"/> class.</returns>
		public abstract HearbalKartDB.Entities.Distributars GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Distributars&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Distributars&gt;"/></returns>
		public static TList<Distributars> Fill(IDataReader reader, TList<Distributars> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.Distributars c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Distributars")
					.Append("|").Append((System.Int32)reader[((int)DistributarsColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Distributars>(
					key.ToString(), // EntityTrackingKey
					"Distributars",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Distributars();
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
					c.Id = (System.Int32)reader[((int)DistributarsColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)DistributarsColumn.Name - 1)))?null:(System.String)reader[((int)DistributarsColumn.Name - 1)];
					c.FirstName = (reader.IsDBNull(((int)DistributarsColumn.FirstName - 1)))?null:(System.String)reader[((int)DistributarsColumn.FirstName - 1)];
					c.LastName = (reader.IsDBNull(((int)DistributarsColumn.LastName - 1)))?null:(System.String)reader[((int)DistributarsColumn.LastName - 1)];
					c.Address = (reader.IsDBNull(((int)DistributarsColumn.Address - 1)))?null:(System.String)reader[((int)DistributarsColumn.Address - 1)];
					c.StateId = (reader.IsDBNull(((int)DistributarsColumn.StateId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.StateId - 1)];
					c.CityId = (reader.IsDBNull(((int)DistributarsColumn.CityId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.CityId - 1)];
					c.CountryId = (reader.IsDBNull(((int)DistributarsColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.CountryId - 1)];
					c.Pin = (reader.IsDBNull(((int)DistributarsColumn.Pin - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.Pin - 1)];
					c.DaliveredDaysId = (reader.IsDBNull(((int)DistributarsColumn.DaliveredDaysId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.DaliveredDaysId - 1)];
					c.Description = (reader.IsDBNull(((int)DistributarsColumn.Description - 1)))?null:(System.String)reader[((int)DistributarsColumn.Description - 1)];
					c.MobileNo = (reader.IsDBNull(((int)DistributarsColumn.MobileNo - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.MobileNo - 1)];
					c.LandNo = (reader.IsDBNull(((int)DistributarsColumn.LandNo - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.LandNo - 1)];
					c.IsActive = (reader.IsDBNull(((int)DistributarsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DistributarsColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)DistributarsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.CreatedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)DistributarsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.DeletedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)DistributarsColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Distributars"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Distributars"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Distributars entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)DistributarsColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)DistributarsColumn.Name - 1)))?null:(System.String)reader[((int)DistributarsColumn.Name - 1)];
			entity.FirstName = (reader.IsDBNull(((int)DistributarsColumn.FirstName - 1)))?null:(System.String)reader[((int)DistributarsColumn.FirstName - 1)];
			entity.LastName = (reader.IsDBNull(((int)DistributarsColumn.LastName - 1)))?null:(System.String)reader[((int)DistributarsColumn.LastName - 1)];
			entity.Address = (reader.IsDBNull(((int)DistributarsColumn.Address - 1)))?null:(System.String)reader[((int)DistributarsColumn.Address - 1)];
			entity.StateId = (reader.IsDBNull(((int)DistributarsColumn.StateId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.StateId - 1)];
			entity.CityId = (reader.IsDBNull(((int)DistributarsColumn.CityId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.CityId - 1)];
			entity.CountryId = (reader.IsDBNull(((int)DistributarsColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.CountryId - 1)];
			entity.Pin = (reader.IsDBNull(((int)DistributarsColumn.Pin - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.Pin - 1)];
			entity.DaliveredDaysId = (reader.IsDBNull(((int)DistributarsColumn.DaliveredDaysId - 1)))?null:(System.Int32?)reader[((int)DistributarsColumn.DaliveredDaysId - 1)];
			entity.Description = (reader.IsDBNull(((int)DistributarsColumn.Description - 1)))?null:(System.String)reader[((int)DistributarsColumn.Description - 1)];
			entity.MobileNo = (reader.IsDBNull(((int)DistributarsColumn.MobileNo - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.MobileNo - 1)];
			entity.LandNo = (reader.IsDBNull(((int)DistributarsColumn.LandNo - 1)))?null:(System.Int64?)reader[((int)DistributarsColumn.LandNo - 1)];
			entity.IsActive = (reader.IsDBNull(((int)DistributarsColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)DistributarsColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)DistributarsColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.CreatedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)DistributarsColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.DeletedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)DistributarsColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)DistributarsColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Distributars"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Distributars"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Distributars entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.LastName = Convert.IsDBNull(dataRow["LastName"]) ? null : (System.String)dataRow["LastName"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.StateId = Convert.IsDBNull(dataRow["StateID"]) ? null : (System.Int32?)dataRow["StateID"];
			entity.CityId = Convert.IsDBNull(dataRow["CityID"]) ? null : (System.Int32?)dataRow["CityID"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.Pin = Convert.IsDBNull(dataRow["Pin"]) ? null : (System.Int64?)dataRow["Pin"];
			entity.DaliveredDaysId = Convert.IsDBNull(dataRow["DaliveredDaysID"]) ? null : (System.Int32?)dataRow["DaliveredDaysID"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.MobileNo = Convert.IsDBNull(dataRow["MobileNo"]) ? null : (System.Int64?)dataRow["MobileNo"];
			entity.LandNo = Convert.IsDBNull(dataRow["LandNo"]) ? null : (System.Int64?)dataRow["LandNo"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.DeletedDate = Convert.IsDBNull(dataRow["DeletedDate"]) ? null : (System.DateTime?)dataRow["DeletedDate"];
			entity.ModifiedDate = Convert.IsDBNull(dataRow["ModifiedDate"]) ? null : (System.DateTime?)dataRow["ModifiedDate"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Distributars"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Distributars Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Distributars entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CityIdSource	
			if (CanDeepLoad(entity, "Cities|CityIdSource", deepLoadType, innerList) 
				&& entity.CityIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CityId ?? (int)0);
				Cities tmpEntity = EntityManager.LocateEntity<Cities>(EntityLocator.ConstructKeyFromPkItems(typeof(Cities), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CityIdSource = tmpEntity;
				else
					entity.CityIdSource = DataRepository.CitiesProvider.GetById(transactionManager, (entity.CityId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CityIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CityIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CitiesProvider.DeepLoad(transactionManager, entity.CityIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CityIdSource

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

			#region DaliveredDaysIdSource	
			if (CanDeepLoad(entity, "DeliveredDays|DaliveredDaysIdSource", deepLoadType, innerList) 
				&& entity.DaliveredDaysIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DaliveredDaysId ?? (int)0);
				DeliveredDays tmpEntity = EntityManager.LocateEntity<DeliveredDays>(EntityLocator.ConstructKeyFromPkItems(typeof(DeliveredDays), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DaliveredDaysIdSource = tmpEntity;
				else
					entity.DaliveredDaysIdSource = DataRepository.DeliveredDaysProvider.GetById(transactionManager, (entity.DaliveredDaysId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DaliveredDaysIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DaliveredDaysIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.DeliveredDaysProvider.DeepLoad(transactionManager, entity.DaliveredDaysIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DaliveredDaysIdSource

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
			
			#region DistributorsOrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<DistributorsOrders>|DistributorsOrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DistributorsOrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.DistributorsOrdersCollection = DataRepository.DistributorsOrdersProvider.GetByDistributorId(transactionManager, entity.Id);

				if (deep && entity.DistributorsOrdersCollection.Count > 0)
				{
					deepHandles.Add("DistributorsOrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<DistributorsOrders>) DataRepository.DistributorsOrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.DistributorsOrdersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Distributars object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Distributars instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Distributars Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Distributars entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CityIdSource
			if (CanDeepSave(entity, "Cities|CityIdSource", deepSaveType, innerList) 
				&& entity.CityIdSource != null)
			{
				DataRepository.CitiesProvider.Save(transactionManager, entity.CityIdSource);
				entity.CityId = entity.CityIdSource.Id;
			}
			#endregion 
			
			#region CountryIdSource
			if (CanDeepSave(entity, "Countries|CountryIdSource", deepSaveType, innerList) 
				&& entity.CountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.CountryIdSource);
				entity.CountryId = entity.CountryIdSource.Id;
			}
			#endregion 
			
			#region DaliveredDaysIdSource
			if (CanDeepSave(entity, "DeliveredDays|DaliveredDaysIdSource", deepSaveType, innerList) 
				&& entity.DaliveredDaysIdSource != null)
			{
				DataRepository.DeliveredDaysProvider.Save(transactionManager, entity.DaliveredDaysIdSource);
				entity.DaliveredDaysId = entity.DaliveredDaysIdSource.Id;
			}
			#endregion 
			
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
	
			#region List<DistributorsOrders>
				if (CanDeepSave(entity.DistributorsOrdersCollection, "List<DistributorsOrders>|DistributorsOrdersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(DistributorsOrders child in entity.DistributorsOrdersCollection)
					{
						if(child.DistributorIdSource != null)
						{
							child.DistributorId = child.DistributorIdSource.Id;
						}
						else
						{
							child.DistributorId = entity.Id;
						}

					}

					if (entity.DistributorsOrdersCollection.Count > 0 || entity.DistributorsOrdersCollection.DeletedItems.Count > 0)
					{
						//DataRepository.DistributorsOrdersProvider.Save(transactionManager, entity.DistributorsOrdersCollection);
						
						deepHandles.Add("DistributorsOrdersCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< DistributorsOrders >) DataRepository.DistributorsOrdersProvider.DeepSave,
							new object[] { transactionManager, entity.DistributorsOrdersCollection, deepSaveType, childTypes, innerList }
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
	
	#region DistributarsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Distributars</c>
	///</summary>
	public enum DistributarsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Cities</c> at CityIdSource
		///</summary>
		[ChildEntityType(typeof(Cities))]
		Cities,
		
		///<summary>
		/// Composite Property for <c>Countries</c> at CountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
		
		///<summary>
		/// Composite Property for <c>DeliveredDays</c> at DaliveredDaysIdSource
		///</summary>
		[ChildEntityType(typeof(DeliveredDays))]
		DeliveredDays,
		
		///<summary>
		/// Composite Property for <c>States</c> at StateIdSource
		///</summary>
		[ChildEntityType(typeof(States))]
		States,
		///<summary>
		/// Collection of <c>Distributars</c> as OneToMany for DistributorsOrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<DistributorsOrders>))]
		DistributorsOrdersCollection,
	}
	
	#endregion DistributarsChildEntityTypes
	
	#region DistributarsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DistributarsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsFilterBuilder : SqlFilterBuilder<DistributarsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsFilterBuilder class.
		/// </summary>
		public DistributarsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributarsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributarsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributarsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributarsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributarsFilterBuilder
	
	#region DistributarsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DistributarsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsParameterBuilder : ParameterizedSqlFilterBuilder<DistributarsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsParameterBuilder class.
		/// </summary>
		public DistributarsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributarsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributarsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributarsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributarsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributarsParameterBuilder
	
	#region DistributarsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DistributarsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DistributarsSortBuilder : SqlSortBuilder<DistributarsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsSqlSortBuilder class.
		/// </summary>
		public DistributarsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DistributarsSortBuilder
	
} // end namespace

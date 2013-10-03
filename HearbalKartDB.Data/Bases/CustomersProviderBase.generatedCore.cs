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
	/// This class is the base class for any <see cref="CustomersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomersProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.Customers, HearbalKartDB.Entities.CustomersKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.CustomersKey key)
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
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		FK_Customers_Gender Description: 
		/// </summary>
		/// <param name="_gender"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByGender(System.Int32? _gender)
		{
			int count = -1;
			return GetByGender(_gender, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		FK_Customers_Gender Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_gender"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		/// <remarks></remarks>
		public TList<Customers> GetByGender(TransactionManager transactionManager, System.Int32? _gender)
		{
			int count = -1;
			return GetByGender(transactionManager, _gender, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		FK_Customers_Gender Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_gender"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByGender(TransactionManager transactionManager, System.Int32? _gender, int start, int pageLength)
		{
			int count = -1;
			return GetByGender(transactionManager, _gender, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		fkCustomersGender Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_gender"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByGender(System.Int32? _gender, int start, int pageLength)
		{
			int count =  -1;
			return GetByGender(null, _gender, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		fkCustomersGender Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_gender"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByGender(System.Int32? _gender, int start, int pageLength,out int count)
		{
			return GetByGender(null, _gender, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_Gender key.
		///		FK_Customers_Gender Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_gender"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public abstract TList<Customers> GetByGender(TransactionManager transactionManager, System.Int32? _gender, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		FK_Customers_UserType Description: 
		/// </summary>
		/// <param name="_userType"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByUserType(System.Int32? _userType)
		{
			int count = -1;
			return GetByUserType(_userType, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		FK_Customers_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		/// <remarks></remarks>
		public TList<Customers> GetByUserType(TransactionManager transactionManager, System.Int32? _userType)
		{
			int count = -1;
			return GetByUserType(transactionManager, _userType, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		FK_Customers_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByUserType(TransactionManager transactionManager, System.Int32? _userType, int start, int pageLength)
		{
			int count = -1;
			return GetByUserType(transactionManager, _userType, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		fkCustomersUserType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userType"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByUserType(System.Int32? _userType, int start, int pageLength)
		{
			int count =  -1;
			return GetByUserType(null, _userType, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		fkCustomersUserType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_userType"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public TList<Customers> GetByUserType(System.Int32? _userType, int start, int pageLength,out int count)
		{
			return GetByUserType(null, _userType, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Customers_UserType key.
		///		FK_Customers_UserType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userType"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.Customers objects.</returns>
		public abstract TList<Customers> GetByUserType(TransactionManager transactionManager, System.Int32? _userType, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.Customers Get(TransactionManager transactionManager, HearbalKartDB.Entities.CustomersKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Customers index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public HearbalKartDB.Entities.Customers GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public HearbalKartDB.Entities.Customers GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public HearbalKartDB.Entities.Customers GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public HearbalKartDB.Entities.Customers GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public HearbalKartDB.Entities.Customers GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Customers index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.Customers"/> class.</returns>
		public abstract HearbalKartDB.Entities.Customers GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Customers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Customers&gt;"/></returns>
		public static TList<Customers> Fill(IDataReader reader, TList<Customers> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.Customers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Customers")
					.Append("|").Append((System.Int32)reader[((int)CustomersColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Customers>(
					key.ToString(), // EntityTrackingKey
					"Customers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.Customers();
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
					c.Id = (System.Int32)reader[((int)CustomersColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)CustomersColumn.Name - 1)))?null:(System.String)reader[((int)CustomersColumn.Name - 1)];
					c.EmailId = (reader.IsDBNull(((int)CustomersColumn.EmailId - 1)))?null:(System.String)reader[((int)CustomersColumn.EmailId - 1)];
					c.Password = (reader.IsDBNull(((int)CustomersColumn.Password - 1)))?null:(System.String)reader[((int)CustomersColumn.Password - 1)];
					c.UserType = (reader.IsDBNull(((int)CustomersColumn.UserType - 1)))?null:(System.Int32?)reader[((int)CustomersColumn.UserType - 1)];
					c.Gender = (reader.IsDBNull(((int)CustomersColumn.Gender - 1)))?null:(System.Int32?)reader[((int)CustomersColumn.Gender - 1)];
					c.FirstName = (reader.IsDBNull(((int)CustomersColumn.FirstName - 1)))?null:(System.String)reader[((int)CustomersColumn.FirstName - 1)];
					c.LastName = (reader.IsDBNull(((int)CustomersColumn.LastName - 1)))?null:(System.String)reader[((int)CustomersColumn.LastName - 1)];
					c.MobileNumber = (reader.IsDBNull(((int)CustomersColumn.MobileNumber - 1)))?null:(System.String)reader[((int)CustomersColumn.MobileNumber - 1)];
					c.LandNumber = (reader.IsDBNull(((int)CustomersColumn.LandNumber - 1)))?null:(System.String)reader[((int)CustomersColumn.LandNumber - 1)];
					c.IsActive = (reader.IsDBNull(((int)CustomersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CustomersColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CustomersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)CustomersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)CustomersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Customers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Customers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.Customers entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomersColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)CustomersColumn.Name - 1)))?null:(System.String)reader[((int)CustomersColumn.Name - 1)];
			entity.EmailId = (reader.IsDBNull(((int)CustomersColumn.EmailId - 1)))?null:(System.String)reader[((int)CustomersColumn.EmailId - 1)];
			entity.Password = (reader.IsDBNull(((int)CustomersColumn.Password - 1)))?null:(System.String)reader[((int)CustomersColumn.Password - 1)];
			entity.UserType = (reader.IsDBNull(((int)CustomersColumn.UserType - 1)))?null:(System.Int32?)reader[((int)CustomersColumn.UserType - 1)];
			entity.Gender = (reader.IsDBNull(((int)CustomersColumn.Gender - 1)))?null:(System.Int32?)reader[((int)CustomersColumn.Gender - 1)];
			entity.FirstName = (reader.IsDBNull(((int)CustomersColumn.FirstName - 1)))?null:(System.String)reader[((int)CustomersColumn.FirstName - 1)];
			entity.LastName = (reader.IsDBNull(((int)CustomersColumn.LastName - 1)))?null:(System.String)reader[((int)CustomersColumn.LastName - 1)];
			entity.MobileNumber = (reader.IsDBNull(((int)CustomersColumn.MobileNumber - 1)))?null:(System.String)reader[((int)CustomersColumn.MobileNumber - 1)];
			entity.LandNumber = (reader.IsDBNull(((int)CustomersColumn.LandNumber - 1)))?null:(System.String)reader[((int)CustomersColumn.LandNumber - 1)];
			entity.IsActive = (reader.IsDBNull(((int)CustomersColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CustomersColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CustomersColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)CustomersColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)CustomersColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CustomersColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.Customers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Customers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.Customers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.EmailId = Convert.IsDBNull(dataRow["EmailID"]) ? null : (System.String)dataRow["EmailID"];
			entity.Password = Convert.IsDBNull(dataRow["Password"]) ? null : (System.String)dataRow["Password"];
			entity.UserType = Convert.IsDBNull(dataRow["UserType"]) ? null : (System.Int32?)dataRow["UserType"];
			entity.Gender = Convert.IsDBNull(dataRow["Gender"]) ? null : (System.Int32?)dataRow["Gender"];
			entity.FirstName = Convert.IsDBNull(dataRow["FirstName"]) ? null : (System.String)dataRow["FirstName"];
			entity.LastName = Convert.IsDBNull(dataRow["LastName"]) ? null : (System.String)dataRow["LastName"];
			entity.MobileNumber = Convert.IsDBNull(dataRow["MobileNumber"]) ? null : (System.String)dataRow["MobileNumber"];
			entity.LandNumber = Convert.IsDBNull(dataRow["LandNumber"]) ? null : (System.String)dataRow["LandNumber"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.Customers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Customers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.Customers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region GenderSource	
			if (CanDeepLoad(entity, "Gender|GenderSource", deepLoadType, innerList) 
				&& entity.GenderSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.Gender ?? (int)0);
				Gender tmpEntity = EntityManager.LocateEntity<Gender>(EntityLocator.ConstructKeyFromPkItems(typeof(Gender), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.GenderSource = tmpEntity;
				else
					entity.GenderSource = DataRepository.GenderProvider.GetById(transactionManager, (entity.Gender ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'GenderSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.GenderSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.GenderProvider.DeepLoad(transactionManager, entity.GenderSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion GenderSource

			#region UserTypeSource	
			if (CanDeepLoad(entity, "UserType|UserTypeSource", deepLoadType, innerList) 
				&& entity.UserTypeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.UserType ?? (int)0);
				UserType tmpEntity = EntityManager.LocateEntity<UserType>(EntityLocator.ConstructKeyFromPkItems(typeof(UserType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.UserTypeSource = tmpEntity;
				else
					entity.UserTypeSource = DataRepository.UserTypeProvider.GetById(transactionManager, (entity.UserType ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'UserTypeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.UserTypeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.UserTypeProvider.DeepLoad(transactionManager, entity.UserTypeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion UserTypeSource
			
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

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Orders>) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region CustomerBillingCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerBilling>|CustomerBillingCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerBillingCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerBillingCollection = DataRepository.CustomerBillingProvider.GetByCustomerId(transactionManager, entity.Id);

				if (deep && entity.CustomerBillingCollection.Count > 0)
				{
					deepHandles.Add("CustomerBillingCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerBilling>) DataRepository.CustomerBillingProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerBillingCollection, deep, deepLoadType, childTypes, innerList }
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

				entity.OrderDetailsCollection = DataRepository.OrderDetailsProvider.GetByCustomerId(transactionManager, entity.Id);

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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.Customers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.Customers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.Customers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.Customers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region GenderSource
			if (CanDeepSave(entity, "Gender|GenderSource", deepSaveType, innerList) 
				&& entity.GenderSource != null)
			{
				DataRepository.GenderProvider.Save(transactionManager, entity.GenderSource);
				entity.Gender = entity.GenderSource.Id;
			}
			#endregion 
			
			#region UserTypeSource
			if (CanDeepSave(entity, "UserType|UserTypeSource", deepSaveType, innerList) 
				&& entity.UserTypeSource != null)
			{
				DataRepository.UserTypeProvider.Save(transactionManager, entity.UserTypeSource);
				entity.UserType = entity.UserTypeSource.Id;
			}
			#endregion 
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
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
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
				
	
			#region List<CustomerBilling>
				if (CanDeepSave(entity.CustomerBillingCollection, "List<CustomerBilling>|CustomerBillingCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerBilling child in entity.CustomerBillingCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
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
				
	
			#region List<OrderDetails>
				if (CanDeepSave(entity.OrderDetailsCollection, "List<OrderDetails>|OrderDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(OrderDetails child in entity.OrderDetailsCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.Id;
						}
						else
						{
							child.CustomerId = entity.Id;
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
	
	#region CustomersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.Customers</c>
	///</summary>
	public enum CustomersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Gender</c> at GenderSource
		///</summary>
		[ChildEntityType(typeof(Gender))]
		Gender,
		
		///<summary>
		/// Composite Property for <c>UserType</c> at UserTypeSource
		///</summary>
		[ChildEntityType(typeof(UserType))]
		UserType,
		///<summary>
		/// Collection of <c>Customers</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,
		///<summary>
		/// Collection of <c>Customers</c> as OneToMany for CustomerBillingCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerBilling>))]
		CustomerBillingCollection,
		///<summary>
		/// Collection of <c>Customers</c> as OneToMany for OrderDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderDetails>))]
		OrderDetailsCollection,
	}
	
	#endregion CustomersChildEntityTypes
	
	#region CustomersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersFilterBuilder : SqlFilterBuilder<CustomersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		public CustomersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersFilterBuilder
	
	#region CustomersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersParameterBuilder : ParameterizedSqlFilterBuilder<CustomersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		public CustomersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersParameterBuilder
	
	#region CustomersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomersSortBuilder : SqlSortBuilder<CustomersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersSqlSortBuilder class.
		/// </summary>
		public CustomersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomersSortBuilder
	
} // end namespace

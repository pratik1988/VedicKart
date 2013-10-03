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
	/// This class is the base class for any <see cref="ProdCategoryMappingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProdCategoryMappingProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.ProdCategoryMapping, HearbalKartDB.Entities.ProdCategoryMappingKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryMappingKey key)
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
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		FK_ProdCategoryMapping_ProdCategory Description: 
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetByCategoryId(System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(_categoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		FK_ProdCategoryMapping_ProdCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		/// <remarks></remarks>
		public TList<ProdCategoryMapping> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		FK_ProdCategoryMapping_ProdCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		fkProdCategoryMappingProdCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCategoryId(null, _categoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		fkProdCategoryMappingProdCategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_categoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength,out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdCategory key.
		///		FK_ProdCategoryMapping_ProdCategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public abstract TList<ProdCategoryMapping> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		FK_ProdCategoryMapping_ProdSubcategory Description: 
		/// </summary>
		/// <param name="_subCategoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetBySubCategoryId(System.Int32? _subCategoryId)
		{
			int count = -1;
			return GetBySubCategoryId(_subCategoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		FK_ProdCategoryMapping_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_subCategoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		/// <remarks></remarks>
		public TList<ProdCategoryMapping> GetBySubCategoryId(TransactionManager transactionManager, System.Int32? _subCategoryId)
		{
			int count = -1;
			return GetBySubCategoryId(transactionManager, _subCategoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		FK_ProdCategoryMapping_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_subCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetBySubCategoryId(TransactionManager transactionManager, System.Int32? _subCategoryId, int start, int pageLength)
		{
			int count = -1;
			return GetBySubCategoryId(transactionManager, _subCategoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		fkProdCategoryMappingProdSubcategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_subCategoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetBySubCategoryId(System.Int32? _subCategoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySubCategoryId(null, _subCategoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		fkProdCategoryMappingProdSubcategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_subCategoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public TList<ProdCategoryMapping> GetBySubCategoryId(System.Int32? _subCategoryId, int start, int pageLength,out int count)
		{
			return GetBySubCategoryId(null, _subCategoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdCategoryMapping_ProdSubcategory key.
		///		FK_ProdCategoryMapping_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_subCategoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdCategoryMapping objects.</returns>
		public abstract TList<ProdCategoryMapping> GetBySubCategoryId(TransactionManager transactionManager, System.Int32? _subCategoryId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.ProdCategoryMapping Get(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryMappingKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategoryMapping GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategoryMapping GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategoryMapping GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategoryMapping GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public HearbalKartDB.Entities.ProdCategoryMapping GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdCategoryMapping index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> class.</returns>
		public abstract HearbalKartDB.Entities.ProdCategoryMapping GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProdCategoryMapping&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProdCategoryMapping&gt;"/></returns>
		public static TList<ProdCategoryMapping> Fill(IDataReader reader, TList<ProdCategoryMapping> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.ProdCategoryMapping c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProdCategoryMapping")
					.Append("|").Append((System.Int32)reader[((int)ProdCategoryMappingColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProdCategoryMapping>(
					key.ToString(), // EntityTrackingKey
					"ProdCategoryMapping",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.ProdCategoryMapping();
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
					c.Id = (System.Int32)reader[((int)ProdCategoryMappingColumn.Id - 1)];
					c.CategoryId = (reader.IsDBNull(((int)ProdCategoryMappingColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProdCategoryMappingColumn.CategoryId - 1)];
					c.SubCategoryId = (reader.IsDBNull(((int)ProdCategoryMappingColumn.SubCategoryId - 1)))?null:(System.Int32?)reader[((int)ProdCategoryMappingColumn.SubCategoryId - 1)];
					c.IsActive = (reader.IsDBNull(((int)ProdCategoryMappingColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdCategoryMappingColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.ProdCategoryMapping entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProdCategoryMappingColumn.Id - 1)];
			entity.CategoryId = (reader.IsDBNull(((int)ProdCategoryMappingColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProdCategoryMappingColumn.CategoryId - 1)];
			entity.SubCategoryId = (reader.IsDBNull(((int)ProdCategoryMappingColumn.SubCategoryId - 1)))?null:(System.Int32?)reader[((int)ProdCategoryMappingColumn.SubCategoryId - 1)];
			entity.IsActive = (reader.IsDBNull(((int)ProdCategoryMappingColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdCategoryMappingColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ProdCategoryMappingColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdCategoryMappingColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.ProdCategoryMapping entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["Id"];
			entity.CategoryId = Convert.IsDBNull(dataRow["CategoryID"]) ? null : (System.Int32?)dataRow["CategoryID"];
			entity.SubCategoryId = Convert.IsDBNull(dataRow["SubCategoryID"]) ? null : (System.Int32?)dataRow["SubCategoryID"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdCategoryMapping"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdCategoryMapping Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryMapping entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CategoryIdSource	
			if (CanDeepLoad(entity, "ProdCategory|CategoryIdSource", deepLoadType, innerList) 
				&& entity.CategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CategoryId ?? (int)0);
				ProdCategory tmpEntity = EntityManager.LocateEntity<ProdCategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdCategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIdSource = tmpEntity;
				else
					entity.CategoryIdSource = DataRepository.ProdCategoryProvider.GetById(transactionManager, (entity.CategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdCategoryProvider.DeepLoad(transactionManager, entity.CategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CategoryIdSource

			#region SubCategoryIdSource	
			if (CanDeepLoad(entity, "ProdSubcategory|SubCategoryIdSource", deepLoadType, innerList) 
				&& entity.SubCategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SubCategoryId ?? (int)0);
				ProdSubcategory tmpEntity = EntityManager.LocateEntity<ProdSubcategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdSubcategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SubCategoryIdSource = tmpEntity;
				else
					entity.SubCategoryIdSource = DataRepository.ProdSubcategoryProvider.GetById(transactionManager, (entity.SubCategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SubCategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SubCategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdSubcategoryProvider.DeepLoad(transactionManager, entity.SubCategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SubCategoryIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.ProdCategoryMapping object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.ProdCategoryMapping instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdCategoryMapping Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.ProdCategoryMapping entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CategoryIdSource
			if (CanDeepSave(entity, "ProdCategory|CategoryIdSource", deepSaveType, innerList) 
				&& entity.CategoryIdSource != null)
			{
				DataRepository.ProdCategoryProvider.Save(transactionManager, entity.CategoryIdSource);
				entity.CategoryId = entity.CategoryIdSource.Id;
			}
			#endregion 
			
			#region SubCategoryIdSource
			if (CanDeepSave(entity, "ProdSubcategory|SubCategoryIdSource", deepSaveType, innerList) 
				&& entity.SubCategoryIdSource != null)
			{
				DataRepository.ProdSubcategoryProvider.Save(transactionManager, entity.SubCategoryIdSource);
				entity.SubCategoryId = entity.SubCategoryIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region ProdCategoryMappingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.ProdCategoryMapping</c>
	///</summary>
	public enum ProdCategoryMappingChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ProdCategory</c> at CategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ProdCategory))]
		ProdCategory,
		
		///<summary>
		/// Composite Property for <c>ProdSubcategory</c> at SubCategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ProdSubcategory))]
		ProdSubcategory,
	}
	
	#endregion ProdCategoryMappingChildEntityTypes
	
	#region ProdCategoryMappingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProdCategoryMappingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategoryMapping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryMappingFilterBuilder : SqlFilterBuilder<ProdCategoryMappingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingFilterBuilder class.
		/// </summary>
		public ProdCategoryMappingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryMappingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryMappingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryMappingFilterBuilder
	
	#region ProdCategoryMappingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProdCategoryMappingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategoryMapping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryMappingParameterBuilder : ParameterizedSqlFilterBuilder<ProdCategoryMappingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingParameterBuilder class.
		/// </summary>
		public ProdCategoryMappingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryMappingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryMappingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryMappingParameterBuilder
	
	#region ProdCategoryMappingSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProdCategoryMappingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategoryMapping"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProdCategoryMappingSortBuilder : SqlSortBuilder<ProdCategoryMappingColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryMappingSqlSortBuilder class.
		/// </summary>
		public ProdCategoryMappingSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProdCategoryMappingSortBuilder
	
} // end namespace

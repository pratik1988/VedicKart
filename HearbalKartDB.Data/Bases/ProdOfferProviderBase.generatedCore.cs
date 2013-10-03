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
	/// This class is the base class for any <see cref="ProdOfferProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProdOfferProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.ProdOffer, HearbalKartDB.Entities.ProdOfferKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ProdOfferKey key)
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
		public override HearbalKartDB.Entities.ProdOffer Get(TransactionManager transactionManager, HearbalKartDB.Entities.ProdOfferKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProdOffer index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public HearbalKartDB.Entities.ProdOffer GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdOffer index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public HearbalKartDB.Entities.ProdOffer GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdOffer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public HearbalKartDB.Entities.ProdOffer GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdOffer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public HearbalKartDB.Entities.ProdOffer GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdOffer index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public HearbalKartDB.Entities.ProdOffer GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdOffer index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdOffer"/> class.</returns>
		public abstract HearbalKartDB.Entities.ProdOffer GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProdOffer&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProdOffer&gt;"/></returns>
		public static TList<ProdOffer> Fill(IDataReader reader, TList<ProdOffer> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.ProdOffer c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProdOffer")
					.Append("|").Append((System.Int32)reader[((int)ProdOfferColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProdOffer>(
					key.ToString(), // EntityTrackingKey
					"ProdOffer",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.ProdOffer();
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
					c.Id = (System.Int32)reader[((int)ProdOfferColumn.Id - 1)];
					c.OfferPercent = (reader.IsDBNull(((int)ProdOfferColumn.OfferPercent - 1)))?null:(System.Decimal?)reader[((int)ProdOfferColumn.OfferPercent - 1)];
					c.IsActive = (reader.IsDBNull(((int)ProdOfferColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdOfferColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)ProdOfferColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)ProdOfferColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ProdOfferColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdOffer"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdOffer"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.ProdOffer entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProdOfferColumn.Id - 1)];
			entity.OfferPercent = (reader.IsDBNull(((int)ProdOfferColumn.OfferPercent - 1)))?null:(System.Decimal?)reader[((int)ProdOfferColumn.OfferPercent - 1)];
			entity.IsActive = (reader.IsDBNull(((int)ProdOfferColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdOfferColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)ProdOfferColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)ProdOfferColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ProdOfferColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdOfferColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdOffer"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdOffer"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.ProdOffer entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OfferPercent = Convert.IsDBNull(dataRow["OfferPercent"]) ? null : (System.Decimal?)dataRow["OfferPercent"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdOffer"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdOffer Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.ProdOffer entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.ProdOffer object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.ProdOffer instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdOffer Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.ProdOffer entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ProdOfferChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.ProdOffer</c>
	///</summary>
	public enum ProdOfferChildEntityTypes
	{
	}
	
	#endregion ProdOfferChildEntityTypes
	
	#region ProdOfferFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProdOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferFilterBuilder : SqlFilterBuilder<ProdOfferColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilterBuilder class.
		/// </summary>
		public ProdOfferFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdOfferFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdOfferFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdOfferFilterBuilder
	
	#region ProdOfferParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProdOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferParameterBuilder : ParameterizedSqlFilterBuilder<ProdOfferColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferParameterBuilder class.
		/// </summary>
		public ProdOfferParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdOfferParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdOfferParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdOfferParameterBuilder
	
	#region ProdOfferSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProdOfferColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProdOfferSortBuilder : SqlSortBuilder<ProdOfferColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferSqlSortBuilder class.
		/// </summary>
		public ProdOfferSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProdOfferSortBuilder
	
} // end namespace

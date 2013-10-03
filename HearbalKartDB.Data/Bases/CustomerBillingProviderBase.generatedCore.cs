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
	/// This class is the base class for any <see cref="CustomerBillingProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerBillingProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.CustomerBilling, HearbalKartDB.Entities.CustomerBillingKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.CustomerBillingKey key)
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
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		FK_CustomerBilling_Cities Description: 
		/// </summary>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCityId(System.Int32? _cityId)
		{
			int count = -1;
			return GetByCityId(_cityId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		FK_CustomerBilling_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerBilling> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		FK_CustomerBilling_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId, int start, int pageLength)
		{
			int count = -1;
			return GetByCityId(transactionManager, _cityId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		fkCustomerBillingCities Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCityId(System.Int32? _cityId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCityId(null, _cityId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		fkCustomerBillingCities Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_cityId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCityId(System.Int32? _cityId, int start, int pageLength,out int count)
		{
			return GetByCityId(null, _cityId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Cities key.
		///		FK_CustomerBilling_Cities Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_cityId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public abstract TList<CustomerBilling> GetByCityId(TransactionManager transactionManager, System.Int32? _cityId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		FK_CustomerBilling_Countries Description: 
		/// </summary>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCountryId(System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(_countryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		FK_CustomerBilling_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerBilling> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		FK_CustomerBilling_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCountryId(transactionManager, _countryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		fkCustomerBillingCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCountryId(System.Int32? _countryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCountryId(null, _countryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		fkCustomerBillingCountries Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_countryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCountryId(System.Int32? _countryId, int start, int pageLength,out int count)
		{
			return GetByCountryId(null, _countryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Countries key.
		///		FK_CustomerBilling_Countries Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_countryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public abstract TList<CustomerBilling> GetByCountryId(TransactionManager transactionManager, System.Int32? _countryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		FK_CustomerBilling_Customers Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCustomerId(System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		FK_CustomerBilling_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerBilling> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		FK_CustomerBilling_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		fkCustomerBillingCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCustomerId(System.Int32? _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		fkCustomerBillingCustomers Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByCustomerId(System.Int32? _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Customers key.
		///		FK_CustomerBilling_Customers Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public abstract TList<CustomerBilling> GetByCustomerId(TransactionManager transactionManager, System.Int32? _customerId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		FK_CustomerBilling_Orders Description: 
		/// </summary>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByOrderId(System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(_orderId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		FK_CustomerBilling_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerBilling> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		FK_CustomerBilling_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, _orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		fkCustomerBillingOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByOrderId(System.Int32? _orderId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOrderId(null, _orderId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		fkCustomerBillingOrders Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByOrderId(System.Int32? _orderId, int start, int pageLength,out int count)
		{
			return GetByOrderId(null, _orderId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_Orders key.
		///		FK_CustomerBilling_Orders Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public abstract TList<CustomerBilling> GetByOrderId(TransactionManager transactionManager, System.Int32? _orderId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		FK_CustomerBilling_States Description: 
		/// </summary>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByStateId(System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(_stateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		FK_CustomerBilling_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerBilling> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		FK_CustomerBilling_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength)
		{
			int count = -1;
			return GetByStateId(transactionManager, _stateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		fkCustomerBillingStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByStateId(System.Int32? _stateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByStateId(null, _stateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		fkCustomerBillingStates Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_stateId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public TList<CustomerBilling> GetByStateId(System.Int32? _stateId, int start, int pageLength,out int count)
		{
			return GetByStateId(null, _stateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerBilling_States key.
		///		FK_CustomerBilling_States Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_stateId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.CustomerBilling objects.</returns>
		public abstract TList<CustomerBilling> GetByStateId(TransactionManager transactionManager, System.Int32? _stateId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.CustomerBilling Get(TransactionManager transactionManager, HearbalKartDB.Entities.CustomerBillingKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomerBilling index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public HearbalKartDB.Entities.CustomerBilling GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerBilling index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public HearbalKartDB.Entities.CustomerBilling GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerBilling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public HearbalKartDB.Entities.CustomerBilling GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerBilling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public HearbalKartDB.Entities.CustomerBilling GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerBilling index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public HearbalKartDB.Entities.CustomerBilling GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerBilling index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.CustomerBilling"/> class.</returns>
		public abstract HearbalKartDB.Entities.CustomerBilling GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomerBilling&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomerBilling&gt;"/></returns>
		public static TList<CustomerBilling> Fill(IDataReader reader, TList<CustomerBilling> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.CustomerBilling c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerBilling")
					.Append("|").Append((System.Int32)reader[((int)CustomerBillingColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomerBilling>(
					key.ToString(), // EntityTrackingKey
					"CustomerBilling",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.CustomerBilling();
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
					c.Id = (System.Int32)reader[((int)CustomerBillingColumn.Id - 1)];
					c.Name = (reader.IsDBNull(((int)CustomerBillingColumn.Name - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.Name - 1)];
					c.Address = (reader.IsDBNull(((int)CustomerBillingColumn.Address - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.Address - 1)];
					c.LandMark = (reader.IsDBNull(((int)CustomerBillingColumn.LandMark - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.LandMark - 1)];
					c.PinCode = (reader.IsDBNull(((int)CustomerBillingColumn.PinCode - 1)))?null:(System.Int64?)reader[((int)CustomerBillingColumn.PinCode - 1)];
					c.Phone = (reader.IsDBNull(((int)CustomerBillingColumn.Phone - 1)))?null:(System.Int64?)reader[((int)CustomerBillingColumn.Phone - 1)];
					c.CityId = (reader.IsDBNull(((int)CustomerBillingColumn.CityId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CityId - 1)];
					c.StateId = (reader.IsDBNull(((int)CustomerBillingColumn.StateId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.StateId - 1)];
					c.CountryId = (reader.IsDBNull(((int)CustomerBillingColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CountryId - 1)];
					c.IsActive = (reader.IsDBNull(((int)CustomerBillingColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CustomerBillingColumn.IsActive - 1)];
					c.OrderId = (reader.IsDBNull(((int)CustomerBillingColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.OrderId - 1)];
					c.CustomerId = (reader.IsDBNull(((int)CustomerBillingColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CustomerId - 1)];
					c.AddressTypeid = (reader.IsDBNull(((int)CustomerBillingColumn.AddressTypeid - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.AddressTypeid - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)CustomerBillingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)CustomerBillingColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)CustomerBillingColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.DeletedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.CustomerBilling"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.CustomerBilling"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.CustomerBilling entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)CustomerBillingColumn.Id - 1)];
			entity.Name = (reader.IsDBNull(((int)CustomerBillingColumn.Name - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.Name - 1)];
			entity.Address = (reader.IsDBNull(((int)CustomerBillingColumn.Address - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.Address - 1)];
			entity.LandMark = (reader.IsDBNull(((int)CustomerBillingColumn.LandMark - 1)))?null:(System.String)reader[((int)CustomerBillingColumn.LandMark - 1)];
			entity.PinCode = (reader.IsDBNull(((int)CustomerBillingColumn.PinCode - 1)))?null:(System.Int64?)reader[((int)CustomerBillingColumn.PinCode - 1)];
			entity.Phone = (reader.IsDBNull(((int)CustomerBillingColumn.Phone - 1)))?null:(System.Int64?)reader[((int)CustomerBillingColumn.Phone - 1)];
			entity.CityId = (reader.IsDBNull(((int)CustomerBillingColumn.CityId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CityId - 1)];
			entity.StateId = (reader.IsDBNull(((int)CustomerBillingColumn.StateId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.StateId - 1)];
			entity.CountryId = (reader.IsDBNull(((int)CustomerBillingColumn.CountryId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CountryId - 1)];
			entity.IsActive = (reader.IsDBNull(((int)CustomerBillingColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)CustomerBillingColumn.IsActive - 1)];
			entity.OrderId = (reader.IsDBNull(((int)CustomerBillingColumn.OrderId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.OrderId - 1)];
			entity.CustomerId = (reader.IsDBNull(((int)CustomerBillingColumn.CustomerId - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.CustomerId - 1)];
			entity.AddressTypeid = (reader.IsDBNull(((int)CustomerBillingColumn.AddressTypeid - 1)))?null:(System.Int32?)reader[((int)CustomerBillingColumn.AddressTypeid - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)CustomerBillingColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)CustomerBillingColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)CustomerBillingColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)CustomerBillingColumn.DeletedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.CustomerBilling"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.CustomerBilling"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.CustomerBilling entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.LandMark = Convert.IsDBNull(dataRow["LandMark"]) ? null : (System.String)dataRow["LandMark"];
			entity.PinCode = Convert.IsDBNull(dataRow["PinCode"]) ? null : (System.Int64?)dataRow["PinCode"];
			entity.Phone = Convert.IsDBNull(dataRow["Phone"]) ? null : (System.Int64?)dataRow["Phone"];
			entity.CityId = Convert.IsDBNull(dataRow["CityID"]) ? null : (System.Int32?)dataRow["CityID"];
			entity.StateId = Convert.IsDBNull(dataRow["StateID"]) ? null : (System.Int32?)dataRow["StateID"];
			entity.CountryId = Convert.IsDBNull(dataRow["CountryID"]) ? null : (System.Int32?)dataRow["CountryID"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.OrderId = Convert.IsDBNull(dataRow["OrderID"]) ? null : (System.Int32?)dataRow["OrderID"];
			entity.CustomerId = Convert.IsDBNull(dataRow["CustomerID"]) ? null : (System.Int32?)dataRow["CustomerID"];
			entity.AddressTypeid = Convert.IsDBNull(dataRow["AddressTypeiD"]) ? null : (System.Int32?)dataRow["AddressTypeiD"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.CustomerBilling"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.CustomerBilling Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.CustomerBilling entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customers|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CustomerId ?? (int)0);
				Customers tmpEntity = EntityManager.LocateEntity<Customers>(EntityLocator.ConstructKeyFromPkItems(typeof(Customers), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomersProvider.GetById(transactionManager, (entity.CustomerId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomersProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource

			#region OrderIdSource	
			if (CanDeepLoad(entity, "Orders|OrderIdSource", deepLoadType, innerList) 
				&& entity.OrderIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OrderId ?? (int)0);
				Orders tmpEntity = EntityManager.LocateEntity<Orders>(EntityLocator.ConstructKeyFromPkItems(typeof(Orders), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OrderIdSource = tmpEntity;
				else
					entity.OrderIdSource = DataRepository.OrdersProvider.GetById(transactionManager, (entity.OrderId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrderIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OrderIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OrdersProvider.DeepLoad(transactionManager, entity.OrderIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OrderIdSource

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
			
			#region OrdersCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<Orders>|OrdersCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OrdersCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.OrdersCollection = DataRepository.OrdersProvider.GetByBillingId(transactionManager, entity.Id);

				if (deep && entity.OrdersCollection.Count > 0)
				{
					deepHandles.Add("OrdersCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<Orders>) DataRepository.OrdersProvider.DeepLoad,
						new object[] { transactionManager, entity.OrdersCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.CustomerBilling object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.CustomerBilling instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.CustomerBilling Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.CustomerBilling entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customers|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomersProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.Id;
			}
			#endregion 
			
			#region OrderIdSource
			if (CanDeepSave(entity, "Orders|OrderIdSource", deepSaveType, innerList) 
				&& entity.OrderIdSource != null)
			{
				DataRepository.OrdersProvider.Save(transactionManager, entity.OrderIdSource);
				entity.OrderId = entity.OrderIdSource.Id;
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
	
			#region List<Orders>
				if (CanDeepSave(entity.OrdersCollection, "List<Orders>|OrdersCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(Orders child in entity.OrdersCollection)
					{
						if(child.BillingIdSource != null)
						{
							child.BillingId = child.BillingIdSource.Id;
						}
						else
						{
							child.BillingId = entity.Id;
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
	
	#region CustomerBillingChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.CustomerBilling</c>
	///</summary>
	public enum CustomerBillingChildEntityTypes
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
		/// Composite Property for <c>Customers</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customers))]
		Customers,
		
		///<summary>
		/// Composite Property for <c>Orders</c> at OrderIdSource
		///</summary>
		[ChildEntityType(typeof(Orders))]
		Orders,
		
		///<summary>
		/// Composite Property for <c>States</c> at StateIdSource
		///</summary>
		[ChildEntityType(typeof(States))]
		States,
		///<summary>
		/// Collection of <c>CustomerBilling</c> as OneToMany for OrdersCollection
		///</summary>
		[ChildEntityType(typeof(TList<Orders>))]
		OrdersCollection,
	}
	
	#endregion CustomerBillingChildEntityTypes
	
	#region CustomerBillingFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerBillingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingFilterBuilder : SqlFilterBuilder<CustomerBillingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilterBuilder class.
		/// </summary>
		public CustomerBillingFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerBillingFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerBillingFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerBillingFilterBuilder
	
	#region CustomerBillingParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerBillingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingParameterBuilder : ParameterizedSqlFilterBuilder<CustomerBillingColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingParameterBuilder class.
		/// </summary>
		public CustomerBillingParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerBillingParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerBillingParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerBillingParameterBuilder
	
	#region CustomerBillingSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerBillingColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerBillingSortBuilder : SqlSortBuilder<CustomerBillingColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingSqlSortBuilder class.
		/// </summary>
		public CustomerBillingSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerBillingSortBuilder
	
} // end namespace

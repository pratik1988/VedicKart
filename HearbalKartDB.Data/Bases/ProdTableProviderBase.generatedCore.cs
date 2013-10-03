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
	/// This class is the base class for any <see cref="ProdTableProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ProdTableProviderBaseCore : EntityProviderBase<HearbalKartDB.Entities.ProdTable, HearbalKartDB.Entities.ProdTableKey>
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
		public override bool Delete(TransactionManager transactionManager, HearbalKartDB.Entities.ProdTableKey key)
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
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		FK_ProdTable_ItemPurchase Description: 
		/// </summary>
		/// <param name="_purchaseId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByPurchaseId(System.Int32? _purchaseId)
		{
			int count = -1;
			return GetByPurchaseId(_purchaseId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		FK_ProdTable_ItemPurchase Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByPurchaseId(TransactionManager transactionManager, System.Int32? _purchaseId)
		{
			int count = -1;
			return GetByPurchaseId(transactionManager, _purchaseId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		FK_ProdTable_ItemPurchase Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByPurchaseId(TransactionManager transactionManager, System.Int32? _purchaseId, int start, int pageLength)
		{
			int count = -1;
			return GetByPurchaseId(transactionManager, _purchaseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		fkProdTableItemPurchase Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_purchaseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByPurchaseId(System.Int32? _purchaseId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPurchaseId(null, _purchaseId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		fkProdTableItemPurchase Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_purchaseId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByPurchaseId(System.Int32? _purchaseId, int start, int pageLength,out int count)
		{
			return GetByPurchaseId(null, _purchaseId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemPurchase key.
		///		FK_ProdTable_ItemPurchase Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_purchaseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByPurchaseId(TransactionManager transactionManager, System.Int32? _purchaseId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		FK_ProdTable_Items Description: 
		/// </summary>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByItemId(System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(_itemId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		FK_ProdTable_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		FK_ProdTable_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength)
		{
			int count = -1;
			return GetByItemId(transactionManager, _itemId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		fkProdTableItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByItemId(System.Int32? _itemId, int start, int pageLength)
		{
			int count =  -1;
			return GetByItemId(null, _itemId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		fkProdTableItems Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByItemId(System.Int32? _itemId, int start, int pageLength,out int count)
		{
			return GetByItemId(null, _itemId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_Items key.
		///		FK_ProdTable_Items Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_itemId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByItemId(TransactionManager transactionManager, System.Int32? _itemId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		FK_ProdTable_ItemSell Description: 
		/// </summary>
		/// <param name="_sellId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySellId(System.Int32? _sellId)
		{
			int count = -1;
			return GetBySellId(_sellId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		FK_ProdTable_ItemSell Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetBySellId(TransactionManager transactionManager, System.Int32? _sellId)
		{
			int count = -1;
			return GetBySellId(transactionManager, _sellId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		FK_ProdTable_ItemSell Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySellId(TransactionManager transactionManager, System.Int32? _sellId, int start, int pageLength)
		{
			int count = -1;
			return GetBySellId(transactionManager, _sellId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		fkProdTableItemSell Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sellId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySellId(System.Int32? _sellId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySellId(null, _sellId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		fkProdTableItemSell Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_sellId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySellId(System.Int32? _sellId, int start, int pageLength,out int count)
		{
			return GetBySellId(null, _sellId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ItemSell key.
		///		FK_ProdTable_ItemSell Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_sellId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetBySellId(TransactionManager transactionManager, System.Int32? _sellId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		FK_ProdTable_ProdCompany Description: 
		/// </summary>
		/// <param name="_companyId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCompanyId(System.Int32? _companyId)
		{
			int count = -1;
			return GetByCompanyId(_companyId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		FK_ProdTable_ProdCompany Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		FK_ProdTable_ProdCompany Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId, int start, int pageLength)
		{
			int count = -1;
			return GetByCompanyId(transactionManager, _companyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		fkProdTableProdCompany Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCompanyId(System.Int32? _companyId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCompanyId(null, _companyId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		fkProdTableProdCompany Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_companyId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCompanyId(System.Int32? _companyId, int start, int pageLength,out int count)
		{
			return GetByCompanyId(null, _companyId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdCompany key.
		///		FK_ProdTable_ProdCompany Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_companyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByCompanyId(TransactionManager transactionManager, System.Int32? _companyId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		FK_ProdTable_ProdMedicineFor Description: 
		/// </summary>
		/// <param name="_medicineForId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByMedicineForId(System.Int32? _medicineForId)
		{
			int count = -1;
			return GetByMedicineForId(_medicineForId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		FK_ProdTable_ProdMedicineFor Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medicineForId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByMedicineForId(TransactionManager transactionManager, System.Int32? _medicineForId)
		{
			int count = -1;
			return GetByMedicineForId(transactionManager, _medicineForId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		FK_ProdTable_ProdMedicineFor Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medicineForId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByMedicineForId(TransactionManager transactionManager, System.Int32? _medicineForId, int start, int pageLength)
		{
			int count = -1;
			return GetByMedicineForId(transactionManager, _medicineForId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		fkProdTableProdMedicineFor Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_medicineForId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByMedicineForId(System.Int32? _medicineForId, int start, int pageLength)
		{
			int count =  -1;
			return GetByMedicineForId(null, _medicineForId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		fkProdTableProdMedicineFor Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_medicineForId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByMedicineForId(System.Int32? _medicineForId, int start, int pageLength,out int count)
		{
			return GetByMedicineForId(null, _medicineForId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdMedicineFor key.
		///		FK_ProdTable_ProdMedicineFor Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medicineForId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByMedicineForId(TransactionManager transactionManager, System.Int32? _medicineForId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		FK_ProdTable_ProdSubcategory Description: 
		/// </summary>
		/// <param name="_categoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCategoryId(System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(_categoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		FK_ProdTable_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		FK_ProdTable_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByCategoryId(transactionManager, _categoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		fkProdTableProdSubcategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_categoryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCategoryId(null, _categoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		fkProdTableProdSubcategory Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_categoryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByCategoryId(System.Int32? _categoryId, int start, int pageLength,out int count)
		{
			return GetByCategoryId(null, _categoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSubcategory key.
		///		FK_ProdTable_ProdSubcategory Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_categoryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByCategoryId(TransactionManager transactionManager, System.Int32? _categoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		FK_ProdTable_ProdSupplymentType Description: 
		/// </summary>
		/// <param name="_supplementId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySupplementId(System.Int32? _supplementId)
		{
			int count = -1;
			return GetBySupplementId(_supplementId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		FK_ProdTable_ProdSupplymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplementId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetBySupplementId(TransactionManager transactionManager, System.Int32? _supplementId)
		{
			int count = -1;
			return GetBySupplementId(transactionManager, _supplementId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		FK_ProdTable_ProdSupplymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySupplementId(TransactionManager transactionManager, System.Int32? _supplementId, int start, int pageLength)
		{
			int count = -1;
			return GetBySupplementId(transactionManager, _supplementId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		fkProdTableProdSupplymentType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_supplementId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySupplementId(System.Int32? _supplementId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySupplementId(null, _supplementId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		fkProdTableProdSupplymentType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_supplementId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetBySupplementId(System.Int32? _supplementId, int start, int pageLength,out int count)
		{
			return GetBySupplementId(null, _supplementId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdSupplymentType key.
		///		FK_ProdTable_ProdSupplymentType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_supplementId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetBySupplementId(TransactionManager transactionManager, System.Int32? _supplementId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		FK_ProdTable_ProdType Description: 
		/// </summary>
		/// <param name="_typeId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByTypeId(System.Int32? _typeId)
		{
			int count = -1;
			return GetByTypeId(_typeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		FK_ProdTable_ProdType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_typeId"></param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		/// <remarks></remarks>
		public TList<ProdTable> GetByTypeId(TransactionManager transactionManager, System.Int32? _typeId)
		{
			int count = -1;
			return GetByTypeId(transactionManager, _typeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		FK_ProdTable_ProdType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_typeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByTypeId(TransactionManager transactionManager, System.Int32? _typeId, int start, int pageLength)
		{
			int count = -1;
			return GetByTypeId(transactionManager, _typeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		fkProdTableProdType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_typeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByTypeId(System.Int32? _typeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTypeId(null, _typeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		fkProdTableProdType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_typeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public TList<ProdTable> GetByTypeId(System.Int32? _typeId, int start, int pageLength,out int count)
		{
			return GetByTypeId(null, _typeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ProdTable_ProdType key.
		///		FK_ProdTable_ProdType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_typeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of HearbalKartDB.Entities.ProdTable objects.</returns>
		public abstract TList<ProdTable> GetByTypeId(TransactionManager transactionManager, System.Int32? _typeId, int start, int pageLength, out int count);
		
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
		public override HearbalKartDB.Entities.ProdTable Get(TransactionManager transactionManager, HearbalKartDB.Entities.ProdTableKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ProdTable index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public HearbalKartDB.Entities.ProdTable GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdTable index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public HearbalKartDB.Entities.ProdTable GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdTable index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public HearbalKartDB.Entities.ProdTable GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdTable index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public HearbalKartDB.Entities.ProdTable GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdTable index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public HearbalKartDB.Entities.ProdTable GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProdTable index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="HearbalKartDB.Entities.ProdTable"/> class.</returns>
		public abstract HearbalKartDB.Entities.ProdTable GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ProdTable&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ProdTable&gt;"/></returns>
		public static TList<ProdTable> Fill(IDataReader reader, TList<ProdTable> rows, int start, int pageLength)
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
				
				HearbalKartDB.Entities.ProdTable c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ProdTable")
					.Append("|").Append((System.Int32)reader[((int)ProdTableColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ProdTable>(
					key.ToString(), // EntityTrackingKey
					"ProdTable",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new HearbalKartDB.Entities.ProdTable();
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
					c.Id = (System.Int32)reader[((int)ProdTableColumn.Id - 1)];
					c.ItemId = (reader.IsDBNull(((int)ProdTableColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.ItemId - 1)];
					c.CategoryId = (reader.IsDBNull(((int)ProdTableColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.CategoryId - 1)];
					c.CompanyId = (reader.IsDBNull(((int)ProdTableColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.CompanyId - 1)];
					c.TypeId = (reader.IsDBNull(((int)ProdTableColumn.TypeId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.TypeId - 1)];
					c.SupplementId = (reader.IsDBNull(((int)ProdTableColumn.SupplementId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.SupplementId - 1)];
					c.MedicineForId = (reader.IsDBNull(((int)ProdTableColumn.MedicineForId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.MedicineForId - 1)];
					c.PurchaseId = (reader.IsDBNull(((int)ProdTableColumn.PurchaseId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.PurchaseId - 1)];
					c.SellId = (reader.IsDBNull(((int)ProdTableColumn.SellId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.SellId - 1)];
					c.OfferId = (reader.IsDBNull(((int)ProdTableColumn.OfferId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.OfferId - 1)];
					c.IsActive = (reader.IsDBNull(((int)ProdTableColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdTableColumn.IsActive - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)ProdTableColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.CreatedDate - 1)];
					c.ModifiedDate = (reader.IsDBNull(((int)ProdTableColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.ModifiedDate - 1)];
					c.DeletedDate = (reader.IsDBNull(((int)ProdTableColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.DeletedDate - 1)];
					c.ImageUrl = (reader.IsDBNull(((int)ProdTableColumn.ImageUrl - 1)))?null:(System.String)reader[((int)ProdTableColumn.ImageUrl - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdTable"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdTable"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, HearbalKartDB.Entities.ProdTable entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ProdTableColumn.Id - 1)];
			entity.ItemId = (reader.IsDBNull(((int)ProdTableColumn.ItemId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.ItemId - 1)];
			entity.CategoryId = (reader.IsDBNull(((int)ProdTableColumn.CategoryId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.CategoryId - 1)];
			entity.CompanyId = (reader.IsDBNull(((int)ProdTableColumn.CompanyId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.CompanyId - 1)];
			entity.TypeId = (reader.IsDBNull(((int)ProdTableColumn.TypeId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.TypeId - 1)];
			entity.SupplementId = (reader.IsDBNull(((int)ProdTableColumn.SupplementId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.SupplementId - 1)];
			entity.MedicineForId = (reader.IsDBNull(((int)ProdTableColumn.MedicineForId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.MedicineForId - 1)];
			entity.PurchaseId = (reader.IsDBNull(((int)ProdTableColumn.PurchaseId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.PurchaseId - 1)];
			entity.SellId = (reader.IsDBNull(((int)ProdTableColumn.SellId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.SellId - 1)];
			entity.OfferId = (reader.IsDBNull(((int)ProdTableColumn.OfferId - 1)))?null:(System.Int32?)reader[((int)ProdTableColumn.OfferId - 1)];
			entity.IsActive = (reader.IsDBNull(((int)ProdTableColumn.IsActive - 1)))?null:(System.Boolean?)reader[((int)ProdTableColumn.IsActive - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)ProdTableColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.CreatedDate - 1)];
			entity.ModifiedDate = (reader.IsDBNull(((int)ProdTableColumn.ModifiedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.ModifiedDate - 1)];
			entity.DeletedDate = (reader.IsDBNull(((int)ProdTableColumn.DeletedDate - 1)))?null:(System.DateTime?)reader[((int)ProdTableColumn.DeletedDate - 1)];
			entity.ImageUrl = (reader.IsDBNull(((int)ProdTableColumn.ImageUrl - 1)))?null:(System.String)reader[((int)ProdTableColumn.ImageUrl - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="HearbalKartDB.Entities.ProdTable"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdTable"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, HearbalKartDB.Entities.ProdTable entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.ItemId = Convert.IsDBNull(dataRow["ItemID"]) ? null : (System.Int32?)dataRow["ItemID"];
			entity.CategoryId = Convert.IsDBNull(dataRow["CategoryID"]) ? null : (System.Int32?)dataRow["CategoryID"];
			entity.CompanyId = Convert.IsDBNull(dataRow["CompanyID"]) ? null : (System.Int32?)dataRow["CompanyID"];
			entity.TypeId = Convert.IsDBNull(dataRow["TypeID"]) ? null : (System.Int32?)dataRow["TypeID"];
			entity.SupplementId = Convert.IsDBNull(dataRow["SupplementID"]) ? null : (System.Int32?)dataRow["SupplementID"];
			entity.MedicineForId = Convert.IsDBNull(dataRow["MedicineForID"]) ? null : (System.Int32?)dataRow["MedicineForID"];
			entity.PurchaseId = Convert.IsDBNull(dataRow["PurchaseID"]) ? null : (System.Int32?)dataRow["PurchaseID"];
			entity.SellId = Convert.IsDBNull(dataRow["SellID"]) ? null : (System.Int32?)dataRow["SellID"];
			entity.OfferId = Convert.IsDBNull(dataRow["OfferID"]) ? null : (System.Int32?)dataRow["OfferID"];
			entity.IsActive = Convert.IsDBNull(dataRow["IsActive"]) ? null : (System.Boolean?)dataRow["IsActive"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
			entity.ModifiedDate = Convert.IsDBNull(dataRow["ModifiedDate"]) ? null : (System.DateTime?)dataRow["ModifiedDate"];
			entity.DeletedDate = Convert.IsDBNull(dataRow["DeletedDate"]) ? null : (System.DateTime?)dataRow["DeletedDate"];
			entity.ImageUrl = Convert.IsDBNull(dataRow["ImageUrl"]) ? null : (System.String)dataRow["ImageUrl"];
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
		/// <param name="entity">The <see cref="HearbalKartDB.Entities.ProdTable"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdTable Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, HearbalKartDB.Entities.ProdTable entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region PurchaseIdSource	
			if (CanDeepLoad(entity, "ItemPurchase|PurchaseIdSource", deepLoadType, innerList) 
				&& entity.PurchaseIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.PurchaseId ?? (int)0);
				ItemPurchase tmpEntity = EntityManager.LocateEntity<ItemPurchase>(EntityLocator.ConstructKeyFromPkItems(typeof(ItemPurchase), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PurchaseIdSource = tmpEntity;
				else
					entity.PurchaseIdSource = DataRepository.ItemPurchaseProvider.GetById(transactionManager, (entity.PurchaseId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PurchaseIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PurchaseIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ItemPurchaseProvider.DeepLoad(transactionManager, entity.PurchaseIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PurchaseIdSource

			#region ItemIdSource	
			if (CanDeepLoad(entity, "Items|ItemIdSource", deepLoadType, innerList) 
				&& entity.ItemIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ItemId ?? (int)0);
				Items tmpEntity = EntityManager.LocateEntity<Items>(EntityLocator.ConstructKeyFromPkItems(typeof(Items), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ItemIdSource = tmpEntity;
				else
					entity.ItemIdSource = DataRepository.ItemsProvider.GetById(transactionManager, (entity.ItemId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ItemIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ItemIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ItemsProvider.DeepLoad(transactionManager, entity.ItemIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ItemIdSource

			#region SellIdSource	
			if (CanDeepLoad(entity, "ItemSell|SellIdSource", deepLoadType, innerList) 
				&& entity.SellIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SellId ?? (int)0);
				ItemSell tmpEntity = EntityManager.LocateEntity<ItemSell>(EntityLocator.ConstructKeyFromPkItems(typeof(ItemSell), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SellIdSource = tmpEntity;
				else
					entity.SellIdSource = DataRepository.ItemSellProvider.GetById(transactionManager, (entity.SellId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SellIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SellIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ItemSellProvider.DeepLoad(transactionManager, entity.SellIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SellIdSource

			#region CompanyIdSource	
			if (CanDeepLoad(entity, "ProdCompany|CompanyIdSource", deepLoadType, innerList) 
				&& entity.CompanyIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CompanyId ?? (int)0);
				ProdCompany tmpEntity = EntityManager.LocateEntity<ProdCompany>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdCompany), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CompanyIdSource = tmpEntity;
				else
					entity.CompanyIdSource = DataRepository.ProdCompanyProvider.GetById(transactionManager, (entity.CompanyId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CompanyIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CompanyIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdCompanyProvider.DeepLoad(transactionManager, entity.CompanyIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CompanyIdSource

			#region MedicineForIdSource	
			if (CanDeepLoad(entity, "ProdMedicineFor|MedicineForIdSource", deepLoadType, innerList) 
				&& entity.MedicineForIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.MedicineForId ?? (int)0);
				ProdMedicineFor tmpEntity = EntityManager.LocateEntity<ProdMedicineFor>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdMedicineFor), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.MedicineForIdSource = tmpEntity;
				else
					entity.MedicineForIdSource = DataRepository.ProdMedicineForProvider.GetById(transactionManager, (entity.MedicineForId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'MedicineForIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.MedicineForIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdMedicineForProvider.DeepLoad(transactionManager, entity.MedicineForIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion MedicineForIdSource

			#region CategoryIdSource	
			if (CanDeepLoad(entity, "ProdSubcategory|CategoryIdSource", deepLoadType, innerList) 
				&& entity.CategoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CategoryId ?? (int)0);
				ProdSubcategory tmpEntity = EntityManager.LocateEntity<ProdSubcategory>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdSubcategory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CategoryIdSource = tmpEntity;
				else
					entity.CategoryIdSource = DataRepository.ProdSubcategoryProvider.GetById(transactionManager, (entity.CategoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CategoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CategoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdSubcategoryProvider.DeepLoad(transactionManager, entity.CategoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CategoryIdSource

			#region SupplementIdSource	
			if (CanDeepLoad(entity, "ProdSupplymentType|SupplementIdSource", deepLoadType, innerList) 
				&& entity.SupplementIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SupplementId ?? (int)0);
				ProdSupplymentType tmpEntity = EntityManager.LocateEntity<ProdSupplymentType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdSupplymentType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SupplementIdSource = tmpEntity;
				else
					entity.SupplementIdSource = DataRepository.ProdSupplymentTypeProvider.GetById(transactionManager, (entity.SupplementId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SupplementIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SupplementIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdSupplymentTypeProvider.DeepLoad(transactionManager, entity.SupplementIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SupplementIdSource

			#region TypeIdSource	
			if (CanDeepLoad(entity, "ProdType|TypeIdSource", deepLoadType, innerList) 
				&& entity.TypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TypeId ?? (int)0);
				ProdType tmpEntity = EntityManager.LocateEntity<ProdType>(EntityLocator.ConstructKeyFromPkItems(typeof(ProdType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TypeIdSource = tmpEntity;
				else
					entity.TypeIdSource = DataRepository.ProdTypeProvider.GetById(transactionManager, (entity.TypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProdTypeProvider.DeepLoad(transactionManager, entity.TypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TypeIdSource
			
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
		/// Deep Save the entire object graph of the HearbalKartDB.Entities.ProdTable object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">HearbalKartDB.Entities.ProdTable instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">HearbalKartDB.Entities.ProdTable Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, HearbalKartDB.Entities.ProdTable entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PurchaseIdSource
			if (CanDeepSave(entity, "ItemPurchase|PurchaseIdSource", deepSaveType, innerList) 
				&& entity.PurchaseIdSource != null)
			{
				DataRepository.ItemPurchaseProvider.Save(transactionManager, entity.PurchaseIdSource);
				entity.PurchaseId = entity.PurchaseIdSource.Id;
			}
			#endregion 
			
			#region ItemIdSource
			if (CanDeepSave(entity, "Items|ItemIdSource", deepSaveType, innerList) 
				&& entity.ItemIdSource != null)
			{
				DataRepository.ItemsProvider.Save(transactionManager, entity.ItemIdSource);
				entity.ItemId = entity.ItemIdSource.Id;
			}
			#endregion 
			
			#region SellIdSource
			if (CanDeepSave(entity, "ItemSell|SellIdSource", deepSaveType, innerList) 
				&& entity.SellIdSource != null)
			{
				DataRepository.ItemSellProvider.Save(transactionManager, entity.SellIdSource);
				entity.SellId = entity.SellIdSource.Id;
			}
			#endregion 
			
			#region CompanyIdSource
			if (CanDeepSave(entity, "ProdCompany|CompanyIdSource", deepSaveType, innerList) 
				&& entity.CompanyIdSource != null)
			{
				DataRepository.ProdCompanyProvider.Save(transactionManager, entity.CompanyIdSource);
				entity.CompanyId = entity.CompanyIdSource.Id;
			}
			#endregion 
			
			#region MedicineForIdSource
			if (CanDeepSave(entity, "ProdMedicineFor|MedicineForIdSource", deepSaveType, innerList) 
				&& entity.MedicineForIdSource != null)
			{
				DataRepository.ProdMedicineForProvider.Save(transactionManager, entity.MedicineForIdSource);
				entity.MedicineForId = entity.MedicineForIdSource.Id;
			}
			#endregion 
			
			#region CategoryIdSource
			if (CanDeepSave(entity, "ProdSubcategory|CategoryIdSource", deepSaveType, innerList) 
				&& entity.CategoryIdSource != null)
			{
				DataRepository.ProdSubcategoryProvider.Save(transactionManager, entity.CategoryIdSource);
				entity.CategoryId = entity.CategoryIdSource.Id;
			}
			#endregion 
			
			#region SupplementIdSource
			if (CanDeepSave(entity, "ProdSupplymentType|SupplementIdSource", deepSaveType, innerList) 
				&& entity.SupplementIdSource != null)
			{
				DataRepository.ProdSupplymentTypeProvider.Save(transactionManager, entity.SupplementIdSource);
				entity.SupplementId = entity.SupplementIdSource.Id;
			}
			#endregion 
			
			#region TypeIdSource
			if (CanDeepSave(entity, "ProdType|TypeIdSource", deepSaveType, innerList) 
				&& entity.TypeIdSource != null)
			{
				DataRepository.ProdTypeProvider.Save(transactionManager, entity.TypeIdSource);
				entity.TypeId = entity.TypeIdSource.Id;
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
	
	#region ProdTableChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>HearbalKartDB.Entities.ProdTable</c>
	///</summary>
	public enum ProdTableChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ItemPurchase</c> at PurchaseIdSource
		///</summary>
		[ChildEntityType(typeof(ItemPurchase))]
		ItemPurchase,
		
		///<summary>
		/// Composite Property for <c>Items</c> at ItemIdSource
		///</summary>
		[ChildEntityType(typeof(Items))]
		Items,
		
		///<summary>
		/// Composite Property for <c>ItemSell</c> at SellIdSource
		///</summary>
		[ChildEntityType(typeof(ItemSell))]
		ItemSell,
		
		///<summary>
		/// Composite Property for <c>ProdCompany</c> at CompanyIdSource
		///</summary>
		[ChildEntityType(typeof(ProdCompany))]
		ProdCompany,
		
		///<summary>
		/// Composite Property for <c>ProdMedicineFor</c> at MedicineForIdSource
		///</summary>
		[ChildEntityType(typeof(ProdMedicineFor))]
		ProdMedicineFor,
		
		///<summary>
		/// Composite Property for <c>ProdSubcategory</c> at CategoryIdSource
		///</summary>
		[ChildEntityType(typeof(ProdSubcategory))]
		ProdSubcategory,
		
		///<summary>
		/// Composite Property for <c>ProdSupplymentType</c> at SupplementIdSource
		///</summary>
		[ChildEntityType(typeof(ProdSupplymentType))]
		ProdSupplymentType,
		
		///<summary>
		/// Composite Property for <c>ProdType</c> at TypeIdSource
		///</summary>
		[ChildEntityType(typeof(ProdType))]
		ProdType,
	}
	
	#endregion ProdTableChildEntityTypes
	
	#region ProdTableFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ProdTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableFilterBuilder : SqlFilterBuilder<ProdTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableFilterBuilder class.
		/// </summary>
		public ProdTableFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTableFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTableFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTableFilterBuilder
	
	#region ProdTableParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ProdTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableParameterBuilder : ParameterizedSqlFilterBuilder<ProdTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableParameterBuilder class.
		/// </summary>
		public ProdTableParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTableParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTableParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTableParameterBuilder
	
	#region ProdTableSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ProdTableColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ProdTableSortBuilder : SqlSortBuilder<ProdTableColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableSqlSortBuilder class.
		/// </summary>
		public ProdTableSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ProdTableSortBuilder
	
} // end namespace

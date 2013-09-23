#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using HearbalKartDB.Data.Bases;
#endregion

namespace HearbalKartDB.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ProdTableProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdTableDataSourceDesigner))]
	public class ProdTableDataSource : ProviderDataSource<ProdTable, ProdTableKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableDataSource class.
		/// </summary>
		public ProdTableDataSource() : base(DataRepository.ProdTableProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdTableDataSourceView used by the ProdTableDataSource.
		/// </summary>
		protected ProdTableDataSourceView ProdTableView
		{
			get { return ( View as ProdTableDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdTableDataSource control invokes to retrieve data.
		/// </summary>
		public ProdTableSelectMethod SelectMethod
		{
			get
			{
				ProdTableSelectMethod selectMethod = ProdTableSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdTableSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdTableDataSourceView class that is to be
		/// used by the ProdTableDataSource.
		/// </summary>
		/// <returns>An instance of the ProdTableDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdTable, ProdTableKey> GetNewDataSourceView()
		{
			return new ProdTableDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the ProdTableDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdTableDataSourceView : ProviderDataSourceView<ProdTable, ProdTableKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdTableDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdTableDataSourceView(ProdTableDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdTableDataSource ProdTableOwner
		{
			get { return Owner as ProdTableDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdTableSelectMethod SelectMethod
		{
			get { return ProdTableOwner.SelectMethod; }
			set { ProdTableOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdTableProviderBase ProdTableProvider
		{
			get { return Provider as ProdTableProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdTable> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdTable> results = null;
			ProdTable item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _purchaseId_nullable;
			System.Int32? _itemId_nullable;
			System.Int32? _sellId_nullable;
			System.Int32? _categoryId_nullable;
			System.Int32? _companyId_nullable;
			System.Int32? _medicineForId_nullable;
			System.Int32? _supplementId_nullable;
			System.Int32? _typeId_nullable;

			switch ( SelectMethod )
			{
				case ProdTableSelectMethod.Get:
					ProdTableKey entityKey  = new ProdTableKey();
					entityKey.Load(values);
					item = ProdTableProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdTable>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdTableSelectMethod.GetAll:
                    results = ProdTableProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdTableSelectMethod.GetPaged:
					results = ProdTableProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdTableSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdTableProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdTableProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdTableSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdTableProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdTable>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProdTableSelectMethod.GetByPurchaseId:
					_purchaseId_nullable = (System.Int32?) EntityUtil.ChangeType(values["PurchaseId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByPurchaseId(GetTransactionManager(), _purchaseId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetByItemId:
					_itemId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByItemId(GetTransactionManager(), _itemId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetBySellId:
					_sellId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SellId"], typeof(System.Int32?));
					results = ProdTableProvider.GetBySellId(GetTransactionManager(), _sellId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetByCategoryId:
					_categoryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CategoryId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByCategoryId(GetTransactionManager(), _categoryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetByCompanyId:
					_companyId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CompanyId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByCompanyId(GetTransactionManager(), _companyId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetByMedicineForId:
					_medicineForId_nullable = (System.Int32?) EntityUtil.ChangeType(values["MedicineForId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByMedicineForId(GetTransactionManager(), _medicineForId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetBySupplementId:
					_supplementId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SupplementId"], typeof(System.Int32?));
					results = ProdTableProvider.GetBySupplementId(GetTransactionManager(), _supplementId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ProdTableSelectMethod.GetByTypeId:
					_typeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["TypeId"], typeof(System.Int32?));
					results = ProdTableProvider.GetByTypeId(GetTransactionManager(), _typeId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == ProdTableSelectMethod.Get || SelectMethod == ProdTableSelectMethod.GetById )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				ProdTable entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdTableProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<ProdTable> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdTableProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdTableDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdTableDataSource class.
	/// </summary>
	public class ProdTableDataSourceDesigner : ProviderDataSourceDesigner<ProdTable, ProdTableKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdTableDataSourceDesigner class.
		/// </summary>
		public ProdTableDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdTableSelectMethod SelectMethod
		{
			get { return ((ProdTableDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new ProdTableDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdTableDataSourceActionList

	/// <summary>
	/// Supports the ProdTableDataSourceDesigner class.
	/// </summary>
	internal class ProdTableDataSourceActionList : DesignerActionList
	{
		private ProdTableDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdTableDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdTableDataSourceActionList(ProdTableDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdTableSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion ProdTableDataSourceActionList
	
	#endregion ProdTableDataSourceDesigner
	
	#region ProdTableSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdTableDataSource.SelectMethod property.
	/// </summary>
	public enum ProdTableSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByPurchaseId method.
		/// </summary>
		GetByPurchaseId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId,
		/// <summary>
		/// Represents the GetBySellId method.
		/// </summary>
		GetBySellId,
		/// <summary>
		/// Represents the GetByCategoryId method.
		/// </summary>
		GetByCategoryId,
		/// <summary>
		/// Represents the GetByCompanyId method.
		/// </summary>
		GetByCompanyId,
		/// <summary>
		/// Represents the GetByMedicineForId method.
		/// </summary>
		GetByMedicineForId,
		/// <summary>
		/// Represents the GetBySupplementId method.
		/// </summary>
		GetBySupplementId,
		/// <summary>
		/// Represents the GetByTypeId method.
		/// </summary>
		GetByTypeId
	}
	
	#endregion ProdTableSelectMethod

	#region ProdTableFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableFilter : SqlFilter<ProdTableColumn>
	{
	}
	
	#endregion ProdTableFilter

	#region ProdTableExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableExpressionBuilder : SqlExpressionBuilder<ProdTableColumn>
	{
	}
	
	#endregion ProdTableExpressionBuilder	

	#region ProdTableProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdTableChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableProperty : ChildEntityProperty<ProdTableChildEntityTypes>
	{
	}
	
	#endregion ProdTableProperty
}


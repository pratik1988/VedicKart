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
	/// Represents the DataRepository.CustomerBillingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerBillingDataSourceDesigner))]
	public class CustomerBillingDataSource : ProviderDataSource<CustomerBilling, CustomerBillingKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingDataSource class.
		/// </summary>
		public CustomerBillingDataSource() : base(DataRepository.CustomerBillingProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerBillingDataSourceView used by the CustomerBillingDataSource.
		/// </summary>
		protected CustomerBillingDataSourceView CustomerBillingView
		{
			get { return ( View as CustomerBillingDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerBillingDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerBillingSelectMethod SelectMethod
		{
			get
			{
				CustomerBillingSelectMethod selectMethod = CustomerBillingSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerBillingSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerBillingDataSourceView class that is to be
		/// used by the CustomerBillingDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerBillingDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerBilling, CustomerBillingKey> GetNewDataSourceView()
		{
			return new CustomerBillingDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerBillingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerBillingDataSourceView : ProviderDataSourceView<CustomerBilling, CustomerBillingKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerBillingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerBillingDataSourceView(CustomerBillingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerBillingDataSource CustomerBillingOwner
		{
			get { return Owner as CustomerBillingDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerBillingSelectMethod SelectMethod
		{
			get { return CustomerBillingOwner.SelectMethod; }
			set { CustomerBillingOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerBillingProviderBase CustomerBillingProvider
		{
			get { return Provider as CustomerBillingProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerBilling> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerBilling> results = null;
			CustomerBilling item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _cityId_nullable;
			System.Int32? _countryId_nullable;
			System.Int32? _customerId_nullable;
			System.Int32? _orderId_nullable;
			System.Int32? _stateId_nullable;

			switch ( SelectMethod )
			{
				case CustomerBillingSelectMethod.Get:
					CustomerBillingKey entityKey  = new CustomerBillingKey();
					entityKey.Load(values);
					item = CustomerBillingProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<CustomerBilling>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerBillingSelectMethod.GetAll:
                    results = CustomerBillingProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case CustomerBillingSelectMethod.GetPaged:
					results = CustomerBillingProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerBillingSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerBillingProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerBillingProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerBillingSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CustomerBillingProvider.GetById(GetTransactionManager(), _id);
					results = new TList<CustomerBilling>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomerBillingSelectMethod.GetByCityId:
					_cityId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CityId"], typeof(System.Int32?));
					results = CustomerBillingProvider.GetByCityId(GetTransactionManager(), _cityId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerBillingSelectMethod.GetByCountryId:
					_countryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32?));
					results = CustomerBillingProvider.GetByCountryId(GetTransactionManager(), _countryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerBillingSelectMethod.GetByCustomerId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					results = CustomerBillingProvider.GetByCustomerId(GetTransactionManager(), _customerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerBillingSelectMethod.GetByOrderId:
					_orderId_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32?));
					results = CustomerBillingProvider.GetByOrderId(GetTransactionManager(), _orderId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomerBillingSelectMethod.GetByStateId:
					_stateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["StateId"], typeof(System.Int32?));
					results = CustomerBillingProvider.GetByStateId(GetTransactionManager(), _stateId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerBillingSelectMethod.Get || SelectMethod == CustomerBillingSelectMethod.GetById )
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
				CustomerBilling entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					CustomerBillingProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerBilling> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			CustomerBillingProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerBillingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerBillingDataSource class.
	/// </summary>
	public class CustomerBillingDataSourceDesigner : ProviderDataSourceDesigner<CustomerBilling, CustomerBillingKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerBillingDataSourceDesigner class.
		/// </summary>
		public CustomerBillingDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerBillingSelectMethod SelectMethod
		{
			get { return ((CustomerBillingDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerBillingDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerBillingDataSourceActionList

	/// <summary>
	/// Supports the CustomerBillingDataSourceDesigner class.
	/// </summary>
	internal class CustomerBillingDataSourceActionList : DesignerActionList
	{
		private CustomerBillingDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerBillingDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerBillingDataSourceActionList(CustomerBillingDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerBillingSelectMethod SelectMethod
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

	#endregion CustomerBillingDataSourceActionList
	
	#endregion CustomerBillingDataSourceDesigner
	
	#region CustomerBillingSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerBillingDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerBillingSelectMethod
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
		/// Represents the GetByCityId method.
		/// </summary>
		GetByCityId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByOrderId method.
		/// </summary>
		GetByOrderId,
		/// <summary>
		/// Represents the GetByStateId method.
		/// </summary>
		GetByStateId
	}
	
	#endregion CustomerBillingSelectMethod

	#region CustomerBillingFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingFilter : SqlFilter<CustomerBillingColumn>
	{
	}
	
	#endregion CustomerBillingFilter

	#region CustomerBillingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingExpressionBuilder : SqlExpressionBuilder<CustomerBillingColumn>
	{
	}
	
	#endregion CustomerBillingExpressionBuilder	

	#region CustomerBillingProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerBillingChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingProperty : ChildEntityProperty<CustomerBillingChildEntityTypes>
	{
	}
	
	#endregion CustomerBillingProperty
}


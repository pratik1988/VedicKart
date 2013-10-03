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
	/// Represents the DataRepository.OrdersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OrdersDataSourceDesigner))]
	public class OrdersDataSource : ProviderDataSource<Orders, OrdersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersDataSource class.
		/// </summary>
		public OrdersDataSource() : base(DataRepository.OrdersProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OrdersDataSourceView used by the OrdersDataSource.
		/// </summary>
		protected OrdersDataSourceView OrdersView
		{
			get { return ( View as OrdersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OrdersDataSource control invokes to retrieve data.
		/// </summary>
		public OrdersSelectMethod SelectMethod
		{
			get
			{
				OrdersSelectMethod selectMethod = OrdersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OrdersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OrdersDataSourceView class that is to be
		/// used by the OrdersDataSource.
		/// </summary>
		/// <returns>An instance of the OrdersDataSourceView class.</returns>
		protected override BaseDataSourceView<Orders, OrdersKey> GetNewDataSourceView()
		{
			return new OrdersDataSourceView(this, DefaultViewName);
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
	/// Supports the OrdersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OrdersDataSourceView : ProviderDataSourceView<Orders, OrdersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OrdersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OrdersDataSourceView(OrdersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OrdersDataSource OrdersOwner
		{
			get { return Owner as OrdersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OrdersSelectMethod SelectMethod
		{
			get { return OrdersOwner.SelectMethod; }
			set { OrdersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OrdersProviderBase OrdersProvider
		{
			get { return Provider as OrdersProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Orders> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Orders> results = null;
			Orders item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _billingId_nullable;
			System.Int32? _customerId_nullable;
			System.Int32? _orderStatusId_nullable;

			switch ( SelectMethod )
			{
				case OrdersSelectMethod.Get:
					OrdersKey entityKey  = new OrdersKey();
					entityKey.Load(values);
					item = OrdersProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Orders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OrdersSelectMethod.GetAll:
                    results = OrdersProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case OrdersSelectMethod.GetPaged:
					results = OrdersProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OrdersSelectMethod.Find:
					if ( FilterParameters != null )
						results = OrdersProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OrdersProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OrdersSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OrdersProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Orders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case OrdersSelectMethod.GetByBillingId:
					_billingId_nullable = (System.Int32?) EntityUtil.ChangeType(values["BillingId"], typeof(System.Int32?));
					results = OrdersProvider.GetByBillingId(GetTransactionManager(), _billingId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case OrdersSelectMethod.GetByCustomerId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					results = OrdersProvider.GetByCustomerId(GetTransactionManager(), _customerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case OrdersSelectMethod.GetByOrderStatusId:
					_orderStatusId_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderStatusId"], typeof(System.Int32?));
					results = OrdersProvider.GetByOrderStatusId(GetTransactionManager(), _orderStatusId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == OrdersSelectMethod.Get || SelectMethod == OrdersSelectMethod.GetById )
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
				Orders entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					OrdersProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Orders> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			OrdersProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OrdersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OrdersDataSource class.
	/// </summary>
	public class OrdersDataSourceDesigner : ProviderDataSourceDesigner<Orders, OrdersKey>
	{
		/// <summary>
		/// Initializes a new instance of the OrdersDataSourceDesigner class.
		/// </summary>
		public OrdersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrdersSelectMethod SelectMethod
		{
			get { return ((OrdersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OrdersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OrdersDataSourceActionList

	/// <summary>
	/// Supports the OrdersDataSourceDesigner class.
	/// </summary>
	internal class OrdersDataSourceActionList : DesignerActionList
	{
		private OrdersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OrdersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OrdersDataSourceActionList(OrdersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrdersSelectMethod SelectMethod
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

	#endregion OrdersDataSourceActionList
	
	#endregion OrdersDataSourceDesigner
	
	#region OrdersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OrdersDataSource.SelectMethod property.
	/// </summary>
	public enum OrdersSelectMethod
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
		/// Represents the GetByBillingId method.
		/// </summary>
		GetByBillingId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByOrderStatusId method.
		/// </summary>
		GetByOrderStatusId
	}
	
	#endregion OrdersSelectMethod

	#region OrdersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilter : SqlFilter<OrdersColumn>
	{
	}
	
	#endregion OrdersFilter

	#region OrdersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersExpressionBuilder : SqlExpressionBuilder<OrdersColumn>
	{
	}
	
	#endregion OrdersExpressionBuilder	

	#region OrdersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OrdersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersProperty : ChildEntityProperty<OrdersChildEntityTypes>
	{
	}
	
	#endregion OrdersProperty
}


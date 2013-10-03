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
	/// Represents the DataRepository.OrderDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OrderDetailsDataSourceDesigner))]
	public class OrderDetailsDataSource : ProviderDataSource<OrderDetails, OrderDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsDataSource class.
		/// </summary>
		public OrderDetailsDataSource() : base(DataRepository.OrderDetailsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OrderDetailsDataSourceView used by the OrderDetailsDataSource.
		/// </summary>
		protected OrderDetailsDataSourceView OrderDetailsView
		{
			get { return ( View as OrderDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OrderDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public OrderDetailsSelectMethod SelectMethod
		{
			get
			{
				OrderDetailsSelectMethod selectMethod = OrderDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OrderDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OrderDetailsDataSourceView class that is to be
		/// used by the OrderDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the OrderDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<OrderDetails, OrderDetailsKey> GetNewDataSourceView()
		{
			return new OrderDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the OrderDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OrderDetailsDataSourceView : ProviderDataSourceView<OrderDetails, OrderDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OrderDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OrderDetailsDataSourceView(OrderDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OrderDetailsDataSource OrderDetailsOwner
		{
			get { return Owner as OrderDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OrderDetailsSelectMethod SelectMethod
		{
			get { return OrderDetailsOwner.SelectMethod; }
			set { OrderDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OrderDetailsProviderBase OrderDetailsProvider
		{
			get { return Provider as OrderDetailsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OrderDetails> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OrderDetails> results = null;
			OrderDetails item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _customerId_nullable;
			System.Int32? _itemId_nullable;
			System.Int32? _orderId_nullable;

			switch ( SelectMethod )
			{
				case OrderDetailsSelectMethod.Get:
					OrderDetailsKey entityKey  = new OrderDetailsKey();
					entityKey.Load(values);
					item = OrderDetailsProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<OrderDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OrderDetailsSelectMethod.GetAll:
                    results = OrderDetailsProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case OrderDetailsSelectMethod.GetPaged:
					results = OrderDetailsProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OrderDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = OrderDetailsProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OrderDetailsProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OrderDetailsSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OrderDetailsProvider.GetById(GetTransactionManager(), _id);
					results = new TList<OrderDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case OrderDetailsSelectMethod.GetByCustomerId:
					_customerId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32?));
					results = OrderDetailsProvider.GetByCustomerId(GetTransactionManager(), _customerId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case OrderDetailsSelectMethod.GetByItemId:
					_itemId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int32?));
					results = OrderDetailsProvider.GetByItemId(GetTransactionManager(), _itemId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case OrderDetailsSelectMethod.GetByOrderId:
					_orderId_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32?));
					results = OrderDetailsProvider.GetByOrderId(GetTransactionManager(), _orderId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == OrderDetailsSelectMethod.Get || SelectMethod == OrderDetailsSelectMethod.GetById )
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
				OrderDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					OrderDetailsProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OrderDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			OrderDetailsProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OrderDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OrderDetailsDataSource class.
	/// </summary>
	public class OrderDetailsDataSourceDesigner : ProviderDataSourceDesigner<OrderDetails, OrderDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the OrderDetailsDataSourceDesigner class.
		/// </summary>
		public OrderDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderDetailsSelectMethod SelectMethod
		{
			get { return ((OrderDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OrderDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OrderDetailsDataSourceActionList

	/// <summary>
	/// Supports the OrderDetailsDataSourceDesigner class.
	/// </summary>
	internal class OrderDetailsDataSourceActionList : DesignerActionList
	{
		private OrderDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OrderDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OrderDetailsDataSourceActionList(OrderDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderDetailsSelectMethod SelectMethod
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

	#endregion OrderDetailsDataSourceActionList
	
	#endregion OrderDetailsDataSourceDesigner
	
	#region OrderDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OrderDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum OrderDetailsSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId,
		/// <summary>
		/// Represents the GetByOrderId method.
		/// </summary>
		GetByOrderId
	}
	
	#endregion OrderDetailsSelectMethod

	#region OrderDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsFilter : SqlFilter<OrderDetailsColumn>
	{
	}
	
	#endregion OrderDetailsFilter

	#region OrderDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsExpressionBuilder : SqlExpressionBuilder<OrderDetailsColumn>
	{
	}
	
	#endregion OrderDetailsExpressionBuilder	

	#region OrderDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OrderDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsProperty : ChildEntityProperty<OrderDetailsChildEntityTypes>
	{
	}
	
	#endregion OrderDetailsProperty
}


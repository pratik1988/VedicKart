﻿#region Using Directives
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
	/// Represents the DataRepository.OrderStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OrderStatusDataSourceDesigner))]
	public class OrderStatusDataSource : ProviderDataSource<OrderStatus, OrderStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSource class.
		/// </summary>
		public OrderStatusDataSource() : base(DataRepository.OrderStatusProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OrderStatusDataSourceView used by the OrderStatusDataSource.
		/// </summary>
		protected OrderStatusDataSourceView OrderStatusView
		{
			get { return ( View as OrderStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OrderStatusDataSource control invokes to retrieve data.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
		{
			get
			{
				OrderStatusSelectMethod selectMethod = OrderStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OrderStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OrderStatusDataSourceView class that is to be
		/// used by the OrderStatusDataSource.
		/// </summary>
		/// <returns>An instance of the OrderStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<OrderStatus, OrderStatusKey> GetNewDataSourceView()
		{
			return new OrderStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the OrderStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OrderStatusDataSourceView : ProviderDataSourceView<OrderStatus, OrderStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OrderStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OrderStatusDataSourceView(OrderStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OrderStatusDataSource OrderStatusOwner
		{
			get { return Owner as OrderStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OrderStatusSelectMethod SelectMethod
		{
			get { return OrderStatusOwner.SelectMethod; }
			set { OrderStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OrderStatusProviderBase OrderStatusProvider
		{
			get { return Provider as OrderStatusProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OrderStatus> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OrderStatus> results = null;
			OrderStatus item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case OrderStatusSelectMethod.Get:
					OrderStatusKey entityKey  = new OrderStatusKey();
					entityKey.Load(values);
					item = OrderStatusProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<OrderStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OrderStatusSelectMethod.GetAll:
                    results = OrderStatusProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case OrderStatusSelectMethod.GetPaged:
					results = OrderStatusProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OrderStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = OrderStatusProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OrderStatusProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OrderStatusSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = OrderStatusProvider.GetById(GetTransactionManager(), _id);
					results = new TList<OrderStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == OrderStatusSelectMethod.Get || SelectMethod == OrderStatusSelectMethod.GetById )
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
				OrderStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					OrderStatusProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OrderStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			OrderStatusProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OrderStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OrderStatusDataSource class.
	/// </summary>
	public class OrderStatusDataSourceDesigner : ProviderDataSourceDesigner<OrderStatus, OrderStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceDesigner class.
		/// </summary>
		public OrderStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
		{
			get { return ((OrderStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OrderStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OrderStatusDataSourceActionList

	/// <summary>
	/// Supports the OrderStatusDataSourceDesigner class.
	/// </summary>
	internal class OrderStatusDataSourceActionList : DesignerActionList
	{
		private OrderStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OrderStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OrderStatusDataSourceActionList(OrderStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OrderStatusSelectMethod SelectMethod
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

	#endregion OrderStatusDataSourceActionList
	
	#endregion OrderStatusDataSourceDesigner
	
	#region OrderStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OrderStatusDataSource.SelectMethod property.
	/// </summary>
	public enum OrderStatusSelectMethod
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
		GetById
	}
	
	#endregion OrderStatusSelectMethod

	#region OrderStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilter : SqlFilter<OrderStatusColumn>
	{
	}
	
	#endregion OrderStatusFilter

	#region OrderStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusExpressionBuilder : SqlExpressionBuilder<OrderStatusColumn>
	{
	}
	
	#endregion OrderStatusExpressionBuilder	

	#region OrderStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OrderStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusProperty : ChildEntityProperty<OrderStatusChildEntityTypes>
	{
	}
	
	#endregion OrderStatusProperty
}


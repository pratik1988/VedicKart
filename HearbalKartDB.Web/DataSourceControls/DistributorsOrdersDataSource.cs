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
	/// Represents the DataRepository.DistributorsOrdersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DistributorsOrdersDataSourceDesigner))]
	public class DistributorsOrdersDataSource : ProviderDataSource<DistributorsOrders, DistributorsOrdersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersDataSource class.
		/// </summary>
		public DistributorsOrdersDataSource() : base(DataRepository.DistributorsOrdersProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DistributorsOrdersDataSourceView used by the DistributorsOrdersDataSource.
		/// </summary>
		protected DistributorsOrdersDataSourceView DistributorsOrdersView
		{
			get { return ( View as DistributorsOrdersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DistributorsOrdersDataSource control invokes to retrieve data.
		/// </summary>
		public DistributorsOrdersSelectMethod SelectMethod
		{
			get
			{
				DistributorsOrdersSelectMethod selectMethod = DistributorsOrdersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DistributorsOrdersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DistributorsOrdersDataSourceView class that is to be
		/// used by the DistributorsOrdersDataSource.
		/// </summary>
		/// <returns>An instance of the DistributorsOrdersDataSourceView class.</returns>
		protected override BaseDataSourceView<DistributorsOrders, DistributorsOrdersKey> GetNewDataSourceView()
		{
			return new DistributorsOrdersDataSourceView(this, DefaultViewName);
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
	/// Supports the DistributorsOrdersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DistributorsOrdersDataSourceView : ProviderDataSourceView<DistributorsOrders, DistributorsOrdersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DistributorsOrdersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DistributorsOrdersDataSourceView(DistributorsOrdersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DistributorsOrdersDataSource DistributorsOrdersOwner
		{
			get { return Owner as DistributorsOrdersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DistributorsOrdersSelectMethod SelectMethod
		{
			get { return DistributorsOrdersOwner.SelectMethod; }
			set { DistributorsOrdersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DistributorsOrdersProviderBase DistributorsOrdersProvider
		{
			get { return Provider as DistributorsOrdersProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DistributorsOrders> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DistributorsOrders> results = null;
			DistributorsOrders item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _distributorId_nullable;
			System.Int32? _orderId_nullable;

			switch ( SelectMethod )
			{
				case DistributorsOrdersSelectMethod.Get:
					DistributorsOrdersKey entityKey  = new DistributorsOrdersKey();
					entityKey.Load(values);
					item = DistributorsOrdersProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<DistributorsOrders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DistributorsOrdersSelectMethod.GetAll:
                    results = DistributorsOrdersProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DistributorsOrdersSelectMethod.GetPaged:
					results = DistributorsOrdersProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DistributorsOrdersSelectMethod.Find:
					if ( FilterParameters != null )
						results = DistributorsOrdersProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DistributorsOrdersProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DistributorsOrdersSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DistributorsOrdersProvider.GetById(GetTransactionManager(), _id);
					results = new TList<DistributorsOrders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DistributorsOrdersSelectMethod.GetByDistributorId:
					_distributorId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DistributorId"], typeof(System.Int32?));
					results = DistributorsOrdersProvider.GetByDistributorId(GetTransactionManager(), _distributorId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DistributorsOrdersSelectMethod.GetByOrderId:
					_orderId_nullable = (System.Int32?) EntityUtil.ChangeType(values["OrderId"], typeof(System.Int32?));
					results = DistributorsOrdersProvider.GetByOrderId(GetTransactionManager(), _orderId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DistributorsOrdersSelectMethod.Get || SelectMethod == DistributorsOrdersSelectMethod.GetById )
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
				DistributorsOrders entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DistributorsOrdersProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DistributorsOrders> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DistributorsOrdersProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DistributorsOrdersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DistributorsOrdersDataSource class.
	/// </summary>
	public class DistributorsOrdersDataSourceDesigner : ProviderDataSourceDesigner<DistributorsOrders, DistributorsOrdersKey>
	{
		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersDataSourceDesigner class.
		/// </summary>
		public DistributorsOrdersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DistributorsOrdersSelectMethod SelectMethod
		{
			get { return ((DistributorsOrdersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DistributorsOrdersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DistributorsOrdersDataSourceActionList

	/// <summary>
	/// Supports the DistributorsOrdersDataSourceDesigner class.
	/// </summary>
	internal class DistributorsOrdersDataSourceActionList : DesignerActionList
	{
		private DistributorsOrdersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DistributorsOrdersDataSourceActionList(DistributorsOrdersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DistributorsOrdersSelectMethod SelectMethod
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

	#endregion DistributorsOrdersDataSourceActionList
	
	#endregion DistributorsOrdersDataSourceDesigner
	
	#region DistributorsOrdersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DistributorsOrdersDataSource.SelectMethod property.
	/// </summary>
	public enum DistributorsOrdersSelectMethod
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
		/// Represents the GetByDistributorId method.
		/// </summary>
		GetByDistributorId,
		/// <summary>
		/// Represents the GetByOrderId method.
		/// </summary>
		GetByOrderId
	}
	
	#endregion DistributorsOrdersSelectMethod

	#region DistributorsOrdersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersFilter : SqlFilter<DistributorsOrdersColumn>
	{
	}
	
	#endregion DistributorsOrdersFilter

	#region DistributorsOrdersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersExpressionBuilder : SqlExpressionBuilder<DistributorsOrdersColumn>
	{
	}
	
	#endregion DistributorsOrdersExpressionBuilder	

	#region DistributorsOrdersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DistributorsOrdersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersProperty : ChildEntityProperty<DistributorsOrdersChildEntityTypes>
	{
	}
	
	#endregion DistributorsOrdersProperty
}


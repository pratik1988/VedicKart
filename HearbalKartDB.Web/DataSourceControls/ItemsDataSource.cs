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
	/// Represents the DataRepository.ItemsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemsDataSourceDesigner))]
	public class ItemsDataSource : ProviderDataSource<Items, ItemsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsDataSource class.
		/// </summary>
		public ItemsDataSource() : base(DataRepository.ItemsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemsDataSourceView used by the ItemsDataSource.
		/// </summary>
		protected ItemsDataSourceView ItemsView
		{
			get { return ( View as ItemsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemsDataSource control invokes to retrieve data.
		/// </summary>
		public ItemsSelectMethod SelectMethod
		{
			get
			{
				ItemsSelectMethod selectMethod = ItemsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemsDataSourceView class that is to be
		/// used by the ItemsDataSource.
		/// </summary>
		/// <returns>An instance of the ItemsDataSourceView class.</returns>
		protected override BaseDataSourceView<Items, ItemsKey> GetNewDataSourceView()
		{
			return new ItemsDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemsDataSourceView : ProviderDataSourceView<Items, ItemsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemsDataSourceView(ItemsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemsDataSource ItemsOwner
		{
			get { return Owner as ItemsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemsSelectMethod SelectMethod
		{
			get { return ItemsOwner.SelectMethod; }
			set { ItemsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemsProviderBase ItemsProvider
		{
			get { return Provider as ItemsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Items> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Items> results = null;
			Items item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ItemsSelectMethod.Get:
					ItemsKey entityKey  = new ItemsKey();
					entityKey.Load(values);
					item = ItemsProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Items>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemsSelectMethod.GetAll:
                    results = ItemsProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ItemsSelectMethod.GetPaged:
					results = ItemsProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemsProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemsProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemsSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ItemsProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Items>();
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
			if ( SelectMethod == ItemsSelectMethod.Get || SelectMethod == ItemsSelectMethod.GetById )
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
				Items entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ItemsProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Items> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ItemsProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemsDataSource class.
	/// </summary>
	public class ItemsDataSourceDesigner : ProviderDataSourceDesigner<Items, ItemsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemsDataSourceDesigner class.
		/// </summary>
		public ItemsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemsSelectMethod SelectMethod
		{
			get { return ((ItemsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemsDataSourceActionList

	/// <summary>
	/// Supports the ItemsDataSourceDesigner class.
	/// </summary>
	internal class ItemsDataSourceActionList : DesignerActionList
	{
		private ItemsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemsDataSourceActionList(ItemsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemsSelectMethod SelectMethod
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

	#endregion ItemsDataSourceActionList
	
	#endregion ItemsDataSourceDesigner
	
	#region ItemsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemsDataSource.SelectMethod property.
	/// </summary>
	public enum ItemsSelectMethod
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
	
	#endregion ItemsSelectMethod

	#region ItemsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsFilter : SqlFilter<ItemsColumn>
	{
	}
	
	#endregion ItemsFilter

	#region ItemsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsExpressionBuilder : SqlExpressionBuilder<ItemsColumn>
	{
	}
	
	#endregion ItemsExpressionBuilder	

	#region ItemsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsProperty : ChildEntityProperty<ItemsChildEntityTypes>
	{
	}
	
	#endregion ItemsProperty
}


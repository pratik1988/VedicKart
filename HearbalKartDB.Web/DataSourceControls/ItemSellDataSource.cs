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
	/// Represents the DataRepository.ItemSellProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemSellDataSourceDesigner))]
	public class ItemSellDataSource : ProviderDataSource<ItemSell, ItemSellKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellDataSource class.
		/// </summary>
		public ItemSellDataSource() : base(DataRepository.ItemSellProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemSellDataSourceView used by the ItemSellDataSource.
		/// </summary>
		protected ItemSellDataSourceView ItemSellView
		{
			get { return ( View as ItemSellDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemSellDataSource control invokes to retrieve data.
		/// </summary>
		public ItemSellSelectMethod SelectMethod
		{
			get
			{
				ItemSellSelectMethod selectMethod = ItemSellSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemSellSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemSellDataSourceView class that is to be
		/// used by the ItemSellDataSource.
		/// </summary>
		/// <returns>An instance of the ItemSellDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemSell, ItemSellKey> GetNewDataSourceView()
		{
			return new ItemSellDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemSellDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemSellDataSourceView : ProviderDataSourceView<ItemSell, ItemSellKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemSellDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemSellDataSourceView(ItemSellDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemSellDataSource ItemSellOwner
		{
			get { return Owner as ItemSellDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemSellSelectMethod SelectMethod
		{
			get { return ItemSellOwner.SelectMethod; }
			set { ItemSellOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemSellProviderBase ItemSellProvider
		{
			get { return Provider as ItemSellProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemSell> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemSell> results = null;
			ItemSell item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _itemId_nullable;

			switch ( SelectMethod )
			{
				case ItemSellSelectMethod.Get:
					ItemSellKey entityKey  = new ItemSellKey();
					entityKey.Load(values);
					item = ItemSellProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ItemSell>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemSellSelectMethod.GetAll:
                    results = ItemSellProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ItemSellSelectMethod.GetPaged:
					results = ItemSellProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemSellSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemSellProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemSellProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemSellSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ItemSellProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ItemSell>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemSellSelectMethod.GetByItemId:
					_itemId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int32?));
					results = ItemSellProvider.GetByItemId(GetTransactionManager(), _itemId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemSellSelectMethod.Get || SelectMethod == ItemSellSelectMethod.GetById )
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
				ItemSell entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ItemSellProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemSell> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ItemSellProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemSellDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemSellDataSource class.
	/// </summary>
	public class ItemSellDataSourceDesigner : ProviderDataSourceDesigner<ItemSell, ItemSellKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemSellDataSourceDesigner class.
		/// </summary>
		public ItemSellDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemSellSelectMethod SelectMethod
		{
			get { return ((ItemSellDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemSellDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemSellDataSourceActionList

	/// <summary>
	/// Supports the ItemSellDataSourceDesigner class.
	/// </summary>
	internal class ItemSellDataSourceActionList : DesignerActionList
	{
		private ItemSellDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemSellDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemSellDataSourceActionList(ItemSellDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemSellSelectMethod SelectMethod
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

	#endregion ItemSellDataSourceActionList
	
	#endregion ItemSellDataSourceDesigner
	
	#region ItemSellSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemSellDataSource.SelectMethod property.
	/// </summary>
	public enum ItemSellSelectMethod
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
		/// Represents the GetByItemId method.
		/// </summary>
		GetByItemId
	}
	
	#endregion ItemSellSelectMethod

	#region ItemSellFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellFilter : SqlFilter<ItemSellColumn>
	{
	}
	
	#endregion ItemSellFilter

	#region ItemSellExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellExpressionBuilder : SqlExpressionBuilder<ItemSellColumn>
	{
	}
	
	#endregion ItemSellExpressionBuilder	

	#region ItemSellProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemSellChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellProperty : ChildEntityProperty<ItemSellChildEntityTypes>
	{
	}
	
	#endregion ItemSellProperty
}


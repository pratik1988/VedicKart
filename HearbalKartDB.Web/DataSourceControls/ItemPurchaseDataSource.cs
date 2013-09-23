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
	/// Represents the DataRepository.ItemPurchaseProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ItemPurchaseDataSourceDesigner))]
	public class ItemPurchaseDataSource : ProviderDataSource<ItemPurchase, ItemPurchaseKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseDataSource class.
		/// </summary>
		public ItemPurchaseDataSource() : base(DataRepository.ItemPurchaseProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ItemPurchaseDataSourceView used by the ItemPurchaseDataSource.
		/// </summary>
		protected ItemPurchaseDataSourceView ItemPurchaseView
		{
			get { return ( View as ItemPurchaseDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ItemPurchaseDataSource control invokes to retrieve data.
		/// </summary>
		public ItemPurchaseSelectMethod SelectMethod
		{
			get
			{
				ItemPurchaseSelectMethod selectMethod = ItemPurchaseSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ItemPurchaseSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ItemPurchaseDataSourceView class that is to be
		/// used by the ItemPurchaseDataSource.
		/// </summary>
		/// <returns>An instance of the ItemPurchaseDataSourceView class.</returns>
		protected override BaseDataSourceView<ItemPurchase, ItemPurchaseKey> GetNewDataSourceView()
		{
			return new ItemPurchaseDataSourceView(this, DefaultViewName);
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
	/// Supports the ItemPurchaseDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ItemPurchaseDataSourceView : ProviderDataSourceView<ItemPurchase, ItemPurchaseKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ItemPurchaseDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ItemPurchaseDataSourceView(ItemPurchaseDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ItemPurchaseDataSource ItemPurchaseOwner
		{
			get { return Owner as ItemPurchaseDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ItemPurchaseSelectMethod SelectMethod
		{
			get { return ItemPurchaseOwner.SelectMethod; }
			set { ItemPurchaseOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ItemPurchaseProviderBase ItemPurchaseProvider
		{
			get { return Provider as ItemPurchaseProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ItemPurchase> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ItemPurchase> results = null;
			ItemPurchase item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _itemId_nullable;

			switch ( SelectMethod )
			{
				case ItemPurchaseSelectMethod.Get:
					ItemPurchaseKey entityKey  = new ItemPurchaseKey();
					entityKey.Load(values);
					item = ItemPurchaseProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ItemPurchase>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ItemPurchaseSelectMethod.GetAll:
                    results = ItemPurchaseProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ItemPurchaseSelectMethod.GetPaged:
					results = ItemPurchaseProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ItemPurchaseSelectMethod.Find:
					if ( FilterParameters != null )
						results = ItemPurchaseProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ItemPurchaseProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ItemPurchaseSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ItemPurchaseProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ItemPurchase>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ItemPurchaseSelectMethod.GetByItemId:
					_itemId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ItemId"], typeof(System.Int32?));
					results = ItemPurchaseProvider.GetByItemId(GetTransactionManager(), _itemId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ItemPurchaseSelectMethod.Get || SelectMethod == ItemPurchaseSelectMethod.GetById )
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
				ItemPurchase entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ItemPurchaseProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ItemPurchase> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ItemPurchaseProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ItemPurchaseDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ItemPurchaseDataSource class.
	/// </summary>
	public class ItemPurchaseDataSourceDesigner : ProviderDataSourceDesigner<ItemPurchase, ItemPurchaseKey>
	{
		/// <summary>
		/// Initializes a new instance of the ItemPurchaseDataSourceDesigner class.
		/// </summary>
		public ItemPurchaseDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemPurchaseSelectMethod SelectMethod
		{
			get { return ((ItemPurchaseDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ItemPurchaseDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ItemPurchaseDataSourceActionList

	/// <summary>
	/// Supports the ItemPurchaseDataSourceDesigner class.
	/// </summary>
	internal class ItemPurchaseDataSourceActionList : DesignerActionList
	{
		private ItemPurchaseDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ItemPurchaseDataSourceActionList(ItemPurchaseDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ItemPurchaseSelectMethod SelectMethod
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

	#endregion ItemPurchaseDataSourceActionList
	
	#endregion ItemPurchaseDataSourceDesigner
	
	#region ItemPurchaseSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ItemPurchaseDataSource.SelectMethod property.
	/// </summary>
	public enum ItemPurchaseSelectMethod
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
	
	#endregion ItemPurchaseSelectMethod

	#region ItemPurchaseFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemPurchase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemPurchaseFilter : SqlFilter<ItemPurchaseColumn>
	{
	}
	
	#endregion ItemPurchaseFilter

	#region ItemPurchaseExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemPurchase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemPurchaseExpressionBuilder : SqlExpressionBuilder<ItemPurchaseColumn>
	{
	}
	
	#endregion ItemPurchaseExpressionBuilder	

	#region ItemPurchaseProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ItemPurchaseChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ItemPurchase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemPurchaseProperty : ChildEntityProperty<ItemPurchaseChildEntityTypes>
	{
	}
	
	#endregion ItemPurchaseProperty
}


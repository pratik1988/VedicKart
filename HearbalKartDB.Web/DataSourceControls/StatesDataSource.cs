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
	/// Represents the DataRepository.StatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(StatesDataSourceDesigner))]
	public class StatesDataSource : ProviderDataSource<States, StatesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesDataSource class.
		/// </summary>
		public StatesDataSource() : base(DataRepository.StatesProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the StatesDataSourceView used by the StatesDataSource.
		/// </summary>
		protected StatesDataSourceView StatesView
		{
			get { return ( View as StatesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the StatesDataSource control invokes to retrieve data.
		/// </summary>
		public StatesSelectMethod SelectMethod
		{
			get
			{
				StatesSelectMethod selectMethod = StatesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (StatesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the StatesDataSourceView class that is to be
		/// used by the StatesDataSource.
		/// </summary>
		/// <returns>An instance of the StatesDataSourceView class.</returns>
		protected override BaseDataSourceView<States, StatesKey> GetNewDataSourceView()
		{
			return new StatesDataSourceView(this, DefaultViewName);
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
	/// Supports the StatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class StatesDataSourceView : ProviderDataSourceView<States, StatesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the StatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public StatesDataSourceView(StatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal StatesDataSource StatesOwner
		{
			get { return Owner as StatesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal StatesSelectMethod SelectMethod
		{
			get { return StatesOwner.SelectMethod; }
			set { StatesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal StatesProviderBase StatesProvider
		{
			get { return Provider as StatesProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<States> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<States> results = null;
			States item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _countryId_nullable;

			switch ( SelectMethod )
			{
				case StatesSelectMethod.Get:
					StatesKey entityKey  = new StatesKey();
					entityKey.Load(values);
					item = StatesProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<States>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case StatesSelectMethod.GetAll:
                    results = StatesProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case StatesSelectMethod.GetPaged:
					results = StatesProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case StatesSelectMethod.Find:
					if ( FilterParameters != null )
						results = StatesProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = StatesProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case StatesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = StatesProvider.GetById(GetTransactionManager(), _id);
					results = new TList<States>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case StatesSelectMethod.GetByCountryId:
					_countryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32?));
					results = StatesProvider.GetByCountryId(GetTransactionManager(), _countryId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == StatesSelectMethod.Get || SelectMethod == StatesSelectMethod.GetById )
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
				States entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					StatesProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<States> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			StatesProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region StatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the StatesDataSource class.
	/// </summary>
	public class StatesDataSourceDesigner : ProviderDataSourceDesigner<States, StatesKey>
	{
		/// <summary>
		/// Initializes a new instance of the StatesDataSourceDesigner class.
		/// </summary>
		public StatesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StatesSelectMethod SelectMethod
		{
			get { return ((StatesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new StatesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region StatesDataSourceActionList

	/// <summary>
	/// Supports the StatesDataSourceDesigner class.
	/// </summary>
	internal class StatesDataSourceActionList : DesignerActionList
	{
		private StatesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the StatesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public StatesDataSourceActionList(StatesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public StatesSelectMethod SelectMethod
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

	#endregion StatesDataSourceActionList
	
	#endregion StatesDataSourceDesigner
	
	#region StatesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the StatesDataSource.SelectMethod property.
	/// </summary>
	public enum StatesSelectMethod
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
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId
	}
	
	#endregion StatesSelectMethod

	#region StatesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesFilter : SqlFilter<StatesColumn>
	{
	}
	
	#endregion StatesFilter

	#region StatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesExpressionBuilder : SqlExpressionBuilder<StatesColumn>
	{
	}
	
	#endregion StatesExpressionBuilder	

	#region StatesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;StatesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesProperty : ChildEntityProperty<StatesChildEntityTypes>
	{
	}
	
	#endregion StatesProperty
}


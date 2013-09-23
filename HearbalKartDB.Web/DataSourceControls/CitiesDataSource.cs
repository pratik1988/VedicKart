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
	/// Represents the DataRepository.CitiesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CitiesDataSourceDesigner))]
	public class CitiesDataSource : ProviderDataSource<Cities, CitiesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesDataSource class.
		/// </summary>
		public CitiesDataSource() : base(DataRepository.CitiesProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CitiesDataSourceView used by the CitiesDataSource.
		/// </summary>
		protected CitiesDataSourceView CitiesView
		{
			get { return ( View as CitiesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CitiesDataSource control invokes to retrieve data.
		/// </summary>
		public CitiesSelectMethod SelectMethod
		{
			get
			{
				CitiesSelectMethod selectMethod = CitiesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CitiesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CitiesDataSourceView class that is to be
		/// used by the CitiesDataSource.
		/// </summary>
		/// <returns>An instance of the CitiesDataSourceView class.</returns>
		protected override BaseDataSourceView<Cities, CitiesKey> GetNewDataSourceView()
		{
			return new CitiesDataSourceView(this, DefaultViewName);
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
	/// Supports the CitiesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CitiesDataSourceView : ProviderDataSourceView<Cities, CitiesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CitiesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CitiesDataSourceView(CitiesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CitiesDataSource CitiesOwner
		{
			get { return Owner as CitiesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CitiesSelectMethod SelectMethod
		{
			get { return CitiesOwner.SelectMethod; }
			set { CitiesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CitiesProviderBase CitiesProvider
		{
			get { return Provider as CitiesProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Cities> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Cities> results = null;
			Cities item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _stateId_nullable;

			switch ( SelectMethod )
			{
				case CitiesSelectMethod.Get:
					CitiesKey entityKey  = new CitiesKey();
					entityKey.Load(values);
					item = CitiesProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Cities>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CitiesSelectMethod.GetAll:
                    results = CitiesProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case CitiesSelectMethod.GetPaged:
					results = CitiesProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CitiesSelectMethod.Find:
					if ( FilterParameters != null )
						results = CitiesProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CitiesProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CitiesSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CitiesProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Cities>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CitiesSelectMethod.GetByStateId:
					_stateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["StateId"], typeof(System.Int32?));
					results = CitiesProvider.GetByStateId(GetTransactionManager(), _stateId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CitiesSelectMethod.Get || SelectMethod == CitiesSelectMethod.GetById )
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
				Cities entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					CitiesProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Cities> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			CitiesProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CitiesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CitiesDataSource class.
	/// </summary>
	public class CitiesDataSourceDesigner : ProviderDataSourceDesigner<Cities, CitiesKey>
	{
		/// <summary>
		/// Initializes a new instance of the CitiesDataSourceDesigner class.
		/// </summary>
		public CitiesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CitiesSelectMethod SelectMethod
		{
			get { return ((CitiesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CitiesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CitiesDataSourceActionList

	/// <summary>
	/// Supports the CitiesDataSourceDesigner class.
	/// </summary>
	internal class CitiesDataSourceActionList : DesignerActionList
	{
		private CitiesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CitiesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CitiesDataSourceActionList(CitiesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CitiesSelectMethod SelectMethod
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

	#endregion CitiesDataSourceActionList
	
	#endregion CitiesDataSourceDesigner
	
	#region CitiesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CitiesDataSource.SelectMethod property.
	/// </summary>
	public enum CitiesSelectMethod
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
		/// Represents the GetByStateId method.
		/// </summary>
		GetByStateId
	}
	
	#endregion CitiesSelectMethod

	#region CitiesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesFilter : SqlFilter<CitiesColumn>
	{
	}
	
	#endregion CitiesFilter

	#region CitiesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesExpressionBuilder : SqlExpressionBuilder<CitiesColumn>
	{
	}
	
	#endregion CitiesExpressionBuilder	

	#region CitiesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CitiesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesProperty : ChildEntityProperty<CitiesChildEntityTypes>
	{
	}
	
	#endregion CitiesProperty
}


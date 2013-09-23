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
	/// Represents the DataRepository.GenderProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(GenderDataSourceDesigner))]
	public class GenderDataSource : ProviderDataSource<Gender, GenderKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderDataSource class.
		/// </summary>
		public GenderDataSource() : base(DataRepository.GenderProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the GenderDataSourceView used by the GenderDataSource.
		/// </summary>
		protected GenderDataSourceView GenderView
		{
			get { return ( View as GenderDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the GenderDataSource control invokes to retrieve data.
		/// </summary>
		public GenderSelectMethod SelectMethod
		{
			get
			{
				GenderSelectMethod selectMethod = GenderSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (GenderSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the GenderDataSourceView class that is to be
		/// used by the GenderDataSource.
		/// </summary>
		/// <returns>An instance of the GenderDataSourceView class.</returns>
		protected override BaseDataSourceView<Gender, GenderKey> GetNewDataSourceView()
		{
			return new GenderDataSourceView(this, DefaultViewName);
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
	/// Supports the GenderDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class GenderDataSourceView : ProviderDataSourceView<Gender, GenderKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the GenderDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public GenderDataSourceView(GenderDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal GenderDataSource GenderOwner
		{
			get { return Owner as GenderDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal GenderSelectMethod SelectMethod
		{
			get { return GenderOwner.SelectMethod; }
			set { GenderOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal GenderProviderBase GenderProvider
		{
			get { return Provider as GenderProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Gender> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Gender> results = null;
			Gender item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case GenderSelectMethod.Get:
					GenderKey entityKey  = new GenderKey();
					entityKey.Load(values);
					item = GenderProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Gender>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case GenderSelectMethod.GetAll:
                    results = GenderProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case GenderSelectMethod.GetPaged:
					results = GenderProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case GenderSelectMethod.Find:
					if ( FilterParameters != null )
						results = GenderProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = GenderProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case GenderSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = GenderProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Gender>();
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
			if ( SelectMethod == GenderSelectMethod.Get || SelectMethod == GenderSelectMethod.GetById )
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
				Gender entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					GenderProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Gender> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			GenderProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region GenderDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the GenderDataSource class.
	/// </summary>
	public class GenderDataSourceDesigner : ProviderDataSourceDesigner<Gender, GenderKey>
	{
		/// <summary>
		/// Initializes a new instance of the GenderDataSourceDesigner class.
		/// </summary>
		public GenderDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GenderSelectMethod SelectMethod
		{
			get { return ((GenderDataSource) DataSource).SelectMethod; }
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
				actions.Add(new GenderDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region GenderDataSourceActionList

	/// <summary>
	/// Supports the GenderDataSourceDesigner class.
	/// </summary>
	internal class GenderDataSourceActionList : DesignerActionList
	{
		private GenderDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the GenderDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public GenderDataSourceActionList(GenderDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public GenderSelectMethod SelectMethod
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

	#endregion GenderDataSourceActionList
	
	#endregion GenderDataSourceDesigner
	
	#region GenderSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the GenderDataSource.SelectMethod property.
	/// </summary>
	public enum GenderSelectMethod
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
	
	#endregion GenderSelectMethod

	#region GenderFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderFilter : SqlFilter<GenderColumn>
	{
	}
	
	#endregion GenderFilter

	#region GenderExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderExpressionBuilder : SqlExpressionBuilder<GenderColumn>
	{
	}
	
	#endregion GenderExpressionBuilder	

	#region GenderProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;GenderChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderProperty : ChildEntityProperty<GenderChildEntityTypes>
	{
	}
	
	#endregion GenderProperty
}


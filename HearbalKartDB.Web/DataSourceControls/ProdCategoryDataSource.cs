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
	/// Represents the DataRepository.ProdCategoryProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdCategoryDataSourceDesigner))]
	public class ProdCategoryDataSource : ProviderDataSource<ProdCategory, ProdCategoryKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryDataSource class.
		/// </summary>
		public ProdCategoryDataSource() : base(DataRepository.ProdCategoryProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdCategoryDataSourceView used by the ProdCategoryDataSource.
		/// </summary>
		protected ProdCategoryDataSourceView ProdCategoryView
		{
			get { return ( View as ProdCategoryDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdCategoryDataSource control invokes to retrieve data.
		/// </summary>
		public ProdCategorySelectMethod SelectMethod
		{
			get
			{
				ProdCategorySelectMethod selectMethod = ProdCategorySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdCategorySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdCategoryDataSourceView class that is to be
		/// used by the ProdCategoryDataSource.
		/// </summary>
		/// <returns>An instance of the ProdCategoryDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdCategory, ProdCategoryKey> GetNewDataSourceView()
		{
			return new ProdCategoryDataSourceView(this, DefaultViewName);
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
	/// Supports the ProdCategoryDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdCategoryDataSourceView : ProviderDataSourceView<ProdCategory, ProdCategoryKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdCategoryDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdCategoryDataSourceView(ProdCategoryDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdCategoryDataSource ProdCategoryOwner
		{
			get { return Owner as ProdCategoryDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdCategorySelectMethod SelectMethod
		{
			get { return ProdCategoryOwner.SelectMethod; }
			set { ProdCategoryOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdCategoryProviderBase ProdCategoryProvider
		{
			get { return Provider as ProdCategoryProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdCategory> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdCategory> results = null;
			ProdCategory item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProdCategorySelectMethod.Get:
					ProdCategoryKey entityKey  = new ProdCategoryKey();
					entityKey.Load(values);
					item = ProdCategoryProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdCategory>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdCategorySelectMethod.GetAll:
                    results = ProdCategoryProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdCategorySelectMethod.GetPaged:
					results = ProdCategoryProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdCategorySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdCategoryProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdCategoryProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdCategorySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdCategoryProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdCategory>();
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
			if ( SelectMethod == ProdCategorySelectMethod.Get || SelectMethod == ProdCategorySelectMethod.GetById )
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
				ProdCategory entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdCategoryProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProdCategory> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdCategoryProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdCategoryDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdCategoryDataSource class.
	/// </summary>
	public class ProdCategoryDataSourceDesigner : ProviderDataSourceDesigner<ProdCategory, ProdCategoryKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdCategoryDataSourceDesigner class.
		/// </summary>
		public ProdCategoryDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdCategorySelectMethod SelectMethod
		{
			get { return ((ProdCategoryDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProdCategoryDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdCategoryDataSourceActionList

	/// <summary>
	/// Supports the ProdCategoryDataSourceDesigner class.
	/// </summary>
	internal class ProdCategoryDataSourceActionList : DesignerActionList
	{
		private ProdCategoryDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdCategoryDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdCategoryDataSourceActionList(ProdCategoryDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdCategorySelectMethod SelectMethod
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

	#endregion ProdCategoryDataSourceActionList
	
	#endregion ProdCategoryDataSourceDesigner
	
	#region ProdCategorySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdCategoryDataSource.SelectMethod property.
	/// </summary>
	public enum ProdCategorySelectMethod
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
	
	#endregion ProdCategorySelectMethod

	#region ProdCategoryFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryFilter : SqlFilter<ProdCategoryColumn>
	{
	}
	
	#endregion ProdCategoryFilter

	#region ProdCategoryExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryExpressionBuilder : SqlExpressionBuilder<ProdCategoryColumn>
	{
	}
	
	#endregion ProdCategoryExpressionBuilder	

	#region ProdCategoryProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdCategoryChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryProperty : ChildEntityProperty<ProdCategoryChildEntityTypes>
	{
	}
	
	#endregion ProdCategoryProperty
}


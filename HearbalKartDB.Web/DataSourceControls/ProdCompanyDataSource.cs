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
	/// Represents the DataRepository.ProdCompanyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdCompanyDataSourceDesigner))]
	public class ProdCompanyDataSource : ProviderDataSource<ProdCompany, ProdCompanyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCompanyDataSource class.
		/// </summary>
		public ProdCompanyDataSource() : base(DataRepository.ProdCompanyProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdCompanyDataSourceView used by the ProdCompanyDataSource.
		/// </summary>
		protected ProdCompanyDataSourceView ProdCompanyView
		{
			get { return ( View as ProdCompanyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdCompanyDataSource control invokes to retrieve data.
		/// </summary>
		public ProdCompanySelectMethod SelectMethod
		{
			get
			{
				ProdCompanySelectMethod selectMethod = ProdCompanySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdCompanySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdCompanyDataSourceView class that is to be
		/// used by the ProdCompanyDataSource.
		/// </summary>
		/// <returns>An instance of the ProdCompanyDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdCompany, ProdCompanyKey> GetNewDataSourceView()
		{
			return new ProdCompanyDataSourceView(this, DefaultViewName);
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
	/// Supports the ProdCompanyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdCompanyDataSourceView : ProviderDataSourceView<ProdCompany, ProdCompanyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCompanyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdCompanyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdCompanyDataSourceView(ProdCompanyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdCompanyDataSource ProdCompanyOwner
		{
			get { return Owner as ProdCompanyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdCompanySelectMethod SelectMethod
		{
			get { return ProdCompanyOwner.SelectMethod; }
			set { ProdCompanyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdCompanyProviderBase ProdCompanyProvider
		{
			get { return Provider as ProdCompanyProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdCompany> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdCompany> results = null;
			ProdCompany item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProdCompanySelectMethod.Get:
					ProdCompanyKey entityKey  = new ProdCompanyKey();
					entityKey.Load(values);
					item = ProdCompanyProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdCompany>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdCompanySelectMethod.GetAll:
                    results = ProdCompanyProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdCompanySelectMethod.GetPaged:
					results = ProdCompanyProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdCompanySelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdCompanyProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdCompanyProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdCompanySelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdCompanyProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdCompany>();
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
			if ( SelectMethod == ProdCompanySelectMethod.Get || SelectMethod == ProdCompanySelectMethod.GetById )
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
				ProdCompany entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdCompanyProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProdCompany> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdCompanyProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdCompanyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdCompanyDataSource class.
	/// </summary>
	public class ProdCompanyDataSourceDesigner : ProviderDataSourceDesigner<ProdCompany, ProdCompanyKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdCompanyDataSourceDesigner class.
		/// </summary>
		public ProdCompanyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdCompanySelectMethod SelectMethod
		{
			get { return ((ProdCompanyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProdCompanyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdCompanyDataSourceActionList

	/// <summary>
	/// Supports the ProdCompanyDataSourceDesigner class.
	/// </summary>
	internal class ProdCompanyDataSourceActionList : DesignerActionList
	{
		private ProdCompanyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdCompanyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdCompanyDataSourceActionList(ProdCompanyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdCompanySelectMethod SelectMethod
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

	#endregion ProdCompanyDataSourceActionList
	
	#endregion ProdCompanyDataSourceDesigner
	
	#region ProdCompanySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdCompanyDataSource.SelectMethod property.
	/// </summary>
	public enum ProdCompanySelectMethod
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
	
	#endregion ProdCompanySelectMethod

	#region ProdCompanyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCompany"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCompanyFilter : SqlFilter<ProdCompanyColumn>
	{
	}
	
	#endregion ProdCompanyFilter

	#region ProdCompanyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCompany"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCompanyExpressionBuilder : SqlExpressionBuilder<ProdCompanyColumn>
	{
	}
	
	#endregion ProdCompanyExpressionBuilder	

	#region ProdCompanyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdCompanyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCompany"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCompanyProperty : ChildEntityProperty<ProdCompanyChildEntityTypes>
	{
	}
	
	#endregion ProdCompanyProperty
}


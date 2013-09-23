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
	/// Represents the DataRepository.ProdSupplymentTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdSupplymentTypeDataSourceDesigner))]
	public class ProdSupplymentTypeDataSource : ProviderDataSource<ProdSupplymentType, ProdSupplymentTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeDataSource class.
		/// </summary>
		public ProdSupplymentTypeDataSource() : base(DataRepository.ProdSupplymentTypeProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdSupplymentTypeDataSourceView used by the ProdSupplymentTypeDataSource.
		/// </summary>
		protected ProdSupplymentTypeDataSourceView ProdSupplymentTypeView
		{
			get { return ( View as ProdSupplymentTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdSupplymentTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ProdSupplymentTypeSelectMethod SelectMethod
		{
			get
			{
				ProdSupplymentTypeSelectMethod selectMethod = ProdSupplymentTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdSupplymentTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdSupplymentTypeDataSourceView class that is to be
		/// used by the ProdSupplymentTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ProdSupplymentTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdSupplymentType, ProdSupplymentTypeKey> GetNewDataSourceView()
		{
			return new ProdSupplymentTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ProdSupplymentTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdSupplymentTypeDataSourceView : ProviderDataSourceView<ProdSupplymentType, ProdSupplymentTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdSupplymentTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdSupplymentTypeDataSourceView(ProdSupplymentTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdSupplymentTypeDataSource ProdSupplymentTypeOwner
		{
			get { return Owner as ProdSupplymentTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdSupplymentTypeSelectMethod SelectMethod
		{
			get { return ProdSupplymentTypeOwner.SelectMethod; }
			set { ProdSupplymentTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdSupplymentTypeProviderBase ProdSupplymentTypeProvider
		{
			get { return Provider as ProdSupplymentTypeProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdSupplymentType> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdSupplymentType> results = null;
			ProdSupplymentType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProdSupplymentTypeSelectMethod.Get:
					ProdSupplymentTypeKey entityKey  = new ProdSupplymentTypeKey();
					entityKey.Load(values);
					item = ProdSupplymentTypeProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdSupplymentType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdSupplymentTypeSelectMethod.GetAll:
                    results = ProdSupplymentTypeProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdSupplymentTypeSelectMethod.GetPaged:
					results = ProdSupplymentTypeProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdSupplymentTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdSupplymentTypeProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdSupplymentTypeProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdSupplymentTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdSupplymentTypeProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdSupplymentType>();
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
			if ( SelectMethod == ProdSupplymentTypeSelectMethod.Get || SelectMethod == ProdSupplymentTypeSelectMethod.GetById )
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
				ProdSupplymentType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdSupplymentTypeProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProdSupplymentType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdSupplymentTypeProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdSupplymentTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdSupplymentTypeDataSource class.
	/// </summary>
	public class ProdSupplymentTypeDataSourceDesigner : ProviderDataSourceDesigner<ProdSupplymentType, ProdSupplymentTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeDataSourceDesigner class.
		/// </summary>
		public ProdSupplymentTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdSupplymentTypeSelectMethod SelectMethod
		{
			get { return ((ProdSupplymentTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProdSupplymentTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdSupplymentTypeDataSourceActionList

	/// <summary>
	/// Supports the ProdSupplymentTypeDataSourceDesigner class.
	/// </summary>
	internal class ProdSupplymentTypeDataSourceActionList : DesignerActionList
	{
		private ProdSupplymentTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdSupplymentTypeDataSourceActionList(ProdSupplymentTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdSupplymentTypeSelectMethod SelectMethod
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

	#endregion ProdSupplymentTypeDataSourceActionList
	
	#endregion ProdSupplymentTypeDataSourceDesigner
	
	#region ProdSupplymentTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdSupplymentTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ProdSupplymentTypeSelectMethod
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
	
	#endregion ProdSupplymentTypeSelectMethod

	#region ProdSupplymentTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdSupplymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdSupplymentTypeFilter : SqlFilter<ProdSupplymentTypeColumn>
	{
	}
	
	#endregion ProdSupplymentTypeFilter

	#region ProdSupplymentTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdSupplymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdSupplymentTypeExpressionBuilder : SqlExpressionBuilder<ProdSupplymentTypeColumn>
	{
	}
	
	#endregion ProdSupplymentTypeExpressionBuilder	

	#region ProdSupplymentTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdSupplymentTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdSupplymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdSupplymentTypeProperty : ChildEntityProperty<ProdSupplymentTypeChildEntityTypes>
	{
	}
	
	#endregion ProdSupplymentTypeProperty
}


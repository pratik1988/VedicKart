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
	/// Represents the DataRepository.ProdOfferProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdOfferDataSourceDesigner))]
	public class ProdOfferDataSource : ProviderDataSource<ProdOffer, ProdOfferKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferDataSource class.
		/// </summary>
		public ProdOfferDataSource() : base(DataRepository.ProdOfferProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdOfferDataSourceView used by the ProdOfferDataSource.
		/// </summary>
		protected ProdOfferDataSourceView ProdOfferView
		{
			get { return ( View as ProdOfferDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdOfferDataSource control invokes to retrieve data.
		/// </summary>
		public ProdOfferSelectMethod SelectMethod
		{
			get
			{
				ProdOfferSelectMethod selectMethod = ProdOfferSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdOfferSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdOfferDataSourceView class that is to be
		/// used by the ProdOfferDataSource.
		/// </summary>
		/// <returns>An instance of the ProdOfferDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdOffer, ProdOfferKey> GetNewDataSourceView()
		{
			return new ProdOfferDataSourceView(this, DefaultViewName);
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
	/// Supports the ProdOfferDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdOfferDataSourceView : ProviderDataSourceView<ProdOffer, ProdOfferKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdOfferDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdOfferDataSourceView(ProdOfferDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdOfferDataSource ProdOfferOwner
		{
			get { return Owner as ProdOfferDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdOfferSelectMethod SelectMethod
		{
			get { return ProdOfferOwner.SelectMethod; }
			set { ProdOfferOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdOfferProviderBase ProdOfferProvider
		{
			get { return Provider as ProdOfferProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdOffer> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdOffer> results = null;
			ProdOffer item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProdOfferSelectMethod.Get:
					ProdOfferKey entityKey  = new ProdOfferKey();
					entityKey.Load(values);
					item = ProdOfferProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdOffer>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdOfferSelectMethod.GetAll:
                    results = ProdOfferProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdOfferSelectMethod.GetPaged:
					results = ProdOfferProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdOfferSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdOfferProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdOfferProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdOfferSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdOfferProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdOffer>();
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
			if ( SelectMethod == ProdOfferSelectMethod.Get || SelectMethod == ProdOfferSelectMethod.GetById )
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
				ProdOffer entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdOfferProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProdOffer> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdOfferProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdOfferDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdOfferDataSource class.
	/// </summary>
	public class ProdOfferDataSourceDesigner : ProviderDataSourceDesigner<ProdOffer, ProdOfferKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdOfferDataSourceDesigner class.
		/// </summary>
		public ProdOfferDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdOfferSelectMethod SelectMethod
		{
			get { return ((ProdOfferDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProdOfferDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdOfferDataSourceActionList

	/// <summary>
	/// Supports the ProdOfferDataSourceDesigner class.
	/// </summary>
	internal class ProdOfferDataSourceActionList : DesignerActionList
	{
		private ProdOfferDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdOfferDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdOfferDataSourceActionList(ProdOfferDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdOfferSelectMethod SelectMethod
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

	#endregion ProdOfferDataSourceActionList
	
	#endregion ProdOfferDataSourceDesigner
	
	#region ProdOfferSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdOfferDataSource.SelectMethod property.
	/// </summary>
	public enum ProdOfferSelectMethod
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
	
	#endregion ProdOfferSelectMethod

	#region ProdOfferFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferFilter : SqlFilter<ProdOfferColumn>
	{
	}
	
	#endregion ProdOfferFilter

	#region ProdOfferExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferExpressionBuilder : SqlExpressionBuilder<ProdOfferColumn>
	{
	}
	
	#endregion ProdOfferExpressionBuilder	

	#region ProdOfferProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdOfferChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferProperty : ChildEntityProperty<ProdOfferChildEntityTypes>
	{
	}
	
	#endregion ProdOfferProperty
}


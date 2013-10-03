﻿#region Using Directives
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
	/// Represents the DataRepository.ProdTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProdTypeDataSourceDesigner))]
	public class ProdTypeDataSource : ProviderDataSource<ProdType, ProdTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTypeDataSource class.
		/// </summary>
		public ProdTypeDataSource() : base(DataRepository.ProdTypeProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProdTypeDataSourceView used by the ProdTypeDataSource.
		/// </summary>
		protected ProdTypeDataSourceView ProdTypeView
		{
			get { return ( View as ProdTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProdTypeDataSource control invokes to retrieve data.
		/// </summary>
		public ProdTypeSelectMethod SelectMethod
		{
			get
			{
				ProdTypeSelectMethod selectMethod = ProdTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProdTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProdTypeDataSourceView class that is to be
		/// used by the ProdTypeDataSource.
		/// </summary>
		/// <returns>An instance of the ProdTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<ProdType, ProdTypeKey> GetNewDataSourceView()
		{
			return new ProdTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the ProdTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProdTypeDataSourceView : ProviderDataSourceView<ProdType, ProdTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProdTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProdTypeDataSourceView(ProdTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProdTypeDataSource ProdTypeOwner
		{
			get { return Owner as ProdTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProdTypeSelectMethod SelectMethod
		{
			get { return ProdTypeOwner.SelectMethod; }
			set { ProdTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProdTypeProviderBase ProdTypeProvider
		{
			get { return Provider as ProdTypeProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ProdType> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ProdType> results = null;
			ProdType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case ProdTypeSelectMethod.Get:
					ProdTypeKey entityKey  = new ProdTypeKey();
					entityKey.Load(values);
					item = ProdTypeProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ProdType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProdTypeSelectMethod.GetAll:
                    results = ProdTypeProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ProdTypeSelectMethod.GetPaged:
					results = ProdTypeProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProdTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProdTypeProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProdTypeProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProdTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = ProdTypeProvider.GetById(GetTransactionManager(), _id);
					results = new TList<ProdType>();
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
			if ( SelectMethod == ProdTypeSelectMethod.Get || SelectMethod == ProdTypeSelectMethod.GetById )
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
				ProdType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ProdTypeProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ProdType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ProdTypeProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProdTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProdTypeDataSource class.
	/// </summary>
	public class ProdTypeDataSourceDesigner : ProviderDataSourceDesigner<ProdType, ProdTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProdTypeDataSourceDesigner class.
		/// </summary>
		public ProdTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdTypeSelectMethod SelectMethod
		{
			get { return ((ProdTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProdTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProdTypeDataSourceActionList

	/// <summary>
	/// Supports the ProdTypeDataSourceDesigner class.
	/// </summary>
	internal class ProdTypeDataSourceActionList : DesignerActionList
	{
		private ProdTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProdTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProdTypeDataSourceActionList(ProdTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProdTypeSelectMethod SelectMethod
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

	#endregion ProdTypeDataSourceActionList
	
	#endregion ProdTypeDataSourceDesigner
	
	#region ProdTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProdTypeDataSource.SelectMethod property.
	/// </summary>
	public enum ProdTypeSelectMethod
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
	
	#endregion ProdTypeSelectMethod

	#region ProdTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTypeFilter : SqlFilter<ProdTypeColumn>
	{
	}
	
	#endregion ProdTypeFilter

	#region ProdTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTypeExpressionBuilder : SqlExpressionBuilder<ProdTypeColumn>
	{
	}
	
	#endregion ProdTypeExpressionBuilder	

	#region ProdTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProdTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ProdType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTypeProperty : ChildEntityProperty<ProdTypeChildEntityTypes>
	{
	}
	
	#endregion ProdTypeProperty
}


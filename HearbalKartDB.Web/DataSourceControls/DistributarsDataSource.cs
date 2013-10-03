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
	/// Represents the DataRepository.DistributarsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DistributarsDataSourceDesigner))]
	public class DistributarsDataSource : ProviderDataSource<Distributars, DistributarsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsDataSource class.
		/// </summary>
		public DistributarsDataSource() : base(DataRepository.DistributarsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DistributarsDataSourceView used by the DistributarsDataSource.
		/// </summary>
		protected DistributarsDataSourceView DistributarsView
		{
			get { return ( View as DistributarsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DistributarsDataSource control invokes to retrieve data.
		/// </summary>
		public DistributarsSelectMethod SelectMethod
		{
			get
			{
				DistributarsSelectMethod selectMethod = DistributarsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DistributarsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DistributarsDataSourceView class that is to be
		/// used by the DistributarsDataSource.
		/// </summary>
		/// <returns>An instance of the DistributarsDataSourceView class.</returns>
		protected override BaseDataSourceView<Distributars, DistributarsKey> GetNewDataSourceView()
		{
			return new DistributarsDataSourceView(this, DefaultViewName);
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
	/// Supports the DistributarsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DistributarsDataSourceView : ProviderDataSourceView<Distributars, DistributarsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DistributarsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DistributarsDataSourceView(DistributarsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DistributarsDataSource DistributarsOwner
		{
			get { return Owner as DistributarsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DistributarsSelectMethod SelectMethod
		{
			get { return DistributarsOwner.SelectMethod; }
			set { DistributarsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DistributarsProviderBase DistributarsProvider
		{
			get { return Provider as DistributarsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Distributars> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Distributars> results = null;
			Distributars item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _cityId_nullable;
			System.Int32? _countryId_nullable;
			System.Int32? _daliveredDaysId_nullable;
			System.Int32? _stateId_nullable;

			switch ( SelectMethod )
			{
				case DistributarsSelectMethod.Get:
					DistributarsKey entityKey  = new DistributarsKey();
					entityKey.Load(values);
					item = DistributarsProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Distributars>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DistributarsSelectMethod.GetAll:
                    results = DistributarsProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DistributarsSelectMethod.GetPaged:
					results = DistributarsProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DistributarsSelectMethod.Find:
					if ( FilterParameters != null )
						results = DistributarsProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DistributarsProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DistributarsSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DistributarsProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Distributars>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DistributarsSelectMethod.GetByCityId:
					_cityId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CityId"], typeof(System.Int32?));
					results = DistributarsProvider.GetByCityId(GetTransactionManager(), _cityId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DistributarsSelectMethod.GetByCountryId:
					_countryId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32?));
					results = DistributarsProvider.GetByCountryId(GetTransactionManager(), _countryId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DistributarsSelectMethod.GetByDaliveredDaysId:
					_daliveredDaysId_nullable = (System.Int32?) EntityUtil.ChangeType(values["DaliveredDaysId"], typeof(System.Int32?));
					results = DistributarsProvider.GetByDaliveredDaysId(GetTransactionManager(), _daliveredDaysId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case DistributarsSelectMethod.GetByStateId:
					_stateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["StateId"], typeof(System.Int32?));
					results = DistributarsProvider.GetByStateId(GetTransactionManager(), _stateId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DistributarsSelectMethod.Get || SelectMethod == DistributarsSelectMethod.GetById )
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
				Distributars entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DistributarsProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Distributars> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DistributarsProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DistributarsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DistributarsDataSource class.
	/// </summary>
	public class DistributarsDataSourceDesigner : ProviderDataSourceDesigner<Distributars, DistributarsKey>
	{
		/// <summary>
		/// Initializes a new instance of the DistributarsDataSourceDesigner class.
		/// </summary>
		public DistributarsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DistributarsSelectMethod SelectMethod
		{
			get { return ((DistributarsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DistributarsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DistributarsDataSourceActionList

	/// <summary>
	/// Supports the DistributarsDataSourceDesigner class.
	/// </summary>
	internal class DistributarsDataSourceActionList : DesignerActionList
	{
		private DistributarsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DistributarsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DistributarsDataSourceActionList(DistributarsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DistributarsSelectMethod SelectMethod
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

	#endregion DistributarsDataSourceActionList
	
	#endregion DistributarsDataSourceDesigner
	
	#region DistributarsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DistributarsDataSource.SelectMethod property.
	/// </summary>
	public enum DistributarsSelectMethod
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
		/// Represents the GetByCityId method.
		/// </summary>
		GetByCityId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId,
		/// <summary>
		/// Represents the GetByDaliveredDaysId method.
		/// </summary>
		GetByDaliveredDaysId,
		/// <summary>
		/// Represents the GetByStateId method.
		/// </summary>
		GetByStateId
	}
	
	#endregion DistributarsSelectMethod

	#region DistributarsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsFilter : SqlFilter<DistributarsColumn>
	{
	}
	
	#endregion DistributarsFilter

	#region DistributarsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsExpressionBuilder : SqlExpressionBuilder<DistributarsColumn>
	{
	}
	
	#endregion DistributarsExpressionBuilder	

	#region DistributarsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DistributarsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsProperty : ChildEntityProperty<DistributarsChildEntityTypes>
	{
	}
	
	#endregion DistributarsProperty
}


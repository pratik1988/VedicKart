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
	/// Represents the DataRepository.DeliveredDaysProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DeliveredDaysDataSourceDesigner))]
	public class DeliveredDaysDataSource : ProviderDataSource<DeliveredDays, DeliveredDaysKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysDataSource class.
		/// </summary>
		public DeliveredDaysDataSource() : base(DataRepository.DeliveredDaysProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DeliveredDaysDataSourceView used by the DeliveredDaysDataSource.
		/// </summary>
		protected DeliveredDaysDataSourceView DeliveredDaysView
		{
			get { return ( View as DeliveredDaysDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DeliveredDaysDataSource control invokes to retrieve data.
		/// </summary>
		public DeliveredDaysSelectMethod SelectMethod
		{
			get
			{
				DeliveredDaysSelectMethod selectMethod = DeliveredDaysSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DeliveredDaysSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DeliveredDaysDataSourceView class that is to be
		/// used by the DeliveredDaysDataSource.
		/// </summary>
		/// <returns>An instance of the DeliveredDaysDataSourceView class.</returns>
		protected override BaseDataSourceView<DeliveredDays, DeliveredDaysKey> GetNewDataSourceView()
		{
			return new DeliveredDaysDataSourceView(this, DefaultViewName);
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
	/// Supports the DeliveredDaysDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DeliveredDaysDataSourceView : ProviderDataSourceView<DeliveredDays, DeliveredDaysKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DeliveredDaysDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DeliveredDaysDataSourceView(DeliveredDaysDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DeliveredDaysDataSource DeliveredDaysOwner
		{
			get { return Owner as DeliveredDaysDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DeliveredDaysSelectMethod SelectMethod
		{
			get { return DeliveredDaysOwner.SelectMethod; }
			set { DeliveredDaysOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DeliveredDaysProviderBase DeliveredDaysProvider
		{
			get { return Provider as DeliveredDaysProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DeliveredDays> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DeliveredDays> results = null;
			DeliveredDays item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case DeliveredDaysSelectMethod.Get:
					DeliveredDaysKey entityKey  = new DeliveredDaysKey();
					entityKey.Load(values);
					item = DeliveredDaysProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<DeliveredDays>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DeliveredDaysSelectMethod.GetAll:
                    results = DeliveredDaysProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DeliveredDaysSelectMethod.GetPaged:
					results = DeliveredDaysProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DeliveredDaysSelectMethod.Find:
					if ( FilterParameters != null )
						results = DeliveredDaysProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DeliveredDaysProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DeliveredDaysSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = DeliveredDaysProvider.GetById(GetTransactionManager(), _id);
					results = new TList<DeliveredDays>();
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
			if ( SelectMethod == DeliveredDaysSelectMethod.Get || SelectMethod == DeliveredDaysSelectMethod.GetById )
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
				DeliveredDays entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DeliveredDaysProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DeliveredDays> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DeliveredDaysProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DeliveredDaysDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DeliveredDaysDataSource class.
	/// </summary>
	public class DeliveredDaysDataSourceDesigner : ProviderDataSourceDesigner<DeliveredDays, DeliveredDaysKey>
	{
		/// <summary>
		/// Initializes a new instance of the DeliveredDaysDataSourceDesigner class.
		/// </summary>
		public DeliveredDaysDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DeliveredDaysSelectMethod SelectMethod
		{
			get { return ((DeliveredDaysDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DeliveredDaysDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DeliveredDaysDataSourceActionList

	/// <summary>
	/// Supports the DeliveredDaysDataSourceDesigner class.
	/// </summary>
	internal class DeliveredDaysDataSourceActionList : DesignerActionList
	{
		private DeliveredDaysDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DeliveredDaysDataSourceActionList(DeliveredDaysDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DeliveredDaysSelectMethod SelectMethod
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

	#endregion DeliveredDaysDataSourceActionList
	
	#endregion DeliveredDaysDataSourceDesigner
	
	#region DeliveredDaysSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DeliveredDaysDataSource.SelectMethod property.
	/// </summary>
	public enum DeliveredDaysSelectMethod
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
	
	#endregion DeliveredDaysSelectMethod

	#region DeliveredDaysFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysFilter : SqlFilter<DeliveredDaysColumn>
	{
	}
	
	#endregion DeliveredDaysFilter

	#region DeliveredDaysExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysExpressionBuilder : SqlExpressionBuilder<DeliveredDaysColumn>
	{
	}
	
	#endregion DeliveredDaysExpressionBuilder	

	#region DeliveredDaysProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DeliveredDaysChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysProperty : ChildEntityProperty<DeliveredDaysChildEntityTypes>
	{
	}
	
	#endregion DeliveredDaysProperty
}


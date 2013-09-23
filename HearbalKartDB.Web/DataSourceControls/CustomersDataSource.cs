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
	/// Represents the DataRepository.CustomersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomersDataSourceDesigner))]
	public class CustomersDataSource : ProviderDataSource<Customers, CustomersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersDataSource class.
		/// </summary>
		public CustomersDataSource() : base(DataRepository.CustomersProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomersDataSourceView used by the CustomersDataSource.
		/// </summary>
		protected CustomersDataSourceView CustomersView
		{
			get { return ( View as CustomersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomersDataSource control invokes to retrieve data.
		/// </summary>
		public CustomersSelectMethod SelectMethod
		{
			get
			{
				CustomersSelectMethod selectMethod = CustomersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomersDataSourceView class that is to be
		/// used by the CustomersDataSource.
		/// </summary>
		/// <returns>An instance of the CustomersDataSourceView class.</returns>
		protected override BaseDataSourceView<Customers, CustomersKey> GetNewDataSourceView()
		{
			return new CustomersDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomersDataSourceView : ProviderDataSourceView<Customers, CustomersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomersDataSourceView(CustomersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomersDataSource CustomersOwner
		{
			get { return Owner as CustomersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomersSelectMethod SelectMethod
		{
			get { return CustomersOwner.SelectMethod; }
			set { CustomersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomersProviderBase CustomersProvider
		{
			get { return Provider as CustomersProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Customers> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Customers> results = null;
			Customers item;
			count = 0;
			
			System.Int32 _id;
			System.Int32? _gender_nullable;
			System.Int32? _userType_nullable;

			switch ( SelectMethod )
			{
				case CustomersSelectMethod.Get:
					CustomersKey entityKey  = new CustomersKey();
					entityKey.Load(values);
					item = CustomersProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Customers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomersSelectMethod.GetAll:
                    results = CustomersProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case CustomersSelectMethod.GetPaged:
					results = CustomersProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomersSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomersProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomersProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomersSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = CustomersProvider.GetById(GetTransactionManager(), _id);
					results = new TList<Customers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomersSelectMethod.GetByGender:
					_gender_nullable = (System.Int32?) EntityUtil.ChangeType(values["Gender"], typeof(System.Int32?));
					results = CustomersProvider.GetByGender(GetTransactionManager(), _gender_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CustomersSelectMethod.GetByUserType:
					_userType_nullable = (System.Int32?) EntityUtil.ChangeType(values["UserType"], typeof(System.Int32?));
					results = CustomersProvider.GetByUserType(GetTransactionManager(), _userType_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomersSelectMethod.Get || SelectMethod == CustomersSelectMethod.GetById )
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
				Customers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					CustomersProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Customers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			CustomersProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomersDataSource class.
	/// </summary>
	public class CustomersDataSourceDesigner : ProviderDataSourceDesigner<Customers, CustomersKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomersDataSourceDesigner class.
		/// </summary>
		public CustomersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomersSelectMethod SelectMethod
		{
			get { return ((CustomersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomersDataSourceActionList

	/// <summary>
	/// Supports the CustomersDataSourceDesigner class.
	/// </summary>
	internal class CustomersDataSourceActionList : DesignerActionList
	{
		private CustomersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomersDataSourceActionList(CustomersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomersSelectMethod SelectMethod
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

	#endregion CustomersDataSourceActionList
	
	#endregion CustomersDataSourceDesigner
	
	#region CustomersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomersDataSource.SelectMethod property.
	/// </summary>
	public enum CustomersSelectMethod
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
		/// Represents the GetByGender method.
		/// </summary>
		GetByGender,
		/// <summary>
		/// Represents the GetByUserType method.
		/// </summary>
		GetByUserType
	}
	
	#endregion CustomersSelectMethod

	#region CustomersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersFilter : SqlFilter<CustomersColumn>
	{
	}
	
	#endregion CustomersFilter

	#region CustomersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersExpressionBuilder : SqlExpressionBuilder<CustomersColumn>
	{
	}
	
	#endregion CustomersExpressionBuilder	

	#region CustomersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersProperty : ChildEntityProperty<CustomersChildEntityTypes>
	{
	}
	
	#endregion CustomersProperty
}


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
	/// Represents the DataRepository.UserTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UserTypeDataSourceDesigner))]
	public class UserTypeDataSource : ProviderDataSource<UserType, UserTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeDataSource class.
		/// </summary>
		public UserTypeDataSource() : base(DataRepository.UserTypeProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UserTypeDataSourceView used by the UserTypeDataSource.
		/// </summary>
		protected UserTypeDataSourceView UserTypeView
		{
			get { return ( View as UserTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UserTypeDataSource control invokes to retrieve data.
		/// </summary>
		public UserTypeSelectMethod SelectMethod
		{
			get
			{
				UserTypeSelectMethod selectMethod = UserTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UserTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UserTypeDataSourceView class that is to be
		/// used by the UserTypeDataSource.
		/// </summary>
		/// <returns>An instance of the UserTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<UserType, UserTypeKey> GetNewDataSourceView()
		{
			return new UserTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the UserTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UserTypeDataSourceView : ProviderDataSourceView<UserType, UserTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UserTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UserTypeDataSourceView(UserTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UserTypeDataSource UserTypeOwner
		{
			get { return Owner as UserTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UserTypeSelectMethod SelectMethod
		{
			get { return UserTypeOwner.SelectMethod; }
			set { UserTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UserTypeProviderBase UserTypeProvider
		{
			get { return Provider as UserTypeProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<UserType> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<UserType> results = null;
			UserType item;
			count = 0;
			
			System.Int32 _id;

			switch ( SelectMethod )
			{
				case UserTypeSelectMethod.Get:
					UserTypeKey entityKey  = new UserTypeKey();
					entityKey.Load(values);
					item = UserTypeProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<UserType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UserTypeSelectMethod.GetAll:
                    results = UserTypeProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case UserTypeSelectMethod.GetPaged:
					results = UserTypeProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UserTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = UserTypeProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UserTypeProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UserTypeSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["Id"], typeof(System.Int32)) : (int)0;
					item = UserTypeProvider.GetById(GetTransactionManager(), _id);
					results = new TList<UserType>();
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
			if ( SelectMethod == UserTypeSelectMethod.Get || SelectMethod == UserTypeSelectMethod.GetById )
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
				UserType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					UserTypeProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<UserType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			UserTypeProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UserTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UserTypeDataSource class.
	/// </summary>
	public class UserTypeDataSourceDesigner : ProviderDataSourceDesigner<UserType, UserTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the UserTypeDataSourceDesigner class.
		/// </summary>
		public UserTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserTypeSelectMethod SelectMethod
		{
			get { return ((UserTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UserTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UserTypeDataSourceActionList

	/// <summary>
	/// Supports the UserTypeDataSourceDesigner class.
	/// </summary>
	internal class UserTypeDataSourceActionList : DesignerActionList
	{
		private UserTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UserTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UserTypeDataSourceActionList(UserTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserTypeSelectMethod SelectMethod
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

	#endregion UserTypeDataSourceActionList
	
	#endregion UserTypeDataSourceDesigner
	
	#region UserTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UserTypeDataSource.SelectMethod property.
	/// </summary>
	public enum UserTypeSelectMethod
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
	
	#endregion UserTypeSelectMethod

	#region UserTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeFilter : SqlFilter<UserTypeColumn>
	{
	}
	
	#endregion UserTypeFilter

	#region UserTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeExpressionBuilder : SqlExpressionBuilder<UserTypeColumn>
	{
	}
	
	#endregion UserTypeExpressionBuilder	

	#region UserTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UserTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeProperty : ChildEntityProperty<UserTypeChildEntityTypes>
	{
	}
	
	#endregion UserTypeProperty
}


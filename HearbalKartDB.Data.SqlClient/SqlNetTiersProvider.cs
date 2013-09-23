#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using HearbalKartDB.Data.Bases;

#endregion

namespace HearbalKartDB.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : HearbalKartDB.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "UserTypeProvider"
			
		private SqlUserTypeProvider innerSqlUserTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UserType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserTypeProviderBase UserTypeProvider
		{
			get
			{
				if (innerSqlUserTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserTypeProvider == null)
						{
							this.innerSqlUserTypeProvider = new SqlUserTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUserTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserTypeProvider SqlUserTypeProvider
		{
			get {return UserTypeProvider as SqlUserTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProdCompanyProvider"
			
		private SqlProdCompanyProvider innerSqlProdCompanyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdCompany"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdCompanyProviderBase ProdCompanyProvider
		{
			get
			{
				if (innerSqlProdCompanyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdCompanyProvider == null)
						{
							this.innerSqlProdCompanyProvider = new SqlProdCompanyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdCompanyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdCompanyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdCompanyProvider SqlProdCompanyProvider
		{
			get {return ProdCompanyProvider as SqlProdCompanyProvider;}
		}
		
		#endregion
		
		
		#region "ItemSellProvider"
			
		private SqlItemSellProvider innerSqlItemSellProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemSell"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemSellProviderBase ItemSellProvider
		{
			get
			{
				if (innerSqlItemSellProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemSellProvider == null)
						{
							this.innerSqlItemSellProvider = new SqlItemSellProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemSellProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlItemSellProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemSellProvider SqlItemSellProvider
		{
			get {return ItemSellProvider as SqlItemSellProvider;}
		}
		
		#endregion
		
		
		#region "ProdTableProvider"
			
		private SqlProdTableProvider innerSqlProdTableProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdTableProviderBase ProdTableProvider
		{
			get
			{
				if (innerSqlProdTableProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdTableProvider == null)
						{
							this.innerSqlProdTableProvider = new SqlProdTableProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdTableProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdTableProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdTableProvider SqlProdTableProvider
		{
			get {return ProdTableProvider as SqlProdTableProvider;}
		}
		
		#endregion
		
		
		#region "GenderProvider"
			
		private SqlGenderProvider innerSqlGenderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Gender"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GenderProviderBase GenderProvider
		{
			get
			{
				if (innerSqlGenderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGenderProvider == null)
						{
							this.innerSqlGenderProvider = new SqlGenderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGenderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlGenderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGenderProvider SqlGenderProvider
		{
			get {return GenderProvider as SqlGenderProvider;}
		}
		
		#endregion
		
		
		#region "ItemsProvider"
			
		private SqlItemsProvider innerSqlItemsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Items"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemsProviderBase ItemsProvider
		{
			get
			{
				if (innerSqlItemsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemsProvider == null)
						{
							this.innerSqlItemsProvider = new SqlItemsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlItemsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemsProvider SqlItemsProvider
		{
			get {return ItemsProvider as SqlItemsProvider;}
		}
		
		#endregion
		
		
		#region "DeliveredDaysProvider"
			
		private SqlDeliveredDaysProvider innerSqlDeliveredDaysProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DeliveredDays"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DeliveredDaysProviderBase DeliveredDaysProvider
		{
			get
			{
				if (innerSqlDeliveredDaysProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDeliveredDaysProvider == null)
						{
							this.innerSqlDeliveredDaysProvider = new SqlDeliveredDaysProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDeliveredDaysProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDeliveredDaysProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDeliveredDaysProvider SqlDeliveredDaysProvider
		{
			get {return DeliveredDaysProvider as SqlDeliveredDaysProvider;}
		}
		
		#endregion
		
		
		#region "CitiesProvider"
			
		private SqlCitiesProvider innerSqlCitiesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Cities"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CitiesProviderBase CitiesProvider
		{
			get
			{
				if (innerSqlCitiesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCitiesProvider == null)
						{
							this.innerSqlCitiesProvider = new SqlCitiesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCitiesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCitiesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCitiesProvider SqlCitiesProvider
		{
			get {return CitiesProvider as SqlCitiesProvider;}
		}
		
		#endregion
		
		
		#region "DistributarsProvider"
			
		private SqlDistributarsProvider innerSqlDistributarsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Distributars"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DistributarsProviderBase DistributarsProvider
		{
			get
			{
				if (innerSqlDistributarsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDistributarsProvider == null)
						{
							this.innerSqlDistributarsProvider = new SqlDistributarsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDistributarsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDistributarsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDistributarsProvider SqlDistributarsProvider
		{
			get {return DistributarsProvider as SqlDistributarsProvider;}
		}
		
		#endregion
		
		
		#region "CustomersProvider"
			
		private SqlCustomersProvider innerSqlCustomersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Customers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomersProviderBase CustomersProvider
		{
			get
			{
				if (innerSqlCustomersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomersProvider == null)
						{
							this.innerSqlCustomersProvider = new SqlCustomersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomersProvider SqlCustomersProvider
		{
			get {return CustomersProvider as SqlCustomersProvider;}
		}
		
		#endregion
		
		
		#region "ProdTypeProvider"
			
		private SqlProdTypeProvider innerSqlProdTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdTypeProviderBase ProdTypeProvider
		{
			get
			{
				if (innerSqlProdTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdTypeProvider == null)
						{
							this.innerSqlProdTypeProvider = new SqlProdTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdTypeProvider SqlProdTypeProvider
		{
			get {return ProdTypeProvider as SqlProdTypeProvider;}
		}
		
		#endregion
		
		
		#region "ProdCategoryProvider"
			
		private SqlProdCategoryProvider innerSqlProdCategoryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdCategoryProviderBase ProdCategoryProvider
		{
			get
			{
				if (innerSqlProdCategoryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdCategoryProvider == null)
						{
							this.innerSqlProdCategoryProvider = new SqlProdCategoryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdCategoryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdCategoryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdCategoryProvider SqlProdCategoryProvider
		{
			get {return ProdCategoryProvider as SqlProdCategoryProvider;}
		}
		
		#endregion
		
		
		#region "ProdMedicineForProvider"
			
		private SqlProdMedicineForProvider innerSqlProdMedicineForProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdMedicineFor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdMedicineForProviderBase ProdMedicineForProvider
		{
			get
			{
				if (innerSqlProdMedicineForProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdMedicineForProvider == null)
						{
							this.innerSqlProdMedicineForProvider = new SqlProdMedicineForProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdMedicineForProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdMedicineForProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdMedicineForProvider SqlProdMedicineForProvider
		{
			get {return ProdMedicineForProvider as SqlProdMedicineForProvider;}
		}
		
		#endregion
		
		
		#region "StatesProvider"
			
		private SqlStatesProvider innerSqlStatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="States"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override StatesProviderBase StatesProvider
		{
			get
			{
				if (innerSqlStatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlStatesProvider == null)
						{
							this.innerSqlStatesProvider = new SqlStatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlStatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlStatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlStatesProvider SqlStatesProvider
		{
			get {return StatesProvider as SqlStatesProvider;}
		}
		
		#endregion
		
		
		#region "ProdSupplymentTypeProvider"
			
		private SqlProdSupplymentTypeProvider innerSqlProdSupplymentTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdSupplymentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdSupplymentTypeProviderBase ProdSupplymentTypeProvider
		{
			get
			{
				if (innerSqlProdSupplymentTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdSupplymentTypeProvider == null)
						{
							this.innerSqlProdSupplymentTypeProvider = new SqlProdSupplymentTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdSupplymentTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdSupplymentTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdSupplymentTypeProvider SqlProdSupplymentTypeProvider
		{
			get {return ProdSupplymentTypeProvider as SqlProdSupplymentTypeProvider;}
		}
		
		#endregion
		
		
		#region "OrderStatusProvider"
			
		private SqlOrderStatusProvider innerSqlOrderStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderStatusProviderBase OrderStatusProvider
		{
			get
			{
				if (innerSqlOrderStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderStatusProvider == null)
						{
							this.innerSqlOrderStatusProvider = new SqlOrderStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrderStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderStatusProvider SqlOrderStatusProvider
		{
			get {return OrderStatusProvider as SqlOrderStatusProvider;}
		}
		
		#endregion
		
		
		#region "CountriesProvider"
			
		private SqlCountriesProvider innerSqlCountriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountriesProviderBase CountriesProvider
		{
			get
			{
				if (innerSqlCountriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountriesProvider == null)
						{
							this.innerSqlCountriesProvider = new SqlCountriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCountriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountriesProvider SqlCountriesProvider
		{
			get {return CountriesProvider as SqlCountriesProvider;}
		}
		
		#endregion
		
		
		#region "OrdersProvider"
			
		private SqlOrdersProvider innerSqlOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrdersProviderBase OrdersProvider
		{
			get
			{
				if (innerSqlOrdersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrdersProvider == null)
						{
							this.innerSqlOrdersProvider = new SqlOrdersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrdersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrdersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrdersProvider SqlOrdersProvider
		{
			get {return OrdersProvider as SqlOrdersProvider;}
		}
		
		#endregion
		
		
		#region "OrderDetailsProvider"
			
		private SqlOrderDetailsProvider innerSqlOrderDetailsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="OrderDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override OrderDetailsProviderBase OrderDetailsProvider
		{
			get
			{
				if (innerSqlOrderDetailsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlOrderDetailsProvider == null)
						{
							this.innerSqlOrderDetailsProvider = new SqlOrderDetailsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlOrderDetailsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlOrderDetailsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlOrderDetailsProvider SqlOrderDetailsProvider
		{
			get {return OrderDetailsProvider as SqlOrderDetailsProvider;}
		}
		
		#endregion
		
		
		#region "DistributorsOrdersProvider"
			
		private SqlDistributorsOrdersProvider innerSqlDistributorsOrdersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DistributorsOrders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DistributorsOrdersProviderBase DistributorsOrdersProvider
		{
			get
			{
				if (innerSqlDistributorsOrdersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDistributorsOrdersProvider == null)
						{
							this.innerSqlDistributorsOrdersProvider = new SqlDistributorsOrdersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDistributorsOrdersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDistributorsOrdersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDistributorsOrdersProvider SqlDistributorsOrdersProvider
		{
			get {return DistributorsOrdersProvider as SqlDistributorsOrdersProvider;}
		}
		
		#endregion
		
		
		#region "ItemPurchaseProvider"
			
		private SqlItemPurchaseProvider innerSqlItemPurchaseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ItemPurchase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ItemPurchaseProviderBase ItemPurchaseProvider
		{
			get
			{
				if (innerSqlItemPurchaseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlItemPurchaseProvider == null)
						{
							this.innerSqlItemPurchaseProvider = new SqlItemPurchaseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlItemPurchaseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlItemPurchaseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlItemPurchaseProvider SqlItemPurchaseProvider
		{
			get {return ItemPurchaseProvider as SqlItemPurchaseProvider;}
		}
		
		#endregion
		
		
		#region "ProdOfferProvider"
			
		private SqlProdOfferProvider innerSqlProdOfferProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ProdOffer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProdOfferProviderBase ProdOfferProvider
		{
			get
			{
				if (innerSqlProdOfferProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProdOfferProvider == null)
						{
							this.innerSqlProdOfferProvider = new SqlProdOfferProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProdOfferProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlProdOfferProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProdOfferProvider SqlProdOfferProvider
		{
			get {return ProdOfferProvider as SqlProdOfferProvider;}
		}
		
		#endregion
		
		
		#region "CustomerBillingProvider"
			
		private SqlCustomerBillingProvider innerSqlCustomerBillingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomerBilling"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomerBillingProviderBase CustomerBillingProvider
		{
			get
			{
				if (innerSqlCustomerBillingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomerBillingProvider == null)
						{
							this.innerSqlCustomerBillingProvider = new SqlCustomerBillingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomerBillingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlCustomerBillingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomerBillingProvider SqlCustomerBillingProvider
		{
			get {return CustomerBillingProvider as SqlCustomerBillingProvider;}
		}
		
		#endregion
		
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}

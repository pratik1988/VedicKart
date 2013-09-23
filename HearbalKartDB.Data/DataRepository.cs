#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using HearbalKartDB.Entities;
using HearbalKartDB.Data;
using HearbalKartDB.Data.Bases;

#endregion

namespace HearbalKartDB.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("HearbalKartDB.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region UserTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UserType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserTypeProviderBase UserTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserTypeProvider;
			}
		}
		
		#endregion
		
		#region ProdCompanyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdCompany"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdCompanyProviderBase ProdCompanyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdCompanyProvider;
			}
		}
		
		#endregion
		
		#region ItemSellProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemSell"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ItemSellProviderBase ItemSellProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemSellProvider;
			}
		}
		
		#endregion
		
		#region ProdTableProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdTableProviderBase ProdTableProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdTableProvider;
			}
		}
		
		#endregion
		
		#region GenderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Gender"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GenderProviderBase GenderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GenderProvider;
			}
		}
		
		#endregion
		
		#region ItemsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Items"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ItemsProviderBase ItemsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemsProvider;
			}
		}
		
		#endregion
		
		#region DeliveredDaysProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DeliveredDays"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DeliveredDaysProviderBase DeliveredDaysProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DeliveredDaysProvider;
			}
		}
		
		#endregion
		
		#region CitiesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Cities"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CitiesProviderBase CitiesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CitiesProvider;
			}
		}
		
		#endregion
		
		#region DistributarsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Distributars"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DistributarsProviderBase DistributarsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DistributarsProvider;
			}
		}
		
		#endregion
		
		#region CustomersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Customers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomersProviderBase CustomersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomersProvider;
			}
		}
		
		#endregion
		
		#region ProdTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdTypeProviderBase ProdTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdTypeProvider;
			}
		}
		
		#endregion
		
		#region ProdCategoryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdCategory"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdCategoryProviderBase ProdCategoryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdCategoryProvider;
			}
		}
		
		#endregion
		
		#region ProdMedicineForProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdMedicineFor"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdMedicineForProviderBase ProdMedicineForProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdMedicineForProvider;
			}
		}
		
		#endregion
		
		#region StatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="States"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static StatesProviderBase StatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.StatesProvider;
			}
		}
		
		#endregion
		
		#region ProdSupplymentTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdSupplymentType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdSupplymentTypeProviderBase ProdSupplymentTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdSupplymentTypeProvider;
			}
		}
		
		#endregion
		
		#region OrderStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderStatusProviderBase OrderStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderStatusProvider;
			}
		}
		
		#endregion
		
		#region CountriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountriesProviderBase CountriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountriesProvider;
			}
		}
		
		#endregion
		
		#region OrdersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Orders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrdersProviderBase OrdersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrdersProvider;
			}
		}
		
		#endregion
		
		#region OrderDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OrderDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OrderDetailsProviderBase OrderDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OrderDetailsProvider;
			}
		}
		
		#endregion
		
		#region DistributorsOrdersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DistributorsOrders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DistributorsOrdersProviderBase DistributorsOrdersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DistributorsOrdersProvider;
			}
		}
		
		#endregion
		
		#region ItemPurchaseProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ItemPurchase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ItemPurchaseProviderBase ItemPurchaseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ItemPurchaseProvider;
			}
		}
		
		#endregion
		
		#region ProdOfferProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ProdOffer"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProdOfferProviderBase ProdOfferProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProdOfferProvider;
			}
		}
		
		#endregion
		
		#region CustomerBillingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerBilling"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerBillingProviderBase CustomerBillingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerBillingProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region UserTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeFilters : UserTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		public UserTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserTypeFilters
	
	#region UserTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="UserType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserTypeQuery : UserTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		public UserTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserTypeQuery
		
	#region ProdCompanyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCompany"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCompanyFilters : ProdCompanyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCompanyFilters class.
		/// </summary>
		public ProdCompanyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCompanyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCompanyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCompanyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCompanyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCompanyFilters
	
	#region ProdCompanyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdCompanyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdCompany"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCompanyQuery : ProdCompanyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCompanyQuery class.
		/// </summary>
		public ProdCompanyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCompanyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCompanyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCompanyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCompanyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCompanyQuery
		
	#region ItemSellFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellFilters : ItemSellFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellFilters class.
		/// </summary>
		public ItemSellFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemSellFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemSellFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemSellFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemSellFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemSellFilters
	
	#region ItemSellQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ItemSellParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ItemSell"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemSellQuery : ItemSellParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemSellQuery class.
		/// </summary>
		public ItemSellQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemSellQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemSellQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemSellQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemSellQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemSellQuery
		
	#region ProdTableFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableFilters : ProdTableFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableFilters class.
		/// </summary>
		public ProdTableFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTableFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTableFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTableFilters
	
	#region ProdTableQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdTableParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTableQuery : ProdTableParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTableQuery class.
		/// </summary>
		public ProdTableQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTableQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTableQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTableQuery
		
	#region GenderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderFilters : GenderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderFilters class.
		/// </summary>
		public GenderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GenderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GenderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GenderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GenderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GenderFilters
	
	#region GenderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GenderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Gender"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GenderQuery : GenderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GenderQuery class.
		/// </summary>
		public GenderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GenderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GenderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GenderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GenderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GenderQuery
		
	#region ItemsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsFilters : ItemsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsFilters class.
		/// </summary>
		public ItemsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemsFilters
	
	#region ItemsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ItemsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Items"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemsQuery : ItemsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemsQuery class.
		/// </summary>
		public ItemsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemsQuery
		
	#region DeliveredDaysFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysFilters : DeliveredDaysFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilters class.
		/// </summary>
		public DeliveredDaysFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DeliveredDaysFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DeliveredDaysFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DeliveredDaysFilters
	
	#region DeliveredDaysQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DeliveredDaysParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DeliveredDays"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DeliveredDaysQuery : DeliveredDaysParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysQuery class.
		/// </summary>
		public DeliveredDaysQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DeliveredDaysQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DeliveredDaysQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DeliveredDaysQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DeliveredDaysQuery
		
	#region CitiesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesFilters : CitiesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesFilters class.
		/// </summary>
		public CitiesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CitiesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CitiesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CitiesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CitiesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CitiesFilters
	
	#region CitiesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CitiesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Cities"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CitiesQuery : CitiesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CitiesQuery class.
		/// </summary>
		public CitiesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CitiesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CitiesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CitiesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CitiesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CitiesQuery
		
	#region DistributarsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsFilters : DistributarsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsFilters class.
		/// </summary>
		public DistributarsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributarsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributarsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributarsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributarsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributarsFilters
	
	#region DistributarsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DistributarsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Distributars"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributarsQuery : DistributarsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributarsQuery class.
		/// </summary>
		public DistributarsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributarsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributarsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributarsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributarsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributarsQuery
		
	#region CustomersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersFilters : CustomersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		public CustomersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersFilters
	
	#region CustomersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Customers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomersQuery : CustomersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		public CustomersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomersQuery
		
	#region ProdTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTypeFilters : ProdTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTypeFilters class.
		/// </summary>
		public ProdTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTypeFilters
	
	#region ProdTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdTypeQuery : ProdTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdTypeQuery class.
		/// </summary>
		public ProdTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdTypeQuery
		
	#region ProdCategoryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryFilters : ProdCategoryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilters class.
		/// </summary>
		public ProdCategoryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryFilters
	
	#region ProdCategoryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdCategoryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdCategory"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdCategoryQuery : ProdCategoryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdCategoryQuery class.
		/// </summary>
		public ProdCategoryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdCategoryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdCategoryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdCategoryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdCategoryQuery
		
	#region ProdMedicineForFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdMedicineFor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdMedicineForFilters : ProdMedicineForFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForFilters class.
		/// </summary>
		public ProdMedicineForFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdMedicineForFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdMedicineForFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdMedicineForFilters
	
	#region ProdMedicineForQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdMedicineForParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdMedicineFor"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdMedicineForQuery : ProdMedicineForParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForQuery class.
		/// </summary>
		public ProdMedicineForQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdMedicineForQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdMedicineForQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdMedicineForQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdMedicineForQuery
		
	#region StatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesFilters : StatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesFilters class.
		/// </summary>
		public StatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the StatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StatesFilters
	
	#region StatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="StatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="States"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class StatesQuery : StatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StatesQuery class.
		/// </summary>
		public StatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the StatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public StatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the StatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public StatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion StatesQuery
		
	#region ProdSupplymentTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdSupplymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdSupplymentTypeFilters : ProdSupplymentTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeFilters class.
		/// </summary>
		public ProdSupplymentTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdSupplymentTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdSupplymentTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdSupplymentTypeFilters
	
	#region ProdSupplymentTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdSupplymentTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdSupplymentType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdSupplymentTypeQuery : ProdSupplymentTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeQuery class.
		/// </summary>
		public ProdSupplymentTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdSupplymentTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdSupplymentTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdSupplymentTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdSupplymentTypeQuery
		
	#region OrderStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusFilters : OrderStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		public OrderStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusFilters
	
	#region OrderStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderStatusQuery : OrderStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		public OrderStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderStatusQuery
		
	#region CountriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilters : CountriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		public CountriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesFilters
	
	#region CountriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesQuery : CountriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		public CountriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesQuery
		
	#region OrdersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilters : OrdersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		public OrdersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersFilters
	
	#region OrdersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrdersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersQuery : OrdersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		public OrdersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersQuery
		
	#region OrderDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsFilters : OrderDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		public OrderDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsFilters
	
	#region OrderDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OrderDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OrderDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrderDetailsQuery : OrderDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		public OrderDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrderDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrderDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrderDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrderDetailsQuery
		
	#region DistributorsOrdersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersFilters : DistributorsOrdersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilters class.
		/// </summary>
		public DistributorsOrdersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributorsOrdersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributorsOrdersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributorsOrdersFilters
	
	#region DistributorsOrdersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DistributorsOrdersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DistributorsOrders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DistributorsOrdersQuery : DistributorsOrdersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersQuery class.
		/// </summary>
		public DistributorsOrdersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DistributorsOrdersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DistributorsOrdersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DistributorsOrdersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DistributorsOrdersQuery
		
	#region ItemPurchaseFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ItemPurchase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemPurchaseFilters : ItemPurchaseFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseFilters class.
		/// </summary>
		public ItemPurchaseFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemPurchaseFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemPurchaseFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemPurchaseFilters
	
	#region ItemPurchaseQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ItemPurchaseParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ItemPurchase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ItemPurchaseQuery : ItemPurchaseParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseQuery class.
		/// </summary>
		public ItemPurchaseQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ItemPurchaseQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ItemPurchaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ItemPurchaseQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ItemPurchaseQuery
		
	#region ProdOfferFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferFilters : ProdOfferFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilters class.
		/// </summary>
		public ProdOfferFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdOfferFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdOfferFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdOfferFilters
	
	#region ProdOfferQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProdOfferParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ProdOffer"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProdOfferQuery : ProdOfferParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProdOfferQuery class.
		/// </summary>
		public ProdOfferQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProdOfferQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProdOfferQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProdOfferQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProdOfferQuery
		
	#region CustomerBillingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingFilters : CustomerBillingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilters class.
		/// </summary>
		public CustomerBillingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerBillingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerBillingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerBillingFilters
	
	#region CustomerBillingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerBillingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerBilling"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerBillingQuery : CustomerBillingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerBillingQuery class.
		/// </summary>
		public CustomerBillingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerBillingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerBillingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerBillingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerBillingQuery
	#endregion

	
}

#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using HearbalKartDB.Entities;

#endregion

namespace HearbalKartDB.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current UserTypeProviderBase instance.
		///</summary>
		public virtual UserTypeProviderBase UserTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdCompanyProviderBase instance.
		///</summary>
		public virtual ProdCompanyProviderBase ProdCompanyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemSellProviderBase instance.
		///</summary>
		public virtual ItemSellProviderBase ItemSellProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdTableProviderBase instance.
		///</summary>
		public virtual ProdTableProviderBase ProdTableProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current GenderProviderBase instance.
		///</summary>
		public virtual GenderProviderBase GenderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemsProviderBase instance.
		///</summary>
		public virtual ItemsProviderBase ItemsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DeliveredDaysProviderBase instance.
		///</summary>
		public virtual DeliveredDaysProviderBase DeliveredDaysProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CitiesProviderBase instance.
		///</summary>
		public virtual CitiesProviderBase CitiesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DistributarsProviderBase instance.
		///</summary>
		public virtual DistributarsProviderBase DistributarsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomersProviderBase instance.
		///</summary>
		public virtual CustomersProviderBase CustomersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdTypeProviderBase instance.
		///</summary>
		public virtual ProdTypeProviderBase ProdTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdCategoryProviderBase instance.
		///</summary>
		public virtual ProdCategoryProviderBase ProdCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdMedicineForProviderBase instance.
		///</summary>
		public virtual ProdMedicineForProviderBase ProdMedicineForProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StatesProviderBase instance.
		///</summary>
		public virtual StatesProviderBase StatesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdSupplymentTypeProviderBase instance.
		///</summary>
		public virtual ProdSupplymentTypeProviderBase ProdSupplymentTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderStatusProviderBase instance.
		///</summary>
		public virtual OrderStatusProviderBase OrderStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountriesProviderBase instance.
		///</summary>
		public virtual CountriesProviderBase CountriesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrdersProviderBase instance.
		///</summary>
		public virtual OrdersProviderBase OrdersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderDetailsProviderBase instance.
		///</summary>
		public virtual OrderDetailsProviderBase OrderDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DistributorsOrdersProviderBase instance.
		///</summary>
		public virtual DistributorsOrdersProviderBase DistributorsOrdersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemPurchaseProviderBase instance.
		///</summary>
		public virtual ItemPurchaseProviderBase ItemPurchaseProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProdOfferProviderBase instance.
		///</summary>
		public virtual ProdOfferProviderBase ProdOfferProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerBillingProviderBase instance.
		///</summary>
		public virtual CustomerBillingProviderBase CustomerBillingProvider{get {throw new NotImplementedException();}}
		
		
	}
}

﻿using System;
using System.ComponentModel;

namespace HearbalKartDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'Orders' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IOrders 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Orders"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// CustomerID : 
		/// </summary>
		System.Int32?  CustomerId  { get; set; }
		
		/// <summary>
		/// OrderStatusID : 
		/// </summary>
		System.Int32?  OrderStatusId  { get; set; }
		
		/// <summary>
		/// BillingID : 
		/// </summary>
		System.Int32?  BillingId  { get; set; }
		
		/// <summary>
		/// TotalAmount : 
		/// </summary>
		System.Int64?  TotalAmount  { get; set; }
		
		/// <summary>
		/// SurveyID : 
		/// </summary>
		System.Int32?  SurveyId  { get; set; }
		
		/// <summary>
		/// ISActive : 
		/// </summary>
		System.Boolean?  IsActive  { get; set; }
		
		/// <summary>
		/// ISDeliver : 
		/// </summary>
		System.Boolean?  IsDeliver  { get; set; }
		
		/// <summary>
		/// IsSurveyDone : 
		/// </summary>
		System.Boolean?  IsSurveyDone  { get; set; }
		
		/// <summary>
		/// BookingDate : 
		/// </summary>
		System.DateTime?  BookingDate  { get; set; }
		
		/// <summary>
		/// CreatedDate : 
		/// </summary>
		System.DateTime?  CreatedDate  { get; set; }
		
		/// <summary>
		/// ModifiedDate : 
		/// </summary>
		System.DateTime?  ModifiedDate  { get; set; }
		
		/// <summary>
		/// DeletedDate : 
		/// </summary>
		System.DateTime?  DeletedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _customerBillingOrderId
		/// </summary>	
		TList<CustomerBilling> CustomerBillingCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _orderDetailsOrderId
		/// </summary>	
		TList<OrderDetails> OrderDetailsCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _distributorsOrdersOrderId
		/// </summary>	
		TList<DistributorsOrders> DistributorsOrdersCollection {  get;  set;}	

		#endregion Data Properties

	}
}



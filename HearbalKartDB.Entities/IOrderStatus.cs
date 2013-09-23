﻿using System;
using System.ComponentModel;

namespace HearbalKartDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'OrderStatus' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IOrderStatus 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "OrderStatus"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// ISActive : 
		/// </summary>
		System.Boolean?  IsActive  { get; set; }
		
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
		///	which are related to this object through the relation _ordersOrderStatusId
		/// </summary>	
		TList<Orders> OrdersCollection {  get;  set;}	

		#endregion Data Properties

	}
}



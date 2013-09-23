﻿using System;
using System.ComponentModel;

namespace HearbalKartDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'Distributars' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDistributars 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Distributars"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// FirstName : 
		/// </summary>
		System.String  FirstName  { get; set; }
		
		/// <summary>
		/// LastName : 
		/// </summary>
		System.String  LastName  { get; set; }
		
		/// <summary>
		/// Address : 
		/// </summary>
		System.String  Address  { get; set; }
		
		/// <summary>
		/// StateID : 
		/// </summary>
		System.Int32?  StateId  { get; set; }
		
		/// <summary>
		/// CityID : 
		/// </summary>
		System.Int32?  CityId  { get; set; }
		
		/// <summary>
		/// CountryID : 
		/// </summary>
		System.Int32?  CountryId  { get; set; }
		
		/// <summary>
		/// Pin : 
		/// </summary>
		System.Int64?  Pin  { get; set; }
		
		/// <summary>
		/// DaliveredDaysID : 
		/// </summary>
		System.Int32?  DaliveredDaysId  { get; set; }
		
		/// <summary>
		/// Description : 
		/// </summary>
		System.String  Description  { get; set; }
		
		/// <summary>
		/// MobileNo : 
		/// </summary>
		System.Int64?  MobileNo  { get; set; }
		
		/// <summary>
		/// LandNo : 
		/// </summary>
		System.Int64?  LandNo  { get; set; }
		
		/// <summary>
		/// IsActive : 
		/// </summary>
		System.Boolean?  IsActive  { get; set; }
		
		/// <summary>
		/// CreatedDate : 
		/// </summary>
		System.DateTime?  CreatedDate  { get; set; }
		
		/// <summary>
		/// DeletedDate : 
		/// </summary>
		System.DateTime?  DeletedDate  { get; set; }
		
		/// <summary>
		/// ModifiedDate : 
		/// </summary>
		System.DateTime?  ModifiedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _distributorsOrdersDistributorId
		/// </summary>	
		TList<DistributorsOrders> DistributorsOrdersCollection {  get;  set;}	

		#endregion Data Properties

	}
}



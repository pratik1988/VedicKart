﻿using System;
using System.ComponentModel;

namespace HearbalKartDB.Entities
{
	/// <summary>
	///		The data structure representation of the 'ProdSubcategory' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProdSubcategory 
	{
		/// <summary>			
		/// Id : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProdSubcategory"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// CategoryID : 
		/// </summary>
		System.Int32?  CategoryId  { get; set; }
		
		/// <summary>
		/// SubCategoryName : 
		/// </summary>
		System.String  SubCategoryName  { get; set; }
		
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
		///	which are related to this object through the relation _prodCategoryMappingSubCategoryId
		/// </summary>	
		TList<ProdCategoryMapping> ProdCategoryMappingCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _prodTableCategoryId
		/// </summary>	
		TList<ProdTable> ProdTableCollection {  get;  set;}	

		#endregion Data Properties

	}
}


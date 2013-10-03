
USE [HearbalKartDB]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdMedicineFor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdMedicineFor]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdMedicineFor table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdMedicineFor]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdMedicineFor] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdMedicineFor]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdMedicineFor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdMedicineFor]
					(
					[Name]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdMedicineFor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdMedicineFor]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdMedicineFor table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdMedicineFor] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdMedicineFor table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdMedicineFor]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdMedicineFor_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdMedicineFor_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdMedicineFor_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdMedicineFor table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdMedicineFor_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdMedicineFor]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdMedicineFor]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the States table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_Get_List

AS


				
				SELECT
					[ID],
					[CountryID],
					[Name],
					[Pin],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[PinCode]
				FROM
					[dbo].[States]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the States table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[States]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[CountryID], O.[Name], O.[Pin], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate], O.[PinCode]
				FROM
				    [dbo].[States] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[States]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the States table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_Insert
(

	@Id int    OUTPUT,

	@CountryId int   ,

	@Name nvarchar (MAX)  ,

	@Pin bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   ,

	@PinCode nvarchar (MAX)  
)
AS


				
				INSERT INTO [dbo].[States]
					(
					[CountryID]
					,[Name]
					,[Pin]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					,[PinCode]
					)
				VALUES
					(
					@CountryId
					,@Name
					,@Pin
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					,@PinCode
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the States table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_Update
(

	@Id int   ,

	@CountryId int   ,

	@Name nvarchar (MAX)  ,

	@Pin bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   ,

	@PinCode nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[States]
				SET
					[CountryID] = @CountryId
					,[Name] = @Name
					,[Pin] = @Pin
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
					,[PinCode] = @PinCode
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the States table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[States] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_GetByCountryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_GetByCountryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_GetByCountryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the States table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_GetByCountryId
(

	@CountryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[CountryID],
					[Name],
					[Pin],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[PinCode]
				FROM
					[dbo].[States]
				WHERE
					[CountryID] = @CountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the States table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[CountryID],
					[Name],
					[Pin],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[PinCode]
				FROM
					[dbo].[States]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.States_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.States_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.States_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the States table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.States_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@CountryId int   = null ,

	@Name nvarchar (MAX)  = null ,

	@Pin bigint   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null ,

	@PinCode nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [CountryID]
	, [Name]
	, [Pin]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
	, [PinCode]
    FROM
	[dbo].[States]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([CountryID] = @CountryId OR @CountryId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Pin] = @Pin OR @Pin IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
	AND ([PinCode] = @PinCode OR @PinCode IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [CountryID]
	, [Name]
	, [Pin]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
	, [PinCode]
    FROM
	[dbo].[States]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([CountryID] = @CountryId AND @CountryId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Pin] = @Pin AND @Pin is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	OR ([PinCode] = @PinCode AND @PinCode is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdCompany table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_Get_List

AS


				
				SELECT
					[ID],
					[CompanyName],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCompany]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdCompany table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCompany]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[CompanyName], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdCompany] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCompany]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdCompany table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_Insert
(

	@Id int    OUTPUT,

	@CompanyName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdCompany]
					(
					[CompanyName]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@CompanyName
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdCompany table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_Update
(

	@Id int   ,

	@CompanyName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdCompany]
				SET
					[CompanyName] = @CompanyName
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdCompany table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdCompany] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdCompany table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[CompanyName],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCompany]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCompany_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCompany_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCompany_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdCompany table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCompany_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@CompanyName nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [CompanyName]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCompany]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [CompanyName]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCompany]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdOffer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_Get_List

AS


				
				SELECT
					[ID],
					[OfferPercent],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdOffer]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdOffer table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdOffer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[OfferPercent], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdOffer] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdOffer]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdOffer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_Insert
(

	@Id int    OUTPUT,

	@OfferPercent decimal (18, 0)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdOffer]
					(
					[OfferPercent]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@OfferPercent
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdOffer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_Update
(

	@Id int   ,

	@OfferPercent decimal (18, 0)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdOffer]
				SET
					[OfferPercent] = @OfferPercent
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdOffer table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdOffer] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdOffer table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[OfferPercent],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdOffer]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdOffer_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdOffer_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdOffer_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdOffer table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdOffer_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@OfferPercent decimal (18, 0)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [OfferPercent]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdOffer]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([OfferPercent] = @OfferPercent OR @OfferPercent IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [OfferPercent]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdOffer]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([OfferPercent] = @OfferPercent AND @OfferPercent is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_Get_List

AS


				
				SELECT
					[Id],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategory]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdCategory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([Id])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [Id]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[Id], O.[Name], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdCategory] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[Id] = PageIndex.[Id]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdCategory]
					(
					[Name]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdCategory]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdCategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdCategory] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdCategory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategory]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategory_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdCategory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategory_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCategory]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCategory]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdSubcategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_Get_List

AS


				
				SELECT
					[Id],
					[CategoryID],
					[SubCategoryName],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdSubcategory]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdSubcategory table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([Id])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [Id]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdSubcategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[Id], O.[CategoryID], O.[SubCategoryName], O.[ISActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdSubcategory] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[Id] = PageIndex.[Id]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdSubcategory]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdSubcategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_Insert
(

	@Id int    OUTPUT,

	@CategoryId int   ,

	@SubCategoryName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdSubcategory]
					(
					[CategoryID]
					,[SubCategoryName]
					,[ISActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@CategoryId
					,@SubCategoryName
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdSubcategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_Update
(

	@Id int   ,

	@CategoryId int   ,

	@SubCategoryName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdSubcategory]
				SET
					[CategoryID] = @CategoryId
					,[SubCategoryName] = @SubCategoryName
					,[ISActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdSubcategory table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdSubcategory] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdSubcategory table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[CategoryID],
					[SubCategoryName],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdSubcategory]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSubcategory_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSubcategory_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSubcategory_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdSubcategory table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSubcategory_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@CategoryId int   = null ,

	@SubCategoryName nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [CategoryID]
	, [SubCategoryName]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdSubcategory]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([CategoryID] = @CategoryId OR @CategoryId IS NULL)
	AND ([SubCategoryName] = @SubCategoryName OR @SubCategoryName IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [CategoryID]
	, [SubCategoryName]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdSubcategory]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([CategoryID] = @CategoryId AND @CategoryId is not null)
	OR ([SubCategoryName] = @SubCategoryName AND @SubCategoryName is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdSupplymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdSupplymentType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdSupplymentType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdSupplymentType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdSupplymentType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdSupplymentType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdSupplymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdSupplymentType]
					(
					[Name]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdSupplymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdSupplymentType]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdSupplymentType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdSupplymentType] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdSupplymentType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdSupplymentType]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdSupplymentType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdSupplymentType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdSupplymentType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdSupplymentType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdSupplymentType_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdSupplymentType]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdSupplymentType]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[Deleteddate]
				FROM
					[dbo].[Countries]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Countries table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Countries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[Deleteddate]
				FROM
				    [dbo].[Countries] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Countries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@Deleteddate datetime   
)
AS


				
				INSERT INTO [dbo].[Countries]
					(
					[Name]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[Deleteddate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@Deleteddate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@Deleteddate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Countries]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[Deleteddate] = @Deleteddate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Countries] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Countries table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[Deleteddate]
				FROM
					[dbo].[Countries]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Countries table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@Deleteddate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [Deleteddate]
    FROM
	[dbo].[Countries]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([Deleteddate] = @Deleteddate OR @Deleteddate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [Deleteddate]
    FROM
	[dbo].[Countries]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([Deleteddate] = @Deleteddate AND @Deleteddate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdCategoryMapping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_Get_List

AS


				
				SELECT
					[Id],
					[CategoryID],
					[SubCategoryID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategoryMapping]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdCategoryMapping table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [Id] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([Id])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [Id]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCategoryMapping]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[Id], O.[CategoryID], O.[SubCategoryID], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdCategoryMapping] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[Id] = PageIndex.[Id]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdCategoryMapping]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdCategoryMapping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_Insert
(

	@Id int    OUTPUT,

	@CategoryId int   ,

	@SubCategoryId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdCategoryMapping]
					(
					[CategoryID]
					,[SubCategoryID]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@CategoryId
					,@SubCategoryId
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdCategoryMapping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_Update
(

	@Id int   ,

	@CategoryId int   ,

	@SubCategoryId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdCategoryMapping]
				SET
					[CategoryID] = @CategoryId
					,[SubCategoryID] = @SubCategoryId
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[Id] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdCategoryMapping table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdCategoryMapping] WITH (ROWLOCK) 
				WHERE
					[Id] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdCategoryMapping table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_GetByCategoryId
(

	@CategoryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[CategoryID],
					[SubCategoryID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategoryMapping]
				WHERE
					[CategoryID] = @CategoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_GetBySubCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_GetBySubCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_GetBySubCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdCategoryMapping table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_GetBySubCategoryId
(

	@SubCategoryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[Id],
					[CategoryID],
					[SubCategoryID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategoryMapping]
				WHERE
					[SubCategoryID] = @SubCategoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdCategoryMapping table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_GetById
(

	@Id int   
)
AS


				SELECT
					[Id],
					[CategoryID],
					[SubCategoryID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdCategoryMapping]
				WHERE
					[Id] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdCategoryMapping_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdCategoryMapping_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdCategoryMapping_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdCategoryMapping table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdCategoryMapping_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@CategoryId int   = null ,

	@SubCategoryId int   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [Id]
	, [CategoryID]
	, [SubCategoryID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCategoryMapping]
    WHERE 
	 ([Id] = @Id OR @Id IS NULL)
	AND ([CategoryID] = @CategoryId OR @CategoryId IS NULL)
	AND ([SubCategoryID] = @SubCategoryId OR @SubCategoryId IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [Id]
	, [CategoryID]
	, [SubCategoryID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdCategoryMapping]
    WHERE 
	 ([Id] = @Id AND @Id is not null)
	OR ([CategoryID] = @CategoryId AND @CategoryId is not null)
	OR ([SubCategoryID] = @SubCategoryId AND @SubCategoryId is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ProdType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ProdType]
					(
					[Name]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdType]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdType] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ProdType]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdType_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdType]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ProdType]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ProdTable table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_Get_List

AS


				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ProdTable table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ProdTable]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[ItemID], O.[CategoryID], O.[CompanyID], O.[TypeID], O.[SupplementID], O.[MedicineForID], O.[PurchaseID], O.[SellID], O.[OfferID], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate], O.[ImageUrl]
				FROM
				    [dbo].[ProdTable] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ProdTable]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ProdTable table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_Insert
(

	@Id int    OUTPUT,

	@ItemId int   ,

	@CategoryId int   ,

	@CompanyId int   ,

	@TypeId int   ,

	@SupplementId int   ,

	@MedicineForId int   ,

	@PurchaseId int   ,

	@SellId int   ,

	@OfferId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   ,

	@ImageUrl nvarchar (MAX)  
)
AS


				
				INSERT INTO [dbo].[ProdTable]
					(
					[ItemID]
					,[CategoryID]
					,[CompanyID]
					,[TypeID]
					,[SupplementID]
					,[MedicineForID]
					,[PurchaseID]
					,[SellID]
					,[OfferID]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					,[ImageUrl]
					)
				VALUES
					(
					@ItemId
					,@CategoryId
					,@CompanyId
					,@TypeId
					,@SupplementId
					,@MedicineForId
					,@PurchaseId
					,@SellId
					,@OfferId
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					,@ImageUrl
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ProdTable table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_Update
(

	@Id int   ,

	@ItemId int   ,

	@CategoryId int   ,

	@CompanyId int   ,

	@TypeId int   ,

	@SupplementId int   ,

	@MedicineForId int   ,

	@PurchaseId int   ,

	@SellId int   ,

	@OfferId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   ,

	@ImageUrl nvarchar (MAX)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ProdTable]
				SET
					[ItemID] = @ItemId
					,[CategoryID] = @CategoryId
					,[CompanyID] = @CompanyId
					,[TypeID] = @TypeId
					,[SupplementID] = @SupplementId
					,[MedicineForID] = @MedicineForId
					,[PurchaseID] = @PurchaseId
					,[SellID] = @SellId
					,[OfferID] = @OfferId
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
					,[ImageUrl] = @ImageUrl
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ProdTable table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ProdTable] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByPurchaseId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByPurchaseId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByPurchaseId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByPurchaseId
(

	@PurchaseId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[PurchaseID] = @PurchaseId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByItemId
(

	@ItemId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[ItemID] = @ItemId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetBySellId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetBySellId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetBySellId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetBySellId
(

	@SellId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[SellID] = @SellId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByCompanyId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByCompanyId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByCompanyId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByCompanyId
(

	@CompanyId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[CompanyID] = @CompanyId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByMedicineForId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByMedicineForId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByMedicineForId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByMedicineForId
(

	@MedicineForId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[MedicineForID] = @MedicineForId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByCategoryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByCategoryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByCategoryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByCategoryId
(

	@CategoryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[CategoryID] = @CategoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetBySupplementId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetBySupplementId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetBySupplementId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetBySupplementId
(

	@SupplementId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[SupplementID] = @SupplementId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetByTypeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetByTypeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetByTypeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetByTypeId
(

	@TypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[TypeID] = @TypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ProdTable table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[ItemID],
					[CategoryID],
					[CompanyID],
					[TypeID],
					[SupplementID],
					[MedicineForID],
					[PurchaseID],
					[SellID],
					[OfferID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate],
					[ImageUrl]
				FROM
					[dbo].[ProdTable]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ProdTable_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ProdTable_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ProdTable_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ProdTable table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ProdTable_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@ItemId int   = null ,

	@CategoryId int   = null ,

	@CompanyId int   = null ,

	@TypeId int   = null ,

	@SupplementId int   = null ,

	@MedicineForId int   = null ,

	@PurchaseId int   = null ,

	@SellId int   = null ,

	@OfferId int   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null ,

	@ImageUrl nvarchar (MAX)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [CategoryID]
	, [CompanyID]
	, [TypeID]
	, [SupplementID]
	, [MedicineForID]
	, [PurchaseID]
	, [SellID]
	, [OfferID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
	, [ImageUrl]
    FROM
	[dbo].[ProdTable]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([ItemID] = @ItemId OR @ItemId IS NULL)
	AND ([CategoryID] = @CategoryId OR @CategoryId IS NULL)
	AND ([CompanyID] = @CompanyId OR @CompanyId IS NULL)
	AND ([TypeID] = @TypeId OR @TypeId IS NULL)
	AND ([SupplementID] = @SupplementId OR @SupplementId IS NULL)
	AND ([MedicineForID] = @MedicineForId OR @MedicineForId IS NULL)
	AND ([PurchaseID] = @PurchaseId OR @PurchaseId IS NULL)
	AND ([SellID] = @SellId OR @SellId IS NULL)
	AND ([OfferID] = @OfferId OR @OfferId IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
	AND ([ImageUrl] = @ImageUrl OR @ImageUrl IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [CategoryID]
	, [CompanyID]
	, [TypeID]
	, [SupplementID]
	, [MedicineForID]
	, [PurchaseID]
	, [SellID]
	, [OfferID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
	, [ImageUrl]
    FROM
	[dbo].[ProdTable]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([ItemID] = @ItemId AND @ItemId is not null)
	OR ([CategoryID] = @CategoryId AND @CategoryId is not null)
	OR ([CompanyID] = @CompanyId AND @CompanyId is not null)
	OR ([TypeID] = @TypeId AND @TypeId is not null)
	OR ([SupplementID] = @SupplementId AND @SupplementId is not null)
	OR ([MedicineForID] = @MedicineForId AND @MedicineForId is not null)
	OR ([PurchaseID] = @PurchaseId AND @PurchaseId is not null)
	OR ([SellID] = @SellId AND @SellId is not null)
	OR ([OfferID] = @OfferId AND @OfferId is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	OR ([ImageUrl] = @ImageUrl AND @ImageUrl is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderStatus]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the OrderStatus table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[ISActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[OrderStatus] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[OrderStatus]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[OrderStatus]
					(
					[Name]
					,[ISActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[OrderStatus]
				SET
					[Name] = @Name
					,[ISActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the OrderStatus table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[OrderStatus] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OrderStatus table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderStatus]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderStatus_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderStatus_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderStatus_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the OrderStatus table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderStatus_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[OrderStatus]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[OrderStatus]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Cities table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[StateID],
					[Pin],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Cities]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Cities table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Cities]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[IsActive], O.[StateID], O.[Pin], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[Cities] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Cities]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Cities table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@StateId int   ,

	@Pin bigint   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Cities]
					(
					[Name]
					,[IsActive]
					,[StateID]
					,[Pin]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@IsActive
					,@StateId
					,@Pin
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Cities table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@IsActive bit   ,

	@StateId int   ,

	@Pin bigint   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Cities]
				SET
					[Name] = @Name
					,[IsActive] = @IsActive
					,[StateID] = @StateId
					,[Pin] = @Pin
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Cities table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Cities] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_GetByStateId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_GetByStateId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_GetByStateId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Cities table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_GetByStateId
(

	@StateId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[IsActive],
					[StateID],
					[Pin],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Cities]
				WHERE
					[StateID] = @StateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Cities table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[IsActive],
					[StateID],
					[Pin],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Cities]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Cities_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Cities_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Cities_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Cities table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Cities_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@StateId int   = null ,

	@Pin bigint   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [StateID]
	, [Pin]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Cities]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([StateID] = @StateId OR @StateId IS NULL)
	AND ([Pin] = @Pin OR @Pin IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [IsActive]
	, [StateID]
	, [Pin]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Cities]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([StateID] = @StateId AND @StateId is not null)
	OR ([Pin] = @Pin AND @Pin is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Gender table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_Get_List

AS


				
				SELECT
					[ID],
					[GName],
					[ISActive],
					[CreatedDAte],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Gender]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Gender table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Gender]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[GName], O.[ISActive], O.[CreatedDAte], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[Gender] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Gender]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Gender table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_Insert
(

	@Id int    OUTPUT,

	@Gname nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Gender]
					(
					[GName]
					,[ISActive]
					,[CreatedDAte]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Gname
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Gender table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_Update
(

	@Id int   ,

	@Gname nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Gender]
				SET
					[GName] = @Gname
					,[ISActive] = @IsActive
					,[CreatedDAte] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Gender table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Gender] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Gender table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[GName],
					[ISActive],
					[CreatedDAte],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Gender]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Gender_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Gender_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Gender_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Gender table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Gender_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Gname nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [GName]
	, [ISActive]
	, [CreatedDAte]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Gender]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([GName] = @Gname OR @Gname IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDAte] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [GName]
	, [ISActive]
	, [CreatedDAte]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Gender]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([GName] = @Gname AND @Gname is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDAte] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Distributars table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Distributars table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Distributars]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[FirstName], O.[LastName], O.[Address], O.[StateID], O.[CityID], O.[CountryID], O.[Pin], O.[DaliveredDaysID], O.[Description], O.[MobileNo], O.[LandNo], O.[IsActive], O.[CreatedDate], O.[DeletedDate], O.[ModifiedDate]
				FROM
				    [dbo].[Distributars] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Distributars]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Distributars table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@FirstName nvarchar (MAX)  ,

	@LastName nvarchar (MAX)  ,

	@Address nvarchar (MAX)  ,

	@StateId int   ,

	@CityId int   ,

	@CountryId int   ,

	@Pin bigint   ,

	@DaliveredDaysId int   ,

	@Description nvarchar (MAX)  ,

	@MobileNo bigint   ,

	@LandNo bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@DeletedDate datetime   ,

	@ModifiedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Distributars]
					(
					[Name]
					,[FirstName]
					,[LastName]
					,[Address]
					,[StateID]
					,[CityID]
					,[CountryID]
					,[Pin]
					,[DaliveredDaysID]
					,[Description]
					,[MobileNo]
					,[LandNo]
					,[IsActive]
					,[CreatedDate]
					,[DeletedDate]
					,[ModifiedDate]
					)
				VALUES
					(
					@Name
					,@FirstName
					,@LastName
					,@Address
					,@StateId
					,@CityId
					,@CountryId
					,@Pin
					,@DaliveredDaysId
					,@Description
					,@MobileNo
					,@LandNo
					,@IsActive
					,@CreatedDate
					,@DeletedDate
					,@ModifiedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Distributars table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@FirstName nvarchar (MAX)  ,

	@LastName nvarchar (MAX)  ,

	@Address nvarchar (MAX)  ,

	@StateId int   ,

	@CityId int   ,

	@CountryId int   ,

	@Pin bigint   ,

	@DaliveredDaysId int   ,

	@Description nvarchar (MAX)  ,

	@MobileNo bigint   ,

	@LandNo bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@DeletedDate datetime   ,

	@ModifiedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Distributars]
				SET
					[Name] = @Name
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[Address] = @Address
					,[StateID] = @StateId
					,[CityID] = @CityId
					,[CountryID] = @CountryId
					,[Pin] = @Pin
					,[DaliveredDaysID] = @DaliveredDaysId
					,[Description] = @Description
					,[MobileNo] = @MobileNo
					,[LandNo] = @LandNo
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[DeletedDate] = @DeletedDate
					,[ModifiedDate] = @ModifiedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Distributars table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Distributars] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetByCityId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetByCityId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetByCityId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Distributars table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetByCityId
(

	@CityId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
				WHERE
					[CityID] = @CityId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetByCountryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetByCountryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetByCountryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Distributars table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetByCountryId
(

	@CountryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
				WHERE
					[CountryID] = @CountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetByDaliveredDaysId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetByDaliveredDaysId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetByDaliveredDaysId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Distributars table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetByDaliveredDaysId
(

	@DaliveredDaysId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
				WHERE
					[DaliveredDaysID] = @DaliveredDaysId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetByStateId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetByStateId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetByStateId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Distributars table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetByStateId
(

	@StateId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
				WHERE
					[StateID] = @StateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Distributars table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[FirstName],
					[LastName],
					[Address],
					[StateID],
					[CityID],
					[CountryID],
					[Pin],
					[DaliveredDaysID],
					[Description],
					[MobileNo],
					[LandNo],
					[IsActive],
					[CreatedDate],
					[DeletedDate],
					[ModifiedDate]
				FROM
					[dbo].[Distributars]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Distributars_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Distributars_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Distributars_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Distributars table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Distributars_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@FirstName nvarchar (MAX)  = null ,

	@LastName nvarchar (MAX)  = null ,

	@Address nvarchar (MAX)  = null ,

	@StateId int   = null ,

	@CityId int   = null ,

	@CountryId int   = null ,

	@Pin bigint   = null ,

	@DaliveredDaysId int   = null ,

	@Description nvarchar (MAX)  = null ,

	@MobileNo bigint   = null ,

	@LandNo bigint   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@DeletedDate datetime   = null ,

	@ModifiedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [FirstName]
	, [LastName]
	, [Address]
	, [StateID]
	, [CityID]
	, [CountryID]
	, [Pin]
	, [DaliveredDaysID]
	, [Description]
	, [MobileNo]
	, [LandNo]
	, [IsActive]
	, [CreatedDate]
	, [DeletedDate]
	, [ModifiedDate]
    FROM
	[dbo].[Distributars]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([StateID] = @StateId OR @StateId IS NULL)
	AND ([CityID] = @CityId OR @CityId IS NULL)
	AND ([CountryID] = @CountryId OR @CountryId IS NULL)
	AND ([Pin] = @Pin OR @Pin IS NULL)
	AND ([DaliveredDaysID] = @DaliveredDaysId OR @DaliveredDaysId IS NULL)
	AND ([Description] = @Description OR @Description IS NULL)
	AND ([MobileNo] = @MobileNo OR @MobileNo IS NULL)
	AND ([LandNo] = @LandNo OR @LandNo IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [FirstName]
	, [LastName]
	, [Address]
	, [StateID]
	, [CityID]
	, [CountryID]
	, [Pin]
	, [DaliveredDaysID]
	, [Description]
	, [MobileNo]
	, [LandNo]
	, [IsActive]
	, [CreatedDate]
	, [DeletedDate]
	, [ModifiedDate]
    FROM
	[dbo].[Distributars]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([StateID] = @StateId AND @StateId is not null)
	OR ([CityID] = @CityId AND @CityId is not null)
	OR ([CountryID] = @CountryId AND @CountryId is not null)
	OR ([Pin] = @Pin AND @Pin is not null)
	OR ([DaliveredDaysID] = @DaliveredDaysId AND @DaliveredDaysId is not null)
	OR ([Description] = @Description AND @Description is not null)
	OR ([MobileNo] = @MobileNo AND @MobileNo is not null)
	OR ([LandNo] = @LandNo AND @LandNo is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Get_List

AS


				
				SELECT
					[ID],
					[UserType],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[UserType]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the UserType table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[UserType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[UserType], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[UserType] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[UserType]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Insert
(

	@Id int    OUTPUT,

	@UserType nvarchar (100)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[UserType]
					(
					[UserType]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@UserType
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Update
(

	@Id int   ,

	@UserType nvarchar (100)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[UserType]
				SET
					[UserType] = @UserType
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the UserType table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[UserType] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the UserType table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[UserType],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[UserType]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.UserType_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.UserType_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.UserType_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the UserType table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.UserType_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@UserType nvarchar (100)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [UserType]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[UserType]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([UserType] = @UserType OR @UserType IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [UserType]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[UserType]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([UserType] = @UserType AND @UserType is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[EmailID],
					[Password],
					[UserType],
					[Gender],
					[FirstName],
					[LastName],
					[MobileNumber],
					[LandNumber],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Customers]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Customers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Customers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[EmailID], O.[Password], O.[UserType], O.[Gender], O.[FirstName], O.[LastName], O.[MobileNumber], O.[LandNumber], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[Customers] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Customers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@EmailId nvarchar (MAX)  ,

	@Password nvarchar (MAX)  ,

	@UserType int   ,

	@Gender int   ,

	@FirstName nvarchar (MAX)  ,

	@LastName nvarchar (MAX)  ,

	@MobileNumber nvarchar (MAX)  ,

	@LandNumber nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Customers]
					(
					[Name]
					,[EmailID]
					,[Password]
					,[UserType]
					,[Gender]
					,[FirstName]
					,[LastName]
					,[MobileNumber]
					,[LandNumber]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@EmailId
					,@Password
					,@UserType
					,@Gender
					,@FirstName
					,@LastName
					,@MobileNumber
					,@LandNumber
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@EmailId nvarchar (MAX)  ,

	@Password nvarchar (MAX)  ,

	@UserType int   ,

	@Gender int   ,

	@FirstName nvarchar (MAX)  ,

	@LastName nvarchar (MAX)  ,

	@MobileNumber nvarchar (MAX)  ,

	@LandNumber nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Customers]
				SET
					[Name] = @Name
					,[EmailID] = @EmailId
					,[Password] = @Password
					,[UserType] = @UserType
					,[Gender] = @Gender
					,[FirstName] = @FirstName
					,[LastName] = @LastName
					,[MobileNumber] = @MobileNumber
					,[LandNumber] = @LandNumber
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Customers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Customers] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByGender procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByGender') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByGender
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByGender
(

	@Gender int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[EmailID],
					[Password],
					[UserType],
					[Gender],
					[FirstName],
					[LastName],
					[MobileNumber],
					[LandNumber],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Customers]
				WHERE
					[Gender] = @Gender
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetByUserType procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetByUserType') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetByUserType
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetByUserType
(

	@UserType int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[EmailID],
					[Password],
					[UserType],
					[Gender],
					[FirstName],
					[LastName],
					[MobileNumber],
					[LandNumber],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Customers]
				WHERE
					[UserType] = @UserType
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Customers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[EmailID],
					[Password],
					[UserType],
					[Gender],
					[FirstName],
					[LastName],
					[MobileNumber],
					[LandNumber],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Customers]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Customers_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Customers_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Customers_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Customers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Customers_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@EmailId nvarchar (MAX)  = null ,

	@Password nvarchar (MAX)  = null ,

	@UserType int   = null ,

	@Gender int   = null ,

	@FirstName nvarchar (MAX)  = null ,

	@LastName nvarchar (MAX)  = null ,

	@MobileNumber nvarchar (MAX)  = null ,

	@LandNumber nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [EmailID]
	, [Password]
	, [UserType]
	, [Gender]
	, [FirstName]
	, [LastName]
	, [MobileNumber]
	, [LandNumber]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Customers]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([EmailID] = @EmailId OR @EmailId IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([UserType] = @UserType OR @UserType IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([MobileNumber] = @MobileNumber OR @MobileNumber IS NULL)
	AND ([LandNumber] = @LandNumber OR @LandNumber IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [EmailID]
	, [Password]
	, [UserType]
	, [Gender]
	, [FirstName]
	, [LastName]
	, [MobileNumber]
	, [LandNumber]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Customers]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([EmailID] = @EmailId AND @EmailId is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([UserType] = @UserType AND @UserType is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([MobileNumber] = @MobileNumber AND @MobileNumber is not null)
	OR ([LandNumber] = @LandNumber AND @LandNumber is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DeliveredDays table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_Get_List

AS


				
				SELECT
					[ID],
					[DeliveryIN],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DeliveredDays]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DeliveredDays table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[DeliveredDays]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[DeliveryIN], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[DeliveredDays] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DeliveredDays]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DeliveredDays table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_Insert
(

	@Id int    OUTPUT,

	@DeliveryIn nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[DeliveredDays]
					(
					[DeliveryIN]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@DeliveryIn
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DeliveredDays table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_Update
(

	@Id int   ,

	@DeliveryIn nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DeliveredDays]
				SET
					[DeliveryIN] = @DeliveryIn
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DeliveredDays table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[DeliveredDays] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DeliveredDays table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[DeliveryIN],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DeliveredDays]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DeliveredDays_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DeliveredDays_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DeliveredDays_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DeliveredDays table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DeliveredDays_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@DeliveryIn nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [DeliveryIN]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[DeliveredDays]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([DeliveryIN] = @DeliveryIn OR @DeliveryIn IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [DeliveryIN]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[DeliveredDays]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([DeliveryIN] = @DeliveryIn AND @DeliveryIn is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the CustomerBilling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_Get_List

AS


				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the CustomerBilling table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerBilling]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[Name], O.[Address], O.[LandMark], O.[PinCode], O.[Phone], O.[CityID], O.[StateID], O.[CountryID], O.[IsActive], O.[OrderID], O.[CustomerID], O.[AddressTypeiD], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[CustomerBilling] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[CustomerBilling]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the CustomerBilling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_Insert
(

	@Id int    OUTPUT,

	@Name nvarchar (MAX)  ,

	@Address nvarchar (MAX)  ,

	@LandMark nvarchar (MAX)  ,

	@PinCode bigint   ,

	@Phone bigint   ,

	@CityId int   ,

	@StateId int   ,

	@CountryId int   ,

	@IsActive bit   ,

	@OrderId int   ,

	@CustomerId int   ,

	@AddressTypeid int   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[CustomerBilling]
					(
					[Name]
					,[Address]
					,[LandMark]
					,[PinCode]
					,[Phone]
					,[CityID]
					,[StateID]
					,[CountryID]
					,[IsActive]
					,[OrderID]
					,[CustomerID]
					,[AddressTypeiD]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@Name
					,@Address
					,@LandMark
					,@PinCode
					,@Phone
					,@CityId
					,@StateId
					,@CountryId
					,@IsActive
					,@OrderId
					,@CustomerId
					,@AddressTypeid
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the CustomerBilling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_Update
(

	@Id int   ,

	@Name nvarchar (MAX)  ,

	@Address nvarchar (MAX)  ,

	@LandMark nvarchar (MAX)  ,

	@PinCode bigint   ,

	@Phone bigint   ,

	@CityId int   ,

	@StateId int   ,

	@CountryId int   ,

	@IsActive bit   ,

	@OrderId int   ,

	@CustomerId int   ,

	@AddressTypeid int   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[CustomerBilling]
				SET
					[Name] = @Name
					,[Address] = @Address
					,[LandMark] = @LandMark
					,[PinCode] = @PinCode
					,[Phone] = @Phone
					,[CityID] = @CityId
					,[StateID] = @StateId
					,[CountryID] = @CountryId
					,[IsActive] = @IsActive
					,[OrderID] = @OrderId
					,[CustomerID] = @CustomerId
					,[AddressTypeiD] = @AddressTypeid
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the CustomerBilling table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[CustomerBilling] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetByCityId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetByCityId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetByCityId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetByCityId
(

	@CityId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[CityID] = @CityId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetByCountryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetByCountryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetByCountryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetByCountryId
(

	@CountryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[CountryID] = @CountryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetByCustomerId
(

	@CustomerId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[CustomerID] = @CustomerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetByOrderId
(

	@OrderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[OrderID] = @OrderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetByStateId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetByStateId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetByStateId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetByStateId
(

	@StateId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[StateID] = @StateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the CustomerBilling table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[Name],
					[Address],
					[LandMark],
					[PinCode],
					[Phone],
					[CityID],
					[StateID],
					[CountryID],
					[IsActive],
					[OrderID],
					[CustomerID],
					[AddressTypeiD],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[CustomerBilling]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.CustomerBilling_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.CustomerBilling_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.CustomerBilling_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the CustomerBilling table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.CustomerBilling_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@Name nvarchar (MAX)  = null ,

	@Address nvarchar (MAX)  = null ,

	@LandMark nvarchar (MAX)  = null ,

	@PinCode bigint   = null ,

	@Phone bigint   = null ,

	@CityId int   = null ,

	@StateId int   = null ,

	@CountryId int   = null ,

	@IsActive bit   = null ,

	@OrderId int   = null ,

	@CustomerId int   = null ,

	@AddressTypeid int   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Address]
	, [LandMark]
	, [PinCode]
	, [Phone]
	, [CityID]
	, [StateID]
	, [CountryID]
	, [IsActive]
	, [OrderID]
	, [CustomerID]
	, [AddressTypeiD]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[CustomerBilling]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Address] = @Address OR @Address IS NULL)
	AND ([LandMark] = @LandMark OR @LandMark IS NULL)
	AND ([PinCode] = @PinCode OR @PinCode IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([CityID] = @CityId OR @CityId IS NULL)
	AND ([StateID] = @StateId OR @StateId IS NULL)
	AND ([CountryID] = @CountryId OR @CountryId IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([OrderID] = @OrderId OR @OrderId IS NULL)
	AND ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([AddressTypeiD] = @AddressTypeid OR @AddressTypeid IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [Name]
	, [Address]
	, [LandMark]
	, [PinCode]
	, [Phone]
	, [CityID]
	, [StateID]
	, [CountryID]
	, [IsActive]
	, [OrderID]
	, [CustomerID]
	, [AddressTypeiD]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[CustomerBilling]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Address] = @Address AND @Address is not null)
	OR ([LandMark] = @LandMark AND @LandMark is not null)
	OR ([PinCode] = @PinCode AND @PinCode is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([CityID] = @CityId AND @CityId is not null)
	OR ([StateID] = @StateId AND @StateId is not null)
	OR ([CountryID] = @CountryId AND @CountryId is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([OrderID] = @OrderId AND @OrderId is not null)
	OR ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([AddressTypeiD] = @AddressTypeid AND @AddressTypeid is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Get_List

AS


				
				SELECT
					[ID],
					[CustomerID],
					[OrderStatusID],
					[BillingID],
					[TotalAmount],
					[SurveyID],
					[ISActive],
					[ISDeliver],
					[IsSurveyDone],
					[BookingDate],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Orders]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Orders table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[CustomerID], O.[OrderStatusID], O.[BillingID], O.[TotalAmount], O.[SurveyID], O.[ISActive], O.[ISDeliver], O.[IsSurveyDone], O.[BookingDate], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[Orders] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Orders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Insert
(

	@Id int    OUTPUT,

	@CustomerId int   ,

	@OrderStatusId int   ,

	@BillingId int   ,

	@TotalAmount bigint   ,

	@SurveyId int   ,

	@IsActive bit   ,

	@IsDeliver bit   ,

	@IsSurveyDone bit   ,

	@BookingDate datetime   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Orders]
					(
					[CustomerID]
					,[OrderStatusID]
					,[BillingID]
					,[TotalAmount]
					,[SurveyID]
					,[ISActive]
					,[ISDeliver]
					,[IsSurveyDone]
					,[BookingDate]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@CustomerId
					,@OrderStatusId
					,@BillingId
					,@TotalAmount
					,@SurveyId
					,@IsActive
					,@IsDeliver
					,@IsSurveyDone
					,@BookingDate
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Update
(

	@Id int   ,

	@CustomerId int   ,

	@OrderStatusId int   ,

	@BillingId int   ,

	@TotalAmount bigint   ,

	@SurveyId int   ,

	@IsActive bit   ,

	@IsDeliver bit   ,

	@IsSurveyDone bit   ,

	@BookingDate datetime   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Orders]
				SET
					[CustomerID] = @CustomerId
					,[OrderStatusID] = @OrderStatusId
					,[BillingID] = @BillingId
					,[TotalAmount] = @TotalAmount
					,[SurveyID] = @SurveyId
					,[ISActive] = @IsActive
					,[ISDeliver] = @IsDeliver
					,[IsSurveyDone] = @IsSurveyDone
					,[BookingDate] = @BookingDate
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Orders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Orders] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByBillingId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByBillingId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByBillingId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByBillingId
(

	@BillingId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[CustomerID],
					[OrderStatusID],
					[BillingID],
					[TotalAmount],
					[SurveyID],
					[ISActive],
					[ISDeliver],
					[IsSurveyDone],
					[BookingDate],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Orders]
				WHERE
					[BillingID] = @BillingId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByCustomerId
(

	@CustomerId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[CustomerID],
					[OrderStatusID],
					[BillingID],
					[TotalAmount],
					[SurveyID],
					[ISActive],
					[ISDeliver],
					[IsSurveyDone],
					[BookingDate],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Orders]
				WHERE
					[CustomerID] = @CustomerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetByOrderStatusId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetByOrderStatusId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetByOrderStatusId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetByOrderStatusId
(

	@OrderStatusId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[CustomerID],
					[OrderStatusID],
					[BillingID],
					[TotalAmount],
					[SurveyID],
					[ISActive],
					[ISDeliver],
					[IsSurveyDone],
					[BookingDate],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Orders]
				WHERE
					[OrderStatusID] = @OrderStatusId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Orders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[CustomerID],
					[OrderStatusID],
					[BillingID],
					[TotalAmount],
					[SurveyID],
					[ISActive],
					[ISDeliver],
					[IsSurveyDone],
					[BookingDate],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[Orders]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Orders_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Orders_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Orders_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Orders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Orders_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@CustomerId int   = null ,

	@OrderStatusId int   = null ,

	@BillingId int   = null ,

	@TotalAmount bigint   = null ,

	@SurveyId int   = null ,

	@IsActive bit   = null ,

	@IsDeliver bit   = null ,

	@IsSurveyDone bit   = null ,

	@BookingDate datetime   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [CustomerID]
	, [OrderStatusID]
	, [BillingID]
	, [TotalAmount]
	, [SurveyID]
	, [ISActive]
	, [ISDeliver]
	, [IsSurveyDone]
	, [BookingDate]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([OrderStatusID] = @OrderStatusId OR @OrderStatusId IS NULL)
	AND ([BillingID] = @BillingId OR @BillingId IS NULL)
	AND ([TotalAmount] = @TotalAmount OR @TotalAmount IS NULL)
	AND ([SurveyID] = @SurveyId OR @SurveyId IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([ISDeliver] = @IsDeliver OR @IsDeliver IS NULL)
	AND ([IsSurveyDone] = @IsSurveyDone OR @IsSurveyDone IS NULL)
	AND ([BookingDate] = @BookingDate OR @BookingDate IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [CustomerID]
	, [OrderStatusID]
	, [BillingID]
	, [TotalAmount]
	, [SurveyID]
	, [ISActive]
	, [ISDeliver]
	, [IsSurveyDone]
	, [BookingDate]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[Orders]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([OrderStatusID] = @OrderStatusId AND @OrderStatusId is not null)
	OR ([BillingID] = @BillingId AND @BillingId is not null)
	OR ([TotalAmount] = @TotalAmount AND @TotalAmount is not null)
	OR ([SurveyID] = @SurveyId AND @SurveyId is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([ISDeliver] = @IsDeliver AND @IsDeliver is not null)
	OR ([IsSurveyDone] = @IsSurveyDone AND @IsSurveyDone is not null)
	OR ([BookingDate] = @BookingDate AND @BookingDate is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the OrderDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Get_List

AS


				
				SELECT
					[ID],
					[OrderId],
					[CustomerID],
					[ItemID],
					[Amount],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderDetails]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the OrderDetails table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[OrderDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[OrderId], O.[CustomerID], O.[ItemID], O.[Amount], O.[ISActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[OrderDetails] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[OrderDetails]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the OrderDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Insert
(

	@Id int    OUTPUT,

	@OrderId int   ,

	@CustomerId int   ,

	@ItemId int   ,

	@Amount bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[OrderDetails]
					(
					[OrderId]
					,[CustomerID]
					,[ItemID]
					,[Amount]
					,[ISActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@OrderId
					,@CustomerId
					,@ItemId
					,@Amount
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the OrderDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Update
(

	@Id int   ,

	@OrderId int   ,

	@CustomerId int   ,

	@ItemId int   ,

	@Amount bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[OrderDetails]
				SET
					[OrderId] = @OrderId
					,[CustomerID] = @CustomerId
					,[ItemID] = @ItemId
					,[Amount] = @Amount
					,[ISActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the OrderDetails table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[OrderDetails] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByCustomerId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByCustomerId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByCustomerId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OrderDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByCustomerId
(

	@CustomerId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[OrderId],
					[CustomerID],
					[ItemID],
					[Amount],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderDetails]
				WHERE
					[CustomerID] = @CustomerId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OrderDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByItemId
(

	@ItemId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[OrderId],
					[CustomerID],
					[ItemID],
					[Amount],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderDetails]
				WHERE
					[ItemID] = @ItemId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OrderDetails table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetByOrderId
(

	@OrderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[OrderId],
					[CustomerID],
					[ItemID],
					[Amount],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderDetails]
				WHERE
					[OrderId] = @OrderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the OrderDetails table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[OrderId],
					[CustomerID],
					[ItemID],
					[Amount],
					[ISActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[OrderDetails]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.OrderDetails_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.OrderDetails_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.OrderDetails_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the OrderDetails table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.OrderDetails_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@OrderId int   = null ,

	@CustomerId int   = null ,

	@ItemId int   = null ,

	@Amount bigint   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [OrderId]
	, [CustomerID]
	, [ItemID]
	, [Amount]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[OrderDetails]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([OrderId] = @OrderId OR @OrderId IS NULL)
	AND ([CustomerID] = @CustomerId OR @CustomerId IS NULL)
	AND ([ItemID] = @ItemId OR @ItemId IS NULL)
	AND ([Amount] = @Amount OR @Amount IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [OrderId]
	, [CustomerID]
	, [ItemID]
	, [Amount]
	, [ISActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[OrderDetails]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([OrderId] = @OrderId AND @OrderId is not null)
	OR ([CustomerID] = @CustomerId AND @CustomerId is not null)
	OR ([ItemID] = @ItemId AND @ItemId is not null)
	OR ([Amount] = @Amount AND @Amount is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Items table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_Get_List

AS


				
				SELECT
					[ID],
					[ItemName],
					[IsActive],
					[CreatedDate],
					[Modifieddate],
					[DeletedDate]
				FROM
					[dbo].[Items]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Items table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[Items]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[ItemName], O.[IsActive], O.[CreatedDate], O.[Modifieddate], O.[DeletedDate]
				FROM
				    [dbo].[Items] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Items]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Items table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_Insert
(

	@Id int    OUTPUT,

	@ItemName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@Modifieddate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[Items]
					(
					[ItemName]
					,[IsActive]
					,[CreatedDate]
					,[Modifieddate]
					,[DeletedDate]
					)
				VALUES
					(
					@ItemName
					,@IsActive
					,@CreatedDate
					,@Modifieddate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Items table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_Update
(

	@Id int   ,

	@ItemName nvarchar (MAX)  ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@Modifieddate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Items]
				SET
					[ItemName] = @ItemName
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[Modifieddate] = @Modifieddate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Items table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[Items] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Items table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[ItemName],
					[IsActive],
					[CreatedDate],
					[Modifieddate],
					[DeletedDate]
				FROM
					[dbo].[Items]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Items_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Items_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Items_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Items table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Items_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@ItemName nvarchar (MAX)  = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@Modifieddate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [ItemName]
	, [IsActive]
	, [CreatedDate]
	, [Modifieddate]
	, [DeletedDate]
    FROM
	[dbo].[Items]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([ItemName] = @ItemName OR @ItemName IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([Modifieddate] = @Modifieddate OR @Modifieddate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [ItemName]
	, [IsActive]
	, [CreatedDate]
	, [Modifieddate]
	, [DeletedDate]
    FROM
	[dbo].[Items]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([ItemName] = @ItemName AND @ItemName is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([Modifieddate] = @Modifieddate AND @Modifieddate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DistributorsOrders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_Get_List

AS


				
				SELECT
					[ID],
					[DistributorID],
					[OrderID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DistributorsOrders]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DistributorsOrders table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[DistributorsOrders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[DistributorID], O.[OrderID], O.[IsActive], O.[CreatedDate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[DistributorsOrders] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DistributorsOrders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DistributorsOrders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_Insert
(

	@Id int    OUTPUT,

	@DistributorId int   ,

	@OrderId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[DistributorsOrders]
					(
					[DistributorID]
					,[OrderID]
					,[IsActive]
					,[CreatedDate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@DistributorId
					,@OrderId
					,@IsActive
					,@CreatedDate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DistributorsOrders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_Update
(

	@Id int   ,

	@DistributorId int   ,

	@OrderId int   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DistributorsOrders]
				SET
					[DistributorID] = @DistributorId
					,[OrderID] = @OrderId
					,[IsActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DistributorsOrders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[DistributorsOrders] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_GetByDistributorId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_GetByDistributorId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_GetByDistributorId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DistributorsOrders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_GetByDistributorId
(

	@DistributorId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[DistributorID],
					[OrderID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DistributorsOrders]
				WHERE
					[DistributorID] = @DistributorId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_GetByOrderId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_GetByOrderId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_GetByOrderId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DistributorsOrders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_GetByOrderId
(

	@OrderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[DistributorID],
					[OrderID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DistributorsOrders]
				WHERE
					[OrderID] = @OrderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DistributorsOrders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[DistributorID],
					[OrderID],
					[IsActive],
					[CreatedDate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[DistributorsOrders]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.DistributorsOrders_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.DistributorsOrders_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.DistributorsOrders_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DistributorsOrders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.DistributorsOrders_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@DistributorId int   = null ,

	@OrderId int   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [DistributorID]
	, [OrderID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[DistributorsOrders]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([DistributorID] = @DistributorId OR @DistributorId IS NULL)
	AND ([OrderID] = @OrderId OR @OrderId IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [DistributorID]
	, [OrderID]
	, [IsActive]
	, [CreatedDate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[DistributorsOrders]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([DistributorID] = @DistributorId AND @DistributorId is not null)
	OR ([OrderID] = @OrderId AND @OrderId is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ItemSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_Get_List

AS


				
				SELECT
					[ID],
					[ItemID],
					[Cost],
					[CostVary],
					[Createdate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ItemSell]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ItemSell table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ItemSell]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[ItemID], O.[Cost], O.[CostVary], O.[Createdate], O.[ModifiedDate], O.[DeletedDate]
				FROM
				    [dbo].[ItemSell] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ItemSell]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ItemSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_Insert
(

	@Id int    OUTPUT,

	@ItemId int   ,

	@Cost nvarchar (MAX)  ,

	@CostVary decimal (18, 0)  ,

	@Createdate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ItemSell]
					(
					[ItemID]
					,[Cost]
					,[CostVary]
					,[Createdate]
					,[ModifiedDate]
					,[DeletedDate]
					)
				VALUES
					(
					@ItemId
					,@Cost
					,@CostVary
					,@Createdate
					,@ModifiedDate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ItemSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_Update
(

	@Id int   ,

	@ItemId int   ,

	@Cost nvarchar (MAX)  ,

	@CostVary decimal (18, 0)  ,

	@Createdate datetime   ,

	@ModifiedDate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ItemSell]
				SET
					[ItemID] = @ItemId
					,[Cost] = @Cost
					,[CostVary] = @CostVary
					,[Createdate] = @Createdate
					,[ModifiedDate] = @ModifiedDate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ItemSell table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ItemSell] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ItemSell table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_GetByItemId
(

	@ItemId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[Cost],
					[CostVary],
					[Createdate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ItemSell]
				WHERE
					[ItemID] = @ItemId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ItemSell table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[ItemID],
					[Cost],
					[CostVary],
					[Createdate],
					[ModifiedDate],
					[DeletedDate]
				FROM
					[dbo].[ItemSell]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemSell_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemSell_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemSell_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ItemSell table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemSell_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@ItemId int   = null ,

	@Cost nvarchar (MAX)  = null ,

	@CostVary decimal (18, 0)  = null ,

	@Createdate datetime   = null ,

	@ModifiedDate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [Cost]
	, [CostVary]
	, [Createdate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ItemSell]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([ItemID] = @ItemId OR @ItemId IS NULL)
	AND ([Cost] = @Cost OR @Cost IS NULL)
	AND ([CostVary] = @CostVary OR @CostVary IS NULL)
	AND ([Createdate] = @Createdate OR @Createdate IS NULL)
	AND ([ModifiedDate] = @ModifiedDate OR @ModifiedDate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [Cost]
	, [CostVary]
	, [Createdate]
	, [ModifiedDate]
	, [DeletedDate]
    FROM
	[dbo].[ItemSell]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([ItemID] = @ItemId AND @ItemId is not null)
	OR ([Cost] = @Cost AND @Cost is not null)
	OR ([CostVary] = @CostVary AND @CostVary is not null)
	OR ([Createdate] = @Createdate AND @Createdate is not null)
	OR ([ModifiedDate] = @ModifiedDate AND @ModifiedDate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the ItemPurchase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_Get_List

AS


				
				SELECT
					[ID],
					[ItemID],
					[Cost],
					[ISActive],
					[CreatedDate],
					[Modifieddate],
					[DeletedDate]
				FROM
					[dbo].[ItemPurchase]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the ItemPurchase table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				-- Create a temp table to store the select results
				CREATE TABLE #PageIndex
				(
				    [IndexId] int IDENTITY (1, 1) NOT NULL,
				    [ID] int 
				)
				
				-- Insert into the temp table
				DECLARE @SQL AS nvarchar(4000)
				SET @SQL = 'INSERT INTO #PageIndex ([ID])'
				SET @SQL = @SQL + ' SELECT'
				SET @SQL = @SQL + ' [ID]'
				SET @SQL = @SQL + ' FROM [dbo].[ItemPurchase]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				IF LEN(@OrderBy) > 0
				BEGIN
					SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				END
				
				-- Only get the number of rows needed here.
				SET ROWCOUNT @PageUpperBound
				
				-- Populate the temp table
				EXEC sp_executesql @SQL

				-- Reset Rowcount back to all
				SET ROWCOUNT 0
				
				-- Return paged results
				SELECT O.[ID], O.[ItemID], O.[Cost], O.[ISActive], O.[CreatedDate], O.[Modifieddate], O.[DeletedDate]
				FROM
				    [dbo].[ItemPurchase] O,
				    #PageIndex PageIndex
				WHERE
				    PageIndex.IndexId > @PageLowerBound
					AND O.[ID] = PageIndex.[ID]
				ORDER BY
				    PageIndex.IndexId
                
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[ItemPurchase]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the ItemPurchase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_Insert
(

	@Id int    OUTPUT,

	@ItemId int   ,

	@Cost bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@Modifieddate datetime   ,

	@DeletedDate datetime   
)
AS


				
				INSERT INTO [dbo].[ItemPurchase]
					(
					[ItemID]
					,[Cost]
					,[ISActive]
					,[CreatedDate]
					,[Modifieddate]
					,[DeletedDate]
					)
				VALUES
					(
					@ItemId
					,@Cost
					,@IsActive
					,@CreatedDate
					,@Modifieddate
					,@DeletedDate
					)
				-- Get the identity value
				SET @Id = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the ItemPurchase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_Update
(

	@Id int   ,

	@ItemId int   ,

	@Cost bigint   ,

	@IsActive bit   ,

	@CreatedDate datetime   ,

	@Modifieddate datetime   ,

	@DeletedDate datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[ItemPurchase]
				SET
					[ItemID] = @ItemId
					,[Cost] = @Cost
					,[ISActive] = @IsActive
					,[CreatedDate] = @CreatedDate
					,[Modifieddate] = @Modifieddate
					,[DeletedDate] = @DeletedDate
				WHERE
[ID] = @Id 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the ItemPurchase table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_Delete
(

	@Id int   
)
AS


				DELETE FROM [dbo].[ItemPurchase] WITH (ROWLOCK) 
				WHERE
					[ID] = @Id
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_GetByItemId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_GetByItemId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_GetByItemId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ItemPurchase table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_GetByItemId
(

	@ItemId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[ID],
					[ItemID],
					[Cost],
					[ISActive],
					[CreatedDate],
					[Modifieddate],
					[DeletedDate]
				FROM
					[dbo].[ItemPurchase]
				WHERE
					[ItemID] = @ItemId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_GetById procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_GetById') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_GetById
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the ItemPurchase table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_GetById
(

	@Id int   
)
AS


				SELECT
					[ID],
					[ItemID],
					[Cost],
					[ISActive],
					[CreatedDate],
					[Modifieddate],
					[DeletedDate]
				FROM
					[dbo].[ItemPurchase]
				WHERE
					[ID] = @Id
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.ItemPurchase_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.ItemPurchase_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.ItemPurchase_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the ItemPurchase table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.ItemPurchase_Find
(

	@SearchUsingOR bit   = null ,

	@Id int   = null ,

	@ItemId int   = null ,

	@Cost bigint   = null ,

	@IsActive bit   = null ,

	@CreatedDate datetime   = null ,

	@Modifieddate datetime   = null ,

	@DeletedDate datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [Cost]
	, [ISActive]
	, [CreatedDate]
	, [Modifieddate]
	, [DeletedDate]
    FROM
	[dbo].[ItemPurchase]
    WHERE 
	 ([ID] = @Id OR @Id IS NULL)
	AND ([ItemID] = @ItemId OR @ItemId IS NULL)
	AND ([Cost] = @Cost OR @Cost IS NULL)
	AND ([ISActive] = @IsActive OR @IsActive IS NULL)
	AND ([CreatedDate] = @CreatedDate OR @CreatedDate IS NULL)
	AND ([Modifieddate] = @Modifieddate OR @Modifieddate IS NULL)
	AND ([DeletedDate] = @DeletedDate OR @DeletedDate IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [ID]
	, [ItemID]
	, [Cost]
	, [ISActive]
	, [CreatedDate]
	, [Modifieddate]
	, [DeletedDate]
    FROM
	[dbo].[ItemPurchase]
    WHERE 
	 ([ID] = @Id AND @Id is not null)
	OR ([ItemID] = @ItemId AND @ItemId is not null)
	OR ([Cost] = @Cost AND @Cost is not null)
	OR ([ISActive] = @IsActive AND @IsActive is not null)
	OR ([CreatedDate] = @CreatedDate AND @CreatedDate is not null)
	OR ([Modifieddate] = @Modifieddate AND @Modifieddate is not null)
	OR ([DeletedDate] = @DeletedDate AND @DeletedDate is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO


ALTER PROCEDURE [dbo].[CompanyAndAddress_GetAll]
AS

BEGIN

SELECT

	 [Company].[id]
	,[Company].name
	,[Company].phoneNumber
	,[Company].faxNumber
	,[Company].email
	,[Company].mediaId
	,[Company].url
	,[Addresses].Address1
	,[Addresses].City
	,[Addresses].[State]
	,[Addresses].ZipCode
	,[Addresses].Latitude
	,[Addresses].Longitude
	,[Addresses].AddressType
	

FROM [dbo].[Company]
INNER JOIN [dbo].[Addresses]
ON [Company].id = [Addresses].CompanyId

WHERE [Addresses].AddressType =1
END

CREATE TABLE [dbo].[Brands]
(
	[BrandId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NOT NULL, 
    [PercentageOfProfit] FLOAT NOT NULL, 
    [Rating] INT NULL
)

/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

insert into [dbo].[Brands]
(
    [Name], 
    [PercentageOfProfit], 
    [Rating]
)
values	('Samsung', 10.0, 5),
		('LG',      7.0,  4),
		('Xiaomi',  5.0,  5),
		('Meizu',   3.0,  3);

insert into [dbo].[Params]
(
    [CPU], 
    [ScreenDiagonal], 
    [Color], 
    [Capacity], 
    [Memory]
)
values	('Qualcomm Snapdragon 435', 6.44, 'Red',   4070, 6),
		('Qualcomm Snapdragon 821', 5.15, 'Green', 2100, 6),
		('Qualcomm Snapdragon 835', 6.4,  'Blue',  6040, 6),
		('Qualcomm Snapdragon 625', 5.7,  'White', 4600, 4);

insert into [dbo].[Phones]
(
    [BrandId], 
    [ParamsId], 
    [Name], 
    [Price]
)
values	(1, 1, 'Mi6 6/64GB Red',                 4070.0),
		(2, 2, 'Mi Mix 6/256GB Green',           2100.0),
		(3, 3, 'Mi Note 2 6/128GB Bright Blue',  6040.0),
		(4, 4, 'Mi Max 2 4/64GB White',          4600.0);
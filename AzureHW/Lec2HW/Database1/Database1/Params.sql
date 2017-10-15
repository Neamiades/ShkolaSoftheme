CREATE TABLE [dbo].[Params]
(
	[ParamsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CPU] NCHAR(100) NOT NULL, 
    [ScreenDiagonal] FLOAT NOT NULL, 
    [Color] NCHAR(20) NOT NULL, 
    [Capacity] INT NOT NULL, 
    [Memory] INT NOT NULL
)

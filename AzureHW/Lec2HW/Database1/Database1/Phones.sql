CREATE TABLE [dbo].[Phones]
(
	[PhoneId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BrandId] INT NOT NULL, 
    [ParamsId] INT NOT NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [Price] DECIMAL NOT NULL
)
GO
ALTER TABLE [dbo].[Phones]  WITH CHECK ADD CONSTRAINT [FK_Phones_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brands] ([BrandId])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_Brands]
GO

ALTER TABLE [dbo].[Phones]  WITH CHECK ADD CONSTRAINT [FK_Phones_Params] FOREIGN KEY([ParamsId])
REFERENCES [dbo].[Params] ([ParamsId])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_Params]
GO
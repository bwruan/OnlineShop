USE [OnlineShop]
GO
SET IDENTITY_INSERT [dbo].[CardType] ON 

INSERT [dbo].[CardType] ([CardTypeId], [Name]) VALUES (1, N'Visa')
INSERT [dbo].[CardType] ([CardTypeId], [Name]) VALUES (2, N'MasterCard')
INSERT [dbo].[CardType] ([CardTypeId], [Name]) VALUES (3, N'AmericanExpress')
INSERT [dbo].[CardType] ([CardTypeId], [Name]) VALUES (4, N'Discover')
SET IDENTITY_INSERT [dbo].[CardType] OFF

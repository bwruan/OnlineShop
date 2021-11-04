CREATE TABLE dbo.Item(
	ItemId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	Name varchar(50) not null,
	Price smallmoney not null,
	Picture varbinary(max),
    ItemTypeId int not null foreign key references dbo.ItemType(ItemTypeId)
);
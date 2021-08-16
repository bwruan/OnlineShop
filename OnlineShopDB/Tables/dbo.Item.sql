CREATE TABLE dbo.Item(
	ItemId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	Name varchar(50) not null,
	Price smallmoney not null,
	Quantity int not null,
	Picture varbinary(max),
    ItemType int not null foreign key references dbo.ItemType(ItemTypeId),
	SellerId bigint not null foreign key references dbo.Account(AccountId)
);
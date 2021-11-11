CREATE TABLE dbo.Cart(
	CartId bigint PRIMARY KEY Identity(1,1) NOT NULL,
    ItemId bigint not null foreign key references dbo.Item(ItemId),
	Amount int not null,
	AccountId bigint not null foreign key references dbo.Account(accountId)
);
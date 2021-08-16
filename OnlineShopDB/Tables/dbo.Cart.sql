CREATE TABLE dbo.Cart(
	CartId bigint PRIMARY KEY Identity(1,1) NOT NULL,
    ItemId bigint not null foreign key references dbo.Item(ItemId),
	AccountId bigint not null foreign key references dbo.Account(AccountId),
	Amount int not null
);
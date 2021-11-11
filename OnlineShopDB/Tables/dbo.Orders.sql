CREATE TABLE dbo.Orders(
	OrderId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	OrderNum int not null,
	PurchaseDate date not null default getdate(),
	Amount int not null, 
	ItemId bigint not null foreign key references dbo.Item(ItemId),
	AccountId bigint not null foreign key references dbo.Account(AccountId)
);
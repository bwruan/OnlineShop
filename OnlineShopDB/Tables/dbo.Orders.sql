CREATE TABLE dbo.Orders(
	OrderId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	OrderNum int not null,
    CartId bigint not null foreign key references dbo.Cart(CartId),
	PurchaseDate date not null default getdate()
);
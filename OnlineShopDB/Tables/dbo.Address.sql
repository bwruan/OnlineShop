CREATE TABLE dbo.Address(
	AddressId bigint PRIMARY KEY Identity(1,1) NOT NULL,
    Shipping varchar(50) not null,
	AccountId bigint not null foreign key references dbo.Account(AccountId)
);
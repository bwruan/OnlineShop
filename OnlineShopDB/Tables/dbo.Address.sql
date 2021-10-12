CREATE TABLE dbo.Address(
	AddressId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	CustomerName varchar(50) not null,
    UnitStreet varchar(50) not null,
	City varchar(50) not null,
	State varchar(25) not null,
	Zipcode varchar(25) not null,
	AccountId bigint not null foreign key references dbo.Account(AccountId)
);
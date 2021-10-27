CREATE TABLE dbo.PaymentInfo(
	PaymentId bigint PRIMARY KEY Identity(1,1) NOT NULL,
	NameOnCard varchar(25) not null,
	CardNumber varchar(16) not null,
	SecurityCode varchar(3) not null,
	ExpDate varchar(25) not null,
	BillingName varchar(50) not null,
	BillingUnit varchar(50) not null,
	BillingCity varchar(50) not null,
	BillingState varchar(25) not null,
	BillingZipcode varchar(25) not null,
    CardType int not null foreign key references dbo.CardType(CardTypeId),
	AccountId bigint not null foreign key references dbo.Account(AccountId)
);
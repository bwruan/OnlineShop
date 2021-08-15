CREATE TABLE dbo.Account(
	AccountId bigint PRIMARY KEY Identity(1,1) NOT NULL,
    Name varchar(25) not null,
	Email varchar(50) not null,
	Password varchar(32) not null,
	Status bit default 0 not null,
	CreatedDate datetime2(7) not null default getdate(),
	UpdatedDate datetime2(7)
);
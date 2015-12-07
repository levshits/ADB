IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Account_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Account] DROP CONSTRAINT [FK_Account_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Card_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Card] DROP CONSTRAINT [FK_Card_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Card_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Card] DROP CONSTRAINT [FK_Card_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Client_Principal]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_Client_Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_ResidenceCity]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_ResidenceCity]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Contract_Client]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Contract] DROP CONSTRAINT [FK_Contract_Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_CreditContract_Contract]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [CreditContract] DROP CONSTRAINT [FK_CreditContract_Contract]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_DepositContract_Contract]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [DepositContract] DROP CONSTRAINT [FK_DepositContract_Contract]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_TransactionHistory_Account]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [TransactionHistory] DROP CONSTRAINT [FK_TransactionHistory_Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_TransactionHistory_Account_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [TransactionHistory] DROP CONSTRAINT [FK_TransactionHistory_Account_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Account]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Account]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Card]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Card]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[City]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [City]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Client]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Client]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Contract]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Contract]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[CreditContract]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [CreditContract]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[DepositContract]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [DepositContract]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Principal]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Principal]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[TransactionHistory]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [TransactionHistory]
;

CREATE TABLE [Account]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[OwnerId] int NOT NULL,
	[Balance] decimal(18) NOT NULL DEFAULT 0,
	[CurrencyType] smallint NOT NULL DEFAULT 0,
	[AccountId] nvarchar(600) NOT NULL,
	[Version] int NOT NULL,
	[ActivityType] smallint NOT NULL,
	[UserType] smallint NOT NULL
)
;

CREATE TABLE [Card]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Number] varchar(16) NOT NULL,
	[ClientId] int NOT NULL,
	[AccountId] int NOT NULL
)
;

CREATE TABLE [City]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(200),
	[Version] int NOT NULL
)
;

CREATE TABLE [Client]
(
	[Id] int NOT NULL,
	[FirstName] nvarchar(200) NOT NULL,
	[MiddleName] nvarchar(200) NOT NULL,
	[LastName] nvarchar(200) NOT NULL,
	[BirthDate] date NOT NULL,
	[PassportSeries] nvarchar(2) NOT NULL,
	[PassportNumber] nvarchar(7) NOT NULL,
	[IssuedBy] nvarchar(500) NOT NULL,
	[IssuedDate] date NOT NULL,
	[PassportId] nvarchar(14) NOT NULL,
	[BirthPlace] nvarchar(500) NOT NULL,
	[ResidenceCityId] int NOT NULL,
	[ResidenceAddress] nvarchar(500) NOT NULL,
	[HomePhone] nvarchar(50),
	[MobilePhone] nvarchar(50),
	[Email] nvarchar(200),
	[Company] nvarchar(500),
	[Position] nvarchar(500),
	[RegistrationAddress] nvarchar(500) NOT NULL,
	[MaritalStatus] int NOT NULL,
	[Nationality] int NOT NULL,
	[DisabilityStatus] int NOT NULL,
	[MonthlyIncome] decimal(19,5) NOT NULL,
	[IsRetired] bit NOT NULL,
	[IsStaff] bit
)
;

CREATE TABLE [Contract]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[AssignDate] varchar(50) NOT NULL,
	[PrincipalId] int NOT NULL,
	[ContractType] smallint NOT NULL
)
;

CREATE TABLE [CreditContract]
(
	[Id] int NOT NULL,
	[CreditType] smallint NOT NULL,
	[PercentValue] decimal(18) NOT NULL,
	[MainAccountId] int NOT NULL,
	[PercentAcountId] int NOT NULL,
	[Period] int NOT NULL,
	[CurrencyType] smallint NOT NULL,
	[Summ] decimal(18) NOT NULL
)
;

CREATE TABLE [DepositContract]
(
	[Id] int NOT NULL,
	[DepositType] smallint NOT NULL,
	[PercentValue] decimal(18) NOT NULL,
	[MainAccountId] int NOT NULL,
	[PercentAccountId] int NOT NULL,
	[Period] int NOT NULL,
	[Summ] decimal(18) NOT NULL,
	[CurrencyType] smallint NOT NULL
)
;

CREATE TABLE [Principal]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Version] int NOT NULL,
	[Name] nvarchar(600)
)
;

CREATE TABLE [TransactionHistory]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[CreateTime] datetime NOT NULL,
	[Version] int NOT NULL,
	[FromAccount] int NOT NULL,
	[ToAccount] int NOT NULL,
	[Count] decimal(18) NOT NULL,
	[CurrencyType] smallint NOT NULL DEFAULT 0
)
;

CREATE INDEX [IXFK_Account_Principal] 
 ON [Account] ([OwnerId] ASC)
;

ALTER TABLE [Account] 
 ADD CONSTRAINT [PK_Account]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Card_Account] 
 ON [Card] ([AccountId] ASC)
;

CREATE INDEX [IXFK_Card_Client] 
 ON [Card] ([ClientId] ASC)
;

ALTER TABLE [Card] 
 ADD CONSTRAINT [PK_Table1]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [City] 
 ADD CONSTRAINT [PK_City]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [City] 
 ADD CONSTRAINT [UK_Name] UNIQUE NONCLUSTERED ([Name])
;

CREATE INDEX [IXFK_Client_Principal] 
 ON [Client] ([Id] ASC)
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [PK_Client]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UK_PassportNumber] UNIQUE NONCLUSTERED ([PassportNumber],[PassportSeries])
;

ALTER TABLE [Client] 
 ADD CONSTRAINT [UK_PassportId] UNIQUE NONCLUSTERED ([PassportId])
;

CREATE INDEX [IXFK_Contract_Client] 
 ON [Contract] ([PrincipalId] ASC)
;

ALTER TABLE [Contract] 
 ADD CONSTRAINT [PK_Contract]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_CreditContract_Contract] 
 ON [CreditContract] ([Id] ASC)
;

ALTER TABLE [CreditContract] 
 ADD CONSTRAINT [PK_CreditContract]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_DepositContract_Contract] 
 ON [DepositContract] ([Id] ASC)
;

ALTER TABLE [DepositContract] 
 ADD CONSTRAINT [PK_DepositContract]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_Principal_Client] 
 ON [Principal] ([Id] ASC)
;

ALTER TABLE [Principal] 
 ADD CONSTRAINT [PK_Principal]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_TransactionHistory_Account] 
 ON [TransactionHistory] ([FromAccount] ASC)
;

CREATE INDEX [IXFK_TransactionHistory_Account_02] 
 ON [TransactionHistory] ([ToAccount] ASC)
;

ALTER TABLE [Account] ADD CONSTRAINT [FK_Account_Principal]
	FOREIGN KEY ([OwnerId]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Card] ADD CONSTRAINT [FK_Card_Account]
	FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Card] ADD CONSTRAINT [FK_Card_Client]
	FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_Client_Principal]
	FOREIGN KEY ([Id]) REFERENCES [Principal] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Client] ADD CONSTRAINT [FK_ResidenceCity]
	FOREIGN KEY ([ResidenceCityId]) REFERENCES [City] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Contract] ADD CONSTRAINT [FK_Contract_Client]
	FOREIGN KEY ([PrincipalId]) REFERENCES [Client] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [CreditContract] ADD CONSTRAINT [FK_CreditContract_Contract]
	FOREIGN KEY ([Id]) REFERENCES [Contract] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [DepositContract] ADD CONSTRAINT [FK_DepositContract_Contract]
	FOREIGN KEY ([Id]) REFERENCES [Contract] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [TransactionHistory] ADD CONSTRAINT [FK_TransactionHistory_Account]
	FOREIGN KEY ([FromAccount]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [TransactionHistory] ADD CONSTRAINT [FK_TransactionHistory_Account_02]
	FOREIGN KEY ([ToAccount]) REFERENCES [Account] ([Id]) ON DELETE No Action ON UPDATE No Action
;

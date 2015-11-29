IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_ResidenceCity]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Client] DROP CONSTRAINT [FK_ResidenceCity]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[City]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [City]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Client]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Client]
;

CREATE TABLE [City]
(
	[Id] int NOT NULL,
	[Name] nvarchar(200),
	[Version] int NOT NULL
)
;

CREATE TABLE [Client]
(
	[Id] int NOT NULL,
	[Version] int NOT NULL,
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
	[IsRetired] bit NOT NULL
)
;

ALTER TABLE [City] 
 ADD CONSTRAINT [PK_City]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [City] 
 ADD CONSTRAINT [UK_Name] UNIQUE NONCLUSTERED ([Name])
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

ALTER TABLE [Client] ADD CONSTRAINT [FK_ResidenceCity]
	FOREIGN KEY ([ResidenceCityId]) REFERENCES [City] ([Id]) ON DELETE No Action ON UPDATE No Action
;

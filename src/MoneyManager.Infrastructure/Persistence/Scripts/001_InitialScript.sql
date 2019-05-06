CREATE TABLE [Users]
(
	[Id]			BIGINT IDENTITY(1,1)	NOT NULL,
	[Identifier]	UNIQUEIDENTIFIER		NOT NULL,
	[Login]			VARCHAR(120)			NOT NULL,
	[Password]		VARCHAR(50)				NOT NULL,
	[FullName]		VARCHAR(250)			NOT NULL,
	[Balance]		DECIMAL(19,4)			NOT NULL,
	[CreatedOn]		DATETIMEOFFSET			NOT NULL,
	[LastUpdatedOn]	DATETIMEOFFSET			NULL,
	[Status]		INT						NOT NULL
)
GO

ALTER TABLE
	[Users]
ADD CONSTRAINT
	[PK_Users_Id]
PRIMARY KEY
	([Id])
GO

CREATE TABLE [Accounts]
(
	[Id]				BIGINT IDENTITY(1,1)	NOT NULL,
	[Identifier]		UNIQUEIDENTIFIER		NOT NULL,
	[UserId]			BIGINT					NOT NULL,
	[ShortName]			VARCHAR(3)				NOT NULL,
	[LongName]			VARCHAR(50)				NOT NULL,
	[Color]				VARCHAR(7)				NOT NULL,
	[Icon]				VARCHAR(20)				NOT NULL,
	[CurrentBalance]	DECIMAL(19,4)			NOT NULL,
	[CreatedOn]			DATETIMEOFFSET			NOT NULL,
	[LastUpdatedOn]		DATETIMEOFFSET			NULL,
	[Status]			INT						NOT NULL
)
GO

ALTER TABLE
	[Accounts]
ADD CONSTRAINT
	[PK_Accounts_Id]
PRIMARY KEY
	([Id])
GO

ALTER TABLE
	[Accounts]
ADD CONSTRAINT
	[FK_Users_Accounts_Id]
FOREIGN KEY
	([UserId])
REFERENCES
	[Users] ([Id])
GO

CREATE TABLE [Incomes]
(
	[Id]			BIGINT IDENTITY(1,1)	NOT NULL,
	[Identifier]	UNIQUEIDENTIFIER		NOT NULL,
	[AccountId]		BIGINT					NOT NULL,
	[Description]	VARCHAR(100)			NOT NULL,
	[Date]			DATE					NOT NULL,
	[Value]			DECIMAL(19,4)			NOT NULL,
	[CreatedOn]		DATETIMEOFFSET			NOT NULL,
	[LastUpdatedOn]	DATETIMEOFFSET			NULL,
	[Status]		INT						NOT NULL
)
GO

ALTER TABLE
	[Incomes]
ADD CONSTRAINT
	[PK_Incomes_Id]
PRIMARY KEY
	([Id])
GO

ALTER TABLE
	[Incomes]
ADD CONSTRAINT
	[FK_Accounts_Incomes_Id]
FOREIGN KEY
	([AccountId])
REFERENCES
	[Accounts] ([Id])
GO

CREATE TABLE [Expenses]
(
	[Id]			BIGINT IDENTITY(1,1)	NOT NULL,
	[Identifier]	UNIQUEIDENTIFIER		NOT NULL,
	[AccountId]		BIGINT					NOT NULL,
	[Description]	VARCHAR(100)			NOT NULL,
	[Date]			DATE					NOT NULL,
	[Value]			DECIMAL(19,4)			NOT NULL,
	[CreatedOn]		DATETIMEOFFSET			NOT NULL,
	[LastUpdatedOn]	DATETIMEOFFSET			NULL,
	[Status]		INT						NOT NULL
)
GO

ALTER TABLE
	[Expenses]
ADD CONSTRAINT
	[PK_Expenses_Id]
PRIMARY KEY
	([Id])
GO

ALTER TABLE
	[Expenses]
ADD CONSTRAINT
	[FK_Accounts_Expenses_Id]
FOREIGN KEY
	([AccountId])
REFERENCES
	[Accounts] ([Id])
GO
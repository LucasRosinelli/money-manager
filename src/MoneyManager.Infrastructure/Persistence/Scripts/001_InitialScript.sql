CREATE TABLE [Users]
(
	[Id]			BIGINT IDENTITY(1,1)	NOT NULL,
	[Identifier]	UNIQUEIDENTIFIER		NOT NULL,
	[Login]			VARCHAR(120)			NOT NULL,
	[Password]		VARCHAR(50)				NOT NULL,
	[FullName]		VARCHAR(250)			NOT NULL,
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
CREATE TABLE dbo.Items
(
	ItemId INT NOT NULL IDENTITY(1, 1),
	SmallMessage VARCHAR(100) NOT NULL,
	LargeMessage CHAR(3000) NOT NULL,
	CONSTRAINT PK_Items PRIMARY KEY CLUSTERED
	(
		ItemId ASC
	)
)

USE Hockey

CREATE TABLE Hockey.DraftPosition (
	Id			   INT NOT NULL,
	PlayerId       INT NOT NULL,
	JuniorTeamId   INT NOT NULL,
	DraftingTeamId INT NOT NULL,
	DraftYear      INT NOT NULL,
	PickNumber     INT NOT NULL

	CONSTRAINT PK_DraftPosition PRIMARY KEY CLUSTERED (
		Id ASC
	) WITH (
		PAD_INDEX              = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY         = OFF, 
		ALLOW_ROW_LOCKS        = ON, 
		ALLOW_PAGE_LOCKS       = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO

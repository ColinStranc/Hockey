USE Hockey

CREATE TABLE Hockey.Game (
	Id			 INT NOT NULL,
	HomeTeamId   INT NOT NULL,
	AwayTeamId   INT NOT NULL,
	Season       CHAR(5) NOT NULL,
	SeasonType   VARCHAR(4) NOT NULL,
	GameDate     DATE NOT NULL,
	HomeScore    INT NOT NULL,
	AwayScore    INT NOT NULL

	CONSTRAINT PK_Game PRIMARY KEY CLUSTERED (
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

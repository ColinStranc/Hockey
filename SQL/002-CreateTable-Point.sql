USE Hockey

CREATE TABLE Hockey.Point (
	Id			 INT NOT NULL,
	GameId       INT NOT NULL,
	PlayerId     INT NOT NULL,
	TeamId       INT NOT NULL,
	OppTeamId    INT NOT NULL,
	TypeOfPoint  VARCHAR(2) NOT NULL,
	TeamScore    INT NOT NULL,  --This is denormalizing a little bit, still worth it?
	OppTeamScore INT NOT NULL,
	Situation    CHAR(2) NOT NULL,
	Period       INT NOT NULL,
	SecondsIn    INT NOT NULL

	CONSTRAINT PK_Point PRIMARY KEY CLUSTERED (
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

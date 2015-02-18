USE Hockey

CREATE TABLE Hockey.TeamPlayer (
	Id			 INT NOT NULL,
	StartDate    DATE NOT NULL,
	EndDate      DATE NULL,
	PlayerId     INT NOT NULL,
	TeamId       INT NOT NULL


	CONSTRAINT PK_TeamPlayer PRIMARY KEY CLUSTERED (
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

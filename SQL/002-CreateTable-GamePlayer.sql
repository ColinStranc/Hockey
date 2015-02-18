USE Hockey

CREATE TABLE Hockey.GamePlayer (
	Id			 INT NOT NULL,
	GameId       INT NOT NULL,
	PlayerId     INT NOT NULL,
	TeamId       INT NOT NULL,
	Goals        INT NOT NULL,
	Assists      INT NOT NULL,
	PIM          INT NOT NULL,
	TOIInSec     INT NOT NULL

	CONSTRAINT PK_GamePlayer PRIMARY KEY CLUSTERED (
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

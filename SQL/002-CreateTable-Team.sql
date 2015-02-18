USE Hockey

CREATE TABLE Hockey.Team (
	Id			 INT NOT NULL,
	Name         VARCHAR(64) NOT NULL,
	Abbreviation VARCHAR(3),
	League       VARCHAR(5) NOT NULL,
	Division     VARCHAR(64) NOT NULL

	/*
	TeamPlace    VARCHAR(64) NOT NULL,
	TeamCommon   VARCHAR(64) NOT NULL,
	LogoUrl      VARCHAR(256) NOT NULL
	*/

	CONSTRAINT PK_Team PRIMARY KEY CLUSTERED (
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

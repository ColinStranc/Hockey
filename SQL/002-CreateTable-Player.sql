USE Hockey

CREATE TABLE Hockey.Player (
	Id			   INT NOT NULL,
	Name           VARCHAR(64) NOT NULL,
	Position       VARCHAR(10) NOT NULL,
	JerseyNumber   INT NOT NULL,
	DateOfBirth    DATE NOT NULL,
	BirthPlace     VARCHAR(64) NOT NULL,
	Handedness     CHAR(1) NOT NULL,
	Height         INT NOT NULL,
	Weight         INT NOT NULL

	/*
	TeamId         VARCHAR(64) NOT NULL,
	TeamLocation   VARCHAR(64) NOT NULL,
	TeamName       VARCHAR(64) NOT NULL,
	PlayerType     VARCHAR(64) NOT NULL,
	SweaterNumber  VARCHAR(64) NOT NULL,
	Age            VARCHAR(64) NOT NULL,
	*/
	
	
	
	
	CONSTRAINT PK_Player PRIMARY KEY CLUSTERED (
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


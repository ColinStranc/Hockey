/*
SELECT
	Team.Name,
	HomeGame.GameDate,
	HomeGame.HomeScore AS Score,
	'Home' AS GameType
FROM
	Hockey.Team,
	Hockey.Game AS HomeGame
WHERE
	Team.Id = HomeGame.HomeTeamId
UNION
SELECT
	Team.Name,
	AwayGame.GameDate,
	AwayGame.AwayScore AS Score,
	'Away' AS Gametype
FROM
	Hockey.Team,
	Hockey.Game AS AwayGame
WHERE
	Team.Id = AwayGame.AwayTeamId
ORDER BY 
	Name, 
	GameDate
*/
/*
SELECT
	Name,
	SUM(Score)
FROM
	(
	SELECT
		Team.Name,
		HomeGame.GameDate,
		HomeGame.HomeScore AS Score,
		'Home' AS GameType
	FROM
		Hockey.Team,
		Hockey.Game AS HomeGame
	WHERE
		Team.Id = HomeGame.HomeTeamId
	UNION
	SELECT
		Team.Name,
		AwayGame.GameDate,
		AwayGame.AwayScore AS Score,
		'Away' AS Gametype
	FROM
		Hockey.Team,
		Hockey.Game AS AwayGame
	WHERE
		Team.Id = AwayGame.AwayTeamId
	) AS Scores
GROUP BY
	Name
ORDER BY
	SUM(Score) DESC
*/
SELECT
	Name,
	SUM(Score),
	SUM(ScoreAgainst),
	SUM(Score) - SUM(ScoreAgainst)
FROM
	(
	SELECT
		Team.Name,
		Game.GameDate,
		Game.HomeScore AS Score,
		Game.AwayScore AS ScoreAgainst,
		'Home' AS GameType
	FROM
		Hockey.Team
		JOIN Hockey.Game ON (
			Team.Id = Game.HomeTeamId
			)
	UNION
	SELECT
		Team.Name,
		Game.GameDate,
		Game.AwayScore AS Score,
		Game.HomeScore AS ScoreAgainst,
		'Away' AS GameType
	FROM
		Hockey.Team
		JOIN Hockey.Game ON (
			Team.Id = Game.AwayTeamId
			)
	) AS Scores
GROUP BY
	Name
ORDER BY
	SUM(Score) - SUM(ScoreAgainst) DESC
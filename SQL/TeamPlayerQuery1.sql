SELECT
	Team.Name,
	League,
	Division,
	Player.Name
FROM
	Hockey.Player,
	Hockey.Team,
	Hockey.TeamPlayer
WHERE
	Team.Id = TeamPlayer.TeamId and
	Player.Id = TeamPlayer.PlayerId
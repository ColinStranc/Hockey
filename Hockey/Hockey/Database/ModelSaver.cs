using Hockey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/*
 * Import To Row Function should be abstracted
 * */


namespace Hockey.Database
{
    class ModelSaver
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ModelSaver));
        public string ConnectionString { get; private set; }
        protected readonly HockeyModel hockeyModel;

        public ModelSaver(HockeyModel hm, string connectionString)
        {
            ConnectionString = connectionString;
            hockeyModel = hm;
        }

        public void SaveModel()
        {
            DeleteExistingRows();
            InsertNewRows();
        }

        private void DeleteExistingRows()
        {
            Log.Info("#### Emptying Existing Rows. ####");
            string[] tableNames = { "TeamPlayer", "GamePlayer", "Point", "Game", "DraftPosition", "Team", "Player" };

            foreach (var tableName in tableNames) {
                Log.InfoFormat("Emptying {0} Table", tableName);
                EmptyTable(tableName);
            }
            
        }

        private void InsertNewRows()
        {
            Log.Info("#### Inserting New Rows. ####");

            InsertToTeamTable(hockeyModel.Teams);
            InsertToPlayerTable(hockeyModel.Players);
            InsertToGameTable(hockeyModel.Games);
            //InsertToPointTable(hockeyModel.Points);
            InsertToTeamPlayerTable(hockeyModel.TeamPlayers);
            //InsertToDraftPositionTable(hockeyModel.DraftPositions);
            //InsertToGamePlayerTable(hockeyModel.GamePlayers);
        }

        private void InsertToPlayerTable(IEnumerable<Player> players)
        {
            Log.Info("Inserting to Player Table.");

            foreach (var player in players)
            {
                InsertPlayerRow(player);
            }
            Log.Info("Finished Inserting to Player Table.\n");
        }

        private void InsertPlayerRow(Player player)
        {
            Log.InfoFormat("Inserting {0} ({1})", player.Name, player.Id);

            using (var cmd = new SqlCmdExt(ConnectionString))
            {
                cmd.CreateCmd(@"
INSERT INTO Hockey.Player (
    Id, Name, Position, JerseyNumber, DateOfBirth, BirthPlace, Handedness, Height, Weight
) VALUES (
    @Id, @Name, @Position, @JerseyNumber, @DateOfBirth, @BirthPlace, @Handedness, @Height, @Weight
)");
                cmd.SetInArg("@Id", player.Id);
                cmd.SetInArg("@Name", player.Name);
                cmd.SetInArg("@Position", player.Position);
                cmd.SetInArg("@JerseyNumber", player.JerseyNumber);
                cmd.SetInArg("@DateOfBirth", player.DateOfBirth);
                cmd.SetInArg("@BirthPlace", player.BirthPlace);
                cmd.SetInArg("@Handedness", player.Handedness);
                cmd.SetInArg("@Height", player.Height);
                cmd.SetInArg("@Weight", player.Weight);

                cmd.ExecuteInsertUpdateDelete();
            }
        }


        private void InsertToTeamTable(IEnumerable<Team> teams)
        {
            Log.Info("Inserting to Team Table.");
            foreach (var team in teams)
            {
                InsertTeamRow(team);
            }
            Log.Info("Finished Inserting to Team Table.\n");
        }

        private void InsertTeamRow(Team team)
        {
            Log.InfoFormat("Inserting {0} ({1})", team.Name, team.Id);

            using (var cmd = new SqlCmdExt(ConnectionString))
            {
                cmd.CreateCmd(@"
INSERT INTO Hockey.Team (
    Id, Name, Abbreviation, League, Division
) VALUES (
    @Id, @Name, @Abbreviation, @League, @Division
)");
                cmd.SetInArg("@Id", team.Id);
                cmd.SetInArg("@Name", team.Name);
                cmd.SetInArg("@Abbreviation", team.Abbreviation);
                cmd.SetInArg("@League", team.League);
                cmd.SetInArg("@Division", team.Division);

                cmd.ExecuteInsertUpdateDelete();
            }
        }

        private void InsertToTeamPlayerTable(IEnumerable<TeamPlayer> teamPlayers)
        {
            Log.Info("Inserting to TeamPlayer Table.");
            foreach (var teamPlayer in teamPlayers)
            {
                InsertTeamPlayerRow(teamPlayer);
            }
            Log.Info("Finished Inserting to TeamPlayer Table.\n");
        }

        private void InsertTeamPlayerRow(TeamPlayer teamPlayer)
        {
            Log.InfoFormat("Inserting TeamPlayer {0}", teamPlayer.Id);

            using (var cmd = new SqlCmdExt(ConnectionString))
            {
                cmd.CreateCmd(@"
INSERT INTO Hockey.TeamPlayer (
    Id, StartDate, EndDate, PlayerId, TeamId
) VALUES (
    @Id, @StartDate, @EndDate, @PlayerId, @TeamId
)");
                cmd.SetInArg("@Id", teamPlayer.Id);
                cmd.SetInArg("@StartDate", teamPlayer.StartDate);
                cmd.SetInArg("@EndDate", teamPlayer.EndDate);
                cmd.SetInArg("@PlayerId", teamPlayer.PlayerId);
                cmd.SetInArg("@TeamId", teamPlayer.TeamId);

                cmd.ExecuteInsertUpdateDelete();
            }
        }

        private void InsertToGameTable(IEnumerable<Game> games) 
        {
            Log.Info("Inserting to Game Table.");
            foreach (var game in games)
            {
                InsertToGameRow(game);
            }
            Log.Info("Finished Inserting to Game Table.\n");
        }

        private void InsertToGameRow(Game game)
        {
            Log.InfoFormat("Inserting Game {0}", game.Id);

            using (var cmd = new SqlCmdExt(ConnectionString))
            {
                cmd.CreateCmd(@"
INSERT INTO Hockey.Game (
    Id, HomeTeamId, AwayTeamId, Season, SeasonType, GameDate, HomeScore, AwayScore
) VALUES (
    @Id, @HomeTeamId, @AwayTeamId, @Season, @SeasonType, @GameDate, @HomeScore, @AwayScore
)");
                cmd.SetInArg("@Id", game.Id);
                cmd.SetInArg("@HomeTeamId", game.HomeTeamId);
                cmd.SetInArg("@AwayTeamId", game.AwayTeamId);
                cmd.SetInArg("@Season", game.Season);
                cmd.SetInArg("@SeasonType", game.SeasonType);
                cmd.SetInArg("@GameDate", game.GameDate);
                cmd.SetInArg("@HomeScore", game.HomeScore);
                cmd.SetInArg("@AwayScore", game.AwayScore);

                cmd.ExecuteInsertUpdateDelete();
            }
        }

        private void EmptyTable(string tableName)
        {

            using (var cmd = new SqlCmdExt(ConnectionString))
            {
                cmd.CreateCmdFormat("DELETE FROM Hockey.{0}", tableName);

                cmd.ExecuteInsertUpdateDelete();
            }

        }
    }
}

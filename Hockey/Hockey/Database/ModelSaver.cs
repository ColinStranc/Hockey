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
            string[] tableNames = { "TeamPlayer", "GamePlayer", "Point", "Game", "DraftPosition", "Team", "Player" };

            foreach (var tableName in tableNames) {
               EmptyTable(tableName);
            }
            
        }

        private void InsertNewRows()
        {

            InsertToTeamTable(hockeyModel.Teams);
            InsertToPlayerTable(hockeyModel.Players);
            //InsertToGameTable(hockeyModel.Games);
            //InsertToPointTable(hockeyModel.Points);
            InsertToTeamPlayerTable(hockeyModel.TeamPlayers);
            //InsertToDraftPositionTable(hockeyModel.DraftPositions);
            //InsertToGamePlayerTable(hockeyModel.GamePlayers);
        }

        private void InsertToPlayerTable(IEnumerable<Player> players)
        {
            Log.Debug("Inserting to Player Table");
            foreach (var player in players)
            {
                InsertPlayerRow(player);
            }
        }

        private void InsertPlayerRow(Player player)
        {
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
            Log.Debug("Inserting to Team Table");
            foreach (var team in teams)
            {
                InsertTeamRow(team);
            }
        }

        private void InsertTeamRow(Team team)
        {
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
            Log.Debug("Inserting to TeamPlayer Table");
            foreach (var teamPlayer in teamPlayers)
            {
                InsertTeamPlayerRow(teamPlayer);
            }
        }

        private void InsertTeamPlayerRow(TeamPlayer teamPlayer)
        {
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

using Cyprom.TableTennisTournaments.Model;
using Cyprom.TableTennisTournaments.Model.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyprom.TableTennisTournaments.Business.Managers
{

    public static class TournamentManager
    {
        // TODO: Properly generate all pools, finale rounds and matches
        public static void StartTournament(Tournament tournament)
        {
            // Tables
            for (var i = 1; i <= tournament.AmountTables; i++)
            {
                var table = ModelManager.CreateTable((short)(i));
                table.Tournament = tournament;
            }

            // Pools
            var pool = ModelManager.CreatePool('A');
            pool.AddPlayingUnit(tournament.PlayingUnits[0]);
            pool.AddPlayingUnit(tournament.PlayingUnits[1]);
            pool.Tournament = tournament;

            // Finale rounds
            var finaleRound = ModelManager.CreateFinaleRound();
            finaleRound.Tournament = tournament;

            // Matches
            var poolMatch = ModelManager.CreateMatch(tournament.PlayingUnits[0], tournament.PlayingUnits[1]);
            poolMatch.Tournament = tournament;
            poolMatch.Pool = pool;
            poolMatch.Table = tournament.Tables[0];
            var finaleMatch = ModelManager.CreateMatch(tournament.PlayingUnits[1], tournament.PlayingUnits[0]);
            finaleMatch.Tournament = tournament;
            finaleMatch.FinaleRound = finaleRound;
            finaleMatch.Table = tournament.Tables[1];
        }
    }
}

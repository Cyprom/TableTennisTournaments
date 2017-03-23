using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Enums;

namespace Cyprom.TableTennisTournaments.Model.Managers
{
    public static class ModelManager
    {
        #region Properties

        public static List<Tournament> Tournaments = new List<Tournament>();
        public static List<PlayingUnit> PlayingUnits = new List<PlayingUnit>();
        public static List<Match> Matches = new List<Match>();
        public static List<Table> Tables = new List<Table>();
        public static List<Pool> Pools = new List<Pool>();
        public static List<FinaleRound> FinaleRounds = new List<FinaleRound>();

        #endregion

        #region Creators

        public static Tournament CreateTournament(string name, bool started, DateTime date, PlayType type, int tables, int maxFinaleRounds, bool poolsReq)
        {
            var tournament = new Tournament(name, started, date, type, tables, maxFinaleRounds, poolsReq);
            Tournaments.Add(tournament);
            return tournament;
        }

        public static Player CreatePlayer(string name, Ranking rank)
        {
            var player = new Player(name, rank);
            PlayingUnits.Add(player);
            return player;
        }

        public static Team CreateTeam(string name1, Ranking rank1, string name2, Ranking rank2)
        {
            var team = new Team(name1, rank1, name2, rank2);
            PlayingUnits.Add(team);
            return team;
        }

        public static Table CreateTable(short number)
        {
            var table = new Table(number);
            Tables.Add(table);
            return table;
        }

        public static Pool CreatePool(char letter)
        {
            var pool = new Pool(letter);
            Pools.Add(pool);
            return pool;
        }

        public static FinaleRound CreateFinaleRound()
        {
            var round = new FinaleRound();
            FinaleRounds.Add(round);
            return round;
        }

        public static Match CreateMatch(PlayingUnit unit1, PlayingUnit unit2)
        {
            var match = new Match(unit1, unit2);
            Matches.Add(match);
            return match;
        }

        #endregion

        #region Object getters

        public static Tournament GetTournament(Guid id)
        {
            return Tournaments.FirstOrDefault(t => t.ID == id);
        }
        public static PlayingUnit GetPlayingUnit(Guid id)
        {
            return PlayingUnits.FirstOrDefault(pu => pu.ID == id);
        }
        public static Match GetMatch(Guid id)
        {
            return Matches.FirstOrDefault(m => m.ID == id);
        }
        public static Table GetTable(Guid id)
        {
            return Tables.FirstOrDefault(t => t.ID == id);
        }
        public static Pool GetPool(Guid id)
        {
            return Pools.FirstOrDefault(p => p.ID == id);
        }
        public static FinaleRound GetFinaleRound(Guid id)
        {
            return FinaleRounds.FirstOrDefault(fr => fr.ID == id);
        }

        #endregion

        #region List getters

        public static List<Tournament> GetTournaments(List<Guid> ids)
        {
            return Tournaments.Where(t => ids.Contains(t.ID)).ToList();
        }
        public static List<PlayingUnit> GetPlayingUnits(List<Guid> ids)
        {
            return PlayingUnits.Where(pu => ids.Contains(pu.ID)).ToList();
        }
        public static List<Match> GetMatches(List<Guid> ids)
        {
            return Matches.Where(m => ids.Contains(m.ID)).ToList();
        }
        public static List<Table> GetTables(List<Guid> ids)
        {
            return Tables.Where(t => ids.Contains(t.ID)).ToList();
        }
        public static List<Pool> GetPools(List<Guid> ids)
        {
            return Pools.Where(p => ids.Contains(p.ID)).ToList();
        }
        public static List<FinaleRound> GetFinaleRounds(List<Guid> ids)
        {
            return FinaleRounds.Where(fr => ids.Contains(fr.ID)).ToList();
        }

        #endregion
    }
}

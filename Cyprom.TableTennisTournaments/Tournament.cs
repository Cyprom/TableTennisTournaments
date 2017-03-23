using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Enums;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Tournament : Identifiable
    {
        #region Constructors

        internal Tournament(string name, bool started, DateTime date, PlayType type, int tables, int finaleRounds, bool poolsReq)
            : base()
        {
            this.Name = name;
            this.Started = started;
            this.Date = date;
            this.Type = type;
            this.AmountTables = tables;
            this.MaxAmountFinaleRounds = finaleRounds;
            this.PoolsRequired = poolsReq;
            this.PoolSizes = new List<int>();
        }

        #endregion

        #region Properties
        
        public string Name { get; set; }
        public bool Started { get; set; }
        public DateTime Date { get; set; }
        public PlayType Type { get; set; }

        // Settings
        public int AmountTables { get; set; }
        public int MaxAmountFinaleRounds { get; set; }
        public bool PoolsRequired { get; set; }
        public List<int> PoolSizes { get; set; }

        #endregion

        #region References
        
        private List<Guid> _playingUnitIDs = new List<Guid>();
        public List<PlayingUnit> PlayingUnits
        {
            get
            {
                return ModelManager.GetPlayingUnits(_playingUnitIDs);
            }
            set
            {
                _playingUnitIDs.Clear();
                foreach (var playingUnit in value)
                {
                    AddPlayingUnit(playingUnit);
                }
            }
        }

        private List<Guid> _poolIDs = new List<Guid>();
        public List<Pool> Pools
        {
            get
            {
                return ModelManager.GetPools(_poolIDs);
            }
            set
            {
                _poolIDs.Clear();
                foreach (var pool in value)
                {
                    AddPool(pool);
                }
            }
        }

        private List<Guid> _finaleRoundIDs = new List<Guid>();
        public List<FinaleRound> FinaleRounds
        {
            get
            {
                return ModelManager.GetFinaleRounds(_finaleRoundIDs);
            }
            set
            {
                _finaleRoundIDs.Clear();
                foreach (var finaleRound in value)
                {
                    AddFinaleRound(finaleRound);
                }
            }
        }

        private List<Guid> _matchIDs = new List<Guid>();
        public List<Match> Matches
        {
            get
            {
                return ModelManager.GetMatches(_matchIDs);
            }
            set
            {
                _matchIDs.Clear();
                foreach (var match in value)
                {
                    AddMatch(match);
                }
            }
        }

        private List<Guid> _tableIDs = new List<Guid>();
        public List<Table> Tables
        {
            get
            {
                return ModelManager.GetTables(_tableIDs);
            }
            set
            {
                _tableIDs.Clear();
                foreach (var table in value)
                {
                    AddTable(table);
                }
            }
        }

        #endregion

#region Helper properties

        public List<Player> Players
        {
            get
            {
                return PlayingUnits.Where(pu => pu is Player).Select(pu => (Player)pu).ToList();
            }
        }

        public List<Team> Teams
        {
            get
            {
                return PlayingUnits.Where(pu => pu is Team).Select(pu => (Team)pu).ToList();
            }
        }

#endregion

        #region Public functions

        public void AddPlayingUnit(PlayingUnit playingUnit)
        {
            if (!_playingUnitIDs.Contains(playingUnit.ID))
            {
                _playingUnitIDs.Add(playingUnit.ID);
                playingUnit.Tournament = this;
            }
        }

        public void AddPool(Pool pool)
        {
            if (!_poolIDs.Contains(pool.ID))
            {
                _poolIDs.Add(pool.ID);
            }
        }

        public void AddFinaleRound(FinaleRound finaleRound)
        {
            if (!_finaleRoundIDs.Contains(finaleRound.ID))
            {
                _finaleRoundIDs.Add(finaleRound.ID);
            }
        }

        public void AddMatch(Match match)
        {
            if (!_matchIDs.Contains(match.ID))
            {
                _matchIDs.Add(match.ID);
            }
        }

        public void AddTable(Table table)
        {
            if (!_tableIDs.Contains(table.ID))
            {
                _tableIDs.Add(table.ID);
            }
        }

        public void RemovePlayingUnit(PlayingUnit playingUnit)
        {
            _playingUnitIDs.Remove(playingUnit.ID);
        }

        public void RemovePool(Pool pool)
        {
            _poolIDs.Remove(pool.ID);
        }

        public void RemoveFinaleRound(FinaleRound finaleRound)
        {
            _finaleRoundIDs.Remove(finaleRound.ID);
        }

        public void RemoveMatch(Match match)
        {
            _matchIDs.Remove(match.ID);
        }

        public void RemoveTable(Table table)
        {
            _tableIDs.Remove(table.ID);
        }

        #endregion

        #region Calculated

        #endregion
    }
}

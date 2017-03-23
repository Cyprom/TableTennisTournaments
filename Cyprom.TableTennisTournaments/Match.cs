using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Match : Identifiable
    {
        #region Constructors

        internal Match(PlayingUnit playingUnit1, PlayingUnit playingUnit2)
            : base()
        {
            _score1 = new SortedDictionary<int, int>();
            _score2 = new SortedDictionary<int, int>();
            this.PlayingUnit1 = playingUnit1;
            this.PlayingUnit2 = playingUnit2;
        }

        #endregion

        #region Properties

        private SortedDictionary<int, int> _score1;
        public SortedDictionary<int, int> Score1
        {
            get
            {
                return _score1;
            }
        }

        private SortedDictionary<int, int> _score2;
        public SortedDictionary<int, int> Score2
        {
            get
            {
                return _score2;
            }
        }

        #endregion

        #region References

        private Guid _tournamentID;
        public Tournament Tournament
        {
            get
            {
                return ModelManager.GetTournament(_tournamentID);
            }
            set
            {
                if (_tournamentID != value.ID)
                {
                    _tournamentID = value.ID;
                    value.AddMatch(this);
                }
            }
        }

        private Guid _playingUnitID1;
        public PlayingUnit PlayingUnit1
        {
            get
            {
                return ModelManager.GetPlayingUnit(_playingUnitID1);
            }
            set
            {
                if (_playingUnitID1 != value.ID)
                {
                    _playingUnitID1 = value.ID;
                    value.AddMatch(this);
                }
            }
        }

        private Guid _playingUnitID2;
        public PlayingUnit PlayingUnit2
        {
            get
            {
                return ModelManager.GetPlayingUnit(_playingUnitID2);
            }
            set
            {
                if (_playingUnitID2 != value.ID)
                {
                    _playingUnitID2 = value.ID;
                    value.AddMatch(this);
                }
            }
        }

        private Guid _tableID;
        public Table Table
        {
            get
            {
                return ModelManager.GetTable(_tableID);
            }
            set
            {
                if (_tableID != value.ID)
                {
                    _tableID = value.ID;
                    value.AddMatch(this);
                }
            }
        }

        private Guid? _poolID;
        public Pool Pool
        {
            get
            {
                return _poolID.HasValue ? ModelManager.GetPool(_poolID.Value) : null;
            }
            set
            {
                if (value != null)
                {
                    if (_poolID != value.ID)
                    {
                        _poolID = value.ID;
                        value.AddMatch(this);
                    }
                }
                else
                {
                    _poolID = null;
                }
            }
        }

        private Guid? _finaleRoundID;
        public FinaleRound FinaleRound
        {
            get
            {
                return _finaleRoundID.HasValue ? ModelManager.GetFinaleRound(_finaleRoundID.Value) : null;
            }
            set
            {
                if (value != null)
                {
                    if (_finaleRoundID != value.ID)
                    {
                        _finaleRoundID = value.ID;
                        value.Match = this;
                    }
                }
                else
                {
                    _finaleRoundID = null;
                }
            }
        }

        #endregion

        #region Calculated

        public PlayingUnit Winner
        {
            get
            {
                return WonMatch(PlayingUnit1) ? PlayingUnit1 : PlayingUnit2;
            }
        }

        #endregion

        #region Public functions

        public void AddSet(int points1, int points2)
        {
            var setNumber = _score1.Keys.Count + 1;
            _score1.Add(setNumber, points1);
            _score2.Add(setNumber, points2);
        }

        public void RemoveSet(int setNumber)
        {
            if (_score1.ContainsKey(setNumber) && _score2.ContainsKey(setNumber))
            {
                _score1.Remove(setNumber);
                _score2.Remove(setNumber);
            }
        }

        public bool WonMatch(PlayingUnit playingUnit)
        {
            var setResults = GetSetResults(playingUnit);
            if (setResults != null)
            {
                return setResults.Item1 > setResults.Item2;
            }
            return false;
        }

        public Tuple<int, int> GetSetResults(PlayingUnit playingUnit)
        {            
            var scores = GetScores(playingUnit);
            if (scores != null)
            {
                var won = 0;
                var lost = 0;
                var playerScore = scores.Item1;
                var opponentScore = scores.Item2;
                foreach (var set in playerScore.Keys)
                {
                    if (playerScore[set] > opponentScore[set])
                    {
                        won++;
                    }
                    else
                    {
                        lost++;
                    }
                }
                return new Tuple<int, int>(won, lost);
            }
            return null;
        }

        public Tuple<int, int> GetPointResults(PlayingUnit playingUnit)
        {
            var scores = GetScores(playingUnit);
            if (scores != null)
            {
                return new Tuple<int, int>(scores.Item1.Values.Sum(), scores.Item2.Values.Sum());
            }
            return null;
        }

        #endregion

        #region Private functions

        private Tuple<SortedDictionary<int, int>, SortedDictionary<int, int>> GetScores(PlayingUnit playingUnit)
        {
            if (_playingUnitID1 == playingUnit.ID)
            {
                return new Tuple<SortedDictionary<int, int>, SortedDictionary<int, int>>(Score1, Score2);
            }
            if (_playingUnitID2 == playingUnit.ID)
            {
                return new Tuple<SortedDictionary<int, int>, SortedDictionary<int, int>>(Score2, Score1);
            }
            return null;
        }

        #endregion

    }
}

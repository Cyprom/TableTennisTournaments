using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public abstract class PlayingUnit : Identifiable
    {

        #region Properties

        public abstract string FullName { get; }

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
                    value.AddPlayingUnit(this);
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
                        value.PlayingUnits.Add(this);
                    }
                }
                else
                {
                    _poolID = null;
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

        #endregion

        #region Public functions

        public void AddMatch(Match match)
        {
            if (!_matchIDs.Contains(match.ID))
            {
                _matchIDs.Add(match.ID);
            }
        }

        public void RemoveMatch(Match match)
        {
            _matchIDs.Remove(match.ID);
        }

        // TODO Meeting with other player?

        #endregion

        #region Calculated

        public int WonMatches
        {
            get
            {
                return Matches.Count(m => m.WonMatch(this));
            }
        }

        public int LostMatches
        {
            get
            {
                return Matches.Count(m => !m.WonMatch(this));
            }
        }

        public int WonSets
        {
            get
            {
                return Matches.Select(m => m.GetSetResults(this).Item1).Sum();
            }
        }

        public int LostSets
        {
            get
            {
                return Matches.Select(m => m.GetSetResults(this).Item2).Sum();
            }
        }

        public int WonPoints
        {
            get
            {
                return Matches.Select(m => m.GetPointResults(this).Item1).Sum();
            }
        }

        public int LostPoints
        {
            get
            {
                return Matches.Select(m => m.GetPointResults(this).Item2).Sum();
            }
        }

        public double MatchRating
        {
            get
            {
                return CalculateRating(WonMatches, LostMatches);
            }
        }

        public double SetRating
        {
            get
            {
                return CalculateRating(WonSets, LostSets);
            }
        }

        public double PointRating
        {
            get
            {
                return CalculateRating(WonPoints, LostPoints);
            }
        }

        #endregion

        #region Private functions

        private double CalculateRating(int won, int lost)
        {
            return won * 100 / (won + lost);
        }

        #endregion

    }
}

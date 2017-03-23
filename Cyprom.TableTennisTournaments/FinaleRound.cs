using System;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public class FinaleRound : Identifiable
    {
        #region Constructors

        internal FinaleRound()
            : base()
        { }

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
                    value.AddFinaleRound(this);
                }
            }
        }

        private Guid _matchID;
        public Match Match
        {
            get
            {
                return ModelManager.GetMatch(_matchID);
            }
            set
            {
                if (_matchID != value.ID)
                {
                    _matchID = value.ID;
                    value.FinaleRound = this;
                }
            }
        }

        private Guid? _previousID1;
        public FinaleRound Previous1
        {
            get
            {
                return _previousID1.HasValue ? ModelManager.GetFinaleRound(_previousID1.Value) : null;
            }
            set
            {
                if (value != null)
                {
                    if (_previousID1 != value.ID)
                    {
                        _previousID1 = value.ID;
                        value.Next = this;
                    }
                }
                else
                {
                    _previousID1 = null;
                }
            }
        }

        private Guid? _previousID2;
        public FinaleRound Previous2
        {
            get
            {
                return _previousID2.HasValue ? ModelManager.GetFinaleRound(_previousID2.Value) : null;
            }
            set
            {
                if (value != null)
                {
                    if (_previousID2 != value.ID)
                    {
                        _previousID2 = value.ID;
                        value.Next = this;
                    }
                }
                else
                {
                    _previousID2 = null;
                }
            }
        }

        private Guid? _nextID;
        public FinaleRound Next
        {
            get
            {
                return _nextID.HasValue ? ModelManager.GetFinaleRound(_nextID.Value) : null;
            }
            set
            {
                if (value != null)
                {
                    if (_nextID != value.ID)
                    {
                        _nextID = value.ID;
                    }
                }
                else
                {
                    _nextID = null;
                }
            }
        }

        #endregion

        #region Calculated

        // TODO Round type/number? -- Use ModelManager

        public PlayingUnit PlayingUnit1
        {
            get
            {
                return Match != null ? Match.PlayingUnit1 : null;
            }
        }

        public PlayingUnit PlayingUnit2
        {
            get
            {
                return Match != null ? Match.PlayingUnit2 : null;
            }
        }

        public SortedDictionary<int, int> Score1
        {
            get
            {
                return Match != null ? Match.Score1 : null;
            }
        }

        public SortedDictionary<int, int> Score2
        {
            get
            {
                return Match != null ? Match.Score2 : null;
            }
        }

        public PlayingUnit Winner
        {
            get
            {
                return Match != null ? Match.Winner : null;
            }
        }

        #endregion
    }
}

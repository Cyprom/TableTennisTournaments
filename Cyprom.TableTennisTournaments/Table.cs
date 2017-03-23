using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Table : Identifiable
    {
        #region Constructors

        internal Table(short number)
            : base()
        {
            this.Number = number;
        }

        #endregion

        #region Properties

        public short Number { get; set; }

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
                    value.AddTable(this);
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

        #endregion

    }
}

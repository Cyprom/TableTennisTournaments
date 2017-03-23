using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model.Managers;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Pool : Identifiable
    {
        #region Constructors

        internal Pool(char letter)
            : base()
        {
            this.Letter = letter;
        }

        #endregion

        #region Properties

        public char Letter { get; set; }

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
                    value.AddPool(this);
                }
            }
        }

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

        #region Calculated

        public int Size
        {
            get
            {
                return PlayingUnits.Count;
            }
        }

        #endregion

        #region Public functions

        public void AddPlayingUnit(PlayingUnit playingUnit)
        {
            if (!_playingUnitIDs.Contains(playingUnit.ID))
            {
                _playingUnitIDs.Add(playingUnit.ID);
            }
        }

        public void AddMatch(Match match)
        {
            if (!_matchIDs.Contains(match.ID))
            {
                _matchIDs.Add(match.ID);
            }
        }

        public void RemovePlayingUnit(PlayingUnit playingUnit)
        {
            _playingUnitIDs.Remove(playingUnit.ID);
        }

        public void RemoveMatch(Match match)
        {
            _matchIDs.Remove(match.ID);
        }

        public List<PlayingUnit> GetResults()
        {
            // TODO Algorithm to sort players by result
            return PlayingUnits;
        }

        #endregion

    }
}

using Cyprom.TableTennisTournaments.Model.Enums;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Player : PlayingUnit
    {
        #region Constructors

        internal Player(string name, Ranking ranking)
            : base()
        {
            this.Name = name;
            this.Ranking = ranking;
        }

        #endregion

        #region Properties

        public string Name { get; set; }
        public Ranking Ranking { get; set; }
        public override string FullName
        {
            get
            {
                return string.Format("{0} ({1})", Name, Ranking);
            }
        }

        #endregion
    }
}

using System;
using Cyprom.TableTennisTournaments.Model.Enums;

namespace Cyprom.TableTennisTournaments.Model
{
    public class Team : PlayingUnit
    {
        #region Constructors

        internal Team(string name1, Ranking ranking1, string name2, Ranking ranking2)
            : base()
        {
            this.Name1 = name1;
            this.Ranking1 = ranking1;
            this.Name2 = name2;
            this.Ranking2 = ranking2;
        }

        #endregion 

        #region Properties

        public string Name1 { get; set; }
        public Ranking Ranking1 { get; set; }
        public string Name2 { get; set; }
        public Ranking Ranking2 { get; set; }
        public override string FullName
        {
            get
            {
                return string.Format("{0} ({1}) & {2} ({3})", Name1, Ranking1, Name2, Ranking2);
            }
        }

        #endregion
    }
}

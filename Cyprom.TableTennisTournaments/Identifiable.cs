using System;

namespace Cyprom.TableTennisTournaments.Model
{
    public abstract class Identifiable
    {

        #region Constructors

        internal Identifiable()
        {
            ID = Guid.NewGuid();
        }

        #endregion

        #region Properties

        public Guid ID { get; set; }

        #endregion

    }
}

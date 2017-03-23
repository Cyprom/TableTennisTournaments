using System;

namespace Cyprom.TableTennisTournaments.Model
{
    public abstract class Identifiable
    {

        #region Constructors

        internal Identifiable()
        {
            _iD = Guid.NewGuid();
        }

        #endregion

        #region Properties

        private Guid _iD;
        public Guid ID
        {
            get
            {
                return _iD;
            }
        }

        #endregion

    }
}

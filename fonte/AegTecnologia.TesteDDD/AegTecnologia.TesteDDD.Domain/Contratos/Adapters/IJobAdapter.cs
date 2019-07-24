using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Domain.Contratos.Adapters
{
    public interface IJobAdapter
    {
        #region IJobAdapter Members

        void Configure(IDictionary<string, object> parameters);

        #endregion
    }
}

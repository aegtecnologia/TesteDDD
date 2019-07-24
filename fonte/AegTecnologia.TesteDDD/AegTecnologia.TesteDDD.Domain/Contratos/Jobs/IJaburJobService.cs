using AegTecnologia.TesteDDD.Domain.Contratos.Adapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Domain.Contratos.Jobs
{
    public interface IJaburJobService : IJobService<ISqlAdapter, ISqlAdapter>
    {
        #region ICalculoLimiteJobService Members

        void Initialize(IDictionary<string, object> parametros);

        #endregion
    }
}

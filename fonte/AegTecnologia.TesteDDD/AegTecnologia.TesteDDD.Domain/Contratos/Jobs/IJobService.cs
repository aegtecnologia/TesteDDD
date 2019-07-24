using AegTecnologia.TesteDDD.Domain.Contratos.Adapters;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Domain.Contratos.Jobs
{
    public interface IJobService<TAdapterInput, TAdapterOutput>
        where TAdapterInput : class, IJobAdapter
        where TAdapterOutput : class, IJobAdapter
    {
        #region IJobService Members

        void Register(PerformContext jobContext);
        void Initialize();

        #endregion
    }
}

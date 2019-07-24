using AegTecnologia.TesteDDD.Domain.Contratos.Adapters;
using AegTecnologia.TesteDDD.Domain.Contratos.Jobs;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Service.Jobs
{
    public abstract class GenericJobService<TInputAdapter, TOutputAdapter> : IJobService<TInputAdapter, TOutputAdapter>
        where TInputAdapter : class, IJobAdapter
        where TOutputAdapter : class, IJobAdapter
    {
        #region Public Properties

        public PerformContext JobContext { get; protected set; }
        public TInputAdapter InputAdapter { get; protected set; }
        public TOutputAdapter OutputAdapter { get; protected set; }

        #endregion

        #region Constructors

        protected GenericJobService(TInputAdapter inputAdapter, TOutputAdapter outputAdapter)
        {
            InputAdapter = inputAdapter ?? throw new ArgumentNullException(nameof(inputAdapter));
            OutputAdapter = outputAdapter ?? throw new ArgumentNullException(nameof(outputAdapter));
        }

        #endregion

        #region IJobService Members

        public virtual void Register(PerformContext jobContext)
        {
            JobContext = jobContext;
            Initialize();
        }

        public abstract void Initialize();

        #endregion
    }
}

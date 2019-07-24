using AegTecnologia.TesteDDD.Domain.Contratos.Adapters;
using AegTecnologia.TesteDDD.Domain.Contratos.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Service.Jobs
{
    public class JaburJobService : GenericJobService<ISqlAdapter, ISqlAdapter>, IJaburJobService
    {
        private readonly ISqlAdapter _inputSqlAdapter;
        private readonly ISqlAdapter _outputSqlAdapter;

        public JaburJobService(ISqlAdapter adapterInput, ISqlAdapter adapterOutput)
            : base(adapterInput,adapterOutput)
        {

        }

        public void Initialize(IDictionary<string, object> parametros)
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AegTecnologia.TesteDDD.Domain.Contratos.Adapters
{
    public interface ISqlAdapter : IJobAdapter
    {
        #region ISqlAdapter Members

        void ExecuteNonQuery(CommandType commandType, string commandText, Dictionary<string, object> commandParameters);
        Task ExecuteNonQueryAsync(CommandType commandType, string commandText, Dictionary<string, object> commandParameters);
        TResult ExecuteScalar<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters);
        IEnumerable<TResult> ExecuteReader<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters, Func<IDataRecord, TResult> extractor);
        Task<IEnumerable<TResult>> ExecuteReaderAsync<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters, Func<IDataRecord, TResult> extractor);

        #endregion
    }
}

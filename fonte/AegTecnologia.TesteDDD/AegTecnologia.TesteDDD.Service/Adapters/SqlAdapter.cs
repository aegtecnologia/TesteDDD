using AegTecnologia.TesteDDD.Domain.Contratos.Adapters;
using AegTecnologia.TesteDDD.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AegTecnologia.TesteDDD.Service.Adapters
{
    public sealed class SqlAdapter : ISqlAdapter
    {
        #region Private Properties

        private SqlConfig Config { get; set; }
        private SqlConnection DbConnection { get; set; }

        #endregion

        #region ISqlAdapter Members

        public void Configure(IDictionary<string, object> parameters)
        {
            if (!TryParse(parameters, out var config)) return;

            Config = config;
            DbConnection = new SqlConnection(Config.ConnectionString);
        }

        public void ExecuteNonQuery(CommandType commandType, string commandText, Dictionary<string, object> commandParameters)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException(nameof(commandText));

            EnsureConnectionOpen();
            using (var cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                cmd.CommandTimeout = Config.Timeout;

                if (commandParameters != null && commandParameters.Any())
                    commandParameters.ForEach((key, value) => cmd.Parameters.AddWithValue($"@{key}", value));

                cmd.ExecuteNonQuery();
            }
        }
   
        public async Task ExecuteNonQueryAsync(CommandType commandType, string commandText, Dictionary<string, object> commandParameters)
        {
            ValidateExecuteNonQueryAsync(commandText);

            EnsureConnectionOpen();
            using (var cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;
                cmd.CommandTimeout = Config.Timeout;

                if (commandParameters != null && commandParameters.Any())
                    commandParameters.ForEach((key, value) => cmd.Parameters.AddWithValue($"@{key}", value));

                await cmd.ExecuteNonQueryAsync();
            }
        }

        private static void ValidateExecuteNonQueryAsync(string commandText)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException(nameof(commandText));
        }

        public TResult ExecuteScalar<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException(nameof(commandText));

            EnsureConnectionOpen();
            using (var cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                if (commandParameters != null && commandParameters.Any())
                    commandParameters.ForEach((key, value) => cmd.Parameters.AddWithValue($"@{key}", value));

                return (TResult)cmd.ExecuteScalar();
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters, Func<IDataRecord, TResult> extractor)
        {
            var result = new List<TResult>();

            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException(nameof(commandText));

            EnsureConnectionOpen();
            using (var cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                if (commandParameters != null && commandParameters.Any())
                    commandParameters.ForEach((key, value) => cmd.Parameters.AddWithValue($"@{key}", value));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(extractor(reader));
                }
            }

            return result;
        }

        public async Task<IEnumerable<TResult>> ExecuteReaderAsync<TResult>(CommandType commandType, string commandText, Dictionary<string, object> commandParameters, Func<IDataRecord, TResult> extractor)
        {
            var result = new List<TResult>();

            ValidateExecuteReaderAsync(commandText);

            EnsureConnectionOpen();
            using (var cmd = DbConnection.CreateCommand())
            {
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                if (commandParameters != null && commandParameters.Any())
                    commandParameters.ForEach((key, value) => cmd.Parameters.AddWithValue($"@{key}", value));

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                        result.Add(extractor(reader));
                }
            }

            return result;
        }

        private static void ValidateExecuteReaderAsync(string commandText)
        {
            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException(nameof(commandText));
        }

        #endregion

        #region Private Methods

        private void EnsureConnectionOpen()
        {
            if (DbConnection.State == ConnectionState.Closed)
                DbConnection.Open();
        }

        private bool TryParse(IDictionary<string, object> parameters, out SqlConfig output)
        {
            if (parameters == null || !parameters.Any())
                throw new ArgumentNullException(nameof(parameters));

            output = new SqlConfig();

            parameters.TryGetValue("connectionString", out var connectionString);
            parameters.TryGetValue("timeout", out var timeout);
            output.ConnectionString = connectionString.ToString();
            output.Timeout = timeout == null ? 30 : (int)timeout;

            return true;
        }

        #endregion

        #region Internal Sealed Classes

        internal sealed class SqlConfig
        {
            public string ConnectionString { get; set; }
            public int Timeout { get; set; }
        }

        #endregion
    }
}

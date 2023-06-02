using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataAccessLibrary;

public class SqlDataAccess
{
    /// <summary>
    ///     The method is responsible for querying the data
    /// </summary>
    /// <param name="sql">SQL query written as a string</param>
    /// <param name="parameters">Parameters for performing a parameterized query</param>
    /// <param name="connectionString">String indicating database connection details</param>
    /// <typeparam name="T">The class model to be queried</typeparam>
    /// <typeparam name="U">Parameter(s) specified to transmit parameterized into query</typeparam>
    /// <returns>One or more database rows transformed as objects</returns>
    public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            List<T> rows = connection.Query<T>(sql, parameters).ToList();
            return rows;
        }
    }
}
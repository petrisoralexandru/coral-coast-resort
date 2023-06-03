using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary;

public class SqlDataAccess
{
    private readonly IConfiguration _config;
    
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    ///     The method is responsible for querying the data. Ideal for reading data.
    /// </summary>
    /// <param name="sql">SQL query written as a string</param>
    /// <param name="parameters">Parameters for performing a parameterized query</param>
    /// <param name="connectionStringName">String indicating database connection details</param>
    /// <param name="options">Parameter specifying whether to execute a query as a stored procedure</param>
    /// <typeparam name="T">The class model to be queried</typeparam>
    /// <typeparam name="U">Parameter(s) specified to transmit parameterized into query</typeparam>
    /// <returns>One or more database rows transformed as objects</returns>
    public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, dynamic? options = null)
    {
        string? connectionString = _config.GetConnectionString(connectionStringName);
        CommandType commandType = CommandType.Text;

        if (options?.IsStoredProcedure != null && options?.IsStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }
        
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            List<T> rows = connection.Query<T>(sql, parameters, commandType: commandType).ToList();
            return rows;
        }
    }
    
    /// <summary>
    ///     The method is responsible for executing queries to the database. Ideal for creating, updating, deleting data.
    /// </summary>
    /// <param name="sql">SQL query written as a string</param>
    /// <param name="parameters">Parameters for performing a parameterized query</param>
    /// <param name="connectionString">String indicating database connection details</param>
    /// <typeparam name="T">Parameter(s) specified to transmit parameterized into query</typeparam>
    public void SaveData<T>(string sql, T parameters, string connectionString)
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(sql, parameters);
        }
    }
}
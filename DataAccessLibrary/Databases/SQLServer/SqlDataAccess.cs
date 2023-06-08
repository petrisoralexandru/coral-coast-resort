using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.Databases.SQLServer;

public class SqlDataAccess : ISqlDataAccess
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
    /// <param name="isStoredProcedure">Parameter specifying whether to execute a stored procedure</param>
    /// <typeparam name="T">The data transfer object to be queried</typeparam>
    /// <typeparam name="U">Parameter(s) specified to transmit parameterized into query</typeparam>
    /// <returns>One or more database rows transformed as objects</returns>
    public List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoredProcedure = false)
    {
        string? connectionString = _config.GetConnectionString(connectionStringName);
        CommandType commandType = CommandType.Text;

        if (isStoredProcedure)
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
    /// <param name="connectionStringName">String indicating database connection details</param>
    /// <param name="isStoredProcedure">Parameter specifying whether to execute a stored procedure</param>
    /// <typeparam name="T">Parameter(s) specified to transmit parameterized into query</typeparam>
    public void SaveData<T>(string sql, T parameters, string connectionStringName, bool isStoredProcedure = false)
    {
        string? connectionString = _config.GetConnectionString(connectionStringName);
        CommandType commandType = CommandType.Text;
        
        if (isStoredProcedure)
        {
            commandType = CommandType.StoredProcedure;
        }
        
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(sql, parameters, commandType: commandType);
        }
    }
}
namespace DataAccessLibrary.Databases.SQLServer;

public interface ISqlDataAccess
{
    /// <summary>
    ///     The method is responsible for querying the data. Ideal for reading data.
    /// </summary>
    /// <param name="sql">SQL query written as a string</param>
    /// <param name="parameters">Parameters for performing a parameterized query</param>
    /// <param name="connectionStringName">String indicating database connection details</param>
    /// <param name="isStoredProcedure">Parameter specifying whether to execute a stored procedure</param>
    /// <typeparam name="T">The class model to be queried</typeparam>
    /// <typeparam name="U">Parameter(s) specified to transmit parameterized into query</typeparam>
    /// <returns>One or more database rows transformed as objects</returns>
    List<T> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoredProcedure = false);

    /// <summary>
    ///     The method is responsible for executing queries to the database. Ideal for creating, updating, deleting data.
    /// </summary>
    /// <param name="sql">SQL query written as a string</param>
    /// <param name="parameters">Parameters for performing a parameterized query</param>
    /// <param name="connectionStringName">String indicating database connection details</param>
    /// <param name="isStoredProcedure">Parameter specifying whether to execute a stored procedure</param>
    /// <typeparam name="T">Parameter(s) specified to transmit parameterized into query</typeparam>
    void SaveData<T>(string sql, T parameters, string connectionStringName, bool isStoredProcedure = false);
}